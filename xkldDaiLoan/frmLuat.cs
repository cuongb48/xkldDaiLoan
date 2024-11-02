using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xkldDaiLoan
{
    public partial class frmLuat : Form
    {
        public frmLuat()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        public void getData()
        {
            string query = "select * from tb_luat";
            DataSet ds = kn.LayDuLieu(query);
            dgv_luat.DataSource = ds.Tables[0];
        }

        private void dgv_luat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frmLuat_Load(object sender, EventArgs e)
        {
            getData();

            dgv_luat.Columns[0].HeaderText = "Mã luật";
            dgv_luat.Columns[0].Width = 75;
            dgv_luat.Columns[1].HeaderText = "Nội dung";
            dgv_luat.Columns[1].Width = 225;
        }
    }
}
