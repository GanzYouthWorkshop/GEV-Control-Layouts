using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Management;
using System.Diagnostics;

namespace GEV.Layouts
{
    public partial class GCLSystemResourcesMonitor : UserControl
    {
        public string NetworkConnectionIP { get; set; }

        public Color ProgressBarBackColor
        {
            get { return this.lmCPU.ProgressBarBackColor; }
            set
            {
                this.lmCPU.ProgressBarBackColor = value;
                this.lmNetwork.ProgressBarBackColor = value;
                this.lmRAM.ProgressBarBackColor = value;
            }
        }

        public GCLSystemResourcesMonitor()
        {
            InitializeComponent();

            this.ProgressBarBackColor = GCLColors.Shadow;
        }

        public void Start()
        {
            Thread t = new Thread(new ThreadStart(this.Runner));
            t.IsBackground = true;
            t.Priority = ThreadPriority.BelowNormal;
            t.Start();
        }

        private void Runner()
        {
            #region Közös opciók
            EnumerationOptions options = new EnumerationOptions();
            options.ReturnImmediately = false;
            #endregion

            #region RAM lekérdező
            var ramQuery = new ManagementObjectSearcher("select FreePhysicalMemory, TotalVisibleMemorySize from Win32_OperatingSystem");
            ramQuery.Options = options;
            #endregion

            #region CPU lekérdező
            var cpuQuery = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            #endregion

            #region Hálózat lekérdező
            var netQueryTemp1 = new ManagementObjectSearcher("select NetConnectionID, Name, Speed, MACAddress from Win32_NetworkAdapter");
            var netQueryTemp2 = new ManagementObjectSearcher("select IPAddress, MACAddress from Win32_NetworkAdapterConfiguration ");
            netQueryTemp1.Options = options;
            netQueryTemp2.Options = options;
            string mac = "";
            ulong netMax = 0;
            string serviceName = "";
            foreach (var item in netQueryTemp2.Get())
            {
                var address = (item["IPAddress"] as string[]);
                if (address != null && address.Contains(this.NetworkConnectionIP))
                {
                    mac = item["MACAddress"].ToString();
                    break;
                }
            }

            PerformanceCounter netQuery = null;
            if (mac != "")
            {
                foreach (var item in netQueryTemp1.Get())
                {
                    string nicMAC = Convert.ToString(item["MACAddress"]);

                    if (nicMAC == mac)
                    {
                        netMax = Convert.ToUInt64(item["Speed"]);
                        serviceName = item["Name"].ToString();
                        break;
                    }
                }
                PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
                var instances = performanceCounterCategory.GetInstanceNames();
                serviceName = serviceName.Replace('/', '_').Replace('#', '_').Replace('(', '[').Replace(')', ']');
                netQuery = new PerformanceCounter("Network Interface", "Bytes Received/sec", serviceName);

            }
            #endregion

            while (true)
            {
                ulong total = 0;
                ulong free = 0;
                foreach (var item in ramQuery.Get())
                {
                    free = Convert.ToUInt64(item["FreePhysicalMemory"]);
                    total = Convert.ToUInt64(item["TotalVisibleMemorySize"]);
                    break;
                }

                double cpu = cpuQuery.NextValue();

                float netCurrent = 0;
                if (netQuery != null)
                {
                    netCurrent = netQuery.NextValue();
                }

                this.lmCPU.Value = (int)(cpu) % 100;
                this.lmRAM.Value = 100 - (int)(((float)free / (float)total) * 100);
                this.lmNetwork.Value = (int)((netCurrent * 8 / (float)netMax) * 100);

                Thread.Sleep(500);
            }
        }
    }
}
