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
using Microsoft.Win32;

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for MyMediaPlayer.xaml
    /// </summary>
    public partial class MyMediaPlayer : DockingLibrary.DockableContent
    {
        private System.Windows.Threading.DispatcherTimer mediaClock = new System.Windows.Threading.DispatcherTimer();
        private bool isLoaded = false;

        public MyMediaPlayer()
        {
            InitializeComponent();
        }

        #region PlayerControls
        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Audio Files (*.wma;*.mp3;*.wav;*.ogg)|*.wma;*.mp3;*.wav;*.ogg" +
                        "|Video Files (*.wmv;*.mpg;*.avi)|*.wmv;*.mpg;*.avi" +
                        "|All Files (*.*)|*.*";
            if (open.ShowDialog() == true)
            {
                mediaPlayer.Source = new Uri(open.FileName, UriKind.Absolute);
                System.IO.FileInfo f = new System.IO.FileInfo(open.FileName);
                nowPlaying.Content = f.Name.Substring(0, (f.Name.Length - f.Extension.Length));
                PositionSlider.Value = 0;
            }
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            mediaClock.Stop();
            PositionSlider.Value = 0;
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            mediaClock.Stop();
        }

        private void Element_MediaOpened(object sender, RoutedEventArgs e)
        {
            PositionSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void Element_MediaEnded(object sender, RoutedEventArgs e)
        {
            PositionSlider.Value = 0;
            mediaClock.Stop();
        }

        private void PositionSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            mediaPlayer.Position = TimeSpan.FromMilliseconds(PositionSlider.Value);
        }

        void mediaClock_Tick(object sender, EventArgs e)
        {
            PositionSlider.Value += 100;
            mediaPlayer.ToolTip = TimeSpan.FromMilliseconds(PositionSlider.Value);
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                isLoaded = true;
                //mediaPlayer clock-for playing media
                mediaClock.Tick += new EventHandler(mediaClock_Tick);
                mediaClock.Interval = new TimeSpan(0, 0, 0, 0, 100);
                //back panel sliders
                VolSlider.ToolTip = "Volume";
                PositionSlider.ToolTip = "Seek";
            }

            if (mediaPlayer.Source != null) mediaClock.Start();
            if (mediaPlayer.Source != null) mediaPlayer.Play();
        }
        #endregion
    }
}
