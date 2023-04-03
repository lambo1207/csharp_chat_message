namespace LamSerVer
{
    partial class ServerLam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listIcon = new System.Windows.Forms.ListView();
            this.rtb_Main = new System.Windows.Forms.RichTextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.rtb_Send = new System.Windows.Forms.RichTextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.XoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChuyenTiepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Image = new System.Windows.Forms.Button();
            this.btn_Icon = new System.Windows.Forms.Button();
            this.btn_File = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.check_lb = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listIcon
            // 
            this.listIcon.HideSelection = false;
            this.listIcon.Location = new System.Drawing.Point(424, 534);
            this.listIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listIcon.Name = "listIcon";
            this.listIcon.Size = new System.Drawing.Size(439, 134);
            this.listIcon.TabIndex = 41;
            this.listIcon.UseCompatibleStateImageBehavior = false;
            this.listIcon.Visible = false;
            this.listIcon.SelectedIndexChanged += new System.EventHandler(this.listIcon_SelectedIndexChanged);
            this.listIcon.MouseLeave += new System.EventHandler(this.listIcon_MouseLeave);
            // 
            // rtb_Main
            // 
            this.rtb_Main.ContextMenuStrip = this.contextMenuStrip1;
            this.rtb_Main.Location = new System.Drawing.Point(353, 71);
            this.rtb_Main.Margin = new System.Windows.Forms.Padding(4);
            this.rtb_Main.Name = "rtb_Main";
            this.rtb_Main.Size = new System.Drawing.Size(625, 584);
            this.rtb_Main.TabIndex = 40;
            this.rtb_Main.Text = "";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServer.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbServer.Location = new System.Drawing.Point(81, 11);
            this.lbServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(100, 31);
            this.lbServer.TabIndex = 36;
            this.lbServer.Text = "Server";
            this.lbServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtb_Send
            // 
            this.rtb_Send.Location = new System.Drawing.Point(357, 727);
            this.rtb_Send.Margin = new System.Windows.Forms.Padding(4);
            this.rtb_Send.Name = "rtb_Send";
            this.rtb_Send.Size = new System.Drawing.Size(505, 48);
            this.rtb_Send.TabIndex = 34;
            this.rtb_Send.Text = "";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Fuchsia;
            this.label1.Location = new System.Drawing.Point(596, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 31);
            this.label1.TabIndex = 43;
            this.label1.Text = "MiniChat";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XoaToolStripMenuItem,
            this.ChuyenTiepToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 80);
            // 
            // XoaToolStripMenuItem
            // 
            this.XoaToolStripMenuItem.Name = "XoaToolStripMenuItem";
            this.XoaToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.XoaToolStripMenuItem.Text = "Xóa";
            this.XoaToolStripMenuItem.Click += new System.EventHandler(this.XoaToolStripMenuItem_Click);
            // 
            // ChuyenTiepToolStripMenuItem
            // 
            this.ChuyenTiepToolStripMenuItem.Name = "ChuyenTiepToolStripMenuItem";
            this.ChuyenTiepToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.ChuyenTiepToolStripMenuItem.Text = "Chuyển Tiếp";
            this.ChuyenTiepToolStripMenuItem.Click += new System.EventHandler(this.ChuyenTiepToolStripMenuItem_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Image = global::LamSerVer.Properties.Resources.cut;
            this.btn_Delete.Location = new System.Drawing.Point(558, 674);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(59, 44);
            this.btn_Delete.TabIndex = 45;
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Image
            // 
            this.btn_Image.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Image.Image = global::LamSerVer.Properties.Resources.picture1;
            this.btn_Image.Location = new System.Drawing.Point(491, 676);
            this.btn_Image.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Image.Name = "btn_Image";
            this.btn_Image.Size = new System.Drawing.Size(59, 44);
            this.btn_Image.TabIndex = 39;
            this.btn_Image.UseVisualStyleBackColor = true;
            this.btn_Image.Click += new System.EventHandler(this.btn_Image_Click);
            // 
            // btn_Icon
            // 
            this.btn_Icon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Icon.Image = global::LamSerVer.Properties.Resources.smiling;
            this.btn_Icon.Location = new System.Drawing.Point(424, 676);
            this.btn_Icon.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Icon.Name = "btn_Icon";
            this.btn_Icon.Size = new System.Drawing.Size(59, 44);
            this.btn_Icon.TabIndex = 38;
            this.btn_Icon.UseVisualStyleBackColor = true;
            this.btn_Icon.Click += new System.EventHandler(this.btn_Icon_Click);
            // 
            // btn_File
            // 
            this.btn_File.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_File.Image = global::LamSerVer.Properties.Resources.folder;
            this.btn_File.Location = new System.Drawing.Point(357, 676);
            this.btn_File.Margin = new System.Windows.Forms.Padding(4);
            this.btn_File.Name = "btn_File";
            this.btn_File.Size = new System.Drawing.Size(59, 44);
            this.btn_File.TabIndex = 37;
            this.btn_File.UseVisualStyleBackColor = true;
            this.btn_File.Click += new System.EventHandler(this.btn_File_Click);
            // 
            // btnSend
            // 
            this.btnSend.Image = global::LamSerVer.Properties.Resources.send;
            this.btnSend.Location = new System.Drawing.Point(897, 727);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 49);
            this.btnSend.TabIndex = 35;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // check_lb
            // 
            this.check_lb.FormattingEnabled = true;
            this.check_lb.Location = new System.Drawing.Point(13, 160);
            this.check_lb.Margin = new System.Windows.Forms.Padding(4);
            this.check_lb.Name = "check_lb";
            this.check_lb.Size = new System.Drawing.Size(328, 616);
            this.check_lb.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(13, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 29);
            this.label2.TabIndex = 46;
            this.label2.Text = "Chọn Client";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1045, 814);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.check_lb);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listIcon);
            this.Controls.Add(this.rtb_Main);
            this.Controls.Add(this.btn_Image);
            this.Controls.Add(this.btn_Icon);
            this.Controls.Add(this.btn_File);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtb_Send);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServerLam";
            this.Text = "Server";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listIcon;
        private System.Windows.Forms.RichTextBox rtb_Main;
        private System.Windows.Forms.Button btn_Image;
        private System.Windows.Forms.Button btn_Icon;
        private System.Windows.Forms.Button btn_File;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtb_Send;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem XoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChuyenTiepToolStripMenuItem;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.CheckedListBox check_lb;
        private System.Windows.Forms.Label label2;
    }
}

