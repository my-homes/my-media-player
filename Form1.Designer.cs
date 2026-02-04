using System.Drawing;
using System.Windows.Forms;

namespace MyMediaPlayer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            contextMenuStrip1 = new ContextMenuStrip(components);
            再生ToolStripMenuItem = new ToolStripMenuItem();
            一時停止ToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            //axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            contextMenuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 再生ToolStripMenuItem, 一時停止ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(123, 48);
            // 
            // 再生ToolStripMenuItem
            // 
            //再生ToolStripMenuItem.Name = "再生ToolStripMenuItem";
            //再生ToolStripMenuItem.Size = new Size(122, 22);
            //再生ToolStripMenuItem.Text = "再生";
            //再生ToolStripMenuItem.Click += 再生ToolStripMenuItem_Click;
            // 
            // 一時停止ToolStripMenuItem
            // 
            //一時停止ToolStripMenuItem.Name = "一時停止ToolStripMenuItem";
            //一時停止ToolStripMenuItem.Size = new Size(122, 22);
            //一時停止ToolStripMenuItem.Text = "一時停止";
            //一時停止ToolStripMenuItem.Click += 一時停止ToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(583, 293);
            panel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripLabel1, toolStripLabel2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            //toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            //toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            //toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            //toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "toolStripButton2";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(86, 22);
            toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(86, 22);
            toolStripLabel2.Text = "toolStripLabel2";
            // 
            // axWindowsMediaPlayer1
            // 
            //axWindowsMediaPlayer1.Enabled = true;
            //axWindowsMediaPlayer1.Location = new Point(655, 240);
            //axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            //axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            //axWindowsMediaPlayer1.Size = new Size(75, 23);
            //axWindowsMediaPlayer1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            //Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            //DragDrop += Form1_DragDrop;
            //DragOver += Form1_DragOver;
            contextMenuStrip1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            //((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 再生ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 一時停止ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        //private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

