using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace LaCODESoftware.BasicHelper
{
    /// <summary>
    /// System.Net具体实现
    /// </summary>
    public class WebHelper
    {
        /// <summary>
        /// 带有cookie的HTTP/1.1 POST请求
        /// </summary>
        /// <param name="cookie">指定cookie</param>
        /// <param name="url">指定url</param>
        /// <param name="Body">指定携带报文</param>
        /// <returns></returns>
        public static async Task<Tuple<Stream, CookieContainer>> GetStreamAsync(CookieContainer cookie, string url, string Body)
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
            HttpWebResponse httpResponse = (HttpWebResponse) await httpRequest.GetResponseAsync();
            cookie.Add(httpResponse.Cookies);
            return new Tuple<Stream, CookieContainer>(httpResponse.GetResponseStream(), cookie);
        }
        /// <summary>
        /// 带有cookie的HTTP/1.1 GET请求
        /// </summary>
        /// <param name="cookie">指定cookie</param>
        /// <param name="url">指定url</param>
        /// <returns></returns>
        public static async Task<Tuple<Stream, CookieContainer>> GetStreamAsync(CookieContainer cookie, string url)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.CookieContainer = cookie;
            httpRequest.Referer = url;
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT; Windows NT 10.0; zh-CN) WindowsPowerShell/5.1.16257.1";
            httpRequest.Accept = "text/html, application/xhtml+xml, */*";
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.Method = "GET";
            HttpWebResponse httpResponse = (HttpWebResponse) await httpRequest.GetResponseAsync();
            if (httpResponse.Cookies.Count > 0)
            {
                cookie.Add(httpResponse.Cookies);
            }
            return new Tuple<Stream, CookieContainer>(httpResponse.GetResponseStream(), cookie);
        }
    }
    /// <summary>
    /// Json序列化
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 把指定json转换成指定实体类T的实例
        /// </summary>
        /// <typeparam name="T">指定实体类</typeparam>
        /// <param name="json">指定json</param>
        /// <returns></returns>
        public static T DataContractJsonDeserialize<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            T obj = default(T);
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            obj = (T)serializer.ReadObject(ms);
            return obj;
        }
        /// <summary>
        /// 把指定流Stream转换成指定实体类T的实例
        /// </summary>
        /// <typeparam name="T">指定实体类</typeparam>
        /// <param name="stream">指定流</param>
        /// <returns></returns>
        public static T DataContractJsonDeserialize<T>(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            T obj = default(T);
            obj = (T)serializer.ReadObject(stream);
            return obj;
        }
        /// <summary>
        /// json序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Stream DataContractJsonSerialize<T>(T t)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, t);
            return memoryStream;
        }
    }
    /// <summary>
    /// 对流的详细操作
    /// </summary>
    public class StreamHelper
    {
        /// <summary>
        /// 把指定流stream转换成字符串
        /// </summary>
        /// <param name="stream">指定流</param>
        /// <returns></returns>
        public static string StreamToString(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        /// <summary>
        /// 把指定cookie写入指定文件file
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="cookie"></param>
        public static void WriteCookiesToDisk(string file, CookieContainer cookie)
        {
            Stream stream = File.Create(file);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, cookie);
        }

        /// <summary>
        /// 从指定文件file磁盘读取Cookie
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static CookieContainer ReadCookiesFromDisk(string file)
        {
            Stream stream = File.Open(file, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            return (CookieContainer)formatter.Deserialize(stream);
        }
    }
}

