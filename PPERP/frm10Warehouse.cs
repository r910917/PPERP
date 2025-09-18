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
    public partial class frm10Warehouse : Form
    {
        DataSet ds = new DataSet();
        public frm10Warehouse()
        {
            InitializeComponent();
        }

        //表單載入
        private void frm10Warehouse_Load(object sender, EventArgs e)
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
            SqlDataAdapter da = new SqlDataAdapter("Select * From Warehouse Select * From Warehouse Order by WhsCode", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "Warehouse");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //4.設定BindingSource
            bsWarehouse.DataSource = ds;
            bsWarehouse.DataMember = "Warehouse";
            txtResult.Text += "4.設定BindingSource ...成功\r\n";

            //5.畫面各欄位的Textbox元件繫結到資料區
            txtWId.DataBindings.Add("Text", bsWarehouse, "WhsCode");
            txtWName.DataBindings.Add("Text", bsWarehouse, "WhsName");
            txtWLocation.DataBindings.Add("Text", bsWarehouse, "WhsLocation");
            txtMRP.DataBindings.Add("Text", bsWarehouse, "MRP");

            cbxMRP.DataBindings.Add("Checked", bsWarehouse, "MRP");

            txtResult.Text += "5.畫面各欄位的Textbox元件繫結到資料區 ...成功\r\n";

            //6.瀏覽列繫結至資料區, 可以逐筆查詢
            bnWarehouse.BindingSource = bsWarehouse;
            txtResult.Text += "6.瀏覽列繫結至資料區, 可以逐筆查詢 ...成功\r\n";

            //7.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";
        }

        //第一筆
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
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
            SqlDataAdapter da = new SqlDataAdapter("Select * From Warehouse Order by WhsCode", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.清除Dateset中現在資料
            ds.Tables["Warehouse"].Clear();
            txtResult.Text += "3.清除Dataset中現在資料...完成\r\n";

            //4.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "Warehouse");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //5.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";

            lblStatus.Text = "第一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        //上一筆
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
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
            SqlDataAdapter da = new SqlDataAdapter("Select * From Warehouse Where WhsCode < @WhsCode Order by WhsCode Desc", dbConn);
            da.SelectCommand.Parameters.AddWithValue("@WhsCode", txtWId.Text.Trim());
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.清除Dateset中現在資料
            ds.Tables["Warehouse"].Clear();
            txtResult.Text += "3.清除Dataset中現在資料...完成\r\n";

            //4.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "Warehouse");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //檢查是不是第一筆資料
            if (ds.Tables["Warehouse"].Rows.Count == 0)
            {
                bindingNavigatorMoveFirstItem.PerformClick();
                txtResult.Text += "4-1 已經是第一筆資料 ...\r\n";
            }

            //5.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";


            lblStatus.Text = "上一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        //下一筆
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
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
            SqlDataAdapter da = new SqlDataAdapter("Select * From Warehouse Where WhsCode > @WhsCode Order by WhsCode", dbConn);
            da.SelectCommand.Parameters.AddWithValue("@WhsCode", txtWId.Text.Trim());
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.清除Dateset中現在資料
            ds.Tables["Warehouse"].Clear();
            txtResult.Text += "3.清除Dataset中現在資料...完成\r\n";

            //4.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "Warehouse");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //檢查是不是最後一筆資料
            if (ds.Tables["Warehouse"].Rows.Count == 0)
            {
                bindingNavigatorMoveLastItem.PerformClick();
                txtResult.Text += "4-1 已經最後一筆 ...\r\n";
            }

            //5.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";


            lblStatus.Text = "下一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        //最後一筆
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
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
            SqlDataAdapter da = new SqlDataAdapter("Select * From Warehouse Order by WhsCode Desc", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.清除Dateset中現在資料
            ds.Tables["Warehouse"].Clear();
            txtResult.Text += "3.清除Dataset中現在資料...完成\r\n";

            //4.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "Warehouse");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //5.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";


            lblStatus.Text = "最後一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "就緒";
            lblStatus.ForeColor = SystemColors.ControlText;

            timerStatus.Enabled = false;
        }
    }
}
