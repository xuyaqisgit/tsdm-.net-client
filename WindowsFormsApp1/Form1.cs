using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TsdmVisit tsdmVisit = new TsdmVisit();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("cookie"))
            {
                tsdmVisit.ReadCookiesFromDisk("cookie");
                tsdmVisit.UserInfo();
                dynamic dynamic = tsdmVisit.dynamic;
                tsdmVisit.GetContent(tsdmVisit.cookie, String.Format("{0}", dynamic.avatar));
                UserAratar.Image = Image.FromStream(tsdmVisit.stream);
                UidLabel.Text = dynamic.uid;
                UsernameLabel.Text = dynamic.username;
            }
            else
            {
                logpanel.Visible = true;
                VerifyImage.Image = Image.FromStream(tsdmVisit.VerifyCode());
            }
            int i = 0;
            tsdmVisit.GetForum("");
            foreach (var str in tsdmVisit.dynamic.group)
            {
                Button btn = new Button
                {
                    Name = "btn" + i.ToString()
                    , Text = str.title.ToString()
                    , AutoSize = true
                    , Tag = str.gid.ToString()
                };
                i++;
                btn.Click += GroupButton_Click;
                flowLayoutPanel3.Controls.Add(btn);
            }
        }

        private void VerifyImage_Click(object sender, EventArgs e)
        {
            VerifyImage.Image = Image.FromStream(tsdmVisit.VerifyCode());
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            tsdmVisit.LogIn(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString());
            if (tsdmVisit.tf == true)
            {
                logpanel.Visible = false;
                tsdmVisit.WriteCookiesToDisk("cookie");
                tsdmVisit.UserInfo();
                dynamic dynamic = tsdmVisit.dynamic;
                tsdmVisit.GetContent(tsdmVisit.cookie, String.Format("{0}",dynamic.avatar));
                UserAratar.Image = Image.FromStream(tsdmVisit.stream);
                UidLabel.Text = dynamic.uid;
                UsernameLabel.Text = dynamic.username;
            }
            else
            {
                VerifyImage.Image = Image.FromStream(tsdmVisit.VerifyCode());
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            tsdmVisit.Check();
            MessageBox.Show(tsdmVisit.message);
        }

        private void UserinfoRenewButton_Click(object sender, EventArgs e)
        {
            tsdmVisit.UserInfo();
            dynamic dynamic = tsdmVisit.dynamic;
            tsdmVisit.GetContent(tsdmVisit.cookie, String.Format("{0}", dynamic.avatar));
            UserAratar.Image = Image.FromStream(tsdmVisit.stream);
            UidLabel.Text = dynamic.uid;
            UsernameLabel.Text = dynamic.username;
        }

        private void ReplyButton_Click(object sender, EventArgs e)
        {
            tsdmVisit.Reply(tid.Text, ReplyBody.Text);
            if (tsdmVisit.tf)
            {
                tid.Clear();
                ReplyBody.Clear();
            }

        }

        private void UserInfoShowButton_Click(object sender, EventArgs e)
        {
            userpanel.Visible = !userpanel.Visible;
        }

        private void UserLogShowButton_Click(object sender, EventArgs e)
        {
            logpanel.Visible = !logpanel.Visible;
            if (logpanel.Visible == true)
            {
                VerifyImage.Image = Image.FromStream(tsdmVisit.VerifyCode());
            }
        }

        private void ReplyShowButton_Click(object sender, EventArgs e)
        {
            ReplyPanel.Visible = !ReplyPanel.Visible;
        }
        private void GroupButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel4.Controls.Clear();
                        Button button = sender as Button;
            tsdmVisit.GetForum(button.Tag.ToString());
            int i = 0;
            foreach (var str in tsdmVisit.dynamic.forum)
            {
                Label label = new Label
                {
                    Name = "btn" + i.ToString()
                    ,
                    Text = str.title.ToString() + "\n" + "今天更新:" + str.todaypost.ToString()
                    ,
                    AutoSize = true
                    ,
                    Tag = str.fid.ToString()
                    ,
                    BorderStyle = BorderStyle.FixedSingle

                };
                i++;
                label.Click += GroupLabel_Click;
                flowLayoutPanel4.Controls.Add(label);
            }
        }
        private void GroupLabel_Click(object sender, EventArgs e)
        {

        }

        private void FourmButton_Click(object sender, EventArgs e)
        {
            FourmPanel.Visible = !FourmPanel.Visible;
        }
    }
}
