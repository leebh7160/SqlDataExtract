using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace LAH_Aircraft_DBExtractor
{
    class DataCheckFuntion
    {
        private DataTable dbTable;
        private DBManager dbManager;
        private UICheckFuntion uICheckFuntion;

        private List<string> tableNameList;

        public DataCheckFuntion(TextBox programStatus, DataGridView dbDataGridView)
        {
            dbManager = new DBManager();
            tableNameList = new List<string>();
            uICheckFuntion = new UICheckFuntion(programStatus, dbDataGridView);
        }

        //SQL 연결 세팅
        private bool FUN_DataInputCheck(string ip, string dbid, string dbpw, string database)
        {
            if (string.IsNullOrWhiteSpace(ip) && string.IsNullOrWhiteSpace(dbid) && string.IsNullOrWhiteSpace(dbpw))
            {
                uICheckFuntion.UIInputDataCheck(false);
                return false;
            }
            try
            {
                dbManager.DBIPSet(ip, dbid, dbpw, database);
                return true;
            }
            catch
            {
                uICheckFuntion.UISQLConnectFail();
                return false;
            }
        }

        //SQL연결
        public bool FUN_SQLConnect(string ip, string dbid, string dbpw, string database)
        {
            if (dbTable != null)
            {
                dbTable.Rows.Clear();
                dbTable.Columns.Clear();
            }

            if (FUN_DataInputCheck(ip, dbid, dbpw, database) == false) return false;
            if (dbManager.DBConnect() == null)
            {
                uICheckFuntion.UISQLConnectFail();
                return false;
            }
            uICheckFuntion.DBConnectCheck(ip + " 연결 완료");
            return true;
        }

        public void FUN_SQLTableColumnName(string tablename)
        {
            List<string> tableNameList = new List<string>();
            tableNameList.AddRange(dbManager.GetDBTableColumnName(tablename));
        }

        public List<string> FUN_GetTableName()
        {
            return dbManager.GetDBTableName();
        }

        public void FUN_SetTableData(string tablename)
        {
            if (dbTable != null)
            {
                dbTable.Rows.Clear();
                dbTable.Columns.Clear();
            }
            dbTable = dbManager.GetDBTableData(tablename).Tables[0];
        }

        public void FUN_GetAllTableData(List<string> tableNameList)
        {
            if (dbTable != null)
                dbTable.Clear();
            List<DataTable> dataTableList = new List<DataTable>();
            dataTableList = dbManager.GetDBAllTableData(tableNameList);
            SaveAllCSVData(dataTableList);
        }

        public void FUN_TableShow()
        {
            if (dbTable == null) return;

                if (dbTable.Rows.Count != 0 && dbTable.Columns.Count != 0)
                {
                    uICheckFuntion.DBTableData(dbTable);
                    uICheckFuntion.UISQLDataTable(true);
                }
                else
                    uICheckFuntion.UISQLDataTable(false);
        }

        //================================================================================
        //파일 세이브 다이얼로그
        public string SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV File|*.csv";
            saveFileDialog.Title = "CSV File Save";
            saveFileDialog.InitialDirectory = @"C:";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                return saveFileDialog.FileName.ToString();
            }
            return null;
        }

        public void SaveSQLData(string tablename)
        {
            string fileName;

            if (dbTable == null) return;

            if (dbTable.Rows.Count != 0 && dbTable.Columns.Count != 0)
            {
                FileStream filestream;
                //fileName = SaveFileDialog();
                fileName = System.IO.Directory.GetCurrentDirectory() + @"\CSV\" + tablename.Substring(4) + ".csv";
                if (fileName != null)
                    filestream = File.Create(fileName);
                else
                    return;

                StreamWriter streamwriter = new StreamWriter(filestream, Encoding.UTF8);

                SQLDataNameExtract(dbTable, streamwriter);
                SQLDataExtract(dbTable, streamwriter);

                streamwriter.Close();
                filestream.Close();

                uICheckFuntion.UISQLDataSave(true);
            }
            else
                uICheckFuntion.UISQLDataSave(false);
        }

        public void SaveAllCSVData(List<DataTable> tableList)
        {
            string fileName;
            if(tableList.Count != 0)
            {
                foreach (DataTable eachTable in tableList)
                {
                    FileStream fileStream;
                    StreamWriter streamwriter;
                    
                    fileName = System.IO.Directory.GetCurrentDirectory() + @"\CSV\" + eachTable.TableName.Substring(4) + ".csv";
                    if (fileName != null)
                        fileStream = File.Create(fileName);
                    else
                        return;

                    streamwriter = new StreamWriter(fileStream, Encoding.UTF8);

                    SQLDataNameExtract(eachTable, streamwriter);
                    SQLDataExtract(eachTable, streamwriter);

                    streamwriter.Close();
                    fileStream.Close();
                }

                uICheckFuntion.UISQLALLDataSave(true);
            }
            else
                uICheckFuntion.UISQLALLDataSave(false);

        }

        private void SQLDataNameExtract(DataTable datatable, StreamWriter _streamwriter)
        {
            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                string tempString;
                tempString = "\"{0}";

                if (i < datatable.Columns.Count - 1)
                    tempString += "\",";
                else
                    tempString += "\"\n";

                _streamwriter.Write(tempString, datatable.Columns[i].ColumnName.ToString());
            }
        }
        private void SQLDataExtract(DataTable datatable, StreamWriter _streamwriter)
        {
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                for (int j = 0; j < datatable.Columns.Count; j++)
                {
                    string tempString;
                    tempString = "\"{0}";

                    if (j < datatable.Columns.Count - 1)
                        tempString += "\",";
                    else
                        tempString += "\"\n";

                    if (datatable.Rows[i].ItemArray[j].ToString() != "")
                        _streamwriter.Write(tempString, datatable.Rows[i].ItemArray[j].ToString());
                    else
                        _streamwriter.Write(tempString, "NULL");
                }
            }
        }
        //================================================================================

    }

}
