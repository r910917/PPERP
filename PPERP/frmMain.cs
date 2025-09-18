using PPERP_FormDesign;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPERP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //主畫面載入後執行
        private void frmMain_Load(object sender, EventArgs e)
        {
            //開啟登入畫面: 只看得到登入畫面
            //frmLogin frmNew = new frmLogin();
            //frmNew.ShowDialog();

        }

        //主畫面顯示後執行: 可以看到登入畫面與主畫面
        private void frmMain_Shown(object sender, EventArgs e)
        {
            frmLogin frmNew = new frmLogin();
            frmNew.ShowDialog();
        }

        private void 連線登入SQLServer資料庫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm4DBConnect frmNew = new frm4DBConnect();
            frmNew.MdiParent = this;
            frmNew.Show();
        }

        private void sqlCommand元件執行完整SQL命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm6SqlCommand frmNew = new frm6SqlCommand();
            frmNew.MdiParent = this;
            frmNew.Show();

        }

        private void 倉庫管理維護練習ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm6Warehouse frmNew = new frm6Warehouse();
            frmNew.MdiParent = this;
            frmNew.Show();
        }

        private void dataset架構基本操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm9Dataset frmNew = new frm9Dataset();
            frmNew.MdiParent = this;
            frmNew.Show();
        }

        private void 資料繫結DatabindingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm10DataBinding frmNew = new frm10DataBinding();
            frmNew.MdiParent = this;
            frmNew.Show();
        }

        private void 練習倉庫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm10Warehouse frmNew = new frm10Warehouse();
            frmNew.MdiParent = this;
            frmNew.Show();
        }

        private void 單一資料表維護ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm11SingleTable frmNew = new frm11SingleTable();
            frmNew.MdiParent = this;
            frmNew.Show();
        }

        private void 資料庫基本操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
