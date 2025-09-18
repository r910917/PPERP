using PPERP;
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

namespace PPERP_FormDesign
{
    public partial class frm11SingleTable : Form
    {
        DataSet ds = new DataSet();
        public frm11SingleTable()
        {
            InitializeComponent();
        }

        //表單載入
        private void frm11SingleTable_Load(object sender, EventArgs e)
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
            SqlDataAdapter da = new SqlDataAdapter("Select top 1 * From BP order by CardCode ", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中
           
            da.Fill(ds, "BP");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //4.設定BindingSource
            bsBP.DataSource = ds;
            bsBP.DataMember = "BP";
            txtResult.Text += "4.設定BindingSource ...成功\r\n";

            //5.畫面各欄位的Textbox元件繫結到資料區
            txtCardCode.DataBindings.Add("Text", bsBP, "CardCode");
            txtCardName.DataBindings.Add("Text", bsBP, "CardName");
            txtPhone1.DataBindings.Add("Text", bsBP, "Phone1");
            txtPhone2.DataBindings.Add("Text", bsBP, "Phone2");
            txtFax.DataBindings.Add("Text", bsBP, "Fax");
            txtAddr.DataBindings.Add("Text", bsBP, "Addr");
            txtCreditLimit.DataBindings.Add("Text", bsBP, "CreditLimit");
            txtBGId.DataBindings.Add("Text", bsBP, "GroupID");

            txtResult.Text += "5.畫面各欄位的Textbox元件繫結到資料區 ...成功\r\n";

            //6.瀏覽列繫結至資料區, 可以逐筆查詢
            bnBPNew.BindingSource = bsBP;
            txtResult.Text += "6.瀏覽列繫結至資料區, 可以逐筆查詢 ...成功\r\n";
            // ----- 客戶群組ComboBox
            //(1)宣告DataAdapter變數, 設定(1)資料庫連線, (2)Select命令
            SqlDataAdapter daBPG = new SqlDataAdapter("Select * From BPGroup", dbConn);
            txtResult.Text += "客戶群組(1).宣告DataAdapter變數與設定 ...成功\r\n";

            //(2)執行DataAdapter的Select命令, 下載資料後儲存在Dataset中
            daBPG.Fill(ds, "BPGroup");
            txtResult.Text += "客戶群組(2).下載資料儲存在Dataset ...成功\r\n";

            //(3)指定畫面ComboBox元件的資料來源
            cbbBPGroup.DataSource = ds.Tables["BPGroup"];
            cbbBPGroup.DisplayMember = "BPGroupName";
            cbbBPGroup.ValueMember = "BPGroupID";
            txtResult.Text += "客戶群組(3)指定ComboBox資料來源 ...成功\r\n";

            //(4)繫結至BP資料表的欄位
            cbbBPGroup.DataBindings.Add("SelectedValue", bsBP, "GroupID");

            //7.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";
        }

        private void bindingNavigatorMoveFirstItem1_Click(object sender, EventArgs e)
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
            else
            {
                txtResult.Text += "1.連線資料庫 ...成功\r\n";
            }

            //2.宣告DataAdapter變數, 設定(1)資料庫連線, (2)Select命令
            SqlDataAdapter da = new SqlDataAdapter("Select top 1 * From BP  order by CardCode ", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.清除Dataset中現在資料
            ds.Tables["BP"].Clear();
            txtResult.Text += "3.清除Dataset中現在資料 ...成功\r\n";
            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "BP");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";
            //7.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";
            lblStatus.Text = "第一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        private void bindingNavigatorMoveLastItem1_Click(object sender, EventArgs e)
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
            else
            {
                txtResult.Text += "1.連線資料庫 ...成功\r\n";
            }

            //2.宣告DataAdapter變數, 設定(1)資料庫連線, (2)Select命令
            SqlDataAdapter da = new SqlDataAdapter("Select top 1 * From BP order by CardCode Desc", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.清除Dataset中現在資料
            ds.Tables["BP"].Clear();
            txtResult.Text += "3.清除Dataset中現在資料 ...成功\r\n";
            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "BP");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";
   

            
            //7.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";

            lblStatus.Text = "最後一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;


        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
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
            else
            {
                txtResult.Text += "1.連線資料庫 ...成功\r\n";
            }

            //2.宣告DataAdapter變數, 設定(1)資料庫連線, (2)Select命令
            SqlDataAdapter da = new SqlDataAdapter("Select Top 1 * From BP Where CardCode > @CardCode Order By CardCode", dbConn);
            da.SelectCommand.Parameters.AddWithValue("@CardCode", txtCardCode.Text.Trim());


            //3.清除Dataset中現在資料
            ds.Tables["BP"].Clear();
            txtResult.Text += "3.清除Dataset中現在資料 ...成功\r\n";
            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "BP");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";
            //檢查是不是最後一筆
            if (ds.Tables["BP"].Rows.Count == 0)
            {
                //bindingNavigatorMoveLastItem1.PerformClick(); //回到最後一筆
                bindingNavigatorMoveFirstItem1.PerformClick(); //回到第一筆, 循環效果
                txtResult.Text += "4-1 已經第一筆 ...\r\n";
            }
            //7.關閉資料庫連線
            lblStatus.Text = "上一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "就緒";
            lblStatus.ForeColor = SystemColors.ControlText;

            timerStatus.Enabled = false;
        }

        private void bindingNavigatorMoveNextItem1_Click(object sender, EventArgs e)
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
            else
            {
                txtResult.Text += "1.連線資料庫 ...成功\r\n";
            }

            //2.宣告DataAdapter變數, 設定(1)資料庫連線, (2)Select命令
            SqlDataAdapter da = new SqlDataAdapter("Select Top 1 * From BP Where CardCode > @CardCode Order By CardCode", dbConn);
            da.SelectCommand.Parameters.AddWithValue("@CardCode", txtCardCode.Text.Trim());


            //3.清除Dataset中現在資料
            ds.Tables["BP"].Clear();
            txtResult.Text += "3.清除Dataset中現在資料 ...成功\r\n";
            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "BP");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";
            //檢查是不是最後一筆
            if (ds.Tables["BP"].Rows.Count == 0)
            {
                //bindingNavigatorMoveLastItem1.PerformClick(); //回到最後一筆
                bindingNavigatorMoveFirstItem1.PerformClick(); //回到第一筆, 循環效果
                txtResult.Text += "4-1 已經最後一筆 ...\r\n";
            }
            //7.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";
            lblStatus.Text = "下一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        private void bindingNavigatorMovePreviousItem1_Click(object sender, EventArgs e)
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
            else
            {
                txtResult.Text += "1.連線資料庫 ...成功\r\n";
            }

            //2.宣告DataAdapter變數, 設定(1)資料庫連線, (2)Select命令
            SqlDataAdapter da = new SqlDataAdapter("Select Top 1 * From BP Where CardCode < @CardCode Order By CardCode Desc", dbConn);
            da.SelectCommand.Parameters.AddWithValue("@CardCode", txtCardCode.Text.Trim());


            //3.清除Dataset中現在資料
            ds.Tables["BP"].Clear();
            txtResult.Text += "3.清除Dataset中現在資料 ...成功\r\n";
            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中

            da.Fill(ds, "BP");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";
            //檢查是不是最後一筆
            if (ds.Tables["BP"].Rows.Count == 0)
            {
                //bindingNavigatorMoveLastItem1.PerformClick(); //回到最後一筆
               bindingNavigatorMoveFirstItem1.PerformClick(); //回到第一筆, 循環效果
                txtResult.Text += "4-1 已經是第一筆 ...\r\n";
            }
            //7.關閉資料庫連線
            dbConn.Close();
            lblStatus.Text = "上一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        private void cbbBPGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

            //1.連線資料庫
            //(1)宣告connection變數
            SqlConnection dbConn;
            //(2)設定連線登入資料
            cls5DB newDB = new cls5DB();
            dbConn = newDB.LoginDB();
            // ----- 客戶群組ComboBox
            //(1)宣告DataAdapter變數, 設定(1)資料庫連線, (2)Select命令
            SqlDataAdapter daBPG = new SqlDataAdapter("Select * From BPGroup", dbConn);
            txtResult.Text += "客戶群組(1).宣告DataAdapter變數與設定 ...成功\r\n";

            
        }

        private void txtBGId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
