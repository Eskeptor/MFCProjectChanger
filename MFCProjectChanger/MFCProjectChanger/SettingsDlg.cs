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
        public delegate void DelegateBoolSet(bool bIsDark);
        public delegate void DelegateStringSet(string strLine, Util.StringArray eType);

        public event DelegateBoolSet EventDarkTheme = null;
        public event DelegateBoolSet EventLatestExeSave = null;
        public event DelegateStringSet EventChangeStringArray = null;

        public SettingsDlg()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 셋팅값 초기 셋팅
        /// </summary>
        /// <param name="bIsDark">다크모드 유무</param>
        /// <param name="bIsLatestExeSave">최근값 기억 유무</param>
        /// <param name="strFolderFilter"></param>
        /// <param name="strExeFilter"></param>
        public void SetInit(bool bIsDark, bool bIsLatestExeSave, string strFolderFilter, string strExeFilter)
        {
            toggleDarkMode.Checked = bIsDark;
            toggleLastPathLog.Checked = bIsLatestExeSave;
            tBoxFolderFilter.Text = strFolderFilter;
            tBoxExeFilter.Text = strExeFilter;
        }
        public void SetInit(bool bIsDark, bool bIsLatestExeSave, string[] strFolderFilter, string[] strExeFilter)
        {
            toggleDarkMode.Checked = bIsDark;
            toggleLastPathLog.Checked = bIsLatestExeSave;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < strFolderFilter.Length; i++)
            {
                stringBuilder.Append(strFolderFilter[i]);
                if (i != strFolderFilter.Length - 1)
                    stringBuilder.Append(",");
            }
            tBoxFolderFilter.Text = stringBuilder.ToString();

            stringBuilder.Clear();
            for (int i = 0; i < strExeFilter.Length; i++)
            {
                stringBuilder.Append(strExeFilter[i]);
                if (i != strExeFilter.Length - 1)
                    stringBuilder.Append(",");
            }
            tBoxExeFilter.Text = stringBuilder.ToString();
        }


        /// <summary>
        /// 다크모드 토글버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toggleDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleDarkMode.Checked)
                settingThemeMgr.Theme = MetroFramework.MetroThemeStyle.Dark;
            else
                settingThemeMgr.Theme = MetroFramework.MetroThemeStyle.Light;

            EventDarkTheme?.Invoke(toggleDarkMode.Checked);
        }


        /// <summary>
        /// 최근값 기억 토글버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toggleLastPathLog_CheckedChanged(object sender, EventArgs e)
        {
            EventLatestExeSave?.Invoke(toggleLastPathLog.Checked);
        }


        /// <summary>
        /// 적용 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            EventChangeStringArray?.Invoke(tBoxFolderFilter.Text, Util.StringArray.FolderFilter);
            EventChangeStringArray?.Invoke(tBoxExeFilter.Text, Util.StringArray.ExeFilter);

            Close();
        }


        /// <summary>
        /// 취소 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
