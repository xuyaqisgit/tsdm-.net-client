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
        public void Pay(string tid)
        {
            GetContent(cookie, "http://www.tsdm.me/forum.php?mobile=yes&tsdmapp=1&mod=post&action=reply&tid=628244");
            var GetResult = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            formhash = GetResult.formhash;
            PostContent(cookie, "http://www.tsdm.me/forum.php?mod=misc&action=pay&mobile=yes&paysubmit=yes&infloat=yes", String.Format("formhash={0}&referer=http://www.tsdm.me/./&tid={1}&paysubmit=true",formhash,tid));
            GetContent(cookie, String.Format("http://www.tsdm.me/forum.php?mod=viewthread&tid={0}&mobile=yes",tid));
        }
        public void Sreach(string body)
        {
            GetContent(cookie, String.Format("http://www.tsdm.me/plugin.php?id=Kahrpba:search&query={0}&mobile=yes", body));
            dynamic = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            stream.Flush();

        }
        public string GetThread(string tid, string page)
        {
            GetContent(cookie, String.Format("http://www.tsdm.me/forum.php?mod=viewthread&mobile=yes&tsdmapp=1&tid={0}&page={1} ", tid, page));
            dynamic = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            stream.Flush();
            string head = "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><base href=\"http://www.tsdm.me/\" /><style type=\"text/css\">img{ width:auto; height:auto; max-width:100%; max-height:100%;}</style></head>";
            string post = "";
            if (dynamic.thread_price != null)
            {
                post += String.Format("<div><a href=\"http://www.tsdm.me/forum.php?mod=misc&action=pay&mobile=yes&paysubmit=yes&infloat=yes\">购买主题 价格:{0}</a><div>", dynamic.thread_price);
            }
            foreach (var item in dynamic.postlist)
            {
                post += String.Format("<table><tbody><tr><td width=\"60\"><div width=\"60\"><div width=\"60\"><img src=\"{0}\" onerror=\"this.onerror=null;this.src=\'http://www.tsdm.me/uc_server/images/noavatar_middle.gif\'\" /></div><div>{1}</div><div>{2}</div><div>{3}</div></div></td><td width=\"400\"><div width=\"400\"><div width=\"400\"><table width=\"400\" cellspacing=\"0\" cellpadding=\"0\"><tbody><tr><td width=\"400\">{4}</td></tr></tbody></table></td></tr></tbody></table><hr />", item.avatar.ToString(), item.author.ToString(), item.author_nickname.ToString(), item.authortitle.ToString(), item.message.ToString());
            }
            return (head + "<body>" + post.Replace(" target=\"_blank\"", "") + "</body></html>");
        }
        public void GetForum(string fid, string page)
        {
            GetContent(cookie, String.Format("http://www.tsdm.me/forum.php?mobile=yes&tsdmapp=1&mod=forumdisplay&fid={0}&page={1}", fid, page));
            dynamic = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            stream.Flush();
        }
        public void GetForum(string gid)
        {
            GetContent(cookie, String.Format("http://www.tsdm.me/forum.php?mobile=yes&tsdmapp=1&gid={0}", gid));
            dynamic = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            stream.Flush();
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
            stream.Flush();
        }
        public void UserInfo()
        {
            GetContent(cookie, "http://www.tsdm.me/home.php?mobile=yes&tsdmapp=1&mod=space&do=profile ");
            dynamic = JsonConvert.DeserializeObject<dynamic>(StreamToString());
            stream.Flush();
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
            stream.Flush();
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
