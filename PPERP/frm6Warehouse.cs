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
    public partial class frm6Warehouse : Form
    {
        public frm6Warehouse()
        {
            InitializeComponent();
        }

        //查詢按鈕
        private void btnSelect_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";

            //1.檢查是否已輸入倉庫代碼
            if (string.IsNullOrWhiteSpace(txtWId.Text))
            {
                //未輸入
                MessageBox.Show("要先輸入倉庫代碼", "輸入錯誤");
            } else
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
                //Select * From Warehouse Where WhsCode='W03'
                //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbConn;
                cmd.CommandText = "Select * From Warehouse Where WhsCode = @wID";
                cmd.Parameters.AddWithValue("@wID", txtWId.Text.Trim());

                //(2)執行Select命令, 結果存在DataReader
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                //4.畫面顯示倉庫明細
                if (dr.HasRows)
                {
                    dr.Read();
                    txtWName.Text = dr[1].ToString();
                    txtWLocation.Text = dr[2].ToString();
                    txtMRP.Text = dr[3].ToString();
                    txtResult.Text += "查詢倉庫 ...成功\r\n";
                }
                else
                {
                    txtResult.Text += "沒有這個倉庫代碼 ...錯誤\r\n";
                    txtWName.Text = "";
                    txtWLocation.Text = "";
                    txtMRP.Text = "";
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
            if (   string.IsNullOrWhiteSpace(txtWId.Text) 
                || string.IsNullOrWhiteSpace(txtWName.Text) 
                || string.IsNullOrWhiteSpace(txtWLocation.Text) 
                || string.IsNullOrWhiteSpace(txtMRP.Text))
            {
                //輸入不完整
                MessageBox.Show("倉庫各欄位都必須輸入", "輸入值錯誤");
            } else
            {
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

                //3.執行資料庫 Insert 命令
                //INSERT INTO Warehouse (WhsCode,WhsName,WhsLocation,MRP) VALUES ('W91','test','L',1)
                //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbConn;
                cmd.CommandText = "INSERT INTO Warehouse (WhsCode,WhsName,WhsLocation,MRP) VALUES (@wID,@wName,@wLoc,@MRP)";
                cmd.Parameters.AddWithValue("@wID", txtWId.Text.Trim());
                cmd.Parameters.AddWithValue("@wName", txtWName.Text.Trim());
                cmd.Parameters.AddWithValue("@wLoc", txtWLocation.Text.Trim());
                cmd.Parameters.AddWithValue("@MRP", txtMRP.Text.Trim());

                //(2)執行 Insert 命令
                try
                {
                    cmd.ExecuteNonQuery();
                    txtResult.Text += "資料Insert ...成功\r\n";
                }
                catch (Exception ex)
                {
                    txtResult.Text += "資料Insert ...失敗\r\n";
                    txtResult.Text += "錯誤訊息: " + ex.Message + "\r\n";
                }

                //5.關閉資料庫連線
                dbConn.Close();
                txtResult.Text += "關閉連線資料庫 ...成功\r\n";
            }
        }

        //修改
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //清除執行結果區
            txtResult.Text = "";

            //1.檢查是否已輸入倉庫代碼, 倉庫名稱, 地點, MRP
            if (string.IsNullOrWhiteSpace(txtWId.Text)
                || string.IsNullOrWhiteSpace(txtWName.Text)
                || string.IsNullOrWhiteSpace(txtWLocation.Text)
                || string.IsNullOrWhiteSpace(txtMRP.Text))
            {
                //輸入不完整
                MessageBox.Show("倉庫各欄位都必須輸入", "輸入值錯誤");
            }
            else
            {
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
                //Update Warehouse Set WhsName = 'test 11', WhsLocation = 'B01', MRP = 1 Where WhsCode = 'W12'
                //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbConn;
                cmd.CommandText = "Update Warehouse Set WhsName = @wName, WhsLocation = @wLoc, MRP = @MRP Where WhsCode = @wID";
                cmd.Parameters.AddWithValue("@wID", txtWId.Text.Trim());
                cmd.Parameters.AddWithValue("@wName", txtWName.Text.Trim());
                cmd.Parameters.AddWithValue("@wLoc", txtWLocation.Text.Trim());
                cmd.Parameters.AddWithValue("@MRP", txtMRP.Text.Trim());
                //(2)執行 Update 命令
                try
                {
                    cmd.ExecuteNonQuery();
                    txtResult.Text += "Update ...成功\r\n";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        //第一筆
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
            //Select Top (1) * From Warehouse Order By WhsCode
            //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = "Select Top (1) * From Warehouse Order By WhsCode";

            //(2)執行Select命令, 結果存在DataReader
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            //3.畫面顯示群組名稱
            if (dr.HasRows)
            {
                dr.Read();
                txtWId.Text = dr[0].ToString();
                txtWName.Text = dr[1].ToString();
                txtWLocation.Text = dr[2].ToString(); 
                txtMRP.Text = dr[3].ToString();

                txtResult.Text += "查詢第1筆 ...成功\r\n";
            }
            else
            {
                txtResult.Text += "資料表沒有資料 ...錯誤\r\n";
                txtWId.Text = "";
                txtWName.Text = "";
                txtWLocation.Text = "";
                txtMRP.Text = "";
            }

            dr.Close();

            //4.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "關閉連線資料庫 ...成功\r\n";
        }

        //最後一筆
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
            //Select Top (1) * From Warehouse Order By WhsCode
            //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = "Select Top (1) * From Warehouse Order By WhsCode Desc";

            //(2)執行Select命令, 結果存在DataReader
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            //3.畫面顯示群組名稱
            if (dr.HasRows)
            {
                dr.Read();
                txtWId.Text = dr[0].ToString();
                txtWName.Text = dr[1].ToString();
                txtWLocation.Text = dr[2].ToString();
                txtMRP.Text = dr[3].ToString();

                txtResult.Text += "查詢最後1筆 ...成功\r\n";
            }
            else
            {
                txtResult.Text += "資料表沒有資料 ...錯誤\r\n";
                txtWId.Text = "";
                txtWName.Text = "";
                txtWLocation.Text = "";
                txtMRP.Text = "";
            }

            dr.Close();

            //4.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "關閉連線資料庫 ...成功\r\n";
        }

        //下一筆
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
            //Select Top (1) * From Warehouse Where WhsCode > 'W11' Order By WhsCode
            //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = "Select Top (1) * From Warehouse Where WhsCode > @wID Order By WhsCode";
            cmd.Parameters.AddWithValue("@wID", txtWId.Text.Trim());

            //(2)執行Select命令, 結果存在DataReader
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            //3.畫面顯示群組名稱
            if (dr.HasRows)
            {
                dr.Read();
                txtWId.Text = dr[0].ToString();
                txtWName.Text = dr[1].ToString();
                txtWLocation.Text = dr[2].ToString();
                txtMRP.Text = dr[3].ToString();

                txtResult.Text += "查詢下一筆 ...成功\r\n";
            }
            else
            {
                txtResult.Text += "已經最後一筆了 ...\r\n";
            }

            dr.Close();

            //4.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "關閉連線資料庫 ...成功\r\n";
        }

        //上一筆
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
            //Select Top (1) * From Warehouse Where WhsCode > 'W11' Order By WhsCode
            //(1) 宣告與設定SQLCommand元件: 連線與要執行的SQL命令
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dbConn;
            cmd.CommandText = "Select Top (1) * From Warehouse Where WhsCode < @wID Order By WhsCode Desc";
            cmd.Parameters.AddWithValue("@wID", txtWId.Text.Trim());

            //(2)執行Select命令, 結果存在DataReader
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            //3.畫面顯示群組名稱
            if (dr.HasRows)
            {
                dr.Read();
                txtWId.Text = dr[0].ToString();
                txtWName.Text = dr[1].ToString();
                txtWLocation.Text = dr[2].ToString();
                txtMRP.Text = dr[3].ToString();

                txtResult.Text += "查詢上一筆 ...成功\r\n";
            }
            else
            {
                txtResult.Text += "已經第一筆了 ...\r\n";
            }

            dr.Close();

            //4.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "關閉連線資料庫 ...成功\r\n";
        }



        private void dgvWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWId.Text = dgvWarehouse.CurrentRow.Cells["WhsCode"].Value.ToString();
            txtWName.Text = dgvWarehouse.CurrentRow.Cells["WhsName"].Value.ToString();
            txtWLocation.Text = dgvWarehouse.CurrentRow.Cells["WhsLocation"].Value.ToString();
            txtMRP.Text = dgvWarehouse.CurrentRow.Cells["MRP"].Value.ToString();
        }

        private void frm6Warehouse_Load(object sender, EventArgs e)
        {
            btnFirst.PerformClick();
            cbbLoadData();
            dgvLoadData();
        }

        //ComboBox資料載入
        private void cbbLoadData()
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
                txtResult.Text += "1.連線資料庫 ...成功\r\n";
            }

            //2.宣告DataAdapter變數, 設定(1)資料庫連線, (2)Select命令
            SqlDataAdapter da = new SqlDataAdapter("Select WhsCode, WhsName From Warehouse", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中
            DataSet ds = new DataSet();
            da.Fill(ds, "Warehouse");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //4.指定畫面ComboBox元件的資料來源
            cbbWarehouse.DataSource = ds.Tables["Warehouse"];
            cbbWarehouse.DisplayMember = "WhsName";
            cbbWarehouse.ValueMember = "WhsCode";
            txtResult.Text += "4.指定ComboBox資料來源 ...成功\r\n";

            //關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "5.關閉資料庫連線 ...\r\n";
        }

        //DataGridView資料載入
        private void dgvLoadData()
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
                txtResult.Text += "1.連線資料庫 ...成功\r\n";
            }

            //2.宣告DataAdapter變數, 設定(1)資料庫連線, (2)Select命令
            SqlDataAdapter da = new SqlDataAdapter("Select * From Warehouse", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中
            DataSet ds = new DataSet();
            da.Fill(ds, "Warehouse");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //4.指定畫面DataGridView元件的資料來源
            dgvWarehouse.DataSource = ds.Tables["Warehouse"];
            txtResult.Text += "4.指定ComboBox資料來源 ...成功\r\n";

            //關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "5.關閉資料庫連線 ...\r\n";

            //DataGridView顯示設定
            //1.欄位標題
            dgvWarehouse.Columns["WhsCode"].HeaderText = "代碼";
            dgvWarehouse.Columns["WhsName"].HeaderText = "名稱";
            dgvWarehouse.Columns["WhsLocation"].HeaderText = "位置";
            dgvWarehouse.Columns["MRP"].HeaderText = "MRP";

            //2.欄位寬度
            dgvWarehouse.AutoResizeColumns();
            //dgvWarehouse.Columns["WhsLocation"].Width = 80;

            //3.指定欄位不顯示
            dgvWarehouse.Columns["MRP"].Visible = false;
        }
    }
}
