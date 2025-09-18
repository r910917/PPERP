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
    public partial class frm10DataBinding : Form
    {
        public frm10DataBinding()
        {
            InitializeComponent();
        }

        //表單載入
        private void frm10DataBinding_Load(object sender, EventArgs e)
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

            //4.設定BindingSource
            bsBPGroup.DataSource = ds;
            bsBPGroup.DataMember = "BPGroup";

            txtResult.Text += "4.設定BindingSource ...成功\r\n";

            //5.畫面各欄位的Textbox元件繫結到資料區
            txtGId.DataBindings.Add("Text", bsBPGroup, "BPGroupID");
            txtGName.DataBindings.Add("Text", bsBPGroup, "BPGroupName");

            txtResult.Text += "5.畫面各欄位的Textbox元件繫結到資料區 ...成功\r\n";

            //6.瀏覽列繫結至資料區, 可以逐筆查詢
            bnBPGroup.BindingSource = bsBPGroup;
            txtResult.Text += "6.瀏覽列繫結至資料區, 可以逐筆查詢 ...成功\r\n";

            //7.關閉資料庫連線
            dbConn.Close();
            txtResult.Text += "7.關閉連線資料庫 ...成功\r\n";


        }

        //第一筆
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "第一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        //上一筆

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "上一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        //下一筆
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "下一筆";
            lblStatus.ForeColor = Color.SeaGreen;
            timerStatus.Enabled = true;
        }

        //最後一筆
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
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
