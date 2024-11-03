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
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaLuat.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaLuat.Text = dgv_luat.Rows[r].Cells["maluat"].Value.ToString();
                txtNoidung.Text = dgv_luat.Rows[r].Cells["noidung"].Value.ToString();
            }
        }

        private void frmLuat_Load(object sender, EventArgs e)
        {
            getData();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgv_luat.Columns[0].HeaderText = "Mã luật";
            dgv_luat.Columns[0].Width = 75;
            dgv_luat.Columns[1].HeaderText = "Nội dung";
            dgv_luat.Columns[1].Width = 225;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearText();
            getData();
        }

        public void clearText()
        {
            txtMaLuat.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaLuat.Text = "";
            txtNoidung.Text = "";
            txtTimKiem.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "insert into tb_luat VALUES(N'{0}', '{1}')",
                txtMaLuat.Text,
                txtNoidung.Text
            );
            if (kn.ThucThi(query) == true)
            {
                MessageBox.Show("Thêm mới thành công!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!");
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            clearText();
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
               "update tb_luat set noidung = '{1}'where maluat = '{0}'",
               txtMaLuat.Text,
                txtNoidung.Text
           );
            if (kn.ThucThi(query) == true)
            {
                MessageBox.Show("Sửa thành công!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "delete from tb_luat where maluat = '{0}'",
                txtMaLuat.Text
            );
            if (kn.ThucThi(query) == true)
            {
                MessageBox.Show("Xóa thành công!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "select tb_luat.* from tb_luat where maluat like N'%{0}%'",
                txtTimKiem.Text
            );
            DataSet ds = kn.LayDuLieu(query);
            dgv_luat.DataSource = ds.Tables[0];
        }
    }
}
