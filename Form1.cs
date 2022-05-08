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
        string settingPath = Environment.CurrentDirectory + "/setting_secret_key.txt";
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
        List<string> uniques = new List<string>() { "GW", "SC", "Printer", "GOT" };
        List<string> multi = new List<string>() { "POS", "AP", "PDA", "CCTV", "EDC", "UPS" };
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
                        cb.CheckedChanged += new EventHandler(deviceCheckbox_CheckedChanged);
                        tlpTxt.Controls.Add(cb, rc % 4, rr);
                        var lnd = LimitedDeviceNumber.Find(k => k.Key == prop.Name).Value;
                        ComboBox cbb = new ComboBox() { Name = "cbb" + prop.Name };
                        for (int i = 1; i <= lnd; i++)
                        {
                            cbb.Items.Add(i);
                        }
                        cbb.SelectedItem = device.Number;
                        //NumericUpDown nud = new NumericUpDown() { Name = "txt" + prop.Name, Text = device.number.ToString(), Maximum = LimitedDeviceNumber.Find(k => k.Key == prop.Name).Value };
                        tlpTxt.Controls.Add(cbb, rc % 4 + 1, rr);
                    }
                }
            }
        }

        private void deviceCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkb = (CheckBox) sender;
            ComboBox cb = Controls.Find("cbb" + chkb.Text, true).FirstOrDefault() as ComboBox;
            cb.Enabled = chkb.Checked;
        }

        private void cbChooseGroup_CheckedChanged(object sender, EventArgs e)
        {
            txtStore.Text = "";
            if (cbChooseGroup.Checked)
            {
                cbSameDir.Enabled = true;
                txtStore.Enabled = false;
                btnBrowse.Enabled = true;
            } else
            {
                cbSameDir.Checked = false;
                cbSameDir.Enabled = false;
                txtStore.Enabled = true;
                btnBrowse.Enabled = false;
            }
        }

        private void cbSameDir_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSameDir.Checked)
            {
                this.btnBrowse.Enabled = false;
                this.txtStore.Text = "";
            } else
            {
                this.btnBrowse.Enabled = true;
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

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm();
            sf.FormClosing += new FormClosingEventHandler(this.settingForm_FormClosing);
            sf.ShowDialog();
        }

        private void settingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cbChooseGroup.Checked = true;
            cbSameDir.Checked = false;
            txtStore.Enabled = false;
            btnBrowse.Enabled = true;
            readSettingFile();
            flpCheckboxes.Controls.Clear();
            tlpTxt.Controls.Clear();
            createForm();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            cbSameDir.Checked = false;
            foreach (Control ctrl in flpCheckboxes.Controls)
            {
                if (ctrl.Name.Contains("cb"))
                {
                    CheckBox cb = (CheckBox)ctrl;
                    cb.Checked = false;
                }
            }
            foreach (Control ctrl in tlpTxt.Controls)
            {
                if (ctrl.Name.Contains("cb") && !ctrl.Name.Contains("cbb"))
                {
                    CheckBox cb = (CheckBox)ctrl;
                    cb.Checked = false;
                }
            }
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> storeIds = getStoreIds();
                List<KeyValuePair<string, List<Device>>> allData = new List<KeyValuePair<string, List<Device>>>();
                List<Device> allDevices = new List<Device>();
                foreach (string storeId in storeIds)
                {
                    List<Device> ld = new List<Device>();
                    string domain = $"11{storeId.Substring(0, 1)}.1{storeId.Substring(1, 2)}.1{storeId.Substring(3, 2)}";
                    foreach (string n in uniques)
                    {
                        CheckBox cb = (CheckBox)Controls.Find("cb" + n, true).FirstOrDefault();
                        if (cb != null && cb.Checked)
                        {
                            ld.Add(new Device()
                            {
                                Name = cb.Text,
                                No = null,
                                IP = getIP(domain, cb.Text),
                                StoreId = storeId,
                            });
                            allDevices.Add(new Device()
                            {
                                Name = cb.Text,
                                No = null,
                                IP = getIP(domain, cb.Text),
                                StoreId = storeId,
                            });
                        }
                    }
                    foreach (string n in multi)
                    {
                        CheckBox cb = (CheckBox)Controls.Find("cb" + n, true).FirstOrDefault();
                        ComboBox cbb = (ComboBox)Controls.Find("cbb" + n, true).FirstOrDefault();
                        if (cb != null && cb.Checked)
                        {
                            ld.Add(new Device()
                            {
                                Name = cb.Text,
                                No = cbb.Text,
                                IP = getIP(domain, cb.Text, cbb.Text),
                                StoreId=storeId,
                            });
                            allDevices.Add(new Device()
                            {
                                Name = cb.Text,
                                No = cbb.Text,
                                IP = getIP(domain, cb.Text, cbb.Text),
                                StoreId = storeId,
                            });
                        }
                    }
                    allData.Add(new KeyValuePair<string, List<Device>>(storeId, ld));
                }
                ResultForm rf = new ResultForm(allData, allDevices);
                rf.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private List<string> getStoreIds()
        {
            List<string> storeIds = new List<string>();
                if (cbChooseGroup.Checked)
                {
                    string storePath = cbSameDir.Checked ? Environment.CurrentDirectory + "/Node.txt" : txtStore.Text;
                    using (StreamReader sr = File.OpenText(storePath))
                    {
                        while (sr.Peek()> 0)
                        {
                            storeIds.Add(sr.ReadLine());
                        }
                    }
                }
                else
                {
                    storeIds = txtStore.Text.Split(',').ToList();
                }
            return storeIds;
        }

        private string getIP(string domain,string deviceName, string no = "" )
        {
            switch (deviceName)
            {
                case "GW":
                    return domain + ".110";
                case "SC":
                    return domain + ".119";
                case "GOT":
                    return domain + ".146";
                case "Printer":
                    return domain + ".121";
                case "POS":
                    return $"{domain}.11{no}";
                case "AP":
                    return $"{domain}.10{no}";
                case "PDA":
                    return $"{domain}.13{no}";
                case "UPS":
                    return $"{domain}.{96 + Int32.Parse(no)}";
                case "EDC":
                    return $"{domain}.{208 + Int32.Parse(no)}";
                case "CCTV":
                    return $"{domain}.{8 +  Int32.Parse(no)}";
                default:
                    return domain + ".110";
            }
        }
    }
}
