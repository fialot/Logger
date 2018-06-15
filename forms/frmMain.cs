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
using System.Net.Sockets;
using System.Threading;
using System.Collections;

using TCPClient;
using myFunctions;
using COMunicator;
using BrightIdeasSoftware;

namespace Logger
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private Comm com;

        byte[] PrevData;
        byte[] comBuffer;

        // objectListView
        //List<logData> logList;              // log data list
        TextMatchFilter filterDesc;         // description filter
        TextMatchFilter filterLevel;        // level filter
        TextMatchFilter filterDevice;       // device filter
        ModelFilter filterHistory;          // history filter
        List<string> deviceList;            // device list

        #region Received data
        public delegate void MyDelegate(comStatus status);

        /// <summary>
        /// Data receive - invoke update
        /// </summary>
        /// <param name="source"></param>
        /// <param name="status"></param>
        private void DataReceive(object source, comStatus status)
        {
            lblPort.Invoke(new MyDelegate(updateLog), new Object[] { status }); //BeginInvoke
        }

        /// <summary>
        /// Update Log
        /// </summary>
        /// <param name="status">Communication status</param>
        public void updateLog(comStatus status)
        {
            // ----- IF CONNECTION CLOSE -----
            if (status == comStatus.Close)
            {
                if (com.OpenInterface == Comm.interfaces.TCPClient || com.OpenInterface == Comm.interfaces.None)
                    Disconnect();
                else if (com.OpenInterface == Comm.interfaces.TCPServer)
                {
                    lblStatus.Text = "Server: Client disconnected";
                    //Log.add("Client disconnected");

                }

            }
            // ----- IF RECEIVED DATA -----
            else if (status == comStatus.OK)
            {
                TimeOut.Enabled = false;    // enable TimeOut timer (wait 40ms for next message)
                TimeOut.Enabled = true;

                // ----- ADD NEW DATA TO BUFFER -----
                byte[] newBytes = com.Read();
                if (newBytes.Length > 0)
                {
                    PrevData = com.AddArray(PrevData, newBytes);
                    comBuffer = PrevData;
                }
            }
            // ----- IF CONNECTION OPENED -----
            else if (status == comStatus.Open)
            {
                if (com.OpenInterface == Comm.interfaces.TCPClient) 
                {
                    //NetConnected();
                }
                else if (com.OpenInterface == Comm.interfaces.TCPServer)
                {
                    lblStatus.Text = "Server: Client connected";
                    //Log.add("Client connected");
                }

            }
            // ----- IF OPEN ERROR -----
            else if (status == comStatus.OpenError)
            {
                Dialogs.ShowErr("Connection Timeout", "Error");
            }
        }

        /// <summary>
        /// TimeOut
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeOut_Tick(object sender, EventArgs e)
        {
            TimeOut.Enabled = false;
            string data = System.Text.Encoding.UTF8.GetString(comBuffer);// get data (UTF-8 encoding)
            PrevData = new byte[0];
            // ----- ADD NEW DATA TO LIST -----
            List<logData> list = AddLog(data, txtLogPath.Text, "unknown", "unknown", chbReceivedTime.Checked);
            ArrayList classList = new ArrayList();
            foreach (logData x in list) classList.Add(new LogItem(x));  // create class from list -> fastObjectListView
            olvLog.AddObjects(classList);                               // add data to fastObjectListView
            // ----- IF COUNT > 10000 -> REMOVE OLD ITEMS -----
            if (olvLog.Items.Count > 10000)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    olvLog.RemoveObject(olvLog.GetItem(0).RowObject);   // delete old logs
                }
            }
            // ----- REFRESH STATUS -----
            RefreshStatus();                                            // refresh status
        }

        #endregion

        #region Functions

        private void Connect()
        {
            com = new Comm(System.Text.Encoding.Default);
            com.ConnectUdp(Conv.ToInt32Def(txtPort.Text, 17000));
            com.ReceivedData += new ReceivedEventHandler(DataReceive);
            lblStatus.Text = "Listening";
            btnListen.Text = "Close";
            statLED.Image = Logger.Properties.Resources.circ_green24;
            RefreshStatus();
        }

        private void Disconnect()
        {
            com.Close();
            com = null;
            lblStatus.Text = "Closed";
            btnListen.Text = "Listen";
            statLED.Image = Logger.Properties.Resources.circ_red24;
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            statCount.Text = " (" + olvLog.GetItemCount() + " logs)";
            if (com != null && com.IsOpen())
                notifyIcon1.Text = "Logger - Listening (" + olvLog.GetItemCount() + " logs)";
            else
                notifyIcon1.Text = "Logger - Stop (" + olvLog.GetItemCount() + " logs)";
        }

        /// <summary>
        /// Convert Log item to string
        /// </summary>
        /// <param name="item">Log Item</param>
        /// <param name="useRecTime">Using received data</param>
        /// <returns></returns>
        private string logItemToString(logData item, bool useRecTime = false)
        {
            if (useRecTime)
                return item.recDate.ToString("yyyy-MM-dd HH:mm:ss") + " " + item.level + "  " + item.description;
            else
                return item.date.ToString("yyyy-MM-dd HH:mm:ss") + " " + item.level + "  " + item.description;
        }

        /// <summary>
        /// Add log to list
        /// </summary>
        /// <param name="text">Text to parse</param>
        /// <param name="dataPath">Path to log files</param>
        /// <param name="defName">Default device</param>
        /// <param name="useRecTime">Using received time</param>
        /// <param name="list">Add new items to list</param>
        /// <returns></returns>
        private List<logData> AddLog(string text, string dataPath = "", string defName = "", string defProcess = "", bool useRecTime = false, List<logData> list = null)
        {
            logData item = new logData();
            item.name = defName;
            item.process = defProcess;
            item.level = 'U';
            item.description = "";
            item.date = DateTime.Now;

            string name = defName;
            string process = defProcess;
            bool isFilled = false;

            if (list == null) list = new List<logData>();
            if (deviceList == null) deviceList = new List<string>();
            text = text.Trim();

            // ----- PARSE TO LINES -----
            string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                // ----- CHECK IS DATE ON BEGIN -----
                bool isDate = false;
                if (lines[i].Length > 20)
                {
                    string datTest = lines[i].Substring(0, 19);
                    DateTime logDate;
                    isDate = DateTime.TryParseExact(datTest, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None,out logDate);
                }


                // ----- CHECK DEVICE NAME -----
                int pos = lines[i].IndexOf(';');
                if (pos >= 0 && !isDate)
                {
                    name = lines[i].Substring(0, pos);
                    process = lines[i].Substring(0, pos);
                    lines[i] = lines[i].Remove(0, pos + 1);
                    pos = name.IndexOf('/');
                    if (pos >= 0)
                    {
                        process = name.Substring(pos + 1, name.Length - (pos+1));
                        name = name.Remove(pos, name.Length - pos);
                        if (name.Length == 0)
                            name = defName;
                    }

                }
                else name = defName;



                if (lines[i].Length > 22)
                {
                    try
                    {
                        // ----- CHECK LOG DATE & LOG LEVEL-----
                        string dat = lines[i].Substring(0, 19);
                        if (Conv.IsInt(dat.Substring(0, 4)) && Conv.IsInt(dat.Substring(5, 2)) && Conv.IsInt(dat.Substring(8, 2))
                            && Conv.IsInt(dat.Substring(11, 2)) && Conv.IsInt(dat.Substring(14, 2)) && Conv.IsInt(dat.Substring(17, 2))
                            && (dat.Substring(4, 1) == "-") && (dat.Substring(13, 1) == ":") &&
                            (lines[i].Substring(20, 1)[0] == 'E' ||
                            lines[i].Substring(20, 1)[0] == 'W' ||
                            lines[i].Substring(20, 1)[0] == 'I' ||
                            lines[i].Substring(20, 1)[0] == 'D' ||
                            lines[i].Substring(20, 1)[0] == 'X' ||
                            lines[i].Substring(20, 1)[0] == 'U'))
                        {
                            // ----- IF CORRECT -----
                            DateTime logDate = DateTime.ParseExact(dat, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                            if (!deviceList.Contains(name))
                            {
                                deviceList.Add(name);
                                string cbText = cbDevice.Text;
                                cbDevice.Items.Clear();
                                cbDevice.Items.Add("all");
                                for (int j = 0; j < deviceList.Count; j++)
                                {
                                    cbDevice.Items.Add(deviceList[j]);
                                }
                                cbDevice.Text = cbText;
                            }

                            // ----- IF DATA TO ADD -> ADD -----
                            if (isFilled)
                            {
                                list.Add(item);
                                isFilled = false;
                                if (dataPath != "")
                                {
                                    // ----- SAVE LOG TO FILE -----
                                    string dir = dataPath + System.IO.Path.DirectorySeparatorChar + item.name;
                                    System.IO.Directory.CreateDirectory(dir);
                                    string file = dir + System.IO.Path.DirectorySeparatorChar + item.process + "_" + DateTime.Now.ToString("yyMMdd") + ".log";
                                    if (!System.IO.File.Exists(file)) Files.SaveFile(file, "-----------------------\n   " + item.name + "   " + DateTime.Now.ToString("yyyy-MM-dd") + "\n-----------------------");
                                    Files.SaveFile(file, Environment.NewLine + logItemToString(item, useRecTime), true);
                                }
                                item.description = "";
                            }

                            // ----- FILL DATA -----
                            item.name = name;
                            item.process = process;
                            item.date = logDate;
                            if (dataPath != "") item.recDate = DateTime.Now;
                            else item.recDate = logDate;
                            item.level = lines[i].Substring(20, 1)[0];
                            item.description = lines[i].Remove(0, 22);
                            item.description = item.description.Trim();
                            isFilled = true;

                        }
                        else
                        {
                            // ----- FILL LINE TO PREVIOUS ITEM -----
                            item.description += Environment.NewLine;
                            if (name != defName) item.description += name + ";";
                            item.description += lines[i];
                        }


                    }
                    catch (Exception err)
                    {
                        // ----- FILL LINE TO PREVIOUS ITEM -----
                        item.description += Environment.NewLine;
                        if (name != defName) item.description += name + ";";
                        item.description += lines[i];
                    }


                }
                else
                {
                    // ----- FILL LINE TO PREVIOUS ITEM -----
                    item.description += Environment.NewLine;
                    if (name != defName) item.description += name + ";";
                    item.description += lines[i];
                }
            }

            // ----- IF DATA TO ADD -> ADD -----
            if (isFilled)
            {
                list.Add(item);
                if (dataPath != "")
                {
                    // ----- SAVE LOG TO FILE -----
                    string dir = dataPath + System.IO.Path.DirectorySeparatorChar + item.name;
                    System.IO.Directory.CreateDirectory(dir);
                    string file = dir + System.IO.Path.DirectorySeparatorChar + item.process + "_" + DateTime.Now.ToString("yyMMdd") + ".log";
                    if (!System.IO.File.Exists(file)) Files.SaveFile(file, "-----------------------\n   " + item.name + "   " + DateTime.Now.ToString("yyyy-MM-dd") + "\n-----------------------");
                    Files.SaveFile(file, Environment.NewLine + logItemToString(item, useRecTime), true);
                }
            }
            else if (item.description.Length > 1)
            {   
                // ----- IF ALONE DATA -> SAVE AS UNKNOWN -----
                item.date = DateTime.Now;
                item.level = 'U';
                if (item.description[0] == '\r') item.description = item.description.Remove(0, 1);
                if (item.description[0] == '\n') item.description = item.description.Remove(0, 1);
                list.Add(item);
                if (dataPath != "")
                {
                    // ----- SAVE LOG TO FILE -----
                    string dir = dataPath + System.IO.Path.DirectorySeparatorChar + item.name;
                    System.IO.Directory.CreateDirectory(dir);
                    string file = dir + System.IO.Path.DirectorySeparatorChar + item.process + "_" + DateTime.Now.ToString("yyMMdd") + ".log";
                    if (!System.IO.File.Exists(file)) Files.SaveFile(file, "-----------------------\n   " + item.name + "   " + DateTime.Now.ToString("yyyy-MM-dd") + "\n-----------------------");
                    Files.SaveFile(file, Environment.NewLine + logItemToString(item, useRecTime), true);
                }
            }

            return list;
        }

        /// <summary>
        /// Read log folder with filter
        /// </summary>
        /// <param name="path">Log folder</param>
        /// <param name="filter">Filter</param>
        /// <returns></returns>
        private List<logData> ReadFolder(string path, logLoadFilter filter)
        {
            List<logData> list = new List<logData>();

            if (path != "")
            {
                // ----- READ LOG DIRECTORIES -----
                string[] dirList = Directory.GetDirectories(path);
                for (int i = 0; i < dirList.Length; i++)
                {
                    string name = Path.GetFileName(dirList[i]);
                    List<string> devList = filter.deviceList.ToList();
                    // ----- USE DEVICE FILTER -----
                    if (devList.Contains(name))
                    {
                        string[] fileList = Directory.GetFiles(dirList[i]);
                        for (int j = 0; j < fileList.Length; j++)
                        {
                            string x = Path.GetExtension(fileList[j]);
                            // ----- USE EXTENSION FILTER -----
                            if (Path.GetExtension(fileList[j]) == ".log")
                            {
                                // ----- USE DATE FILTER -----
                                string fileName = Path.GetFileNameWithoutExtension(fileList[j]);
                                try
                                {
                                    int year, month, day;
                                    year = int.Parse(fileName.Substring(fileName.Length - 6, 2)) + 2000;
                                    month = int.Parse(fileName.Substring(fileName.Length - 4, 2));
                                    day = int.Parse(fileName.Substring(fileName.Length - 2, 2));
                                    DateTime fileDate = new DateTime(year, month, day);
                                    string process = "";
                                    int pos = fileName.IndexOf('_');
                                    if (pos >= 0)
                                    {
                                        process = fileName.Substring(0, pos);
                                    }

                                    bool add = false;
                                    if (filter.useFrom && filter.useTo)
                                    {
                                        if (fileDate >= filter.fromTime && fileDate <= filter.toTime)
                                        {
                                            add = true;
                                        }
                                    }
                                    else if (filter.useFrom)
                                    {
                                        if (fileDate >= filter.fromTime)
                                        {
                                            add = true;
                                        }
                                    }
                                    else if (filter.useTo)
                                    {
                                        if (fileDate <= filter.toTime)
                                        {
                                            add = true;
                                        }
                                    }
                                    else
                                    {
                                        add = true;
                                    }

                                    if (add == true)
                                    {
                                        // ----- ADD FILE TO LOG LIST -----
                                        string text = Files.LoadFile(fileList[j], Encoding.UTF8);
                                        list = AddLog(text, "", name, process, false, list);
                                    }

                                }
                                catch (Exception)
                                {

                                }
                            }
                        }
                    }
                }
            }


            return list;
        }

        #endregion


        #region ObjectListView

        /// <summary>
        /// Initialize ObjectListView
        /// </summary>
        private void InitOLV()
        {
            List<LogItem> list = new List<LogItem>();
            olvLog.SetObjects(list);
        }

        private void olvLog_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            if (e.Item.RowObject != null)
            {
                if (((LogItem)(e.Item.RowObject)).Level == 'E')
                    e.Item.ForeColor = Color.Red;
                else if (((LogItem)(e.Item.RowObject)).Level == 'W')
                    e.Item.ForeColor = Color.Orange;
                else if (((LogItem)(e.Item.RowObject)).Level == 'I')
                    e.Item.ForeColor = Color.Green;
                else if (((LogItem)(e.Item.RowObject)).Level == 'D')
                    e.Item.ForeColor = Color.Brown;
                else if (((LogItem)(e.Item.RowObject)).Level == 'X')
                    e.Item.ForeColor = Color.Black;
                else
                    e.Item.ForeColor = Color.Gray;
            }
        }

        private void olvLog_DoubleClick(object sender, EventArgs e)
        {
            if (olvLog.SelectedIndex >= 0)
            {
                frmText frm = new frmText();
                frm.ShowDialog(((LogItem)olvLog.SelectedItem.RowObject).ToStruct());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            olvLog.ClearObjects();
            RefreshStatus();
        }


        #region Filter

        // ----- DESCRIPTION FILTER -----

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            filterDesc = TextMatchFilter.Contains(olvLog, txtFilter.Text);
            filterDesc.Columns = new OLVColumn[] { olvLogDesc };

            olvLog.UseFiltering = true;
            olvLog.ModelFilter = new CompositeAllFilter(new List<IModelFilter> { filterDesc, filterLevel, filterDevice, filterHistory });
        }

        // ----- LEVEL FILTER -----

        private void chError_CheckedChanged(object sender, EventArgs e)
        {
            List<string> filterList = new List<string>();

            if (chError.Checked)
            {
                filterList.Add("E");
            }
            if (chbWarning.Checked)
            {
                filterList.Add("W");
            }
            if (chbInfo.Checked)
            {
                filterList.Add("I");
            }
            if (chbDebug.Checked)
            {
                filterList.Add("D");
            }
            if (chbExtended.Checked)
            {
                filterList.Add("X");
            }
            if (chbUnknown.Checked)
            {
                filterList.Add("U");
            }
            if (filterList.Count == 0) filterLevel = TextMatchFilter.Contains(olvLog, " ");
            else
            {
                string[] filterArray = filterList.ToArray();
                filterLevel = TextMatchFilter.Prefix(olvLog, filterArray);
            }
            filterLevel.Columns = new OLVColumn[] { olvLogLevel };

            olvLog.UseFiltering = true;
            olvLog.ModelFilter = new CompositeAllFilter(new List<IModelFilter> { filterDesc, filterLevel, filterDevice, filterHistory });

        }

        // ----- DEVICE FILTER -----

        private void cbDevice_TextChanged(object sender, EventArgs e)
        {
            if (cbDevice.Text == "all")
                filterDevice = TextMatchFilter.Contains(olvLog, "");
            else
                filterDevice = TextMatchFilter.Contains(olvLog, cbDevice.Text);
            filterDevice.Columns = new OLVColumn[] { olvLogName };

            olvLog.UseFiltering = true;
            olvLog.ModelFilter = new CompositeAllFilter(new List<IModelFilter> { filterDesc, filterLevel, filterDevice, filterHistory });
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            HistoryFilter();
        }

        public void HistoryFilter()
        {
            if (chbFrom.Checked && chbTo.Checked)
            {
                filterHistory = new ModelFilter(delegate(object x) { return (((LogItem)x).Date > dtFrom.Value && ((LogItem)x).Date < dtTo.Value); });
            }
            else if (chbFrom.Checked)
            {
                filterHistory = new ModelFilter(delegate(object x) { return ((LogItem)x).Date > dtFrom.Value; });
            }
            else if (chbTo.Checked)
            {
                filterHistory = new ModelFilter(delegate(object x) { return ((LogItem)x).Date < dtTo.Value; });
            }
            else
            {
                filterHistory = new ModelFilter(delegate(object x) { return true; });
            }

            olvLog.UseFiltering = true;
            olvLog.ModelFilter = new CompositeAllFilter(new List<IModelFilter> { filterDesc, filterLevel, filterDevice, filterHistory });
        }

        #endregion

        #endregion


        private void frmMain_Load(object sender, EventArgs e)
        {
            cbDevice.Items.Clear();
            cbDevice.Items.Add("all");
            cbDevice.SelectedIndex = 0;
            dtFrom.Value = DateTime.Now.AddDays(-7);
            //logList = new List<logData>();
            InitOLV();
            chbReceivedTime_CheckedChanged(sender, e);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(500);
                this.Hide();
                //this
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                if (com == null || !com.IsOpen())
                    Connect();
                else
                    Disconnect();
                    
            }
            catch (Exception err)
            {
                Dialogs.ShowErr(err.Message, "Error");
            }

        }
        
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            frmLoadHistory frm = new frmLoadHistory();
            logLoadFilter filter = frm.ShowDialog(txtLogPath.Text);     // filter dialog
            if (filter.res == System.Windows.Forms.DialogResult.OK)
            {
                olvLog.ClearObjects();                                  // clear logs
                List<logData> list = ReadFolder(txtLogPath.Text, filter);// read logs from dir
                ArrayList classList = new ArrayList();
                foreach (logData x in list) classList.Add(new LogItem(x));  // create class from list -> fastListView
                olvLog.AddObjects(classList);                           // add logs to fastListView
                RefreshStatus();                                        // refresh status bar
            }
        }

        private void imgInfo_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();               // Show About dialog
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();             // exit app
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtLogPath.Text = fbd.SelectedPath;
            }
        }

        private void chbReceivedTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chbReceivedTime.Checked) olvLogDate.AspectName = "ReceivedDate";
            else olvLogDate.AspectName = "Date";
            ArrayList classList = new ArrayList();
            olvLog.AddObjects(classList);
        }
        
    }
}


