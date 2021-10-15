using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAH_Aircraft_DBExtractor
{
    class UICheckFuntion
    {
        TextBox programStatus;
        DataGridView dbDataGridView;
        public UICheckFuntion(TextBox _programStatus, DataGridView _dataGridView)
        {
            programStatus = _programStatus;
            dbDataGridView = _dataGridView;
        }

        public void UIInputDataCheck(bool inputCheck)
        {
            if (inputCheck == false)
                programStatus.Text = "IP, DBID, DBPW 입력이 필요합니다.";
            else
                programStatus.Text = "연결 확인";
        }

        public void UISQLConnectFail()
        {
            programStatus.Text = "데이터베이스 연결에 실패하였습니다.";
        }

        public void UISQLDataSave(bool check)
        {
            if (check == true)
                programStatus.Text = "추출 완료";
            else
                programStatus.Text = "추출에 실패하였습니다. SQL 연결 또는 테이블 데이터를 확인해주세요.";
        }

        public void UISQLALLDataSave(bool check)
        {
            if (check == true)
                programStatus.Text = "전체 추출 완료";
            else
                programStatus.Text = "추출에 실패하였습니다. SQL 연결 또는 테이블 데이터를 확인해주세요.";
        }

        public void UISQLDataTable(bool check)
        {
            if (check == true)
                programStatus.Text = "테이블 생성 완료";
            else
                programStatus.Text = "테이블 생성에 실패하였습니다. SQL 연결 또는 테이블 데이터를 확인해주세요.";
        }

        public void DBConnectCheck(string connCheck)
        {
            if (connCheck != null)
                programStatus.Text = connCheck;
            else
                UISQLConnectFail();
        }

        public void DBTableData(DataTable datatable)
        {
            dbDataGridView.DataSource = datatable;
        }
    }
}
