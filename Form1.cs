using AxWMPLib;
using Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static Global.EasyObject;

namespace MyMediaPlayer
{
    public partial class Form1 : Form
    {
        AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        System.Windows.Forms.Timer Timer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            MediaPlayer = axWindowsMediaPlayer1;
            this.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.StartPosition = FormStartPosition.Manual;
            Rectangle screen = Screen.FromPoint(Cursor.Position).WorkingArea;
            this.ClientSize = new Size((int)(screen.Width * 0.75), (int)(screen.Height * 0.75)); /**/
            //this.Size = new Size((int)(screen.Width * 0.75), (int)(screen.Height * 0.75)); /**/
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            this.Location = new Point(screen.Left + (screen.Width - w) / 2, screen.Top + (screen.Height - h) / 2);
            this.Size = new Size(w, h);
            //AllocConsole();
            Log("ハロー©");
            //this.AllowDrop = true;
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            Timer.Start();
            //panel1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //panel1.Dock = DockStyle.Fill;
            //panel1.Controls.Add(this.MediaPlayer);
            MediaPlayer.Dock = DockStyle.Fill;
            SetWMPVolume(100);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            var curMedia = MediaPlayer.currentMedia;
            if (curMedia != null)
            {
                string sourceURL = curMedia.sourceURL;
                //Log(sourceURL, "sourceURL");
                string fileName = Path.GetFileName(sourceURL);
                //Log(fileName, "fileName");
                if (this.Text != fileName)
                {
                    this.Text = fileName;
                }
                int duration = (int)MediaPlayer.currentMedia.duration;
                int curPosition = (int)MediaPlayer.Ctlcontrols.currentPosition;
                TimeSpan span1 = new TimeSpan(0, 0, duration);
                TimeSpan span2 = new TimeSpan(0, 0, curPosition);
                toolStripLabel1.Text = String.Format("{0} / {1}  ", span2.ToString(), span1.ToString());
                toolStripLabel2.Text = sourceURL;
            }
            else
            {
                toolStripLabel1.Text = "";
                toolStripLabel2.Text = "";
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((keyData & Keys.KeyCode) == Keys.Space)
            {
                if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
                    MediaPlayer.Ctlcontrols.play();
                else
                    MediaPlayer.Ctlcontrols.pause();
                return true;
            }
            if ((keyData & Keys.KeyCode) == Keys.C)
                CopyMediaPlayerInfo();
            if ((keyData & Keys.KeyCode) == Keys.Left)
                OnKeyDownLeft();
            if ((keyData & Keys.KeyCode) == Keys.Right)
                OnKeyDownRight();

            return base.ProcessDialogKey(keyData);
        }
        void CopyMediaPlayerInfo()
        {
            var curMedia = MediaPlayer.currentMedia;
            if (curMedia != null)
            {
                string sourceURL = curMedia.sourceURL;
                int duration = (int)MediaPlayer.currentMedia.duration;
                int curPosition = (int)MediaPlayer.Ctlcontrols.currentPosition;
                TimeSpan span1 = new TimeSpan(0, 0, duration);
                TimeSpan span2 = new TimeSpan(0, 0, curPosition);
                string str = String.Format(
                    "ファイルパス：{0}\n長さ：{1}\n現在位置：{2}",
                    sourceURL, span1.ToString(), span2.ToString());
                Clipboard.SetText(str);
            }
        }
        void OnKeyDownLeft()
        {
            double value = MediaPlayer.Ctlcontrols.currentPosition;
            if (Control.ModifierKeys != Keys.Control)
                value--;
            else
                value -= 10;

            if (value > 0)
            {
                MediaPlayer.Ctlcontrols.currentPosition = value;
            }
            if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
                MediaPlayer.Ctlcontrols.play();
        }
        void OnKeyDownRight()
        {
            double value = MediaPlayer.Ctlcontrols.currentPosition;
            if (Control.ModifierKeys != Keys.Control)
                value++;
            else
                value += 10;
            if (value < MediaPlayer.currentMedia.duration)
            {
                MediaPlayer.Ctlcontrols.currentPosition = value;
            }
            if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
                MediaPlayer.Ctlcontrols.play();
        }
        private void SetWMPVolume(int volume)
        {
            // Ensure volume is within the valid range (0 to 100)
            if (volume >= 0 && volume <= 100)
            {
                MediaPlayer.settings.volume = volume;
            }
            else
            {
                // Handle invalid input if necessary
                Console.WriteLine("Volume must be between 0 and 100.");
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MediaPlayer.URL = @"C:\Users\user\Music\@1080p\[1080p]  Balo TikTok 【抖音背包】 『Everytime We Touch (Original Mix) - xxxCr3 ｜ 2022抖音最火的歌曲 ｜ Trending TikTok』 【ID：TQ_oIxIDKTA】.mp4";
            //axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media Files|*.mp3;*.m4a;*.wma;*.wav;*.mp4;*.wmv|All Files|*.*";
            openFileDialog.Multiselect = true; // Allow multiple selections
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 1. Create a new, empty playlist in the library
                IWMPPlaylist myPlayList = MediaPlayer.playlistCollection.newPlaylist("MyPlayList");
                // 2. Iterate through the selected files
                foreach (string file in openFileDialog.FileNames)
                {
                    // Create a new media item from the file path
                    IWMPMedia mediaItem = MediaPlayer.newMedia(file);

                    // Add the media item to the playlist
                    myPlayList.appendItem(mediaItem);
                }
                // 3. Set the newly created playlist as the current playlist to start playback
                MediaPlayer.currentPlaylist = myPlayList;
                // Optional: Start playback (it might start automatically depending on control settings)
                MediaPlayer.Ctlcontrols.play();
            }
        }
    }
}
