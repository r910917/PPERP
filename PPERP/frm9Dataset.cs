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
using PPERP;

namespace PPERP_FormDesign
{
    public partial class frm9Dataset : Form
    {
        public frm9Dataset()
        {
            InitializeComponent();
        }


        //DataGridView
        //下拉選單改變選取項
        private void cbbBPGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            txtBGId.Text = cbbBPGroup.SelectedValue.ToString();
        }

        //讀取DataGridView使用者點選的內容
        private void dgvBPGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCurCell.Text = dgvBPGroup.CurrentCell.Value.ToString();

            txtItemId_Selected.Text = dgvBPGroup.CurrentRow.Cells[0].Value.ToString();
            txtItemName_Selected.Text = dgvBPGroup.CurrentRow.Cells[1].Value.ToString();
        }

        //表單畫面元件載入後
        private void frm9Dataset_Load(object sender, EventArgs e)
        {
            cbbLoadData();
            dgvLoadData();
            
        }

        //ComboBox資料載入
        private void cbbLoadData ()
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
            SqlDataAdapter da = new SqlDataAdapter("Select * From BPGroup", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中
            DataSet ds = new DataSet();
            da.Fill(ds, "BPGroup");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //4.指定畫面ComboBox元件的資料來源
            cbbBPGroup.DataSource = ds.Tables["BPGroup"];
            cbbBPGroup.DisplayMember = "BPGroupName";
            cbbBPGroup.ValueMember = "BPGroupID";
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
            SqlDataAdapter da = new SqlDataAdapter("Select * From Item", dbConn);
            txtResult.Text += "2.宣告DataAdapter變數與設定 ...成功\r\n";

            //3.執行DataAdapter的Select命令, 下載資料後儲存在Dataset中
            DataSet ds = new DataSet();
            da.Fill(ds, "Items");
            txtResult.Text += "3.下載資料儲存在Dataset ...成功\r\n";

            //4.指定畫面DataGridView元件的資料來源
            dgvBPGroup.DataSource = ds.Tables["Items"];
            txtResult.Text += "4.指定ComboBox資料來源 ...成功\r\n";

            //關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "5.關閉資料庫連線 ...\r\n";

            //顯示DataGridView資料數與欄位數
            txtResult.Text += "6.共 " + dgvBPGroup.Rows.Count.ToString() + " 筆, " + dgvBPGroup.Columns.Count.ToString() + " 欄位 ...\r\n";
        }
    }
}
