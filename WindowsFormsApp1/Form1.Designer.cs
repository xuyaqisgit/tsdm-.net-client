namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReplyShowButton = new System.Windows.Forms.Button();
            this.UserLogShowButton = new System.Windows.Forms.Button();
            this.UserInfoShowButton = new System.Windows.Forms.Button();
            this.userpanel = new System.Windows.Forms.Panel();
            this.UserinfoRenewButton = new System.Windows.Forms.Button();
            this.CheckButton = new System.Windows.Forms.Button();
            this.UserAratar = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UidLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.logpanel = new System.Windows.Forms.Panel();
            this.LogButton = new System.Windows.Forms.Button();
            this.VerifyImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FourmPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.ReplyPanel = new System.Windows.Forms.Panel();
            this.ReplyButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ReplyBody = new System.Windows.Forms.TextBox();
            this.tid = new System.Windows.Forms.TextBox();
            this.FourmButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.userpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserAratar)).BeginInit();
            this.logpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerifyImage)).BeginInit();
            this.FourmPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ReplyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.userpanel);
            this.flowLayoutPanel1.Controls.Add(this.logpanel);
            this.flowLayoutPanel1.Controls.Add(this.FourmPanel);
            this.flowLayoutPanel1.Controls.Add(this.ReplyPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(736, 412);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FourmButton);
            this.panel1.Controls.Add(this.ReplyShowButton);
            this.panel1.Controls.Add(this.UserLogShowButton);
            this.panel1.Controls.Add(this.UserInfoShowButton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 388);
            this.panel1.TabIndex = 15;
            // 
            // ReplyShowButton
            // 
            this.ReplyShowButton.Location = new System.Drawing.Point(9, 69);
            this.ReplyShowButton.Name = "ReplyShowButton";
            this.ReplyShowButton.Size = new System.Drawing.Size(75, 23);
            this.ReplyShowButton.TabIndex = 3;
            this.ReplyShowButton.Text = "回复";
            this.ReplyShowButton.UseVisualStyleBackColor = true;
            this.ReplyShowButton.Click += new System.EventHandler(this.ReplyShowButton_Click);
            // 
            // UserLogShowButton
            // 
            this.UserLogShowButton.Location = new System.Drawing.Point(9, 38);
            this.UserLogShowButton.Name = "UserLogShowButton";
            this.UserLogShowButton.Size = new System.Drawing.Size(75, 23);
            this.UserLogShowButton.TabIndex = 1;
            this.UserLogShowButton.Text = "登录/切换";
            this.UserLogShowButton.UseVisualStyleBackColor = true;
            this.UserLogShowButton.Click += new System.EventHandler(this.UserLogShowButton_Click);
            // 
            // UserInfoShowButton
            // 
            this.UserInfoShowButton.Location = new System.Drawing.Point(9, 9);
            this.UserInfoShowButton.Name = "UserInfoShowButton";
            this.UserInfoShowButton.Size = new System.Drawing.Size(75, 23);
            this.UserInfoShowButton.TabIndex = 0;
            this.UserInfoShowButton.Text = "用户信息";
            this.UserInfoShowButton.UseVisualStyleBackColor = true;
            this.UserInfoShowButton.Click += new System.EventHandler(this.UserInfoShowButton_Click);
            // 
            // userpanel
            // 
            this.userpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userpanel.Controls.Add(this.UserinfoRenewButton);
            this.userpanel.Controls.Add(this.CheckButton);
            this.userpanel.Controls.Add(this.UserAratar);
            this.userpanel.Controls.Add(this.label5);
            this.userpanel.Controls.Add(this.UidLabel);
            this.userpanel.Controls.Add(this.label7);
            this.userpanel.Controls.Add(this.UsernameLabel);
            this.userpanel.Location = new System.Drawing.Point(104, 3);
            this.userpanel.Name = "userpanel";
            this.userpanel.Size = new System.Drawing.Size(340, 388);
            this.userpanel.TabIndex = 13;
            // 
            // UserinfoRenewButton
            // 
            this.UserinfoRenewButton.Location = new System.Drawing.Point(171, 254);
            this.UserinfoRenewButton.Name = "UserinfoRenewButton";
            this.UserinfoRenewButton.Size = new System.Drawing.Size(75, 23);
            this.UserinfoRenewButton.TabIndex = 12;
            this.UserinfoRenewButton.Text = "刷新";
            this.UserinfoRenewButton.UseVisualStyleBackColor = true;
            this.UserinfoRenewButton.Click += new System.EventHandler(this.UserinfoRenewButton_Click);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(62, 254);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(75, 23);
            this.CheckButton.TabIndex = 9;
            this.CheckButton.Text = "签到";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // UserAratar
            // 
            this.UserAratar.ImageLocation = "";
            this.UserAratar.Location = new System.Drawing.Point(42, 6);
            this.UserAratar.Name = "UserAratar";
            this.UserAratar.Size = new System.Drawing.Size(238, 140);
            this.UserAratar.TabIndex = 8;
            this.UserAratar.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "uid";
            // 
            // UidLabel
            // 
            this.UidLabel.AutoSize = true;
            this.UidLabel.Location = new System.Drawing.Point(87, 158);
            this.UidLabel.Name = "UidLabel";
            this.UidLabel.Size = new System.Drawing.Size(0, 12);
            this.UidLabel.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "用户名";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(87, 173);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(0, 12);
            this.UsernameLabel.TabIndex = 0;
            // 
            // logpanel
            // 
            this.logpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logpanel.Controls.Add(this.LogButton);
            this.logpanel.Controls.Add(this.VerifyImage);
            this.logpanel.Controls.Add(this.label4);
            this.logpanel.Controls.Add(this.textBox3);
            this.logpanel.Controls.Add(this.textBox2);
            this.logpanel.Controls.Add(this.textBox1);
            this.logpanel.Controls.Add(this.comboBox1);
            this.logpanel.Controls.Add(this.label3);
            this.logpanel.Controls.Add(this.label2);
            this.logpanel.Controls.Add(this.label1);
            this.logpanel.Location = new System.Drawing.Point(450, 3);
            this.logpanel.Name = "logpanel";
            this.logpanel.Size = new System.Drawing.Size(340, 388);
            this.logpanel.TabIndex = 12;
            this.logpanel.Visible = false;
            // 
            // LogButton
            // 
            this.LogButton.Location = new System.Drawing.Point(87, 321);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(75, 23);
            this.LogButton.TabIndex = 9;
            this.LogButton.Text = "登录";
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // VerifyImage
            // 
            this.VerifyImage.ImageLocation = "";
            this.VerifyImage.Location = new System.Drawing.Point(6, 173);
            this.VerifyImage.Name = "VerifyImage";
            this.VerifyImage.Size = new System.Drawing.Size(321, 140);
            this.VerifyImage.TabIndex = 8;
            this.VerifyImage.TabStop = false;
            this.VerifyImage.Click += new System.EventHandler(this.VerifyImage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "验证码";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(87, 146);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 118);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "uid",
            "email",
            "username"});
            this.comboBox1.Location = new System.Drawing.Point(87, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "登录方式";
            // 
            // FourmPanel
            // 
            this.FourmPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FourmPanel.Controls.Add(this.flowLayoutPanel2);
            this.FourmPanel.Location = new System.Drawing.Point(796, 3);
            this.FourmPanel.Name = "FourmPanel";
            this.FourmPanel.Size = new System.Drawing.Size(340, 388);
            this.FourmPanel.TabIndex = 16;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(340, 388);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.flowLayoutPanel3);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 183);
            this.panel2.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Location = new System.Drawing.Point(-1, -1);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(332, 183);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.flowLayoutPanel4);
            this.panel3.Location = new System.Drawing.Point(3, 192);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 193);
            this.panel3.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoScroll = true;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(-1, -1);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(332, 193);
            this.flowLayoutPanel4.TabIndex = 0;
            this.flowLayoutPanel4.WrapContents = false;
            // 
            // ReplyPanel
            // 
            this.ReplyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReplyPanel.Controls.Add(this.ReplyButton);
            this.ReplyPanel.Controls.Add(this.label6);
            this.ReplyPanel.Controls.Add(this.ReplyBody);
            this.ReplyPanel.Controls.Add(this.tid);
            this.ReplyPanel.Location = new System.Drawing.Point(1142, 3);
            this.ReplyPanel.Name = "ReplyPanel";
            this.ReplyPanel.Size = new System.Drawing.Size(340, 388);
            this.ReplyPanel.TabIndex = 14;
            // 
            // ReplyButton
            // 
            this.ReplyButton.Location = new System.Drawing.Point(209, 351);
            this.ReplyButton.Name = "ReplyButton";
            this.ReplyButton.Size = new System.Drawing.Size(75, 23);
            this.ReplyButton.TabIndex = 3;
            this.ReplyButton.Text = "回复";
            this.ReplyButton.UseVisualStyleBackColor = true;
            this.ReplyButton.Click += new System.EventHandler(this.ReplyButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "tid";
            // 
            // ReplyBody
            // 
            this.ReplyBody.Location = new System.Drawing.Point(18, 33);
            this.ReplyBody.Multiline = true;
            this.ReplyBody.Name = "ReplyBody";
            this.ReplyBody.Size = new System.Drawing.Size(267, 311);
            this.ReplyBody.TabIndex = 1;
            // 
            // tid
            // 
            this.tid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tid.Location = new System.Drawing.Point(45, 6);
            this.tid.Name = "tid";
            this.tid.Size = new System.Drawing.Size(100, 21);
            this.tid.TabIndex = 0;
            // 
            // FourmButton
            // 
            this.FourmButton.Location = new System.Drawing.Point(10, 99);
            this.FourmButton.Name = "FourmButton";
            this.FourmButton.Size = new System.Drawing.Size(75, 23);
            this.FourmButton.TabIndex = 4;
            this.FourmButton.Text = "论坛";
            this.FourmButton.UseVisualStyleBackColor = true;
            this.FourmButton.Click += new System.EventHandler(this.FourmButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 412);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "TSDM .NET Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.userpanel.ResumeLayout(false);
            this.userpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserAratar)).EndInit();
            this.logpanel.ResumeLayout(false);
            this.logpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerifyImage)).EndInit();
            this.FourmPanel.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ReplyPanel.ResumeLayout(false);
            this.ReplyPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel userpanel;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.PictureBox UserAratar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label UidLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Panel logpanel;
        private System.Windows.Forms.Button LogButton;
        private System.Windows.Forms.PictureBox VerifyImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UserinfoRenewButton;
        private System.Windows.Forms.Panel ReplyPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ReplyBody;
        private System.Windows.Forms.TextBox tid;
        private System.Windows.Forms.Button ReplyButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ReplyShowButton;
        private System.Windows.Forms.Button UserLogShowButton;
        private System.Windows.Forms.Button UserInfoShowButton;
        private System.Windows.Forms.Panel FourmPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button FourmButton;
    }
}

