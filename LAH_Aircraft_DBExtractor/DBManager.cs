using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAH_Aircraft_DBExtractor
{
    class DBManager
    {
        private string source;
        private SqlConnection conn;
        private List<string> tableNameList = new List<string>();
        private List<string> tableColumnNameList = new List<string>();

        public DBManager() { }

        //DB이름 없이 세팅
        public void DBIPSet(string ip, string uid, string pwd, string database)
        {
            string tempipset;
            tempipset = @"server=" + ip + ";uid=" + uid + ";pwd=" + pwd + ";database = " + database;
            source = null;
            source = tempipset;
        }

        public string DBConnect()
        {
            try
            {
                conn = new SqlConnection(source);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Closed)
                        throw new Exception();
                    return conn.State.ToString();
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public List<string> GetDBTableName()
        {
            tableColumnNameList.Clear();
            string sql = "Select table_name from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Tbl_Aircraft_Prerequisites_Action' or TABLE_NAME = 'Tbl_Aircraft_Relation_Action' or TABLE_NAME = 'Tbl_Aircraft_Variable' or TABLE_NAME = 'Tbl_Aircraft_Together_Animation'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            tableNameList.Clear();
            while (reader.Read())
            {
                tableNameList.Add(reader.GetString(0));
            }

            reader.Close();
            return tableNameList;
        }

        //테이블 열 이름 가져옴
        //Select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Tbl_Aircraft_Variable'
        public List<string> GetDBTableColumnName(string tablename)
        {
            tableColumnNameList.Clear();
            List<string> tableColumnName = new List<string>();
            string sql = "Select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @paramTABLENAME";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@paramTABLENAME", tablename);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tableColumnName.Add(reader.GetString(0));
            }
            tableColumnNameList.AddRange(tableColumnName);
            reader.Close();
            return tableColumnNameList;
        }

        //DB테이블 하나 가져오기
        public DataSet GetDBTableData(string tablename)
        {
            DataSet ds = new DataSet();
            string sql = "Select * from " + tablename;

            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
            {
                adapter.Fill(ds);
            }

            return ds;
        }

        //DB테이블 전부 가져오기
        public List<DataTable> GetDBAllTableData(List<string> tableNameList)
        {
            List<DataTable> dataTableList = new List<DataTable>();

            for (int i = 0; i < tableNameList.Count; i++)
            {
                DataTable dt = new DataTable();
                string sql = "Select * from " + tableNameList[i];

                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    adapter.Fill(dt);
                }
                dataTableList.Add(dt);
                dataTableList[i].TableName = tableNameList[i];
            }

            return dataTableList;
        }
    }
}