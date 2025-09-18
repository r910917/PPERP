using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PPERP
{
    public partial class frm4DBConnect : Form
    {
        //全域變數宣告區
        //1.宣告connection變數
        SqlConnection dbConn;

        public frm4DBConnect()
        {
            InitializeComponent();
        }

        private void frm4DBConnect_Load(object sender, EventArgs e)
        {

        }

        //連線登入按鈕
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(dbConn != null && dbConn.State == ConnectionState.Open)
            {
                MessageBox.Show("資料庫已連線中, 不需要重新連線");
            } else
            {
                try
                {
                    //2.設定連線登入資料
                    dbConn = new SqlConnection("data source=(local); user id=sa; password=mis2024; initial catalog=PPERP");
                    //3.進行連線
                    dbConn.Open();
                    //4.回應成功訊息
                    MessageBox.Show("連線登入成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線登入失敗");
                }
            }
        }

        //關閉連線按鈕
        private void btnClose_Click(object sender, EventArgs e)
        {
            if(dbConn != null)
            {
                dbConn.Close();
                MessageBox.Show("已關閉連線");
            } else
            {
                MessageBox.Show("尚未連線登入");
            }
        }

        //檢查資料庫連線狀態按鈕
        private void btnStatus_Click(object sender, EventArgs e)
        {
            if(dbConn != null)
            {
                if (dbConn.State == ConnectionState.Open)
                {
                    MessageBox.Show("資料庫連線中....");
                }
                else if (dbConn.State == ConnectionState.Closed)
                {
                    MessageBox.Show("資料庫連線已關閉....");
                }
                else
                {
                    MessageBox.Show("資料庫連線已中斷....");
                }
            } else
            {
                MessageBox.Show("別白目....");
            }
        }
    }
}
