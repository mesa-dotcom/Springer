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
    public partial class ResultForm : Form
    {
        List<KeyValuePair<string, List<Device>>> data = new List<KeyValuePair<string, List<Device>>>();
        public ResultForm(List<KeyValuePair<string, List<Device>>> d)
        {
            data = d;
           InitializeComponent();
        }
    }
}
