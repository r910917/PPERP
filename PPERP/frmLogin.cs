using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPERP
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //登入按鈕
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //帳號密碼是否輸入完整
            if (string.IsNullOrWhiteSpace(txtLoginID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("帳號密碼未輸入", "登入失敗");
            } else
            {
                //1.連線資料庫
                //(1)宣告connection變數
                SqlConnection dbConn;
                //(2)設定連線登入資料
                cls5DB newDB = new cls5DB();
                dbConn = newDB.LoginDB();
                if (dbConn == null)
                {
                    MessageBox.Show("連線登入失敗");
                    return;
                }

                //2.執行資料庫 Select 命令
                //Select usr_Name, dep_ID, usr_Auth From Users Where usr_ID='2019001' And password='123'
                //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbConn;
                cmd.CommandText = "Select usr_Name, dep_ID, usr_Auth From Users Where usr_ID=@usr_ID And password=@password";
                cmd.Parameters.AddWithValue("@usr_ID", txtLoginID.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                //(2)執行Select命令, 結果存在DataReader
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                //3.畫面顯示群組名稱
                if (dr.HasRows)
                {
                    //帳密正確, 隱藏
                    this.Hide();
                }
                else
                {
                    //帳密錯誤
                    
                    MessageBox.Show("帳號密碼錯誤, 請重新輸入", "登入失敗");
                }

                dr.Close();

                //5.關閉資料庫連線
                dbConn.Close();

                //if (txtLoginID.Text.Trim() == "2019001" && txtPassword.Text.Trim() == "123")
                //{
                //    //帳密正確, 隱藏
                //    this.Hide();
                //}
                //else
                //{
                //    //帳密錯誤
                //    MessageBox.Show("帳號密碼錯誤, 請重新輸入", "登入失敗");
                //}
            }
        }

        //離開按鈕-結束系統
        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit(); //結束程式執行
        }

        //關閉登入表單-結束系統
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnEnd.PerformClick();  //點按離開按鈕
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
