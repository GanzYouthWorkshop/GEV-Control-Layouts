using GEV.Layouts;
using GEV.Layouts.Extended.MiniCAD.Components;
using GEV.Layouts.Extended.MiniCAD.Implementation;
using GEV.Layouts.Extended.MiniCAD.Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApplication3.MiniCadComponent;

namespace WindowsFormsApplication3
{
    public partial class Form1 : GCLForm
    {
        System.Windows.Forms.Timer t;
        public Form1()
        {
            InitializeComponent();

            t = new System.Windows.Forms.Timer();
            t.Interval = 100;
            t.Tick += T_Tick;
            t.Enabled = true;


            this.gclPieChart1.ChartColors.AddRange(new Color[] { GCLColors.SuccessGreen, GCLColors.ErrorRed });
            this.gclPieChart1.Values.AddRange(new double[] { 170000, 6500 });

            this.Controls.Add(new ComboBox());
            //this.gclComboBox1.DataSource = new string[]
            //{
            //    "1",
            //    "2",
            //    "3",
            //    "4"
            //};

            this.gclPropertyGrid1.DataSource = this;// new TestDataStructure();

            this.miniCADEditor1.Document = new Document();
            ComponentLayer layer = new ComponentLayer();
            GridLayer grid = new GridLayer() { GridSize = 5, GridColor = Color.FromArgb(80, 80, 80), ZeroColor = Color.FromArgb(120, 120, 120) };

            this.miniCADEditor1.Document.Layers.Add(grid);
            this.miniCADEditor1.Document.Layers.Add(layer);
            layer.Components.Add(new RectangleComponent());
            layer.Components.Add(new FunctionalBox());
            layer.Components.Add(new Line() { Start = new PointF(5, 5), End = new PointF(20, 20) });

            List<TestDataStructure> test = new List<TestDataStructure>()
            {
                new TestDataStructure(),
                new TestDataStructure(),
                new TestDataStructure(),
            };

            this.dataGridView1.DataSource = test;
        }

        private void T2_Tick()
        {

            EnumerationOptions options = new EnumerationOptions();
            options.ReturnImmediately = false;

            var ramQuery = new ManagementObjectSearcher("select FreePhysicalMemory, TotalVisibleMemorySize from Win32_OperatingSystem");
            ramQuery.Options = options;

            var cpuQuery = new ManagementObjectSearcher("select LoadPercentage from Win32_Processor");
            cpuQuery.Options = options;

            var netQueryTemp1 = new ManagementObjectSearcher("select NetConnectionID, Speed, MACAddress from Win32_NetworkAdapter");
            var netQueryTemp2 = new ManagementObjectSearcher("select IPAddress, MACAddress from Win32_NetworkAdapterConfiguration ");
            netQueryTemp1.Options = options;
            netQueryTemp2.Options = options;
            string mac = "";
            ulong netMax = 0;
            foreach (var item in netQueryTemp2.Get())
            {
                var address = (item["IPAddress"] as string[]);
                if(address != null && address.Contains("192.168.10.103"))
                {
                    mac = item["MACAddress"].ToString();
                    break;
                }
            }
            if(mac != "")
            {
                foreach (var item in netQueryTemp1.Get())
                {
                    string nicMAC = Convert.ToString(item["MACAddress"]);

                    if (nicMAC == mac)
                    {
                        netMax = Convert.ToUInt64(item["Speed"]);
                        break;
                    }
                }
            }
            PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
            var instances = performanceCounterCategory.GetInstanceNames();
            PerformanceCounter netQuery = new PerformanceCounter("Network Interface", "Bytes Received/sec", instances[1]);

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

                double cpu = 0;
                foreach (var item in cpuQuery.Get())
                {
                    cpu = Convert.ToDouble(item["LoadPercentage"]);
                    break;
                }

                float netCurrent = netQuery.NextValue();

                this.gclLineMonitor1.Value = (int)(cpu) % 100;
                this.gclLineMonitor2.Value = 100 - (int)(((float)free / (float)total) * 100);
                this.gclLineMonitor3.Value = (int)((netCurrent * 8 / (float)netMax) * 100);


                this.Invoke(new Action(() => this.label6.Text = DateTime.Now.ToString("HH:mm")));

                this.gclMiniDataLog1.AddValue(this.gclLineMonitor1.Value);


                Thread.Sleep(500);
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            this.gclGauge4.Value = (this.gclGauge4.Value + 1) % 100;
        }

        private void testHtmlControl2_Load(object sender, EventArgs e)
        {

        }

        private void gclButton1_Click(object sender, EventArgs e)
        {
            this.panel2.BackColor = GCLColors.SuccessGreen;
            this.gclIconSpinner2.Text = "";
            this.gclIconSpinner2.AnimationEnabled = true;
            this.label3.Text = "Automata üzem";

            new Thread(new ThreadStart(T2_Tick)) { IsBackground = true }.Start();
        }

        private void gclButton2_Click(object sender, EventArgs e)
        {
            Control topParent = this;
            int x = 0;
            int y = 0;

            while (topParent.Parent != null)
            {
                x += topParent.Left;
                y += topParent.Top;
                topParent = topParent.Parent;
            }

            GCLPanel p = new GCLPanel() { Width = 400, Height = 200 };
            p.Left = this.gclButton2.Left;
            p.Top = this.gclButton2.Top;
            topParent.Controls.Add(p);
            p.BringToFront();
        }
    }
}
