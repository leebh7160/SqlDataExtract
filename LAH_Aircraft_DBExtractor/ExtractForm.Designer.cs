
namespace LAH_Aircraft_DBExtractor
{
    partial class ExtractForm
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
            this.Version = new System.Windows.Forms.Label();
            this.IPInputLabel = new System.Windows.Forms.Label();
            this.IDInputLabel = new System.Windows.Forms.Label();
            this.PWInputLabel = new System.Windows.Forms.Label();
            this.SelectTable = new System.Windows.Forms.Label();
            this.TextBox_InputIP = new System.Windows.Forms.TextBox();
            this.TextBox_InputDBID = new System.Windows.Forms.TextBox();
            this.TextBox_InputDBPW = new System.Windows.Forms.TextBox();
            this.ComboBox_SelectTable = new System.Windows.Forms.ComboBox();
            this.DBDataGridView = new System.Windows.Forms.DataGridView();
            this.DBInterLock = new System.Windows.Forms.Button();
            this.DBDataCheckButton = new System.Windows.Forms.Button();
            this.ExtractCSV = new System.Windows.Forms.Button();
            this.ProgramStatus = new System.Windows.Forms.TextBox();
            this.ExtractCSVAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DBDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Location = new System.Drawing.Point(12, 9);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(188, 12);
            this.Version.TabIndex = 0;
            this.Version.Text = "LAH_Aircraft_DBExtractor 0.3Ver ";
            // 
            // IPInputLabel
            // 
            this.IPInputLabel.AutoSize = true;
            this.IPInputLabel.Location = new System.Drawing.Point(12, 37);
            this.IPInputLabel.Name = "IPInputLabel";
            this.IPInputLabel.Size = new System.Drawing.Size(40, 12);
            this.IPInputLabel.TabIndex = 1;
            this.IPInputLabel.Text = "IP입력";
            // 
            // IDInputLabel
            // 
            this.IDInputLabel.AutoSize = true;
            this.IDInputLabel.Location = new System.Drawing.Point(12, 63);
            this.IDInputLabel.Name = "IDInputLabel";
            this.IDInputLabel.Size = new System.Drawing.Size(56, 12);
            this.IDInputLabel.TabIndex = 2;
            this.IDInputLabel.Text = "DBID입력";
            // 
            // PWInputLabel
            // 
            this.PWInputLabel.AutoSize = true;
            this.PWInputLabel.Location = new System.Drawing.Point(12, 89);
            this.PWInputLabel.Name = "PWInputLabel";
            this.PWInputLabel.Size = new System.Drawing.Size(63, 12);
            this.PWInputLabel.TabIndex = 3;
            this.PWInputLabel.Text = "DBPW입력";
            // 
            // SelectTable
            // 
            this.SelectTable.AutoSize = true;
            this.SelectTable.Location = new System.Drawing.Point(12, 115);
            this.SelectTable.Name = "SelectTable";
            this.SelectTable.Size = new System.Drawing.Size(69, 12);
            this.SelectTable.TabIndex = 4;
            this.SelectTable.Text = "테이블 선택";
            // 
            // TextBox_InputIP
            // 
            this.TextBox_InputIP.Location = new System.Drawing.Point(100, 34);
            this.TextBox_InputIP.Name = "TextBox_InputIP";
            this.TextBox_InputIP.Size = new System.Drawing.Size(168, 21);
            this.TextBox_InputIP.TabIndex = 5;
            // 
            // TextBox_InputDBID
            // 
            this.TextBox_InputDBID.Location = new System.Drawing.Point(100, 60);
            this.TextBox_InputDBID.Name = "TextBox_InputDBID";
            this.TextBox_InputDBID.Size = new System.Drawing.Size(168, 21);
            this.TextBox_InputDBID.TabIndex = 6;
            // 
            // TextBox_InputDBPW
            // 
            this.TextBox_InputDBPW.Location = new System.Drawing.Point(100, 86);
            this.TextBox_InputDBPW.Name = "TextBox_InputDBPW";
            this.TextBox_InputDBPW.Size = new System.Drawing.Size(168, 21);
            this.TextBox_InputDBPW.TabIndex = 7;
            // 
            // ComboBox_SelectTable
            // 
            this.ComboBox_SelectTable.FormattingEnabled = true;
            this.ComboBox_SelectTable.Location = new System.Drawing.Point(100, 113);
            this.ComboBox_SelectTable.Name = "ComboBox_SelectTable";
            this.ComboBox_SelectTable.Size = new System.Drawing.Size(168, 20);
            this.ComboBox_SelectTable.TabIndex = 8;
            this.ComboBox_SelectTable.TextChanged += new System.EventHandler(this.ComboBox_SelectTable_TextChanged);
            // 
            // DBDataGridView
            // 
            this.DBDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBDataGridView.Location = new System.Drawing.Point(274, 34);
            this.DBDataGridView.Name = "DBDataGridView";
            this.DBDataGridView.ReadOnly = true;
            this.DBDataGridView.RowTemplate.Height = 23;
            this.DBDataGridView.Size = new System.Drawing.Size(514, 170);
            this.DBDataGridView.TabIndex = 9;
            // 
            // DBInterLock
            // 
            this.DBInterLock.Location = new System.Drawing.Point(13, 141);
            this.DBInterLock.Name = "DBInterLock";
            this.DBInterLock.Size = new System.Drawing.Size(55, 63);
            this.DBInterLock.TabIndex = 10;
            this.DBInterLock.Text = "DB연결";
            this.DBInterLock.UseVisualStyleBackColor = true;
            this.DBInterLock.Click += new System.EventHandler(this.DBInterLock_Click);
            // 
            // DBDataCheckButton
            // 
            this.DBDataCheckButton.Location = new System.Drawing.Point(74, 141);
            this.DBDataCheckButton.Name = "DBDataCheckButton";
            this.DBDataCheckButton.Size = new System.Drawing.Size(46, 63);
            this.DBDataCheckButton.TabIndex = 11;
            this.DBDataCheckButton.Text = "Table확인";
            this.DBDataCheckButton.UseVisualStyleBackColor = true;
            this.DBDataCheckButton.Click += new System.EventHandler(this.DBDataCheckButton_Click);
            // 
            // ExtractCSV
            // 
            this.ExtractCSV.Location = new System.Drawing.Point(126, 141);
            this.ExtractCSV.Name = "ExtractCSV";
            this.ExtractCSV.Size = new System.Drawing.Size(69, 63);
            this.ExtractCSV.TabIndex = 12;
            this.ExtractCSV.Text = "CSV 파일 선택 추출";
            this.ExtractCSV.UseVisualStyleBackColor = true;
            this.ExtractCSV.Click += new System.EventHandler(this.ExtractCSV_Click);
            // 
            // ProgramStatus
            // 
            this.ProgramStatus.Location = new System.Drawing.Point(14, 210);
            this.ProgramStatus.Multiline = true;
            this.ProgramStatus.Name = "ProgramStatus";
            this.ProgramStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProgramStatus.Size = new System.Drawing.Size(774, 51);
            this.ProgramStatus.TabIndex = 13;
            // 
            // ExtractCSVAll
            // 
            this.ExtractCSVAll.Location = new System.Drawing.Point(201, 141);
            this.ExtractCSVAll.Name = "ExtractCSVAll";
            this.ExtractCSVAll.Size = new System.Drawing.Size(67, 63);
            this.ExtractCSVAll.TabIndex = 14;
            this.ExtractCSVAll.Text = "CSV파일 전체 추출";
            this.ExtractCSVAll.UseVisualStyleBackColor = true;
            this.ExtractCSVAll.Click += new System.EventHandler(this.ExtractCSVAll_Click);
            // 
            // ExtractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 271);
            this.Controls.Add(this.ExtractCSVAll);
            this.Controls.Add(this.ProgramStatus);
            this.Controls.Add(this.ExtractCSV);
            this.Controls.Add(this.DBDataCheckButton);
            this.Controls.Add(this.DBInterLock);
            this.Controls.Add(this.DBDataGridView);
            this.Controls.Add(this.ComboBox_SelectTable);
            this.Controls.Add(this.TextBox_InputDBPW);
            this.Controls.Add(this.TextBox_InputDBID);
            this.Controls.Add(this.TextBox_InputIP);
            this.Controls.Add(this.SelectTable);
            this.Controls.Add(this.PWInputLabel);
            this.Controls.Add(this.IDInputLabel);
            this.Controls.Add(this.IPInputLabel);
            this.Controls.Add(this.Version);
            this.Name = "ExtractForm";
            this.Text = "LAH_Aircraft_DBExtractor 0.3Ver ";
            ((System.ComponentModel.ISupportInitialize)(this.DBDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label IPInputLabel;
        private System.Windows.Forms.Label IDInputLabel;
        private System.Windows.Forms.Label PWInputLabel;
        private System.Windows.Forms.Label SelectTable;
        private System.Windows.Forms.TextBox TextBox_InputIP;
        private System.Windows.Forms.TextBox TextBox_InputDBID;
        private System.Windows.Forms.TextBox TextBox_InputDBPW;
        private System.Windows.Forms.ComboBox ComboBox_SelectTable;
        private System.Windows.Forms.DataGridView DBDataGridView;
        private System.Windows.Forms.Button DBInterLock;
        private System.Windows.Forms.Button DBDataCheckButton;
        private System.Windows.Forms.Button ExtractCSV;
        private System.Windows.Forms.TextBox ProgramStatus;
        private System.Windows.Forms.Button ExtractCSVAll;
    }
}

