using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraControllerApp.Common
{
    public class OpenBrowserHelper
    {
        /// <summary>
        /// 调用谷歌（Chrome）浏览器
        /// </summary>
        /// <param name="url">打开网页的链接</param>
        public static bool OpenChromeBrowserUrl(string url)
        {
            bool isOpen = true;
            try
            {
                // 谷歌浏览器就用谷歌打开，没找到就用系统默认的浏览器
                // 谷歌卸载了，注册表还没有清空，程序会返回一个"系统找不到指定的文件。"的bug
                var chromeKey = @"\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";
                // 通过注册表找到谷歌浏览器安装路径
                string chromeAppFileName = (string)(Registry.GetValue("HKEY_LOCAL_MACHINE" + chromeKey, "", null) ?? Registry.GetValue("HKEY_CURRENT_USER" + chromeKey, "", null));
                // 找到谷歌浏览器则打开
                if (!string.IsNullOrWhiteSpace(chromeAppFileName))
                {
                    Process.Start(chromeAppFileName, url);
                }
                else
                {
                    isOpen = false;
                    //默认浏览器打开
                    //OpenDefaultBrowserUrl(url);
                }
            }
            catch
            {
                isOpen = false;
            }

            return isOpen;
        }

        /// <summary>
        /// 调用IE浏览器
        /// </summary>
        /// <param name="url"></param>
        public static void OpenIe(string url)
        {
            // IE浏览器路径安装：C:\Program Files\Internet Explorer
            // at System.Diagnostics.process.StartWithshellExecuteEx(ProcessStartInfo startInfo)注意这个错误
            try
            {
                if (File.Exists(@"C:\Program Files\Internet Explorer\iexplore.exe"))
                {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo
                    {
                        FileName = @"C:\Program Files\Internet Explorer\iexplore.exe",
                        Arguments = url,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    Process.Start(processStartInfo);
                }
                else
                {
                    if (File.Exists(@"C:\Program Files (x86)\Internet Explorer\iexplore.exe"))
                    {
                        ProcessStartInfo processStartInfo = new ProcessStartInfo
                        {
                            FileName = @"C:\Program Files (x86)\Internet Explorer\iexplore.exe",
                            Arguments = url,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };
                        Process.Start(processStartInfo);
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }

        /// <summary>
        /// 调用系统默认浏览器（用户自己设置了默认浏览器）
        /// </summary>
        /// <param name="url"></param>
        public static bool OpenDefaultBrowserUrl(string url)
        {
            bool isOpen = true;
            try
            {
                //从注册表中读取默认浏览器可执行文件路径
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
                if (key != null)
                {
                    string browserPath = string.Empty;
                    string[] splitArr = new string[] { };
                    string browser = key.GetValue("").ToString();

                    //browser是默认浏览器，不同的浏览器后面的参数不一样。例如："D:\Program Files (x86)\Google\chrome.exe" -- "%1"
                    var lastIndex = browser.IndexOf(".exe", StringComparison.Ordinal);
                    if (lastIndex == -1)
                        lastIndex = browser.IndexOf(".EXE", StringComparison.Ordinal);

                    if (lastIndex != -1)
                    {
                        char[]  V = "\"".ToCharArray();
                        splitArr = browser.Split(V);
                    }
                    //大于0 说明 按照 " 切割到数据
                    if (splitArr.Length > 0)
                    {
                        browserPath = splitArr[1];
                    }
                    else if (splitArr.Length == 0 && lastIndex != -1) //说明有浏览器，列如：D:\QQBrowser\QQBrowser.exe
                    {
                        browserPath = browser;
                    }
                    //打开浏览器
                    var result = Process.Start(browserPath, url);

                    //调用IE
                    //if (result == null)
                    //    OpenIe(url);
                }
                else
                {
                    isOpen = false;
                    //OpenIe(url);
                }

            }
            catch
            {
                isOpen = false;
            }
            return isOpen;
        }
    }
}
