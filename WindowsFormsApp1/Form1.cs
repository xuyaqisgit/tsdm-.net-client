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
        private string fpage;
        private string tpage;
        private string fid;
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
            tsdmVisit.GetForum("");
            foreach (var str in tsdmVisit.dynamic.group)
            {
                Button btn = new Button
                {
                    Name = "btn" + str.gid.ToString()
                    , Text = str.title.ToString()
                    , AutoSize = true
                    , Tag = str.gid.ToString()
                };
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
                tsdmVisit.GetContent(tsdmVisit.cookie, String.Format("{0}", dynamic.avatar));
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
            foreach (var str in tsdmVisit.dynamic.forum)
            {
                Label label = new Label
                {
                    Name = "btn" + str.fid.ToString()
                    ,
                    Text = str.title.ToString() + "\n" + "今天更新:" + str.todaypost.ToString()
                    ,
                    AutoSize = true
                    ,
                    Tag = str.fid.ToString()
                    ,
                    BorderStyle = BorderStyle.FixedSingle

                };
                label.Click += GroupLabel_Click;
                flowLayoutPanel4.Controls.Add(label);
            }
        }
        private void SubGroupButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel7.Controls.Clear();
            Button button = sender as Button;
            tsdmVisit.GetForum(button.Tag.ToString(), "1");
            dynamic dynamic = tsdmVisit.dynamic;
            foreach (var str in dynamic.thread)
            {
                Label label = new Label
                {
                    Name = "Label" + str.tid.ToString()
                    ,
                    Text = str.title.ToString()
                    ,
                    AutoSize = true
                    ,
                    Tag = str.tid.ToString()
                    ,
                    BorderStyle = BorderStyle.FixedSingle

                };
                label.Click += SubGroupLabel_Click;
                flowLayoutPanel7.Controls.Add(label);
            }
            fpage = "1";
            fid = button.Tag.ToString();
        }
        private void GroupLabel_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            flowLayoutPanel6.Controls.Clear();
            flowLayoutPanel7.Controls.Clear();
            tsdmVisit.GetForum(label.Tag.ToString(), "1");
            dynamic dynamic = tsdmVisit.dynamic;
            foreach (var str in dynamic.subforum)
            {
                Button btn = new Button
                {
                    Name = "btn" + str.fid.ToString()
                    , Text = str.name.ToString()
                    , AutoSize = true
                    , Tag = str.fid.ToString()
                };
                btn.Click += SubGroupButton_Click;
                flowLayoutPanel6.Controls.Add(btn);
            }
            foreach (var str in dynamic.thread)
            {
                Label lab = new Label
                {
                    Name = "Label" + str.tid.ToString()
                    ,
                    Text = str.title.ToString()
                    ,
                    AutoSize = true
                    ,
                    Tag = str.tid.ToString()
                    ,
                    BorderStyle = BorderStyle.FixedSingle

                };
                lab.Click += SubGroupLabel_Click;
                flowLayoutPanel7.Controls.Add(lab);
            }
            fpage = "1";
            fid = label.Tag.ToString();
        }

        private void SubGroupLabel_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            webBrowser1.DocumentText = tsdmVisit.GetThread(label.Tag.ToString(), "1");
            tid.Text = label.Tag.ToString();
            tpage = "1";
        }
        private void FourmButton_Click(object sender, EventArgs e)
        {
            FourmPanel.Visible = !FourmPanel.Visible;
        }

        private void WebButton_Click(object sender, EventArgs e)
        {
            WebPanel.Visible = !WebPanel.Visible;
        }

        private void SubForumBottun_Click(object sender, EventArgs e)
        {
            SubForumPanel.Visible = !SubForumPanel.Visible;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int intfpage = int.Parse(fpage);
            if (intfpage > 1)
            {
                intfpage--;
                fpage = intfpage.ToString();
                flowLayoutPanel7.Controls.Clear();
                tsdmVisit.GetForum(fid, fpage);
                foreach (var str in tsdmVisit.dynamic.thread)
                {
                    Label lab = new Label
                    {
                        Name = "Label" + str.tid.ToString()
                        ,
                        Text = str.title.ToString()
                        ,
                        AutoSize = true
                        ,
                        Tag = str.tid.ToString()
                        ,
                        BorderStyle = BorderStyle.FixedSingle

                    };
                    lab.Click += SubGroupLabel_Click;
                    flowLayoutPanel7.Controls.Add(lab);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int intfpage = int.Parse(fpage);
            intfpage++;
            fpage = intfpage.ToString();
            flowLayoutPanel7.Controls.Clear();
            tsdmVisit.GetForum(fid, fpage);
            foreach (var str in tsdmVisit.dynamic.thread)
            {
                Label lab = new Label
                {
                    Name = "Label" + str.tid.ToString()
                    ,
                    Text = str.title.ToString()
                    ,
                    AutoSize = true
                    ,
                    Tag = str.tid.ToString()
                    ,
                    BorderStyle = BorderStyle.FixedSingle

                };
                lab.Click += SubGroupLabel_Click;
                flowLayoutPanel7.Controls.Add(lab);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fpage = textBox4.Text.ToString();
            flowLayoutPanel7.Controls.Clear();
            tsdmVisit.GetForum(fid, fpage);
            foreach (var str in tsdmVisit.dynamic.thread)
            {
                Label lab = new Label
                {
                    Name = "Label" + str.tid.ToString()
                    ,
                    Text = str.title.ToString()
                    ,
                    AutoSize = true
                    ,
                    Tag = str.tid.ToString()
                    ,
                    BorderStyle = BorderStyle.FixedSingle

                };
                lab.Click += SubGroupLabel_Click;
                flowLayoutPanel7.Controls.Add(lab);
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Host.Contains("www.tsdm.me") || e.Url.Host.Contains("forum.php")|| e.Url.Host.Contains("www.tsdm.net"))
            {
                e.Cancel = true;
                if (e.Url.ToString() == "http://www.tsdm.me/forum.php?mod=misc&action=pay&mobile=yes&paysubmit=yes&infloat=yes")
                {
                    tsdmVisit.Pay(tid.Text);
                    webBrowser1.Refresh();
                }
                else
                {
                    MatchCollection matchCollection = Regex.Matches(e.Url.ToString(), @"\b\d+\b");
                    tid.Text = matchCollection[0].ToString();
                    if (matchCollection.Count > 1)
                    {
                        tpage = matchCollection[1].ToString();
                    }
                    else
                    {
                        tpage = "1";
                    }
                    webBrowser1.DocumentText = tsdmVisit.GetThread(tid.Text, tpage);
                }
            }
            else if (e.Url.ToString() == "about:blank")
            {

            }
            else
            {
                e.Cancel = true;
                System.Diagnostics.Process.Start(e.Url.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int inttpage = int.Parse(tpage);
            if (inttpage > 1)
            {
                inttpage--;
                tpage = inttpage.ToString();
                webBrowser1.DocumentText = tsdmVisit.GetThread(tid.Text, tpage);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int inttpage = int.Parse(tpage);
                inttpage++;
            tpage = inttpage.ToString();
            webBrowser1.DocumentText = tsdmVisit.GetThread(tid.Text, tpage);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tpage = textBox5.ToString();
            webBrowser1.DocumentText = tsdmVisit.GetThread(tid.Text, tpage);
        }

    }
}
