using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;


namespace Logger
{

    public struct logData
    {
        public string name;
        public string process;
        public DateTime date;
        public DateTime recDate;
        public char level;
        public string description;
    }

    /// <summary>
    /// Log Item class for FastListView
    /// </summary>
    public class LogItem : INotifyPropertyChanged
    {
        private string name;            // device name
        private string process;         // process name
        private DateTime date;          // log date
        private DateTime recDate;       // received date
        private char level;             // log level
        private string description;     // description

        public LogItem(string name, string process, DateTime date, char level, string description)
        {
            this.name = name;
            this.process = process;
            this.date = date;
            this.recDate = date;
            this.level = level;
            this.description = description;
        }

        public LogItem(logData other)
        {
            this.name = other.name;
            this.process = other.process;
            this.date = other.date;
            this.recDate = other.recDate;
            this.level = other.level;
            this.description = other.description;
        }

        public LogItem(LogItem other)
        {
            this.name = other.Name;
            this.process = other.Process;
            this.date = other.Date;
            this.recDate = other.ReceivedDate;
            this.level = other.Level;
            this.description = other.Description;
        }

        public logData ToStruct()
        {
            logData item = new logData();
            item.name = this.name;
            item.date = this.date;
            item.level = this.level;
            item.description = this.description;
            return item;
        }

        public string Name
        {
            get { return name; }
            set
            {
                //if (name == value) return;
                name = value;
                //this.OnPropertyChanged("Name");
            }
        }

        public string Process
        {
            get { return process; }
            set
            {
                //if (name == value) return;
                process = value;
                //this.OnPropertyChanged("Name");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public DateTime ReceivedDate
        {
            get { return recDate; }
            set { recDate = value; }
        }

        public char Level
        {
            get { return level; }
            set { level = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /*[OLVColumn(ImageAspectName = "ImageName")]
        public string Occupation
        {
            get { return occupation; }
            set
            {
                if (occupation == value) return;
                occupation = value;
                this.OnPropertyChanged("Occupation");
            }
        }
        private string occupation;*/

       


        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    class global
    {

    }
}
