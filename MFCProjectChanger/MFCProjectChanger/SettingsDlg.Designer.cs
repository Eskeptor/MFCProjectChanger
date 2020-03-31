namespace MFCProjectChanger
{
    partial class SettingsDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.toggleDarkMode = new MetroFramework.Controls.MetroToggle();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.toggleLastPathLog = new MetroFramework.Controls.MetroToggle();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.tBoxFolderFilter = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.tBoxExeFilter = new MetroFramework.Controls.MetroTextBox();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnSet = new MetroFramework.Controls.MetroButton();
            this.settingThemeMgr = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.settingThemeMgr)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(34, 81);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "다크모드";
            // 
            // toggleDarkMode
            // 
            this.toggleDarkMode.AutoSize = true;
            this.toggleDarkMode.Location = new System.Drawing.Point(141, 84);
            this.toggleDarkMode.Name = "toggleDarkMode";
            this.toggleDarkMode.Size = new System.Drawing.Size(80, 16);
            this.toggleDarkMode.TabIndex = 1;
            this.toggleDarkMode.Text = "Off";
            this.toggleDarkMode.UseVisualStyleBackColor = true;
            this.toggleDarkMode.CheckedChanged += new System.EventHandler(this.toggleDarkMode_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(34, 116);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(83, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "최근값 기억";
            // 
            // toggleLastPathLog
            // 
            this.toggleLastPathLog.AutoSize = true;
            this.toggleLastPathLog.Location = new System.Drawing.Point(141, 116);
            this.toggleLastPathLog.Name = "toggleLastPathLog";
            this.toggleLastPathLog.Size = new System.Drawing.Size(80, 16);
            this.toggleLastPathLog.TabIndex = 3;
            this.toggleLastPathLog.Text = "Off";
            this.toggleLastPathLog.UseVisualStyleBackColor = true;
            this.toggleLastPathLog.CheckedChanged += new System.EventHandler(this.toggleLastPathLog_CheckedChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(34, 151);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(83, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "폴더 필터링";
            // 
            // tBoxFolderFilter
            // 
            this.tBoxFolderFilter.Location = new System.Drawing.Point(141, 148);
            this.tBoxFolderFilter.Name = "tBoxFolderFilter";
            this.tBoxFolderFilter.Size = new System.Drawing.Size(430, 23);
            this.tBoxFolderFilter.TabIndex = 5;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(34, 186);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(97, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "확장자 필터링";
            // 
            // tBoxExeFilter
            // 
            this.tBoxExeFilter.Location = new System.Drawing.Point(141, 185);
            this.tBoxExeFilter.Name = "tBoxExeFilter";
            this.tBoxExeFilter.Size = new System.Drawing.Size(430, 23);
            this.tBoxExeFilter.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(468, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 36);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "취소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(359, 231);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(103, 36);
            this.btnSet.TabIndex = 9;
            this.btnSet.Text = "적용";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // settingThemeMgr
            // 
            this.settingThemeMgr.Owner = this;
            // 
            // SettingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 290);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tBoxExeFilter);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.tBoxFolderFilter);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.toggleLastPathLog);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.toggleDarkMode);
            this.Controls.Add(this.metroLabel1);
            this.Name = "SettingsDlg";
            this.Resizable = false;
            this.Text = "설정";
            ((System.ComponentModel.ISupportInitialize)(this.settingThemeMgr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroToggle toggleDarkMode;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroToggle toggleLastPathLog;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox tBoxFolderFilter;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox tBoxExeFilter;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnSet;
        private MetroFramework.Components.MetroStyleManager settingThemeMgr;
    }
}