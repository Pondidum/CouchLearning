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

		private static IActionLog Log = LogManager.GetLogger();

		public Form1()
		{
			InitializeComponent();
		}

		private void btnWrite_Click(object sender, EventArgs e)
		{
			Log.Store("btnWrite");
		}
	}
}
