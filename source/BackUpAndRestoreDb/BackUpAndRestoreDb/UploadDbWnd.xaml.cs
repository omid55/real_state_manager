using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.SqlServer.Management.Smo;
using System.ComponentModel;
using System.Windows.Threading;
using Microsoft.SqlServer.Management.Common;
using System.IO;

namespace BackUpAndRestoreDb
{
    /// <summary>
    /// Interaction logic for UploadDbWnd.xaml
    /// </summary>
    public partial class UploadDbWnd : Window
    {
        private string sourceServer, sourceDatabase, username, pass, destinationServer, destinationDatabase;
        private BackgroundWorker upload;
        private DispatcherTimer progressTimer;
        private double progress = 0;
        private bool createDb = false;
        private bool serverMode = false;

        public UploadDbWnd()
        {
            InitializeComponent();

            progressBar1.Maximum = 14;

            upload = new BackgroundWorker();
            upload.DoWork += new DoWorkEventHandler(upload_DoWork);
            upload.RunWorkerCompleted += new RunWorkerCompletedEventHandler(upload_RunWorkerCompleted);
            upload.WorkerSupportsCancellation = true;

            progressTimer = new DispatcherTimer();
            progressTimer.Interval = new TimeSpan(100);
            progressTimer.Tick += new EventHandler(progressTimer_Tick);
        }

        void progressTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progress;
        }

        void upload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                upload.CancelAsync();
                upload.Dispose();
            }
            catch (Exception)
            {
            }
        }

        void populateVariables()   // populate variables for upload background worker to use them
        {
            destinationServer = ServerTextBox.Text;
            destinationDatabase = DatabaseComboBox.Text;
            destinationDatabase=destinationDatabase.Replace(']', ' ');
            destinationDatabase = destinationDatabase.Replace('[', ' ');
            destinationDatabase = destinationDatabase.Trim();
            serverMode = ServerModeRadio.IsChecked.Value;
            if (!serverMode)
            {
                sourceServer = ".\\SQLEXPRESS";
                sourceDatabase = "NewNegin" + new Random().Next(1000);
                //destinationServer = "OMID55\\SQLEXPRESS";
                //destinationDatabase = "mydb2";
            }
            else 
            {
                sourceServer = SourceServerTextBox.Text;
                sourceDatabase = SourceDbComboBox.Text;
                sourceDatabase = sourceDatabase.Replace(']', ' ');
                sourceDatabase = sourceDatabase.Replace('[', ' ');
                sourceDatabase = sourceDatabase.Trim();
            }
            username = UserNameTextBox.Text;
            pass = PasswordTextBox.Password;
        }

        void upload_DoWork(object sender, DoWorkEventArgs e)
        {
            if (upload.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            bool again = false;
            bool attached = false;

        First:
            try
            {
                #region BackUp First
                if (!serverMode)
                {
                    BackUpDatabase bak = new BackUpDatabase();
                    bak.doBackUp();
                }
                #endregion


                #region InitVariables and Save Info In File

                progress = 1;
                again = false;
                attached = false;
                progress = 2;

                StreamWriter sw = new StreamWriter("UploadConfig.conf");
                sw.WriteLine(destinationServer);
                sw.WriteLine(destinationDatabase);
                sw.WriteLine(username);
                sw.WriteLine(MyCrypt.encryptWithDefaultValues(pass));
                if (serverMode)
                {
                    sw.WriteLine(sourceServer);
                    sw.WriteLine(sourceDatabase);
                }
                sw.Close();
                sw.Dispose();

                #endregion


                #region ServerCreation and Delete All Objects On Destination Database

                progress = 3;
                ServerConnection destinationCon;
                if (!String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(pass))
                {
                    destinationCon = new ServerConnection(destinationServer, username, pass);
                }
                else
                {
                    destinationCon = new ServerConnection(destinationServer);
                }
                Server destServer = new Server(destinationCon);

                String fp = Environment.CurrentDirectory + "\\query.sql";
                FileInfo file = new FileInfo(fp);
                string script = file.OpenText().ReadToEnd();
                script = script.Replace("dbo", username);
                try
                {
                    destServer.ConnectionContext.ExecuteNonQuery(script);
                }
                catch (Exception excep)
                {
                    MessageBox.Show("Error In Removing All Objects \n" + excep.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    //MessageBox.Show("خطای تکنیکی \n" + excep.InnerException.Message + "\n" + excep.StackTrace, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                // Connect to server
                Server server = new Server(sourceServer);
                progress = 4;
                #endregion


                #region AttachDatabaseOnServer

                progress = 5;
                if (!serverMode)
                {
                    System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                    string datab = Environment.CurrentDirectory + "\\Negindb.mdf";
                    string logDb = Environment.CurrentDirectory + "\\Negindb_log.ldf";
                    files.Add(datab);
                    server.AttachDatabase(sourceDatabase, files);
                    attached = true;
                    server.Refresh();
                }
                progress = 6;

                #endregion


                #region DatabaseCreation

                progress = 7;
                // Get the Database to Transfer
                Database db = server.Databases[sourceDatabase];
                progress = 8;

                #endregion


                #region TransferConfigAndRun

                progress = 9;
                // Setup transfer
                // I want to copy all objects
                // both Data and Schema
                Transfer t = new Transfer(db);
                t.CopyAllObjects = true;
                t.CopySchema = true;
                t.CopyData = true;
                t.DestinationServer = destinationServer;
                t.DestinationDatabase = destinationDatabase;

                // if username or password entered so server must be create for mixed authentication 
                // else connect to server simple only with its name for windows authentication
                t.DestinationLoginSecure = true;   // for windows authentication
                if (!String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(pass))
                {
                    t.DestinationLoginSecure = false;
                    t.DestinationLogin = username;
                    t.DestinationPassword = pass;
                }

                t.Options.ContinueScriptingOnError = true;
                t.Options.IncludeIfNotExists = true;
                t.DropDestinationObjectsFirst = true;
                //t.UseDestinationTransaction = true;   <<Check Here>>  (long time exec)
                if (createDb == true) t.CreateTargetDatabase = true;
                progress = 10;

                // Transfer Schema and Data
                t.TransferData();
                progress = 11;

                #endregion


                #region DestructEveryThing

                progress = 12;
                if (!serverMode)
                {
                    server.DetachDatabase(sourceDatabase, false);
                }
                progress = 13;

                #endregion


                progress = 14;
                MessageBox.Show("پایگاه داده ها با موفقیت کامل بر روی وب قرار گرفت", "ارسال موفق", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                #region DetachDb

                if (attached && !serverMode)
                {
                    try
                    {
                        Server server = new Server(sourceServer);
                        server.DetachDatabase(sourceDatabase, false);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("خطایی در هنگام حذف پایگاه داده های موقتی در همین سیستم رخ داده است", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        MessageBox.Show("خطای تکنیکی \n" + exc.Message + "\n" + exc.StackTrace, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (exc.InnerException.InnerException != null)
                        {
                            MessageBox.Show("خطای تکنیکی داخلی \n" + exc.InnerException.InnerException.Message, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }

                #endregion


                #region HandlingLdfError

                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("LDF' because it already exists"))
                {
                    try
                    {
                        File.Delete(Environment.CurrentDirectory + "\\Negindb_log.ldf");

                        MessageBox.Show("در حین اجرای درخواست مشکلی بوجود آمد که توسط برنامه شناسایی و حل شد حال دوباره سعی می گردد", "حل مشکل", MessageBoxButton.OK, MessageBoxImage.Information);

                        again = true;
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("خطایی در هنگام ارسال رخ داده است", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        MessageBox.Show("خطای تکنیکی \n" + exx.Message + "\n" + exx.StackTrace, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                #endregion

                else
                {
                    MessageBox.Show("خطایی در هنگام ارسال رخ داده است", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show("خطای تکنیکی \n" + ex.Message + "\n" + ex.StackTrace, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (ex.InnerException.InnerException != null)
                    {
                        MessageBox.Show("خطای تکنیکی داخلی \n" + ex.InnerException.InnerException.Message, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            #region Restore At Last
            if (!serverMode)
            {
                BackUpDatabase ba = new BackUpDatabase();
                ba.doRestore();
            }
            #endregion

            progress = 0;
            if (again) goto First;
            progressTimer.Stop();
            //upload.CancelAsync();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            populateVariables();
            progressTimer.Start();
            upload.RunWorkerAsync();
        }

        private void createDbCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            createDb = createDbCheckBox.IsChecked.Value;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            /*Server s = new Server("174.142.75.244,1344");
            s.ConnectionContext.LoginSecure = false;
            s.ConnectionContext.Login = "testuser";
            s.ConnectionContext.Password = "testuser";
            s.ConnectionContext.Connect();*/
            
            Environment.Exit(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Height = 440;

            ServerTextBox.Focus();

            #region Init TextBoxes

            if (File.Exists("UploadConfig.conf"))
            {
                try
                {
                    StreamReader sr = new StreamReader("UploadConfig.conf");
                    ServerTextBox.Text = sr.ReadLine();
                    DatabaseComboBox.Text = sr.ReadLine();
                    UserNameTextBox.Text = sr.ReadLine();
                    PasswordTextBox.Password = MyCrypt.decryptWithDefaultValues(sr.ReadLine());
                    SourceServerTextBox.Text = sr.ReadLine();
                    SourceDbComboBox.Text = sr.ReadLine();
                }
                catch (Exception) { }
            }

            #endregion
        }

        private void ServerModeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (!SourceServerTextBox.IsVisible)
            {
                this.Height = 512;
                SourceDbComboBox.Visibility = SourceServerTextBox.Visibility = SourceDbLabel.Visibility = SourceServerLabel.Visibility = Visibility.Visible;
            }
        }

        bool firstTime = true;
        private void ClientModeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (!firstTime && SourceServerTextBox.IsVisible)
            {
                this.Height = 440;
                SourceDbComboBox.Visibility = SourceServerTextBox.Visibility = SourceDbLabel.Visibility = SourceServerLabel.Visibility = Visibility.Hidden;
            }
            firstTime = false;
        }

        private void SourceDbComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Server so = new Server(SourceServerTextBox.Text);
                SourceDbComboBox.ItemsSource = so.Databases;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در اتصال به سرور منبع\nاز سرور منبع پاسخی دریافت نگردید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("خطای تکنیکی =>\n\n"+ex.Message, "خطای تکنیکی", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DatabaseComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Server so = new Server(ServerTextBox.Text);
                DatabaseComboBox.ItemsSource = so.Databases;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در اتصال به سرور وب سایت\nاز سرور مقصد پاسخی دریافت نگردید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("خطای تکنیکی =>\n\n" + ex.Message, "خطای تکنیکی", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

