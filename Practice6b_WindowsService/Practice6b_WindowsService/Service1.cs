using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Practice6b_WindowsService
{
    public partial class Service1 : ServiceBase
    {
        Timer timerLog = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteLog("Service start at " + DateTime.Now);
            timerLog.Elapsed += new ElapsedEventHandler(TimeInterval);
            timerLog.Interval = 10000;
            timerLog.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteLog("Service stop at " + DateTime.Now);

        }

        private void WriteLog(string mesenger)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";

            if (!System.IO.File.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string file = path + DateTime.Now.ToString("dd-mm-yyyy") + ".txt";

            if (!System.IO.File.Exists(file))
            {
                using (StreamWriter streamWriter = File.CreateText(file))
                {
                    streamWriter.WriteLine(mesenger);
                }
            }
            else
            {
                using (StreamWriter streamWriter = File.AppendText(file))
                {
                    streamWriter.WriteLine(mesenger);
                }
            }
        }

        private void TimeInterval(object sould, System.Timers.ElapsedEventArgs e)
        {
            WriteLog("Service is recall at " + DateTime.Now);

        }
    }
}
