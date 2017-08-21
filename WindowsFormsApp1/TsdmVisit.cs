using System.Net;
using System.IO;
using System;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    class TsdmVisit
        {
        public CookieContainer cookie = new CookieContainer();
        public Stream stream;
        public bool tf;
        public dynamic dynamic;
        public string formhash;
        public string message;
        public string html;
        public void Sreach(string body)
        {
            GetContent(cookie, String.Format("http://www.tsdm.me/plugin.php?id=Kahrpba:search&query={0}&mobile=yes", body));
            dynamic = JsonConvert.DeserializeObject<dynamic>(Regex.Replace(StreamToString(), "[\\]", ""));

        }
        public void GetThread(string tid, string page)
        {
            GetContent(cookie, String.Format("http://www.tsdm.me/forum.php?mod=viewthread&mobile=yes&tsdmapp=1&tid={0}&page={1} ", tid, page));
            dynamic = JsonConvert.DeserializeObject<dynamic>(StreamToString());
        }
        public void GetForum(string fid, string page)
        {
            GetContent(cookie, String.Format("http://www.tsdm.me/forum.php?mobile=yes&tsdmapp=1&mod=forumdisplay&fid={0}&page={1}", fid, page));
            dynamic = JsonConvert.DeserializeObject<dynamic>(StreamToString());
        }
        public void GetForum(string gid)
        {
            GetContent(cookie, String.Format("http://www.tsdm.me/forum.php?mobile=yes&tsdmapp=1&gid={0}", gid));
            dynamic = JsonConvert.DeserializeObject<dynamic>(StreamToString());
        }
        public void Check()
        {
            GetContent(cookie, "http://www.tsdm.me/forum.php?mobile=yes&tsdmapp=1&mod=post&action=reply&tid=628244");
            var GetResult = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            formhash = GetResult.formhash;
            PostContent(cookie, "http://www.tsdm.me/plugin.php?mobile=yes&tsdmapp=1&id=dsu_paulsign:sign&operation=qiandao&infloat=1&inajax=1", String.Format("qdmode=1&formhash={0}&fastreply=1&qdxq=kx&todaysay=winform客户端签到", formhash));
            var ReplyResult = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            message = ReplyResult.message;
        }
        public void Reply(string tid, string body)
        {
            GetContent(cookie, String.Format("http://www.tsdm.me/forum.php?mobile=yes&tsdmapp=1&mod=post&action=reply&tid={0}", tid));
            var GetResult = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            formhash = GetResult.formhash;
            PostContent(cookie, "http://www.tsdm.me/forum.php?mobile=yes&tsdmapp=1&mod=post&action=reply&replysubmit=yes", String.Format("message={0}&formhash={1}&clienthash=DC0EEB7B38AA1F07AF76895A8E14747B&tid={2}&", body, GetResult.formhash, tid));
            var ReplyResult = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            if (ReplyResult.message == "post_reply_succeed")
            {
                System.Windows.Forms.MessageBox.Show("回复成功");
                tf = true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("回复有问题，请重试" + ReplyResult.message);
                tf = false;
            }
        }
        public void UserInfo()
        {
            GetContent(cookie, "http://www.tsdm.me/home.php?mobile=yes&tsdmapp=1&mod=space&do=profile ");
            dynamic = JsonConvert.DeserializeObject<dynamic>(StreamToString());
        }
        public Stream VerifyCode()
        {
            GetContent(cookie, "http://www.tsdm.me/plugin.php?id=oracle:verify");
            return stream;
        }
        public void LogIn(string username, string password, string verifycode, string loginfield)
        {
            string body = String.Format("password={0}&tsdm_verify={1}&fastloginfield={2}&answer=&username={3}&questionid=0&", password, verifycode, loginfield, username);
            PostContent(cookie, "http://www.tsdm.me/member.php?mobile=yes&tsdmapp=1&mod=logging&action=login&loginsubmit=yes", body);
            var LogResult = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            if (LogResult.message == "location_login_succeed_mobile")
            {
                System.Windows.Forms.MessageBox.Show("登录成功");
                tf = true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("登陆信息有误，请重试");
                tf = false;
            }
        }
        public void PostContent(CookieContainer cookie, string url, string Body)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.CookieContainer = cookie;
            httpRequest.Method = "POST";
            httpRequest.KeepAlive = true;
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT; Windows NT 10.0; zh-CN) WindowsPowerShell/5.1.16257.1";
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(Body);
            httpRequest.ContentLength = bytes.Length;
            Stream stream = httpRequest.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            this.stream = httpResponse.GetResponseStream();
            this.cookie.Add(httpResponse.Cookies);
        }
        public void GetContent(CookieContainer cookie, string url)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.CookieContainer = cookie;
            httpRequest.Referer = url;
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT; Windows NT 10.0; zh-CN) WindowsPowerShell/5.1.16257.1";
            httpRequest.Accept = "text/html, application/xhtml+xml, */*";
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.Method = "GET";
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Stream stream = httpResponse.GetResponseStream();
            this.stream = httpResponse.GetResponseStream();
            this.cookie.Add(httpResponse.Cookies);
        }
        public string StreamToString()
        {
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        public void WriteCookiesToDisk(string file)
        {
            Stream stream = File.Create(file);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, cookie);
        }
        public void ReadCookiesFromDisk(string file)
        {
            Stream stream = File.Open(file, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            cookie = (CookieContainer)formatter.Deserialize(stream);
        }
        public void ReadFileFromDisk(string file)
        {
            stream = File.Open(file, FileMode.Open);
        }
        public void WriteFileToDisk(string file, string body)
        {
            Stream stream = File.Open(file, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(stream);
            streamWriter.WriteLine(body);
            streamWriter.Flush();
        }
    }
}
