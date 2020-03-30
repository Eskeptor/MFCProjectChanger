namespace MFCProjectChanger
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPrjPath = new MetroFramework.Controls.MetroLabel();
            this.lblPrjName = new MetroFramework.Controls.MetroLabel();
            this.lblPrjChangeName = new MetroFramework.Controls.MetroLabel();
            this.tBoxPrjPath = new MetroFramework.Controls.MetroTextBox();
            this.tBoxPrjName = new MetroFramework.Controls.MetroTextBox();
            this.tBoxPrjChangeName = new MetroFramework.Controls.MetroTextBox();
            this.btnPrjPath = new MetroFramework.Controls.MetroButton();
            this.pgbarChange = new MetroFramework.Controls.MetroProgressBar();
            this.btnPrjChange = new MetroFramework.Controls.MetroButton();
            this.tBoxLog = new MetroFramework.Controls.MetroTextBox();
            this.lblPrjLog = new MetroFramework.Controls.MetroLabel();
            this.btnSettings = new MetroFramework.Controls.MetroButton();
            this.mainThemeMgr = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainThemeMgr)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrjPath
            // 
            this.lblPrjPath.AutoSize = true;
            this.lblPrjPath.Location = new System.Drawing.Point(32, 83);
            this.lblPrjPath.Name = "lblPrjPath";
            this.lblPrjPath.Size = new System.Drawing.Size(97, 19);
            this.lblPrjPath.TabIndex = 0;
            this.lblPrjPath.Text = "프로젝트 경로";
            // 
            // lblPrjName
            // 
            this.lblPrjName.AutoSize = true;
            this.lblPrjName.Location = new System.Drawing.Point(32, 123);
            this.lblPrjName.Name = "lblPrjName";
            this.lblPrjName.Size = new System.Drawing.Size(79, 19);
            this.lblPrjName.TabIndex = 1;
            this.lblPrjName.Text = "프로젝트명";
            // 
            // lblPrjChangeName
            // 
            this.lblPrjChangeName.AutoSize = true;
            this.lblPrjChangeName.Location = new System.Drawing.Point(32, 164);
            this.lblPrjChangeName.Name = "lblPrjChangeName";
            this.lblPrjChangeName.Size = new System.Drawing.Size(111, 19);
            this.lblPrjChangeName.TabIndex = 2;
            this.lblPrjChangeName.Text = "변경 프로젝트명";
            // 
            // tBoxPrjPath
            // 
            this.tBoxPrjPath.Location = new System.Drawing.Point(188, 80);
            this.tBoxPrjPath.Name = "tBoxPrjPath";
            this.tBoxPrjPath.Size = new System.Drawing.Size(504, 23);
            this.tBoxPrjPath.TabIndex = 3;
            // 
            // tBoxPrjName
            // 
            this.tBoxPrjName.Location = new System.Drawing.Point(188, 122);
            this.tBoxPrjName.Name = "tBoxPrjName";
            this.tBoxPrjName.Size = new System.Drawing.Size(504, 23);
            this.tBoxPrjName.TabIndex = 4;
            // 
            // tBoxPrjChangeName
            // 
            this.tBoxPrjChangeName.Location = new System.Drawing.Point(188, 163);
            this.tBoxPrjChangeName.Name = "tBoxPrjChangeName";
            this.tBoxPrjChangeName.Size = new System.Drawing.Size(504, 23);
            this.tBoxPrjChangeName.TabIndex = 5;
            // 
            // btnPrjPath
            // 
            this.btnPrjPath.Location = new System.Drawing.Point(717, 80);
            this.btnPrjPath.Name = "btnPrjPath";
            this.btnPrjPath.Size = new System.Drawing.Size(124, 23);
            this.btnPrjPath.TabIndex = 6;
            this.btnPrjPath.Text = "찾아보기";
            this.btnPrjPath.Click += new System.EventHandler(this.btnPrjPath_Click);
            // 
            // pgbarChange
            // 
            this.pgbarChange.Location = new System.Drawing.Point(717, 176);
            this.pgbarChange.Name = "pgbarChange";
            this.pgbarChange.Size = new System.Drawing.Size(124, 10);
            this.pgbarChange.TabIndex = 7;
            // 
            // btnPrjChange
            // 
            this.btnPrjChange.Location = new System.Drawing.Point(717, 122);
            this.btnPrjChange.Name = "btnPrjChange";
            this.btnPrjChange.Size = new System.Drawing.Size(124, 54);
            this.btnPrjChange.TabIndex = 8;
            this.btnPrjChange.Text = "변경";
            this.btnPrjChange.Click += new System.EventHandler(this.btnPrjChange_Click);
            // 
            // tBoxLog
            // 
            this.tBoxLog.Location = new System.Drawing.Point(188, 204);
            this.tBoxLog.Multiline = true;
            this.tBoxLog.Name = "tBoxLog";
            this.tBoxLog.ReadOnly = true;
            this.tBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxLog.Size = new System.Drawing.Size(504, 236);
            this.tBoxLog.TabIndex = 9;
            // 
            // lblPrjLog
            // 
            this.lblPrjLog.AutoSize = true;
            this.lblPrjLog.Location = new System.Drawing.Point(32, 204);
            this.lblPrjLog.Name = "lblPrjLog";
            this.lblPrjLog.Size = new System.Drawing.Size(37, 19);
            this.lblPrjLog.TabIndex = 10;
            this.lblPrjLog.Text = "로그";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(717, 417);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(124, 23);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.Text = "설정";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // mainThemeMgr
            // 
            this.mainThemeMgr.Owner = this;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 462);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblPrjLog);
            this.Controls.Add(this.tBoxLog);
            this.Controls.Add(this.btnPrjChange);
            this.Controls.Add(this.pgbarChange);
            this.Controls.Add(this.btnPrjPath);
            this.Controls.Add(this.tBoxPrjChangeName);
            this.Controls.Add(this.tBoxPrjName);
            this.Controls.Add(this.tBoxPrjPath);
            this.Controls.Add(this.lblPrjChangeName);
            this.Controls.Add(this.lblPrjName);
            this.Controls.Add(this.lblPrjPath);
            this.Name = "FrmMain";
            this.Resizable = false;
            this.Text = "MFC 프로젝트명 변경";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainThemeMgr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblPrjPath;
        private MetroFramework.Controls.MetroLabel lblPrjName;
        private MetroFramework.Controls.MetroLabel lblPrjChangeName;
        private MetroFramework.Controls.MetroTextBox tBoxPrjPath;
        private MetroFramework.Controls.MetroTextBox tBoxPrjName;
        private MetroFramework.Controls.MetroTextBox tBoxPrjChangeName;
        private MetroFramework.Controls.MetroButton btnPrjPath;
        private MetroFramework.Controls.MetroProgressBar pgbarChange;
        private MetroFramework.Controls.MetroButton btnPrjChange;
        private MetroFramework.Controls.MetroTextBox tBoxLog;
        private MetroFramework.Controls.MetroLabel lblPrjLog;
        private MetroFramework.Controls.MetroButton btnSettings;
        private MetroFramework.Components.MetroStyleManager mainThemeMgr;
    }
}

