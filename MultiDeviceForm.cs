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
    public partial class MultiDeviceForm : Form
    {
        string deviceName = "";
        int limited = 0;
        string chosen = "";
        public string newChosen = "";
        public MultiDeviceForm(string dName, string ChooseValue, int limitedNumber)
        {
            deviceName = dName;
            chosen = ChooseValue;
            limited = limitedNumber;
            InitializeComponent();
            SetForm();
        }

        public void SetForm()
        {
            Text = "Choose: " + deviceName;
            lblD.Text = deviceName;
            List<string> list = chosen.Split(',').ToList();
            for (int i = 0; i < limited; i++)
            {
                var row = (int)i / 5;
                var col = (int)i % 5;
                tlpDevices.Controls.Add(new CheckBox() { Text = (i + 1).ToString(), Anchor = AnchorStyles.None, Checked = list.Contains((i + 1).ToString()), Name = deviceName + i.ToString() }, col, row);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            List<string> res = new List<string>();
            foreach (Control ctl in tlpDevices.Controls)
            {
                if (ctl is CheckBox)
                {
                    CheckBox cb = (CheckBox)ctl;
                    if (cb.Checked)
                    {
                        res.Add(cb.Text);
                    }
                }
            }
            if (res.Count != 0)
            {
                newChosen = string.Join(",", res);
                Close();
            } else
            {
                MessageBox.Show("Please choose at least one.!");
            }
        }
    }
}
