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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void btnSuKien_Click(object sender, EventArgs e)
        {
            frmSuKien frm = new frmSuKien();
            frm.ShowDialog();
        }

        private void btnLuat_Click(object sender, EventArgs e)
        {
            frmLuat frm = new frmLuat();
            frm.ShowDialog();
        }

        private void btnTuVan_Click(object sender, EventArgs e)
        {
            frmTuVan frm = new frmTuVan();
            frm.ShowDialog();
        }
    }
}
