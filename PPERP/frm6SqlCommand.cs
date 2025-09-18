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
    public partial class frm6SqlCommand : Form
    {
        public frm6SqlCommand()
        {
            InitializeComponent();
        }

        //執行命令按鈕
        private void btnExecute_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";

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
            else
            {
                txtResult.Text += "連線資料庫 ...成功\r\n";
            }

            //2. 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = txtSQL.Text.Trim();

            //3. 執行SQL命令
            try
            {
                if(rdoCUD.Checked)
                {
                    //Insert, Update, Delete命令
                    cmd.ExecuteNonQuery();
                } 
                else 
                {
                    //Select命令
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            txtResult.Text += dr[i].ToString() + "\t";
                        }
                        txtResult.Text += "\r\n"; // Environment.NewLine;

                        //txtResult.Text += dr[0].ToString() + "\r\t"
                        //                + dr[1].ToString() + "\r\t"
                        //                + dr[2].ToString() + "\r\t"
                        //                + dr[3].ToString() + "\r\t"
                        //                + dr[4].ToString() + "\r\t"
                        //                + dr[5].ToString() + "\r\t"
                        //                + dr[6].ToString() + "\r\t";
                        //txtResult.Text += Environment.NewLine; // "\r\n";
                    }
                    dr.Close();

                    ////拿第1筆
                    //dr.Read();
                    //txtResult.Text = dr.GetString(0) + "\r\t"
                    //                + dr.GetString(1) + "\r\t"
                    //                + dr.GetString(2) + "\r\t"
                    //                + dr.GetString(3) + "\r\t"
                    //                + dr.GetInt32(4).ToString() + "\r\t"
                    //                + dr.GetString(5) + "\r\t"
                    //                + dr.GetDateTime(6).ToString();
                    ////拿第2筆
                    //dr.Read();
                    //txtResult.Text += Environment.NewLine; // "\r\n";
                    //txtResult.Text += dr.GetString(0) + "\r\t"
                    //                + dr.GetString(1) + "\r\t"
                    //                + dr.GetString(2) + "\r\t"
                    //                + dr.GetString(3) + "\r\t"
                    //                + dr.GetInt32(4).ToString() + "\r\t"
                    //                + dr.GetString(5) + "\r\t"
                    //                + dr.GetDateTime(6).ToString();
                    ////拿第3筆
                    //dr.Read();
                    //txtResult.Text += Environment.NewLine; // "\r\n";
                    //txtResult.Text += dr.GetString(0) + "\r\t"
                    //                + dr.GetString(1) + "\r\t"
                    //                + dr.GetString(2) + "\r\t"
                    //                + dr.GetString(3) + "\r\t"
                    //                + dr.GetInt32(4).ToString() + "\r\t"
                    //                + dr.GetString(5) + "\r\t"
                    //                + dr.GetDateTime(6).ToString();
                }

                //txtResult.Text += "SQL命令執行成功";
            }
            catch (Exception ex)
            {
                txtResult.Text = "SQL命令執行失敗-" + ex.Message;
            }

            //4. 關閉資料庫連線
            dbConn.Close();

        }

        //查詢按鈕
        private void btnSelect_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";

            //1.檢查是否已輸入群組代碼
            if (string.IsNullOrWhiteSpace(txtGId.Text))
            {
                //未輸入
                MessageBox.Show("要先輸入群組代碼", "輸入錯誤");
            }
            else
            {
                txtResult.Text += "群組代碼輸入檢查 ...通過\r\n";

                //已輸入
                //2.連線資料庫
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
                else
                {
                    txtResult.Text += "連線資料庫 ...成功\r\n";
                }

                //3.執行資料庫 Select 命令
                //Select * From BPGroup Where BPGroupID = '3'
                //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbConn;
                //cmd.CommandText = "Select * From BPGroup Where BPGroupID = '" +  txtGId.Text.Trim()  +  "'";
                cmd.CommandText = "Select * From BPGroup Where BPGroupID = @gID";
                cmd.Parameters.AddWithValue("@gID", txtGId.Text.Trim());

                //(2)執行Select命令, 結果存在DataReader
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                //4.畫面顯示群組名稱
                if(dr.HasRows)
                {
                    dr.Read();
                    txtGName.Text = dr[1].ToString();
                    txtResult.Text += "查詢群組代碼 ...成功\r\n";
                } else
                {
                    txtResult.Text += "沒有這個群組代碼 ...錯誤\r\n";
                    txtGName.Text = "";
                }

                dr.Close();

                //5.關閉資料庫連線
                dbConn.Close();
                txtResult.Text += "關閉連線資料庫 ...成功\r\n";
            }
        }

        //新增按鈕
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //清除執行結果區
            txtResult.Text = "";

            //1.檢查是否已輸入群組代碼, 群組名稱
            if (string.IsNullOrWhiteSpace(txtGId.Text) || string.IsNullOrWhiteSpace(txtGName.Text))
            {
                //輸入不完整
                MessageBox.Show("群組代碼與群組名稱都必須輸入", "輸入值錯誤");
            } else
            {
                txtResult.Text += "群組代碼與群組名稱輸入檢查 ...通過\r\n";

                //檢查群組代碼是否重複
                if(checkGroupIDDuplicated() == true)
                {
                    //未重複
                    //2.連線資料庫
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
                    else
                    {
                        txtResult.Text += "連線資料庫 ...成功\r\n";
                    }

                    //3.執行資料庫 Insert 命令
                    //INSERT INTO BPGroup (BPGroupID,BPGroupName) VALUES ('11','test 1')
                    //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "INSERT INTO BPGroup (BPGroupID,BPGroupName) VALUES (@gID, @gName)";
                    cmd.Parameters.AddWithValue("@gID", txtGId.Text.Trim());
                    cmd.Parameters.AddWithValue("@gName", txtGName.Text.Trim());

                    //(2)執行 Insert 命令
                    try
                    {
                        cmd.ExecuteNonQuery();
                        txtResult.Text += "資料Insert ...成功\r\n";

                        lblStatus.Text = "新增成功";
                        lblStatus.ForeColor = Color.DodgerBlue;
                    }
                    catch (Exception ex)
                    {
                        txtResult.Text += "資料Insert ...失敗\r\n";
                        txtResult.Text += "錯誤訊息: " + ex.Message + "\r\n";

                        lblStatus.Text = "新增失敗";
                        lblStatus.ForeColor = Color.Red;
                    }

                    //4.關閉資料庫連線
                    dbConn.Close();
                    txtResult.Text += "關閉連線資料庫 ...成功\r\n";
                } else
                {
                    //重複或無法檢查
                    txtResult.Text += "群組代碼重複或資料庫連線失敗 ...錯誤\r\n";

                    lblStatus.Text = "群組代碼重複或資料庫連線失敗";
                    lblStatus.ForeColor =  Color.Red;

                    timerStatus.Enabled = true;
                }
            }
        }

        //群組代碼是否重複檢查: True未重複, False重複
        private bool checkGroupIDDuplicated()
        {
            //1.連線資料庫
            //(1)宣告connection變數
            SqlConnection dbConn;
            //(2)設定連線登入資料
            dbConn = new SqlConnection("data source=(local); user id=sa; password=mis2024; initial catalog=PPERP");
            //(3)進行連線
            try
            {
                dbConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "資料庫連線失敗");
                return false;
            }

            //2.執行資料庫 Select 命令
            //Select * From BPGroup Where BPGroupID='6'
            //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = "Select * From BPGroup Where BPGroupID=@gID";
            cmd.Parameters.AddWithValue("@gID", txtGId.Text.Trim());

            //(2)執行Select命令, 結果存在DataReader
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            //3.回傳是否重複
            bool rtnValue = true;
            if (dr.HasRows)
            {
                //重複
                rtnValue = false;
            }
            dr.Close();

            //5.關閉資料庫連線
            dbConn.Close();

            return rtnValue;
        }


        //修改按鈕
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //清除執行結果區
            txtResult.Text = "";

            //1.檢查是否已輸入群組代碼, 群組名稱
            if (string.IsNullOrWhiteSpace(txtGId.Text) || string.IsNullOrWhiteSpace(txtGName.Text))
            {
                //輸入不完整
                MessageBox.Show("群組代碼與群組名稱都必須輸入", "輸入值錯誤");
            }
            else
            {   //通過檢查
                txtResult.Text += "群組代碼與群組名稱輸入檢查 ...通過\r\n";

                //2.連線資料庫
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
                else
                {
                    txtResult.Text += "連線資料庫 ...成功\r\n";
                }

                //3.執行資料庫 Update 命令
                //UPDATE BPGroup SET BPGroupName = '客戶1234' WHERE BPGroupID = '12'
                //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbConn;
                cmd.CommandText = "UPDATE BPGroup SET BPGroupName = @gName WHERE BPGroupID = @gID";
                cmd.Parameters.AddWithValue("@gID", txtGId.Text.Trim());
                cmd.Parameters.AddWithValue("@gName", txtGName.Text.Trim());

                //(2)執行 Update 命令
                try
                {
                    int rec = cmd.ExecuteNonQuery();
                    txtResult.Text += "資料 Update ...成功-" + rec.ToString() + "筆\r\n";
                }
                catch (Exception ex)
                {
                    txtResult.Text += "資料 Update ...失敗\r\n";
                    txtResult.Text += "錯誤訊息: " + ex.Message + "\r\n";
                }

                //4.關閉資料庫連線
                dbConn.Close();
                txtResult.Text += "關閉連線資料庫 ...成功\r\n";
            }
        }

        //刪除按鈕
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //清除執行結果區
            txtResult.Text = "";

            //1.檢查是否已輸入群組代碼
            if (string.IsNullOrWhiteSpace(txtGId.Text))
            {
                //輸入不完整
                MessageBox.Show("群組代碼必須輸入", "輸入值錯誤");
            }
            else
            { //通過檢查
                txtResult.Text += "群組代碼輸入檢查 ...通過\r\n";

                if(MessageBox.Show("確定要刪除這筆資料嗎?", "刪除確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //2.連線資料庫
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
                    else
                    {
                        txtResult.Text += "連線資料庫 ...成功\r\n";
                    }

                    //3.執行資料庫 Delete 命令
                    //DELETE FROM [BPGroup] WHERE BPGroupID = '11'
                    //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "DELETE FROM [BPGroup] WHERE BPGroupID = @gID";
                    cmd.Parameters.AddWithValue("@gID", txtGId.Text.Trim());

                    //(2)執行 Delete 命令
                    try
                    {
                        int rec = cmd.ExecuteNonQuery();
                        txtResult.Text += "資料 Delete ...成功-" + rec.ToString() + "筆\r\n";
                    }
                    catch (Exception ex)
                    {
                        txtResult.Text += "資料 Delete ...失敗\r\n";
                        txtResult.Text += "錯誤訊息: " + ex.Message + "\r\n";
                    }

                    //4.關閉資料庫連線
                    dbConn.Close();
                    txtResult.Text += "關閉連線資料庫 ...成功\r\n";
                }
            }
        }

        //第一筆按鈕
        private void btnFirst_Click(object sender, EventArgs e)
        {
            //清除執行結果區
            txtResult.Text = "";

            //1.連線資料庫
            //(1)宣告connection變數
            SqlConnection dbConn;
            //(2)設定連線登入資料
            cls5DB newDB = new cls5DB();
            dbConn = newDB.LoginDB();
            if(dbConn == null)
            {
                MessageBox.Show("連線登入失敗");
                return;
            } else
            {
                txtResult.Text += "連線資料庫 ...成功\r\n";
            }

            //2.執行資料庫 Select 命令
            //SELECT Top (1) *  FROM BPGroup Order By BPGroupID
            //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = "SELECT Top (1) * FROM BPGroup Order By BPGroupID";

            //(2)執行Select命令, 結果存在DataReader
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            //3.畫面顯示群組名稱
            if (dr.HasRows)
            {
                dr.Read();
                txtGId.Text = dr[0].ToString();
                txtGName.Text = dr[1].ToString();
                txtResult.Text += "查詢第1筆 ...成功\r\n";

                lblStatus.Text = "第一筆";
            }
            else
            {
                txtResult.Text += "資料表沒有資料 ...錯誤\r\n";
                txtGId.Text = "";
                txtGName.Text = "";

                lblStatus.Text = "資料表還沒有資料";
            }

            dr.Close();

            //4.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "關閉連線資料庫 ...成功\r\n";
        }

        //最後一筆按鈕
        private void btnLast_Click(object sender, EventArgs e)
        {
            //清除執行結果區
            txtResult.Text = "";

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
            else
            {
                txtResult.Text += "連線資料庫 ...成功\r\n";
            }

            //2.執行資料庫 Select 命令
            //SELECT Top (1) *  FROM BPGroup Order By BPGroupID
            //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = "SELECT Top (1) * FROM BPGroup Order By BPGroupID Desc";

            //(2)執行Select命令, 結果存在DataReader
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            //3.畫面顯示群組名稱
            if (dr.HasRows)
            {
                dr.Read();
                txtGId.Text = dr[0].ToString();
                txtGName.Text = dr[1].ToString();
                txtResult.Text += "查詢最後1筆 ...成功\r\n";

                lblStatus.Text = "最後一筆";
            }
            else
            {
                txtResult.Text += "資料表沒有資料 ...錯誤\r\n";
                txtGId.Text = "";
                txtGName.Text = "";

                lblStatus.Text = "資料表還沒有資料";
            }

            dr.Close();

            //4.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "關閉連線資料庫 ...成功\r\n";
        }

        //下一筆按鈕
        private void btnNext_Click(object sender, EventArgs e)
        {
            //清除執行結果區
            txtResult.Text = "";

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
            else
            {
                txtResult.Text += "連線資料庫 ...成功\r\n";
            }

            //2.執行資料庫 Select 命令
            //Select Top (1) * From BPGroup Where BPGroupID > '2' Order By BPGroupID
            //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = "Select Top (1) * From BPGroup Where BPGroupID > @gID Order By BPGroupID";
            cmd.Parameters.AddWithValue("@gID", txtGId.Text.Trim());

            //(2)執行Select命令, 結果存在DataReader
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            //3.畫面顯示群組代碼, 名稱
            if (dr.HasRows)
            {
                dr.Read();
                txtGId.Text = dr[0].ToString();
                txtGName.Text = dr[1].ToString();
                txtResult.Text += "查詢下一筆 ...成功\r\n";
            }
            else
            {
                txtResult.Text += "已經是最後一筆了 ...\r\n";
            }

            dr.Close();

            //4.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "關閉連線資料庫 ...成功\r\n";
        }

        //上一筆按鈕
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //清除執行結果區
            txtResult.Text = "";

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
            else
            {
                txtResult.Text += "連線資料庫 ...成功\r\n";
            }

            //2.執行資料庫 Select 命令
            //Select Top (1) * From BPGroup Where BPGroupID<'3' Order By BPGroupID Desc
            //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = "Select Top (1) * From BPGroup Where BPGroupID < @gID Order By BPGroupID Desc";
            cmd.Parameters.AddWithValue("@gID", txtGId.Text.Trim());

            //(2)執行Select命令, 結果存在DataReader
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            //3.畫面顯示群組代碼, 名稱
            if (dr.HasRows)
            {
                dr.Read();
                txtGId.Text = dr[0].ToString();
                txtGName.Text = dr[1].ToString();
                txtResult.Text += "查詢上一筆 ...成功\r\n";
            }
            else
            {
                txtResult.Text += "已經是第一筆了 ...\r\n";
            }

            dr.Close();

            //4.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "關閉連線資料庫 ...成功\r\n";
        }

        //狀態列清除Timer
        private void timerStatus_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "就緒";
            lblStatus.ForeColor = Color.Blue;

            timerStatus.Enabled = false;
        }
    }
}
