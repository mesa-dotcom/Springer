using Springer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Net.NetworkInformation;

namespace Springer
{
    public partial class ResultFormWatching : Form
    {
        List<Device> dataAll = new List<Device>();
        List<string> devices = new List<string>() { "GW", "SC", "Printer", "GOT" , "POS", "AP", "PDA", "CCTV", "EDC", "UPS" };
        private System.Timers.Timer timer;
        public ResultFormWatching(List<Device> ds)
        {
            dataAll = ds;
            InitializeComponent();
            lblMain.Text = "Pinging the store " + ds[0].StoreId.ToString() +  "...";
            createForm();

            timer = new System.Timers.Timer();
            timer.Interval = 6000;
            timer.Enabled = true;
            timer.Elapsed += timerElapsed;
        }

        public void timerElapsed(object sender, ElapsedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        public void createForm()
        {
            var rr = -1;
            var rc = -1;
            var groupped_ds = dataAll.OrderBy(d => d.Name).GroupBy(d => d.Name).ToList();
            foreach (string device in devices)
            {
                if (groupped_ds.Exists(d => d.Key == device))
                {
                    rc += 1;
                    if (rc % 2 == 0)
                    {
                        rr += 1;
                    }
                    TableLayoutPanel tlpEach = new TableLayoutPanel
                    {
                        Name = "tlp" + device,
                        ColumnCount = 2,
                        RowCount = 1,
                        Dock = DockStyle.Fill,
                    };
                    tlpEach.ColumnStyles.Add(new ColumnStyle { Width = (float)0.2, SizeType = SizeType.Percent });
                    tlpEach.ColumnStyles.Add(new ColumnStyle { Width = (float)0.8, SizeType = SizeType.Percent });
                    tlpEach.Controls.Add(new Label
                    {
                        Name = "tlp_txt" + device, 
                        Text = device,
                        Padding = new Padding(0,10,0,0)
                    }, 0, 0);
                    FlowLayoutPanel flp = new FlowLayoutPanel { Dock = DockStyle.Fill};
                    foreach (var dig in groupped_ds.Find(k => k.Key == device))
                    {
                        PictureBox pb = new PictureBox
                        {
                            Name = "pb" + dig.Name + dig.No,
                            BackColor = Color.Red,
                            Width = 20,
                            Height = 20,
                            Padding = Padding.Empty,
                        };
                        flp.Controls.Add(pb);
                    }
                    tlpEach.Controls.Add(flp, 1, 0);
                    tlpMain.Controls.Add(tlpEach, rc % 2, rr);
                }
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);
            Parallel.ForEach(dataAll, d =>
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(d.IP);
                this.BeginInvoke((Action)delegate ()
                {
                    PictureBox pb = (PictureBox)tlpMain.Controls.Find("pb" + d.Name + d.No, true).FirstOrDefault();
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                   if ( pingReply.Status == IPStatus.Success)
                    {
                        pb.BackColor = Color.Green;
                    }else
                    {
                        pb.BackColor = Color.Red;
                    }
                });
            });
        }

    }
}
