using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace MFCProjectChanger
{
    public partial class FrmMain : MetroForm
    {
        
        private readonly string THEME_LIGHT = "Light";
        private readonly string THEME_DARK = "Dark";
        private readonly string APP_IGNORE_FOLDERS = "IgnoreFolders";
        private readonly string APP_IGNORE_EXTENDS = "IgnoreExtends";
        private readonly string APP_LATEST_PROJECT_PATH = "LatestProjectPath";
        private readonly string APP_LATEST_PROJECT_NAME = "LatestProjectName";
        private readonly string APP_THEME = "AppMetroTheme";
        private readonly string APP_LATEST_EXE_SAVE = "LatestExeSave";

        private Thread m_thrChange = null;      // Change 메인 스레드

        private StringBuilder m_sBuilderLog = new StringBuilder();

        private string[] m_arrStrIgnoreFolders = null;      // 검색에 무시할 폴더를 모아놓은 배열
        private string[] m_arrStrIgnoreEx = null;           // 검색에 무시할 파일 확장자를 모아놓은 배열

        private string m_strCurPrjPath = string.Empty;      // 현재 프로젝트의 경로(절대 경로)
        private string m_strCurPrjName = string.Empty;      // 현재 프로젝트의 명
        private string m_strChgPrjName = string.Empty;      // 변경할 프로젝트의 명

        private bool m_bIsLatestExeSave = false;            // 마지막 작업상태 저장

        public FrmMain()
        {
            InitializeComponent();

            InitAppConfig();
        }


        /// <summary>
        /// AppConfig 셋팅을 불러오는 메소드
        /// </summary>
        private void InitAppConfig()
        {

            // 폴더 필터
            string strIgnoreFolders = AppConfigMgr.GetAppConfig(APP_IGNORE_FOLDERS);
            if (string.IsNullOrEmpty(strIgnoreFolders))
            {
                strIgnoreFolders = "ipch";
                m_arrStrIgnoreFolders = strIgnoreFolders.Split(',');
                AppConfigMgr.SetAppConfig(APP_IGNORE_FOLDERS, strIgnoreFolders);
            }
            else
            {
                m_arrStrIgnoreFolders = strIgnoreFolders.Split(',');
            }

            // 파일 확장자 필터
            string strIgnoreEx = AppConfigMgr.GetAppConfig(APP_IGNORE_EXTENDS);
            if (string.IsNullOrEmpty(strIgnoreEx))
            {
                strIgnoreEx = "bmp,png,ico,suo,VC.db,ipch,sqlite,exe,ilk,pdb";
                m_arrStrIgnoreEx = strIgnoreEx.Split(',');
                AppConfigMgr.SetAppConfig(APP_IGNORE_EXTENDS, strIgnoreEx);
            }
            else
            {
                m_arrStrIgnoreEx = strIgnoreEx.Split(',');
            }

            // 테마
            string strTheme = AppConfigMgr.GetAppConfig(APP_THEME);
            if (string.IsNullOrEmpty(strTheme))
            {
                mainThemeMgr.Theme = MetroFramework.MetroThemeStyle.Light;
                AppConfigMgr.SetAppConfig(APP_THEME, THEME_LIGHT);
            }
            else
            {
                if (strTheme.Equals(THEME_DARK))
                    mainThemeMgr.Theme = MetroFramework.MetroThemeStyle.Dark;
                else
                    mainThemeMgr.Theme = MetroFramework.MetroThemeStyle.Light;
            }

            // 마지막 작업상태 저장 유무
            string strLatestExeSave = AppConfigMgr.GetAppConfig(APP_LATEST_EXE_SAVE);
            if (string.IsNullOrEmpty(strLatestExeSave))
            {
                m_bIsLatestExeSave = true;
                AppConfigMgr.SetAppConfig(APP_LATEST_EXE_SAVE, "true");
            }
            else
            {
                if (strLatestExeSave.Equals("true"))
                    m_bIsLatestExeSave = true;
                else
                    m_bIsLatestExeSave = false;
            }
        }


        /// <summary>
        /// 해당 디렉토리에서 파일 및 폴더를 검색하여 프로젝트명으로 전부 변경하는 메소드
        /// </summary>
        /// <param name="strPath">디렉토리 경로</param>
        /// <param name="strCurPrjName">현재 프로젝트명</param>
        /// <param name="strChgPrjName">변경할 프로젝트명</param>
        /// <param name="bIsChgFile">파일변경 유무</param>
        /// <param name="bIsChgFolder">폴더변경 유무</param>
        private void DirFileNameChange(
            string strPath,
            string strCurPrjName,
            string strChgPrjName,
            bool bIsChgFile,
            bool bIsChgFolder)
        {
            if (string.IsNullOrEmpty(strPath))
            {
                SetLog("파일 경로가 비어있음");
                return;
            }

            if (string.IsNullOrEmpty(strCurPrjName))
            {
                SetLog("프로젝트명이 비어있음");
                return;
            }

            if (string.IsNullOrEmpty(strChgPrjName))
            {
                SetLog("수정할 프로젝트명이 비어있음");
                return;
            }

            try
            {
                if (bIsChgFile)
                {
                    string[] arrStrFiles = Directory.GetFiles(strPath, "*.*");
                    string strEx = string.Empty;
                    string strData = string.Empty;
                    string strNewData = string.Empty;
                    bool bIsIgnoreFile = false;
                    Encoding encoding;
                    Util.RenameResult eRenameResult;

                    foreach (string strFile in arrStrFiles)
                    {
                        strEx = strFile.Substring(strFile.LastIndexOf(".") + 1);
                        foreach (string strIgnore in m_arrStrIgnoreEx)
                        {
                            if (strEx.Equals(strIgnore))
                            {
                                bIsIgnoreFile = true;
                                break;
                            }
                        }

                        if (bIsIgnoreFile)
                        {
                            bIsIgnoreFile = false;
                        }
                        else
                        {
                            encoding = Util.GetEncoding(strFile);
                            using (StreamReader reader = new StreamReader(strFile, encoding))
                            {
                                strData = reader.ReadToEnd();
                            }

                            if (strData.IndexOf(strCurPrjName) != -1)
                            {
                                strNewData = strData.Replace(strCurPrjName, strChgPrjName);

                                using (StreamWriter writer = new StreamWriter(strFile, false, encoding))
                                {
                                    writer.Write(strNewData);
                                }
                            }
                        }

                        eRenameResult = Util.FileRename(strFile, strCurPrjName, strChgPrjName, Util.RenameType.File);
                        if (eRenameResult == Util.RenameResult.Failed)
                        {
                            SetLog(string.Format("파일명 변경 실패 - {0}", strPath));
                        }
                        AddProgress();
                    }
                }

                string[] arrStrDirs = Directory.GetDirectories(strPath);
                
                if (arrStrDirs.Length > 0)
                {
                    string strBackFolder = string.Empty;
                    bool bIsIgnoreFolder = false;
                    Util.RenameResult eRenameResult;

                    foreach (string strDir in arrStrDirs)
                    {
                        strBackFolder = strDir.Substring(strDir.LastIndexOf(@"\") + 1);
                        foreach (string strIgnore in m_arrStrIgnoreFolders)
                        {
                            if (strBackFolder.Equals(strIgnore))
                            {
                                bIsIgnoreFolder = true;
                                break;
                            }
                        }

                        if (bIsIgnoreFolder)
                        {
                            bIsIgnoreFolder = false;
                        }
                        else
                        {
                            DirFileNameChange(strDir, strCurPrjName, strChgPrjName, bIsChgFile, bIsChgFolder);

                            if (bIsChgFolder)
                            {
                                eRenameResult = Util.FileRename(strDir, strCurPrjName, strChgPrjName, Util.RenameType.Folder);
                                if (eRenameResult == Util.RenameResult.Failed)
                                {
                                    SetLog(string.Format("폴더명 변경 실패 - {0}", strPath));
                                }
                                AddProgress();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetLog(ex.Message);
            }
        }


        /// <summary>
        /// 로그를 기록하는 메소드
        /// </summary>
        /// <param name="strLog">기록할 로그</param>
        private void SetLog(string strLog)
        {
            m_sBuilderLog.AppendLine(strLog);

            if (tBoxLog.InvokeRequired)
            {
                tBoxLog.Invoke(new MethodInvoker(delegate ()
                {
                    tBoxLog.Text = m_sBuilderLog.ToString();
                }));
            }
            else
                tBoxLog.Text = m_sBuilderLog.ToString();
        }


        private void ThreadChange(string strPrjPath, string strCurPrjName, string strChgPrjName)
        {
            // 작업시작 로그
            SetLog(string.Format("작업시작 : {0}", DateTime.Now.ToString()));

            // 프로그래스바의 최대값을 폴더내의 파일 및 하위폴더 개수로 설정
            int nFileCount = GetAllFileCount(strPrjPath);
            if (pgbarChange.InvokeRequired)
            {
                pgbarChange.Invoke(new MethodInvoker(delegate ()
                {
                    pgbarChange.Maximum = nFileCount;
                }));
            }
            else
                pgbarChange.Maximum = nFileCount;
            SetLog(string.Format("파일 개수 : {0}", nFileCount));

            // 파일 우선 변경
            DirFileNameChange(strPrjPath, strCurPrjName, strChgPrjName, true, false);
            // 디렉토리 변경
            DirFileNameChange(strPrjPath, strCurPrjName, strChgPrjName, false, true);
            // 최상위 디렉토리 변경
            Util.RenameResult eRenameResult = Util.FileRename(strPrjPath, strCurPrjName, strChgPrjName, Util.RenameType.Folder);
            if (eRenameResult == Util.RenameResult.Failed)
            {
                SetLog(string.Format("폴더명 변경 실패 - {0}", strPrjPath));
            }

            // 작업종료 로그
            SetLog("작업종료 : " + DateTime.Now.ToString());

            MessageBox.Show("작업을 완료하였습니다.");

            m_thrChange = null;
        }


        /// <summary>
        /// 찾아보기 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrjPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tBoxPrjPath.Text = dialog.SelectedPath;
                    tBoxPrjName.Text = dialog.SelectedPath.Substring(dialog.SelectedPath.LastIndexOf(@"\") + 1);
                }
            }
        }
        

        /// <summary>
        /// 변경 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrjChange_Click(object sender, EventArgs e)
        {
            if (m_thrChange == null)
            {
                if (string.IsNullOrEmpty(tBoxPrjPath.Text))
                {
                    SetLog("프로젝트 경로가 비어있음");
                    return;
                }

                if (string.IsNullOrEmpty(tBoxPrjName.Text))
                {
                    SetLog("프로젝트명이 비어있음");
                    return;
                }

                if (string.IsNullOrEmpty(tBoxPrjChangeName.Text))
                {
                    SetLog("변경할 프로젝트명이 비어있음");
                    return;
                }

                m_strCurPrjPath = tBoxPrjPath.Text;
                m_strCurPrjName = tBoxPrjName.Text;
                m_strChgPrjName = tBoxPrjChangeName.Text;

                m_thrChange = new Thread(() => ThreadChange(m_strCurPrjPath, m_strCurPrjName, m_strChgPrjName));
                m_thrChange.Start();
            }
            else
            {
                MessageBox.Show("변경 작업이 이미 진행중입니다.");
                SetLog("작업 스레드 생성 실패");
            }
        }


        /// <summary>
        /// 프로그래스바의 현재 진행상태를 설정하는 메소드
        /// </summary>
        /// <param name="nProg"></param>
        private void SetProgress(int nProg)
        {
            if (pgbarChange.InvokeRequired)
            {
                pgbarChange.Invoke(new MethodInvoker(delegate ()
                {
                    pgbarChange.Value = nProg;
                }));
            }
            else
                pgbarChange.Value = nProg;
        }


        /// <summary>
        /// 프로그래스바의 현재 진행상태를 1증가시키는 메소드
        /// </summary>
        private void AddProgress()
        {
            if (pgbarChange.InvokeRequired)
            {
                pgbarChange.Invoke(new MethodInvoker(delegate ()
                {
                    if (pgbarChange.Value < pgbarChange.Maximum)
                        pgbarChange.Value += 1;
                }));
            }
            else
            {
                if (pgbarChange.Value < pgbarChange.Maximum)
                    pgbarChange.Value += 1;
            }
        }


        /// <summary>
        /// 해당 폴더내의 파일 및 폴더 개수를 반환하는 메소드
        /// </summary>
        /// <param name="strPath">최상위 폴더 경로</param>
        /// <returns>파일 및 폴더 개수</returns>
        public int GetAllFileCount(string strPath)
        {
            int nCount = 0;
            try
            {
                if (Directory.Exists(strPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(strPath);
                    nCount = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories).Length;
                }
            }
            catch { }
            return nCount;
        }


        /// <summary>
        /// String array를 한 줄로 합치는 메소드
        /// </summary>
        /// <param name="strArray">String 배열</param>
        /// <param name="chToken">중간 구분자</param>
        /// <returns></returns>
        private string MergeString(string[] strArray, char chToken)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < strArray.Length; i++)
            {
                stringBuilder.Append(strArray[i]);
                if (i != strArray.Length - 1)
                    stringBuilder.Append(chToken);
            }

            return stringBuilder.ToString();
        }


        /// <summary>
        /// 테마를 다크 또는 라이트로 변경하는 메소드 (For Delegate)
        /// </summary>
        /// <param name="bIsDark">테마가 다크인지 유무</param>
        public void ChangeThemeDark(bool bIsDark)
        {
            if (bIsDark)
            {
                mainThemeMgr.Theme = MetroFramework.MetroThemeStyle.Dark;
            }
            else
            {
                mainThemeMgr.Theme = MetroFramework.MetroThemeStyle.Light;
            }
        }

        /// <summary>
        /// 마지막 작업을 저장(프로젝트 경로, 프로젝트명)하는 플래그를 변경하는 메소드 (For Delegate)
        /// </summary>
        /// <param name="bIsSave">저장 유무</param>
        public void ChangeLatestExeLog(bool bIsSave)
        {
            m_bIsLatestExeSave = bIsSave;
        }


        /// <summary>
        /// string array 값을 바꾸는 메소드 (For Delegate)
        /// </summary>
        /// <param name="strLine"></param>
        /// <param name="eArrayType"></param>
        public void ChangeStrArray(string strLine, Util.StringArray eArrayType)
        {
            if (eArrayType == Util.StringArray.FolderFilter)
                m_arrStrIgnoreFolders = strLine.Split(',');
            else if (eArrayType == Util.StringArray.ExeFilter)
                m_arrStrIgnoreEx = strLine.Split(',');
        }


        /// <summary>
        /// 설정 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (SettingsDlg dlg = new SettingsDlg())
            {
                bool bIsDark = mainThemeMgr.Theme == MetroFramework.MetroThemeStyle.Dark ? true : false;
                dlg.EventDarkTheme += ChangeThemeDark;
                dlg.EventLatestExeSave += ChangeLatestExeLog;
                dlg.EventChangeStringArray += ChangeStrArray;
                dlg.SetInit(bIsDark, m_bIsLatestExeSave, m_arrStrIgnoreFolders, m_arrStrIgnoreEx);

                DialogResult dialogResult = dlg.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    if (mainThemeMgr.Theme == MetroFramework.MetroThemeStyle.Dark)
                        AppConfigMgr.SetAppConfig(APP_THEME, THEME_DARK);
                    else
                        AppConfigMgr.SetAppConfig(APP_THEME, THEME_LIGHT);

                    if (m_bIsLatestExeSave)
                        AppConfigMgr.SetAppConfig(APP_LATEST_EXE_SAVE, "true");
                    else
                        AppConfigMgr.SetAppConfig(APP_LATEST_EXE_SAVE, "false");

                    AppConfigMgr.SetAppConfig(APP_IGNORE_FOLDERS, MergeString(m_arrStrIgnoreFolders, ','));
                    AppConfigMgr.SetAppConfig(APP_IGNORE_EXTENDS, MergeString(m_arrStrIgnoreEx, ','));
                }
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_thrChange != null)
                m_thrChange.Join();

            if (m_bIsLatestExeSave)
            {
                if (string.IsNullOrEmpty(tBoxPrjPath.Text) == false)
                    AppConfigMgr.SetAppConfig(APP_LATEST_PROJECT_PATH, tBoxPrjPath.Text);

                if (string.IsNullOrEmpty(tBoxPrjName.Text) == false)
                    AppConfigMgr.SetAppConfig(APP_LATEST_PROJECT_NAME, tBoxPrjName.Text);
            }
        }
    }
}
