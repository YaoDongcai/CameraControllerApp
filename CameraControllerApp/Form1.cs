using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraControllerApp
{
    public partial class Form1 : Form
    {
        private CameraManager Camera;
        public Form1()
        {
            InitializeComponent();
            Camera = new CameraManager();
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            Camera.SendStatus("on");
        }
    }
}
