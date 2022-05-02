using System;
using System.IO;
using System.Windows.Forms;
using Springer.Models;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Springer
{
    public partial class springer : Form
    {
        string settingPath = Environment.CurrentDirectory + "/setting.txt";
        Setting defaultSetting = new Setting();
        Setting currentSetting = new Setting();
        List<KeyValuePair<string, int>> LimitedDeviceNumber = new List<KeyValuePair<string, int>>()
        {
            new KeyValuePair<string, int>("SC", 0),
            new KeyValuePair<string, int>("GW", 0),
            new KeyValuePair<string, int>("GOT", 0),
            new KeyValuePair<string, int>("Printer", 0),
            new KeyValuePair<string, int>("POS", 8),
            new KeyValuePair<string, int>("AP", 8),
            new KeyValuePair<string, int>("UPS", 3),
            new KeyValuePair<string, int>("EDC", 13),
            new KeyValuePair<string, int>("CCTV", 5),
            new KeyValuePair<string, int>("PDA", 8)
        };
        string[] stores;
        public springer()
        {
            InitializeComponent();
            cbChooseGroup.Checked = true;
            txtStore.Enabled = false;
            btnBrowse.Enabled = true;
            createSettingFile();
            readSettingFile();
            createForm();
        }

        private void createSettingFile()
        {
            try
            {
                if (!File.Exists(settingPath))
                {
                    string str = JsonConvert.SerializeObject(defaultSetting);
                    // Create a new file     
                    using (FileStream fs = File.Create(settingPath))
                    {
                        // Add some text to file    
                        Byte[] data = new UTF8Encoding(true).GetBytes(str);
                        fs.Write(data, 0, data.Length);
                        File.SetAttributes(settingPath, FileAttributes.Hidden);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void readSettingFile()
        {
            try
            {
                using (StreamReader sr = File.OpenText(settingPath))
                {
                    string str = sr.ReadToEnd();
                    currentSetting = JsonConvert.DeserializeObject<Setting>(str);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void createForm()
        {
            List<string> uniques = new List<string>() { "SC", "GW", "Printer", "GOT" };
            var rc = -2;
            var rr = -1;
            foreach (PropertyInfo prop in currentSetting.GetType().GetProperties())
            {
                if (uniques.Contains(prop.Name))
                {
                    UniqueSetting device = (UniqueSetting) prop.GetValue(currentSetting, null);
                    if (device.IsShow)
                        {
                            CheckBox cb = new CheckBox() {
                                Name = "cb" + prop.Name,
                                Text = prop.Name,
                                Checked = device.IsCheck,
                        };
                    flpCheckboxes.Controls.Add(cb);
                    }
                }
                else
                {
                    MultiSetting device = (MultiSetting) prop.GetValue(currentSetting, null);
                    if (device.IsShow)
                    {
                        rc += 2;
                        if (rc % 4 == 0)
                        {
                            rr++;
                        }
                        CheckBox cb = new CheckBox() { Name = "cb" + prop.Name, Text = prop.Name, Checked = true };
                        cb.CheckedChanged += new EventHandler(deviceCheckbox_CheckedChanged);                        tlpTxt.Controls.Add(cb, rc % 4, rr);
                        var lnd = LimitedDeviceNumber.Find(k => k.Key == prop.Name).Value;
                        ComboBox cbb = new ComboBox() { Name = "cbb" + prop.Name };
                        for (int i = 1; i <= lnd; i++)
                        {
                            cbb.Items.Add(i);
                        }
                        cbb.SelectedItem = device.number;
                        //NumericUpDown nud = new NumericUpDown() { Name = "txt" + prop.Name, Text = device.number.ToString(), Maximum = LimitedDeviceNumber.Find(k => k.Key == prop.Name).Value };
                        tlpTxt.Controls.Add(cbb, rc % 4 + 1, rr);
                    }
                }
            }
        }

        private void deviceCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkb = (CheckBox) sender;
            if (!chkb.Checked)
            {
                
            }
        }

        private void cbChooseGroup_CheckedChanged(object sender, EventArgs e)
        {
            txtStore.Text = "";
            if (cbChooseGroup.Checked)
            {
                txtStore.Enabled = false;
                btnBrowse.Enabled = true;
            } else
            {
                txtStore.Enabled = true;
                btnBrowse.Enabled = false;
            }
        }
       
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Text File (*.txt)|*.txt";
            ofd.FilterIndex = 1;
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                txtStore.Text = ofd.FileName;
                stores = File.ReadAllLines(ofd.FileName);
            }
            else
            {
                txtStore.Text = "";
            }

        }
    }
}
