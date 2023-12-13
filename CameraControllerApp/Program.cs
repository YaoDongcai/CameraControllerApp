using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraControllerApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        //全局异常捕获
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogExceptionInfo(e.Exception, "Application_ThreadException");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception)e.ExceptionObject;
            LogExceptionInfo(exception, "CurrentDomain_UnhandledException");

        }
        private static void LogExceptionInfo(Exception exception, string typeName = "Undefined Exception")
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("***************************");
            stringBuilder.AppendLine("--------- Begin  ---------");
            stringBuilder.AppendLine("--------------------------");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff"));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("--------------------------");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(typeName);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("[0].TargetSite");
            stringBuilder.AppendLine(exception.TargetSite.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("[1].StackTrace");
            stringBuilder.AppendLine(exception.StackTrace);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("[2].Source");
            stringBuilder.AppendLine(exception.Source);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("[3].Message");
            stringBuilder.AppendLine(exception.Message);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("[4].HResult");
            stringBuilder.AppendLine();
            if (exception.InnerException != null)
            {
                stringBuilder.AppendLine("--------------");
                stringBuilder.AppendLine("InnerException");
                stringBuilder.AppendLine("--------------");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("[5.0].TargetSite");
                stringBuilder.AppendLine(exception.InnerException.TargetSite.ToString());
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("[5.1].StackTrace");
                stringBuilder.AppendLine(exception.InnerException.StackTrace);
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("[5.2].Source");
                stringBuilder.AppendLine(exception.InnerException.Source);
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("[5.3].Message");
                stringBuilder.AppendLine(exception.InnerException.Message);
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("[5.4].Result");
                stringBuilder.AppendLine();
            }
            stringBuilder.AppendLine("--------- End  ---------");
            stringBuilder.AppendLine();
            string sFilePath = string.Format("{0}crashlog.txt", AppDomain.CurrentDomain.BaseDirectory);
            FileHelper.WriteFile(sFilePath, stringBuilder.ToString());
        }
    }
}
