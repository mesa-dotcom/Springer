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
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;

namespace Springer
{
    public partial class ResultForm : Form
    {
        Ping pinger = new Ping();
        List<KeyValuePair<string, List<Device>>> dataByStore = new List<KeyValuePair<string, List<Device>>>();
        List<Device> dataAll = new List<Device>();
        System.Data.DataTable dt = new System.Data.DataTable();
        int QualifiedSuccess = 3;
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
            dt.Columns.Add("Status All");
            dgwResult.DataSource = dt;
            SetSort(false);
        }
        private async void startPing()
        {
            pgbResult.Maximum = dataAll.Count;
            foreach (var store in dataByStore)
            {
                var storeId = store.Key;
                var devices = store.Value;
                var gwIpRes = await PingIp($"11{storeId.Substring(0, 1)}.1{storeId.Substring(1, 2)}.1{storeId.Substring(3, 2)}.110");
                if (gwIpRes.isSuccess)
                {
                    Device gw = devices.Find(D => D.Name == "GW");
                    if (gw != null)
                    {
                        gw.IsAlive = true;
                        AddRowToDT(gw, gwIpRes.stati);
                        devices.Remove(gw);
                    }
                    for (int i = 0; i < devices.Count(); i++)
                    {
                        var dRes = await PingIp(devices[i].IP, i);
                        if (dRes.isSuccess)
                        {
                            devices[i].IsAlive = true;
                        }
                        AddRowToDT(devices[i], dRes.stati);
                    }
                }
                else
                {
                    devices.ForEach(d =>
                    {
                        AddRowToDT(d, new List<string>() { "Timeout", "Timeout", "Timeout", "Timeout"});
                    });
                }

            }
        }

        private void AddRowToDT(Device d, List<string> stati = null) 
        {
            DataRow dr = dt.NewRow();
            dr["Store ID"] = d.StoreId;
            dr["Device"] = d.Name;
            dr["No"] = d.No ?? "-";
            dr["IP Address"] = d.IP;
            dr["Status"] = d.IsAlive ? "Success" : "Failed";
            if (stati != null)
            {
                dr["Status All"] = String.Join(", ", stati);
            }
            dt.Rows.Add(dr);
            pgbResult.Increment(1);
            CheckProgressBarFull();
        }

        private async Task<(bool isSuccess, int index, List<string> stati)> PingIp(string ip, int index = 0)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                PingReply prl = await pinger.SendPingAsync(ip);
                results.Add(prl.Status.ToString());
            }
            int s = results.Where(r => r.Equals("Success")).Count();
            return  (s >= QualifiedSuccess, index, results);
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            startPing();
        }

        private void CheckProgressBarFull()
        {
            if (pgbResult.Value == pgbResult.Maximum)
            {
                btnExcel.Enabled = true;
                btnCSV.Enabled = true;
                lblProgress.Text = "Pinging is Done!";
                SetSort(true);
            }
        }

        private void dgwResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != "")
            {
                if (e.Value.ToString() == "Success")
                {
                    e.CellStyle.ForeColor = Color.Green;  
                } else if (e.Value.ToString() == "Failed")
                {
                    e.CellStyle.ForeColor = Color.Red;  
                }
            }
        }

        private void SetSort(bool isAllow)
        {
            foreach (DataGridViewColumn column in dgwResult.Columns)
            {
                column.SortMode =isAllow ? DataGridViewColumnSortMode.Automatic : DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application Excell = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = Excell.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excell.ActiveSheet;
            Excell.Visible = true;
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            using (TextWriter tw = new StreamWriter("result.txt"))
            {
                for (int i = 0; i < dgwResult.Rows.Count; i++)
                {
                    for (int j = 0; j < dgwResult.Columns.Count - 1; j++)
                    {
                        tw.Write($"{dgwResult.Rows[i].Cells[j].Value}");

                        if (j != dgwResult.Columns.Count - 2)
                        {
                            tw.Write("|");
                        }
                    }
                    tw.WriteLine();
                }
                Process.Start("notepad.exe", Environment.CurrentDirectory + "\\result.txt");
            }
        }
    }
}
