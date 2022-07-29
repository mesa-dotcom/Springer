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

namespace Springer
{
    public partial class ResultFormWatching : Form
    {
        List<Device> dataAll = new List<Device>();
        List<string> devices = new List<string>() { "GW", "SC", "Printer", "GOT" , "POS", "AP", "PDA", "CCTV", "EDC", "UPS" };
        public ResultFormWatching(List<Device> ds)
        {
            dataAll = ds;
            InitializeComponent();
            lblMain.Text = "Pinging the store " + ds[0].StoreId.ToString() +  "...";
            createForm();
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
                        ColumnCount = 2,
                        RowCount = 1,
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                        Dock = DockStyle.Fill,
                    };
                    tlpEach.ColumnStyles.Add(new ColumnStyle { Width = (float)0.2, SizeType = SizeType.Percent });
                    tlpEach.ColumnStyles.Add(new ColumnStyle { Width = (float)0.8, SizeType = SizeType.Percent });
                    tlpEach.Controls.Add(new Label
                    {
                        Text = device,
                        Anchor = AnchorStyles.None,
                    }, 0, 0);
                    tlpMain.Controls.Add(tlpEach, rc % 2, rr);
                }
            }
        }
    }
}
