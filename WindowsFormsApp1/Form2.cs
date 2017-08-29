using System;
using System.Windows.Forms;
using LaCODESoftware.BasicHelper;
using System.Security.Principal;

namespace LaCODESoftware.Tsdm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start("https://github.com/xuyaqisgit/tsdm-.net-client/");

        private async void Button1_Click(object sender, EventArgs e)
        {
            string temp = StreamHelper.StreamToString((await WebHelper.GetStreamAsync(new System.Net.CookieContainer(), "https://api.github.com/repos/xuyaqisgit/tsdm-.net-client/releases/latest")).Item1);
            Json Last = JsonHelper.DataContractJsonDeserialize<Json>(temp.Replace("\n","").Replace("\r",""));
            string now = Application.ProductVersion;
            if (now != Last.tag_name)
            {
                DialogResult result = MessageBox.Show("是否更新至最新版本","更新确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result==DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://github.com/xuyaqisgit/tsdm-.net-client/releases");
                }
            }
            else
            {
                MessageBox.Show("无最新版本", "无最新版本", MessageBoxButtons.OK);
            }
        }

        private void Edge_Click(object sender, EventArgs e)
        {
            WebHelper.EdgeCoreChange();
        }
    }
}
