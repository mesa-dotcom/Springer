using Springer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Springer
{
    public partial class ResultForm : Form
    {
        Ping pinger = new Ping();
        List<KeyValuePair<string, List<Device>>> dataByStore = new List<KeyValuePair<string, List<Device>>>();
        List<Device> dataAll = new List<Device>();
        DataTable dt = new DataTable();
        int QualifiedSuccess = 2;
        public ResultForm(List<KeyValuePair<string, List<Device>>> d, List<Device> ds)
        {
            dataByStore = d;
            dataAll = ds;
            InitializeComponent();
            addColumnToDataTable();
        }

        private void addColumnToDataTable()
        {
            dt.Columns.Add("Store ID");
            dt.Columns.Add("Device");
            dt.Columns.Add("No");
            dt.Columns.Add("IP Address");
            dt.Columns.Add("Status");
            dgwResult.DataSource = dt;
        }
        private async void startPing()
        {
            pgbResult.Maximum = dataAll.Count;
            foreach (var store in dataByStore)
            {
                var storeId = store.Key;
                var devices = store.Value;
                bool gwIpRes = await PingIp($"11{storeId.Substring(0, 1)}.1{storeId.Substring(1, 2)}.1{storeId.Substring(3, 2)}.110");
                //List<string> gwIpRes = await PingIp("127.0.0.1");
                if (gwIpRes)
                {
                    Device gw = (Device) devices.Find(D => D.Name == "GW");
                    if (gw != null)
                    {
                        gw.IsAlive = true;
                        AddRowToDT(gw);
                        devices.Remove(gw);
                    }
                } else
                {
                    devices.ForEach(d =>
                    {
                        AddRowToDT(d);
                    });
                }

            }
        }

        private void AddRowToDT(Device d)
        {
            DataRow dr = dt.NewRow();
            dr["Store ID"] = d.StoreId;
            dr["Device"] = d.Name;
            dr["No"] = d.No ?? "-";
            dr["IP Address"] = d.IP;
            dr["Status"] = d.IsAlive ? "Success" : "Timeout";
            dt.Rows.Add(dr);
            pgbResult.Increment(1);
        }

        private async Task<bool> PingIp(string ip)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                PingReply prl = await pinger.SendPingAsync(ip);
                results.Add(prl.Status.ToString());
            }
            int s = results.Where(S => S.Equals("Success")).Count();
            return  s > QualifiedSuccess;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            startPing();
        }

        private void dgwResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != "")
            {
                if (e.Value.ToString() == "Success")
                {
                    e.CellStyle.ForeColor = Color.Green;  
                } else if (e.Value.ToString() == "Timeout")
                {
                    e.CellStyle.ForeColor = Color.Red;  
                }
            }
        }
    }
}
