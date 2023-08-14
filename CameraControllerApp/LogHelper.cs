using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace CameraControllerApp
{
    class LogHelper
    {
        public static readonly ILog loginfo = LogManager.GetLogger("loginfo"); 
        public static readonly ILog logerror = LogManager.GetLogger("logerror"); 
        public static void WriteInfoLog(string info) { if (loginfo.IsInfoEnabled) { loginfo.Info(info); } }
        public static void WriteLog(string info, Exception se) 
        { 
            if (logerror.IsErrorEnabled) 
            { logerror.Error(info, se);
            }
        }
    }
}
