using LaCODESoftware.BasicHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaCODESoftware.Tsdm
{
    class Form1VM
    {
        private TsdmHelper tsdmHelper = new TsdmHelper();
        public Control.ControlCollection ControlCollection { get; set; }
        public Json Json { get; set; }
        public bool Visible { get; set; }
        public Stream Stream { get; set; }
        private async Task Form1_LoadAsync(object sender, EventArgs e)
        {
            if (File.Exists("cookie"))
            {
                StreamHelper.ReadCookiesFromDisk("cookie");
                this.Json = await tsdmHelper.UserInfoAsync();
            }
            else
            {
                Visible = true;
                Stream = await tsdmHelper.VerifyCodeAsync();
            }
            Json json = await tsdmHelper.GetForumAsync("");
            foreach (var str in json.group)
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
                ControlCollection.Add(btn);
            }
        }
    }
}
