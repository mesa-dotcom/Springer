using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Springer.Models
{
    internal class Setting
    {
        public UniqueSetting GW { get; set; } = new UniqueSetting() { IsShow = true, IsCheck = false };
        public UniqueSetting SC { get; set; } = new UniqueSetting() { IsShow = true, IsCheck = true };
        public UniqueSetting GOT { get; set; } = new UniqueSetting() { IsShow = false, IsCheck = false };
        public UniqueSetting Printer { get; set; } = new UniqueSetting() { IsShow = false, IsCheck = false };
        public MultiSetting POS { get; set; } = new MultiSetting() { IsShow = true, number = 3 };
        public MultiSetting AP { get; set; } = new MultiSetting() { IsShow = true, number = 2 };
        public MultiSetting PDA { get; set; } = new MultiSetting() { IsShow = true, number = 2 };
        public MultiSetting CCTV { get; set; } = new MultiSetting() { IsShow = false, number = 1 };
        public MultiSetting UPS { get; set; } = new MultiSetting() { IsShow = false, number = 1 };
        public MultiSetting EDC { get; set; } = new MultiSetting() { IsShow = false, number = 1 };
    }
}
