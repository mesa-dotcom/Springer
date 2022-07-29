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
        string settingPath = Environment.CurrentDirectory + "/setting_this_is_secret_file.txt";
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
        bool isWatching = false;
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
            var rc = -3;
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
                        rc += 3;
                        if (rc % 6 == 0)
                        {
                            rr++;
                        }
                        tlpTxt.Controls.Add(createCheckBoxForDevice(prop.Name), rc % 6, rr);
                        tlpTxt.Controls.Add(createRichTextBoxForDevice(prop.Name, device.Number), rc % 6 + 1, rr);
                        tlpTxt.Controls.Add(createButtonForDevice(prop.Name), rc % 6 + 2, rr);
                    }
                }
            }
        }

        private CheckBox createCheckBoxForDevice(string propName)
        {
            CheckBox cb = new CheckBox() { Name = "cb" + propName, Text = propName, Checked = true };
            cb.CheckedChanged += new EventHandler(deviceCheckbox_CheckedChanged);
            return cb;
        }

        private RichTextBox createRichTextBoxForDevice(string propName, int highValue)
        {
            return new RichTextBox() { Name = "rtb" + propName, Text = String.Join(",", Enumerable.Range(1, highValue).ToArray()), Size = new System.Drawing.Size(130, 28), Enabled = false };
        }

        private Button createButtonForDevice(string propName)
        {
            Button btn = new Button()
            {
                Name = "btnChoose" + propName,
                Text = "...",
                Margin = new Padding(0, 2, 0, 0),
                Padding = new Padding(0),
                Size = new System.Drawing.Size(35, 25),
                TextAlign = System.Drawing.ContentAlignment.TopCenter
            };
            btn.Click += new EventHandler(deviceMore_Click);
            return btn;
        }

        private void deviceCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkb = (CheckBox) sender;
            Button cb = (Button)tlpTxt.Controls.Find("btnChoose" + chkb.Text, true).FirstOrDefault();
            cb.Enabled = chkb.Checked;
        }

        private void deviceMore_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            var lnd = LimitedDeviceNumber.Find(k => k.Key == btn.Name.Substring(9)).Value;
            RichTextBox rtb = (RichTextBox)tlpTxt.Controls.Find("rtb" + btn.Name.Substring(9), true).FirstOrDefault();
            MultiDeviceForm mdf = new MultiDeviceForm(btn.Name.Substring(9),rtb.Text, lnd);
            mdf.ShowDialog();
            if (mdf.newChosen != "")
            {
                rtb.Text = mdf.newChosen;
            }
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
            txtStore.Enabled = false;
            btnBrowse.Enabled = true;
            readSettingFile();
            flpCheckboxes.Controls.Clear();
            tlpTxt.Controls.Clear();
            createForm();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
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
                if (ctrl.Name.Contains("cb"))
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
                    var firstDigit = storeId.Substring(0, 1) == "0" ? "7" : storeId.Substring(0, 1);
                    string domain = $"11{firstDigit}.1{storeId.Substring(1, 2)}.1{storeId.Substring(3, 2)}";
                    foreach (string n in uniques)
                    {
                        CheckBox cb = (CheckBox)flpCheckboxes.Controls.Find("cb" + n, true).FirstOrDefault();
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
                        RichTextBox rtb = (RichTextBox)tlpTxt.Controls.Find("rtb" + n, true).FirstOrDefault();
                        if (cb != null && cb.Checked)
                        {
                            List<string> ds = rtb.Text.Split(',').ToList();
                            ds.ForEach(d =>
                            {
                                ld.Add(new Device()
                                {
                                    Name = cb.Text,
                                    No = d,
                                    IP = getIP(domain, cb.Text, d),
                                    StoreId = storeId,
                                });
                                allDevices.Add(new Device()
                                {
                                    Name = cb.Text,
                                    No = d,
                                    IP = getIP(domain, cb.Text, d),
                                    StoreId = storeId
                                }); ;
                            });
                        }
                    }
                    allData.Add(new KeyValuePair<string, List<Device>>(storeId, ld));
                }
                if (allDevices.Count == 0)
                {
                    throw new Exception("No device is selected.!");
                } else if (isWatching)
                {
                    ResultFormWatching rfw = new ResultFormWatching(allDevices);
                    rfw.ShowDialog();
                }
                else
                {
                    ResultForm rf = new ResultForm(allData, allDevices);
                    rf.ShowDialog();
                }
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
                    if (txtStore.Text == "")
                    {
                        throw new Exception("Store ID is empty");
                    }
                    storeIds = txtStore.Text.Split(',').ToList();
                }
            if (storeIds.Count == 0)
            {
                throw new Exception("Store ID is empty");
            } else if (storeIds.Count > 1 && isWatching)
            {
                throw new Exception("Watching mode only allows one store.");
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

        private void cbWatching_CheckedChanged(object sender, EventArgs e)
        {
            isWatching = cbWatching.Checked;
        }
    }
}
