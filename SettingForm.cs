using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Springer.Models;
using Newtonsoft.Json;
using System.Reflection;

namespace Springer
{
    public partial class SettingForm : Form
    {
        string settingPath = Environment.CurrentDirectory + "/setting_secret_key.txt";
        Setting setting = new Setting();
        List<string> uniques = new List<string>() { "SC", "GW", "Printer", "GOT" };
        public SettingForm()
        {
            InitializeComponent();
            settingInput();
        }

        private void settingInput()
        {
            try
            {
                using (StreamReader sr = File.OpenText(settingPath))
                {
                    string str = sr.ReadToEnd();
                    setting = JsonConvert.DeserializeObject<Setting>(str);
                    foreach (PropertyInfo prop in setting.GetType().GetProperties())
                    {
                        if (uniques.Contains(prop.Name))
                        {
                            UniqueSetting device = (UniqueSetting)prop.GetValue(setting, null);
                            CheckBox cbs = (CheckBox) Controls.Find("cbs" + prop.Name, true).FirstOrDefault();
                            cbs.Checked = device.IsShow;
                            if (device.IsCheck)
                            {
                                RadioButton rb = (RadioButton) Controls.Find("rb" + prop.Name + "True", true).FirstOrDefault();
                                rb.Checked = true;
                            } else
                            {
                                RadioButton rb = (RadioButton) Controls.Find("rb" + prop.Name + "False", true).FirstOrDefault();
                                rb.Checked = true;
                            }
                        }
                        else
                        {
                            MultiSetting device = (MultiSetting)prop.GetValue(setting, null);
                            CheckBox cbs = (CheckBox) Controls.Find("cbs" + prop.Name, true).FirstOrDefault();
                            cbs.Checked = device.IsShow;
                            NumericUpDown nud = Controls.Find("nud" + prop.Name, true).FirstOrDefault() as NumericUpDown;
                            nud.Value = device.Number;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Setting newSetting = new Setting();
            try
            {
                foreach (PropertyInfo prop in newSetting.GetType().GetProperties())
                {
                    if (uniques.Contains(prop.Name))
                    {
                        CheckBox cbs = (CheckBox) Controls.Find("cbs" + prop.Name, true).FirstOrDefault();
                        RadioButton rbTrue = (RadioButton)Controls.Find("rb" + prop.Name + "True", true).FirstOrDefault();
                        RadioButton rbFalse = (RadioButton)Controls.Find("rb" + prop.Name + "False", true).FirstOrDefault();
                        prop.SetValue(newSetting, new UniqueSetting() { IsShow = cbs.Checked, IsCheck = rbTrue.Checked ? true : false}, null);
                    }
                    else
                    {
                        CheckBox cbs = (CheckBox) Controls.Find("cbs" + prop.Name, true).FirstOrDefault();
                        NumericUpDown nud = (NumericUpDown)Controls.Find("nud" + prop.Name, true).FirstOrDefault();
                        prop.SetValue(newSetting, new MultiSetting() { IsShow = cbs.Checked, Number = (int) nud.Value}, null);
                    }
                }
                string str = JsonConvert.SerializeObject(newSetting);
                File.Delete(settingPath);
                using (FileStream fs = File.Create(settingPath))
                {
                    Byte[] data = new UTF8Encoding(true).GetBytes(str);
                    fs.Write(data, 0, data.Length);
                    File.SetAttributes(settingPath, FileAttributes.Hidden);
                }
                this.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
