using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using myFunctions;

namespace Logger
{
    public struct logLoadFilter
    {
        public DateTime fromTime;       // load from
        public DateTime toTime;         // load to
        public bool useFrom;            // used From
        public bool useTo;              // used To
        public string[] deviceList;     // selected device list
        public DialogResult res;        // dialog result (Ok/Cancel)
    }

    public partial class frmLoadHistory : Form
    {
        public frmLoadHistory()
        {
            InitializeComponent();
        }

        public logLoadFilter ShowDialog(string path)
        {
            logLoadFilter filter = new logLoadFilter();     // filter
            List<string> devList = new List<string>();      // device list

            // ----- IF EXIST LOG DIRECTORY -----
            if (Directory.Exists(path))
            {
                // ----- GET DIR LIST -----
                string[] dirList = Directory.GetDirectories(path);
                for (int i = 0; i < dirList.Length; i++)
                {
                    // ----- SEPARATE DEVICE NAME -----
                    string name = Path.GetFileName(dirList[i]);
                    lvDevices.Items.Add(name);      // add device to deviceListView
                }

                // ----- FILL FILTER -----
                filter.res = base.ShowDialog();         // <- ShowDialog result
                filter.useFrom = chbFrom.Checked;
                filter.useTo= chbTo.Checked;
                filter.fromTime = dtFrom.Value.Date;
                filter.toTime = dtTo.Value.Date;
                for (int j = 0; j < lvDevices.Items.Count; j++) // get selected devices
                {
                    if (lvDevices.Items[j].Checked)
                        devList.Add(lvDevices.Items[j].Text);
                }
                filter.deviceList = devList.ToArray(); // <- selected devices list
            } 
            else
            {
                // ----- IF NOT EXIST LOG DIRECTORY -----
                Dialogs.ShowErr("Path not exist!", "Error");
                filter.res = System.Windows.Forms.DialogResult.Cancel;
            }
            return filter;
        }

        private void frmLoadHistory_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.AddDays(-7);    // load interval - last 7 days
        }

        #region Select devices

        private void btnAll_Click(object sender, EventArgs e)
        {
            // ----- SELECT ALL DEVICES -----
            for (int j = 0; j < lvDevices.Items.Count; j++)
            {
                lvDevices.Items[j].Checked = true;
            }
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            // ----- SELECT NONE DEVICES -----
            for (int j = 0; j < lvDevices.Items.Count; j++)
            {
                lvDevices.Items[j].Checked = false;
            }
        }

        #endregion

    }
}
