using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace MFCProjectChanger
{
    public partial class SettingsDlg : MetroForm
    {
        public delegate void DelegateThemeDark(bool bIsDark);

        public event DelegateThemeDark EventDarkTheme = null;

        public SettingsDlg()
        {
            InitializeComponent();
        }

        private void toggleDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleDarkMode.Checked)
                settingThemeMgr.Theme = MetroFramework.MetroThemeStyle.Dark;
            else
                settingThemeMgr.Theme = MetroFramework.MetroThemeStyle.Light;

            EventDarkTheme?.Invoke(toggleDarkMode.Checked);
        }
    }
}
