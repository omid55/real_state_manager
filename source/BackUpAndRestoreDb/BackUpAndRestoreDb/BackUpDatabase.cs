using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Windows;

namespace BackUpAndRestoreDb
{
    class BackUpDatabase
    {
        public String mdf = "Negindb.mdf";
        public String ldf = "Negindb_log.ldf";
        public String bak = "C:\\BackUpLocation\\Negindb.bak";

        public BackUpDatabase() { }

        public void doBackUp()
        {
            try
            {
                string path = @"C:\";
                string newpath = System.IO.Path.Combine(path, "BackUpLocation");
                Directory.CreateDirectory(newpath);

                FileStream fmdf = new FileStream(mdf, FileMode.Open, FileAccess.Read);
                FileStream fldf = new FileStream(ldf, FileMode.Open, FileAccess.Read);
                FileStream fbak = new FileStream(bak, FileMode.Create, FileAccess.Write);

                byte[] fmcontent = new byte[fmdf.Length];
                fmdf.Read(fmcontent, 0, (int)fmdf.Length);
                fbak.Write(fmcontent, 0, (int)fmdf.Length);

                byte[] sym = new byte[3];
                sym[0] = (byte)'$'; sym[1] = (byte)'*'; sym[2] = (byte)'^';
                fbak.Write(sym, 0, 3);

                byte[] flcontent = new byte[fldf.Length];
                fldf.Read(flcontent, 0, (int)fldf.Length);
                fbak.Write(flcontent, 0, (int)fldf.Length);

                fbak.Flush();
                fbak.Close();
                fmdf.Close();
                fldf.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool doRestore()
        {
            if (File.Exists("config.conf"))
            {
                StreamReader sr = null;
                String text = "";
                try
                {
                    sr = new StreamReader("config.conf");
                    text = sr.ReadToEnd();
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا در دسترسی به فایل های مربوط به برنامه لطفا با پشتیبانی برنامه تماس حاصل بفرمایید", "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                sr.Close();
                sr.Dispose();
                FileStream fmdf = new FileStream(mdf, FileMode.Create, FileAccess.Write);
                FileStream fldf = new FileStream(ldf, FileMode.Create, FileAccess.Write);
                FileStream fbak = new FileStream(bak, FileMode.Open, FileAccess.Read);

                byte[] fbcontent = new byte[fbak.Length];
                fbak.Read(fbcontent, 0, (int)fbak.Length);
                int len = fbcontent.Length;
                int index = 0;
                FileStream tmp = fmdf;
                while (index < len)
                {
                    if (fbcontent[index] == (byte)'$' && fbcontent[index + 1] == (byte)'*' && fbcontent[index + 2] == (byte)'^')
                    {
                        break;
                    }
                    index++;
                }
                fmdf.Write(fbcontent, 0, index);
                fldf.Write(fbcontent, index + 3, len - index - 3);

                fmdf.Flush();
                fldf.Flush();
                fmdf.Close();
                fldf.Close();
                fbak.Close();
                try
                {
                    execSql(text);
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا در اتصال به پایگاه داده ها", "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
            return false;
        }


        private void execSql(String t)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            con = new SqlConnection();
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|Negindb.mdf\";Integrated Security=True;User Instance=True";
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "EXEC SetExpInfo N'" + t + "'";
            cmd.ExecuteNonQuery();
        }
    }
}
