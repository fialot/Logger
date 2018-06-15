using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger
{
    public partial class frmText : Form
    {
        public frmText()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string text)
        {
            lblTime.Text = "";
            lblLevel.Text = "";
            txtDescription.Text = text;
            return base.ShowDialog();
        }

        public DialogResult ShowDialog(logData item)
        {
            // ----- FILL COMPONENTS -----
            lblDevice.Text = item.name;
            lblTime.Text = item.date.ToString("yyyy-MM-dd HH:mm:ss");
            switch (item.level)
            {
                case 'E':
                     lblLevel.Text = "Error";
                     lblLevel.ForeColor = Color.Red;
                    break;
                case 'W':
                    lblLevel.Text = "Warning";
                    lblLevel.ForeColor = Color.Orange;
                    break;
                case 'I':
                    lblLevel.Text = "Info";
                    lblLevel.ForeColor = Color.Green;
                    break;
                case 'D':
                    lblLevel.Text = "Debug";
                    lblLevel.ForeColor = Color.Brown;
                    break;
                case 'X':
                    lblLevel.Text = "eXtended";
                    lblLevel.ForeColor = Color.Black;
                    break;
                default:
                    lblLevel.Text = "Unknown";
                    lblLevel.ForeColor = Color.Gray;
                    break;
            }
            txtDescription.Text = item.description;
            return base.ShowDialog();
        }
    }
}
