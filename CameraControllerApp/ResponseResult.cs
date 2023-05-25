using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraControllerApp
{
    public class Data
    {
        public string workType;
        public int isSetTime;
        public string unit;
        public int defineTime ;
    }
    class ResponseResult
    {
        // 数据状态码
        public int status { get; set; }
        public Data data { get; set; }

    } 
}
