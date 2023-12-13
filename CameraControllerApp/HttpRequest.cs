using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Common;
using Newtonsoft.Json;

namespace CameraControllerApp
{
    // 以下为封装的App Request 请求类
    class HttpRequest
    {
        /// <summary>
        /// 向指定URL发送GET方法的请求
        /// </summary>
        /// <param name="url">发送请求的URL</param>
        /// <param name="param">请求参数，请求参数应该是 name1=value1&name2=value2 的形式。</param>
        /// <returns>所代表远程资源的响应结果</returns>
        public static string SendGet(string url)
        {
            try
            {
                HttpHelper client = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = url,
                    Encoding = System.Text.Encoding.UTF8,
                    PostEncoding = System.Text.Encoding.UTF8,
                    ContentType = "text/html",
                    Method = "GET",
                    Postdata = "",
                    Timeout = 5000
                };
                HttpResult result = client.GetHtml(item);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    return result.Html;
                }
                else
                {
                    NLogger.Default.Error("请求返还错误，code={0},desc={1}", result.StatusCode, result.StatusDescription);
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// 向指定URL发送GET方法的请求
        /// </summary>
        /// <param name="url">发送请求的URL</param>
        /// <param name="param">请求参数，请求参数应该是 name1=value1&name2=value2 的形式。</param>
        /// <param name="encoding">设置响应信息的编码格式，如utf-8</param>
        /// <returns>所代表远程资源的响应结果</returns>
        public static string SendGet(string url, string param, string encoding)
        {
            string result = String.Empty;
            StreamReader reader = null;
            try
            {
                string urlNameString = url + "?" + param;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlNameString);
                request.Method = "GET";
                request.ContentType = "text/html;charset=" + encoding;
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, Encoding.GetEncoding(encoding));
                result = reader.ReadToEnd();

                reader.Close();
                responseStream.Close();
                response.Close();
                reader = null;
                responseStream = null;
                response = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("发送GET请求出现异常：" + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 向指定 URL 发送POST方法的请求
        /// </summary>
        /// <param name="url">发送请求的 URL</param>
        /// <param name="jsonData">请求参数，请求参数应该是Json格式字符串的形式。</param>
        /// <returns>所代表远程资源的响应结果</returns>
        public static string SendPost(string url, Dictionary<string, string> dic)
        {
            Console.WriteLine("url" + url);
            NLogger.Default.Debug("url:" + url);
            //post请求
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            try
            {
                HttpHelper client = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = url,
                    Encoding = System.Text.Encoding.UTF8,
                    PostEncoding = System.Text.Encoding.UTF8,
                    ContentType = "application/json",
                    Method = "post",
                    Postdata = JsonConvert.SerializeObject(dic)
                };
                HttpResult result = client.GetHtml(item);
                NLogger.Default.Debug("服务器返回报文>>> {0}", result.Html);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string response = result.Html;
                    if (response == null || response == "")
                    {
                        return "Error";
                    }
                    return response;
                }
                else
                {
                    NLogger.Default.Error("请求返还错误，code={0},desc={1}", result.StatusCode, result.StatusDescription);
                }
                return "Error";
            }
            catch (Exception ex)
            {
                NLogger.Default.Error("请求异常", ex);
            }
            return "Error";
        }

        /// <summary>
        /// 向指定 URL 发送POST方法的请求
        /// </summary>
        /// <param name="url">发送请求的 URL</param>
        /// <param name="jsonData">请求参数，请求参数应该是Json格式字符串的形式。</param>
        /// <param name="encoding">设置响应信息的编码格式，如utf-8</param>
        /// <returns>所代表远程资源的响应结果</returns>
        public static string SendPost(string url, string jsonData, string encoding)
        {
            string result = String.Empty;
            try
            {
                CookieContainer cookie = new CookieContainer();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("x-requested-with", "XMLHttpRequest");
                request.ServicePoint.Expect100Continue = false;
                request.ContentType = "application/application/json";
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";
                request.ContentLength = Encoding.UTF8.GetByteCount(jsonData);
                request.CookieContainer = cookie;
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.GetEncoding(encoding)))
                {

                    writer.Write(jsonData);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(encoding)))
                    {
                        result = reader.ReadToEnd();

                        reader.Close();
                    }
                    responseStream.Close();
                }
                response.Close();
                response = null;
                request = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("发送POST请求出现异常：" + ex.Message);
            }
            return result;
        }
    }
}
