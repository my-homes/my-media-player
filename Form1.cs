using AxWMPLib;
using Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
            ReallocConsole();
            Log("ハロー©");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            // axWindowsMediaPlayer1.uiMode = "none"; /* 外観のユーザインタフェースを消す */
            axWindowsMediaPlayer1.settings.autoStart = true; /* 自動開始をオンにする */
            axWindowsMediaPlayer1.Ctlenabled = true;            // ダブルクリックによるフルスクリーン出力を無効化
            axWindowsMediaPlayer1.enableContextMenu = true;     // 右クリックによるコンテキストメニューの出力を無効化
        }
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"C:\Users\user\Music\@1080p\[1080p]  Balo TikTok 【抖音背包】 『Everytime We Touch (Original Mix) - xxxCr3 ｜ 2022抖音最火的歌曲 ｜ Trending TikTok』 【ID：TQ_oIxIDKTA】.mp4";
            //axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media Files|*.mp3;*.wma;*.wav;*.mp4;*.wmv|All Files|*.*";
            openFileDialog.Multiselect = true; // Allow multiple selections
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 1. Create a new, empty playlist in the library
                IWMPPlaylist myPlayList = axWindowsMediaPlayer1.playlistCollection.newPlaylist("MyPlayList");

                // 2. Iterate through the selected files
                foreach (string file in openFileDialog.FileNames)
                {
                    // Create a new media item from the file path
                    IWMPMedia mediaItem = axWindowsMediaPlayer1.newMedia(file);

                    // Add the media item to the playlist
                    myPlayList.appendItem(mediaItem);
                }

                // 3. Set the newly created playlist as the current playlist to start playback
                axWindowsMediaPlayer1.currentPlaylist = myPlayList;

                // Optional: Start playback (it might start automatically depending on control settings)
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
    }
}
