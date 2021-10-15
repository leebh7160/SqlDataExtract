using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAH_Aircraft_DBExtractor
{
    public partial class ExtractForm : Form
    {
        string INIInputIP;
        string INIInputDBID;
        string INIInputDBPW;
        string INIDatabaseName;

        INIClass iniClass;
        DataCheckFuntion dataCheckFuntion;
        List<string> tableNameList;

        public ExtractForm()
        {
            InitializeComponent();
            tableNameList = new List<string>();
            dataCheckFuntion = new DataCheckFuntion(ProgramStatus, DBDataGridView);
            iniClass = new INIClass(System.IO.Directory.GetCurrentDirectory() + @"\Config.ini");
            INISetting();
        }

        private void INISetting()
        {
            INIInputIP = iniClass.GetINIValue("NET", "DEFAULT_IP");
            INIInputDBID = iniClass.GetINIValue("NET", "DEFAULT_DBID");
            INIInputDBPW = iniClass.GetINIValue("NET", "DEFAULT_DBPW");
            INIDatabaseName = iniClass.GetINIValue("NET", "DATABASENAME");

            TextBox_InputIP.Text = INIInputIP;
            TextBox_InputDBID.Text = INIInputDBID;
            TextBox_InputDBPW.Text = INIInputDBPW;
        }


        //========================ComboBox Data Change================================vvv
        private void SetTableName(List<string> tablename)
        {
            ComboBox_SelectTable.Items.Clear();
            for (int i = 0; i < tablename.Count; i++)
            {
                switch (tablename[i])
                {
                    case "Tbl_Aircraft_Variable":
                        ComboBox_SelectTable.Items.Add("Aircraft 객체 테이블");
                        break;
                    case "Tbl_Aircraft_Relation_Action":
                        ComboBox_SelectTable.Items.Add("관계 테이블");
                        break;
                    case "Tbl_Aircraft_Prerequisites_Action":
                        ComboBox_SelectTable.Items.Add("구성 요소 테이블");
                        break;
                    case "Tbl_Aircraft_Together_Animation":
                        ComboBox_SelectTable.Items.Add("연동 객체 테이블");
                        break;
                }
            }
        }
        //========================ComboBox Data Change================================^^^

        private void DBInterLock_Click(object sender, EventArgs e)
        {
            string textboxInputIP = TextBox_InputIP.Text;
            string textBoxInputDBID = TextBox_InputDBID.Text;
            string textBoxInputDBPW = TextBox_InputDBPW.Text;
            string textDatabaseName = INIDatabaseName;

            ComboBox_SelectTable.Text = null;
            ComboBox_SelectTable.Items.Clear();
            DBDataGridView.DataSource = null;

            if (textDatabaseName != null)
            {
                //SQL연결 및 테이블 이름 추출
                if (dataCheckFuntion.FUN_SQLConnect(textboxInputIP, textBoxInputDBID, textBoxInputDBPW, textDatabaseName) == false) return;

                tableNameList.Clear();
                tableNameList.AddRange(dataCheckFuntion.FUN_GetTableName());
                SetTableName(tableNameList);
            }

        }

        //테이블 선택 시
        //UTF-8 형식으로 데이터 추출
        //string형식으로 유니코드 변환없이 추출되는지 확인
        private void ComboBox_SelectTable_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox_SelectTable.Text != "")
            {
                string tableText;
                switch (ComboBox_SelectTable.Text)
                {
                    case "Aircraft 객체 테이블":
                        tableText = "Tbl_Aircraft_Variable";
                        break;
                    case "관계 테이블":
                        tableText = "Tbl_Aircraft_Relation_Action";
                        break;
                    case "구성 요소 테이블":
                        tableText = "Tbl_Aircraft_Prerequisites_Action";
                        break;
                    case "연동 객체 테이블":
                        tableText = "Tbl_Aircraft_Together_Animation";
                        break;
                    default:
                        return;
                }
                dataCheckFuntion.FUN_SQLTableColumnName(tableText);
                dataCheckFuntion.FUN_SetTableData(tableText);
            }
        }

        //테이블 확인
        private void DBDataCheckButton_Click(object sender, EventArgs e)
        {
            dataCheckFuntion.FUN_TableShow();
        }


        //CSV 선택 추출
        private void ExtractCSV_Click(object sender, EventArgs e)
        {
            string tableText;
            switch (ComboBox_SelectTable.Text)
            {
                case "Aircraft 객체 테이블":
                    tableText = "Tbl_Aircraft_Variable";
                    break;
                case "관계 테이블":
                    tableText = "Tbl_Aircraft_Relation_Action";
                    break;
                case "구성 요소 테이블":
                    tableText = "Tbl_Aircraft_Prerequisites_Action";
                    break;
                case "연동 객체 테이블":
                    tableText = "Tbl_Aircraft_Together_Animation";
                    break;
                default:
                    tableText = null;
                    break;
            }
            dataCheckFuntion.SaveSQLData(tableText);
        }

        //CSV 전체 추출
        private void ExtractCSVAll_Click(object sender, EventArgs e)
        {
            dataCheckFuntion.FUN_GetAllTableData(tableNameList);
        }
    }
}
