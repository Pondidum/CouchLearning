using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActionLogger;

namespace UserApplication
{
    public partial class Form1 : Form
    {

        private static IActionLogger Log = LogManager.GetLogger();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, EventArgs e)
		{
			//Log.Store("btnWrite");
            var random = new Random();
            var now = DateTime.Now;

            for (int i = 0; i < 100; i++)
            {
                var mins = random.Next(0, 100);
                var data = new Dictionary<String, Object>();

                data["-created"] = now.AddMinutes(mins);
                data["count"] = i;
                data["mins"] = mins;

                Log.Store("btnWrite", data);
            }
		}
    }
}
