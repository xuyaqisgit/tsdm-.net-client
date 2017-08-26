using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using LaCODESoftware.BasicHelper;

namespace LaCODESoftware.Tsdm
{
    public partial class Form1 : Form
    {
        private TsdmHelper tsdmHelper = new TsdmHelper();
        private string fid;
        private string fpage;
        private string tpage;
        private string spage;
        private string uid;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            if (File.Exists("cookie"))
            {
                tsdmHelper.Cookie = StreamHelper.ReadCookiesFromDisk("cookie");
                Json json = await tsdmHelper.UserInfoAsync();
                UsernameLabel.Text = "用户名:" + json.username;
                UidLabel.Text = "Uid:" + json.uid;
                uid = json.uid;
                label8.Text = json.extcredits1 + "\n" + json.extcredits2 + "\n" + json.extcredits3 + "\n" + json.extcredits4 + "\n" + json.extcredits5 + "\n" + json.extcredits6 + "\n" + json.extcredits7;
                UserAratar.Image = Image.FromStream((await WebHelper.GetStreamAsync(tsdmHelper.Cookie, String.Format("{0}", json.avatar))).Item1);
            }
            else
            {
                logpanel.Visible = true;
                VerifyImage.Image = Image.FromStream(await tsdmHelper.VerifyCodeAsync());
            }
            Json Json = await tsdmHelper.GetForumAsync("");
            foreach (var str in Json.group)
            {
                Button btn = new Button
                {
                    Name = "btn" + str.gid.ToString()
                    ,
                    Text = str.title.ToString()
                    ,
                    AutoSize = true
                    ,
                    Tag = str.gid.ToString()
                };
                btn.Click += GroupButton_ClickAsync;
                flowLayoutPanel3.Controls.Add(btn);
            }
        }

        private async void VerifyImage_ClickAsync(object sender, EventArgs e)
        {
            VerifyImage.Image = Image.FromStream(await tsdmHelper.VerifyCodeAsync());
        }

        private async void LogButton_ClickAsync(object sender, EventArgs e)
        {
            bool result = await tsdmHelper.LogInAsync(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString());
            if (result == true)
            {
                logpanel.Visible = false;
                Json json = await tsdmHelper.UserInfoAsync();
                StreamHelper.WriteCookiesToDisk("cookie", tsdmHelper.Cookie);
                UsernameLabel.Text = "用户名:" + json.username;
                UidLabel.Text = "Uid:" + json.uid;
                uid = json.uid;
                UserAratar.Image = Image.FromStream((await WebHelper.GetStreamAsync(tsdmHelper.Cookie, String.Format("{0}", json.avatar))).Item1);
                label8.Text = json.extcredits1 + "\n" + json.extcredits2 + "\n" + json.extcredits3 + "\n" + json.extcredits4 + "\n" + json.extcredits5 + "\n" + json.extcredits6 + "\n" + json.extcredits7;
            }
            else
            {
                MessageBox.Show("登录失败");
                VerifyImage.Image = Image.FromStream(await tsdmHelper.VerifyCodeAsync());
            }
        }

        private async void CheckButton_ClickAsync(object sender, EventArgs e)
        {
            MessageBox.Show(await tsdmHelper.CheckAsync());
        }

        private async void UserinfoRenewButton_ClickAsync(object sender, EventArgs e)
        {

            Json json = await tsdmHelper.UserInfoAsync();
            UsernameLabel.Text = "用户名:" + json.username;
            UidLabel.Text = "Uid:" + json.uid;
            label8.Text = json.extcredits1 + "\n" + json.extcredits2 + "\n" + json.extcredits3 + "\n" + json.extcredits4 + "\n" + json.extcredits5 + "\n" + json.extcredits6 + "\n" + json.extcredits7;
            UserAratar.Image = Image.FromStream((await WebHelper.GetStreamAsync(tsdmHelper.Cookie, String.Format("{0}", json.avatar))).Item1);

        }

        private async void ReplyButton_ClickAsync(object sender, EventArgs e)
        {

            Tuple<bool, string> Result = await tsdmHelper.ReplyAsync(tid.Text, ReplyBody.Text);
            if (Result.Item1)
            {
                ReplyBody.Clear();
                MessageBox.Show(Result.Item2);
            }
            else
            {
                MessageBox.Show(Result.Item2);
            }
        }

        private void UserInfoShowButton_Click(object sender, EventArgs e)
        {
            userpanel.Visible = !userpanel.Visible;
        }

        private async void UserLogShowButton_ClickAsync(object sender, EventArgs e)
        {
            logpanel.Visible = !logpanel.Visible;
            if (logpanel.Visible == true)
            {
                VerifyImage.Image = Image.FromStream(await tsdmHelper.VerifyCodeAsync());
            }
        }

        private void ReplyShowButton_Click(object sender, EventArgs e)
        {
            ReplyPanel.Visible = !ReplyPanel.Visible;
        }

        private async void GroupButton_ClickAsync(object sender, EventArgs e)
        {
            Button button = sender as Button;
            flowLayoutPanel4.Controls.Clear();
            Json json = await tsdmHelper.GetForumAsync(button.Tag.ToString());
            foreach (var str in json.forum)
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

        private async void SubGroupButton_ClickAsync(object sender, EventArgs e)
        {
            flowLayoutPanel7.Controls.Clear();
            Button button = sender as Button;

            Json json = await tsdmHelper.GetForumAsync(button.Tag.ToString(), "1");
            if (json.status == "-1")
            {
                MessageBox.Show(json.message);
            }
            else
            {
                SubForumAdd(json);
                fpage = "1";
                fid = button.Tag.ToString();
            }
        }

        private async void GroupLabel_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            flowLayoutPanel6.Controls.Clear();
            flowLayoutPanel7.Controls.Clear();
            Json json = await tsdmHelper.GetForumAsync(label.Tag.ToString(), "1");
            foreach (var str in json.subforum)
            {
                Button btn = new Button
                {
                    Name = "btn" + str.fid.ToString()
                    ,
                    Text = str.name.ToString()
                    ,
                    AutoSize = true
                    ,
                    Tag = str.fid.ToString()
                };
                btn.Click += SubGroupButton_ClickAsync;
                flowLayoutPanel6.Controls.Add(btn);
            }
            SubForumAdd(json);
            fpage = "1";
            fid = label.Tag.ToString();

        }

        private async void SubGroupLabel_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            webBrowser1.DocumentText = await tsdmHelper.GetThreadAsync(label.Tag.ToString(), "1");
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

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            int intfpage = int.Parse(fpage);
            if (intfpage > 1)
            {
                intfpage--;
                fpage = intfpage.ToString();
                flowLayoutPanel7.Controls.Clear();
                Json json = await tsdmHelper.GetForumAsync(fid, fpage);
                SubForumAdd(json);
            }
        }

        private async void Button2_ClickAsync(object sender, EventArgs e)
        {
            int intfpage = int.Parse(fpage);
            intfpage++;
            fpage = intfpage.ToString();
            flowLayoutPanel7.Controls.Clear();
            Json json = await tsdmHelper.GetForumAsync(fid, fpage);
            SubForumAdd(json);
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            }
        }

        private async void Button3_ClickAsync(object sender, EventArgs e)
        {
            fpage = textBox4.Text.ToString();
            flowLayoutPanel7.Controls.Clear();
            Json json = await tsdmHelper.GetForumAsync(fid, fpage);
            SubForumAdd(json);
        }

        private async void WebBrowser1_NavigatingAsync(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Host.Contains("www.tsdm.me") || e.Url.Host.Contains("forum.php") || e.Url.Host.Contains("www.tsdm.net"))
            {
                e.Cancel = true;
                if (e.Url.ToString() == "http://www.tsdm.me/forum.php?mod=misc&action=pay&mobile=yes&paysubmit=yes&infloat=yes")
                {
                    await tsdmHelper.PayAsync(tid.Text);
                    webBrowser1.DocumentText = await tsdmHelper.GetThreadAsync(tid.Text, tpage);
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
                    webBrowser1.DocumentText = await tsdmHelper.GetThreadAsync(tid.Text, tpage);
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

        private async void Button6_Click(object sender, EventArgs e)
        {
            int inttpage = int.Parse(tpage);
            if (inttpage > 1)
            {
                inttpage--;
                tpage = inttpage.ToString();
                webBrowser1.DocumentText = await tsdmHelper.GetThreadAsync(tid.Text, tpage);
            }
        }

        private async void Button5_Click(object sender, EventArgs e)
        {
            int inttpage = int.Parse(tpage);
            inttpage++;
            tpage = inttpage.ToString();
            webBrowser1.DocumentText = await tsdmHelper.GetThreadAsync(tid.Text, tpage);
        }

        private async void Button4_Click(object sender, EventArgs e)
        {
            tpage = textBox5.ToString();
            webBrowser1.DocumentText = await tsdmHelper.GetThreadAsync(tid.Text, tpage);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamHelper.WriteCookiesToDisk("cookie", tsdmHelper.Cookie);
        }

        private void SubForumAdd(Json json)
        {
            foreach (var str in json.thread)
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
                    ,
                    MaximumSize = new Size(293, 50)
                };
                lab.Click += SubGroupLabel_Click;
                flowLayoutPanel7.Controls.Add(lab);
            }
        }

        private async void SearchButton_ClickAsync(object sender, EventArgs e)
        {
            webBrowser2.DocumentText = await tsdmHelper.SreachAsync(textBox7.Text,"1");
            spage = "1";
        }

        private async void Button9_ClickAsync(object sender, EventArgs e)
        {
            int intspage = int.Parse(spage);
            if (intspage > 1)
            {
                intspage--;
                spage = intspage.ToString();
                webBrowser2.DocumentText = await tsdmHelper.SreachAsync(textBox7.Text, spage);
            }
        }

        private async void Button8_ClickAsync(object sender, EventArgs e)
        {
            int intspage = int.Parse(spage);
            intspage++;
            spage = intspage.ToString();
            webBrowser2.DocumentText = await tsdmHelper.SreachAsync(textBox7.Text, spage);
        }

        private async void Button7_ClickAsync(object sender, EventArgs e)
        {
            spage = textBox7.Text;
            webBrowser2.DocumentText = await tsdmHelper.SreachAsync(textBox7.Text, spage);
        }

        private void SearchShowButton_Click(object sender, EventArgs e)
        {
            SearchPanel.Visible = !SearchPanel.Visible;
        }

        private async void WebBrowser2_NavigatingAsync(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Host.Contains("www.tsdm.me") || e.Url.Host.Contains("forum.php") || e.Url.Host.Contains("www.tsdm.net"))
            {
                e.Cancel = true;
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
                webBrowser1.DocumentText = await tsdmHelper.GetThreadAsync(tid.Text, tpage);
            }
            else
            {
                    
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(String.Format("http://www.tsdm.me/forum.php?mod=viewthread&tid={0}&fromuid={1}",tid.Text,uid));
        }
    }
}
