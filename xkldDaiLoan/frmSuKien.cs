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
    public partial class frmSuKien : Form
    {
        public frmSuKien()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        public void getData()
        {
            string query = "select masukien,motasukien,maloaisukien,tenloaisukien from tb_sukien, tb_loaisk where tb_sukien.loaisukien = tb_loaisk.maloaisukien";
            DataSet ds = kn.LayDuLieu(query);
            dgv_SuKien.DataSource = ds.Tables[0];
        }

        public void getLoaiSuKien()
        {
            string query = "select * from tb_loaisk";
            DataSet ds = kn.LayDuLieu(query);
            cmbLoaiSuKien.DataSource = ds.Tables[0];
            cmbLoaiSuKien.DisplayMember = "tenloaisukien";
            cmbLoaiSuKien.ValueMember = "maloaisukien";
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgv_SuKien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaSuKien.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaSuKien.Text = dgv_SuKien.Rows[r].Cells["masukien"].Value.ToString();
                txtNoidung.Text = dgv_SuKien.Rows[r].Cells["motasukien"].Value.ToString();
                cmbLoaiSuKien.SelectedValue = dgv_SuKien.Rows[r].Cells["maloaisukien"].Value.ToString();
            }
        }

        private void frmSuKien_Load(object sender, EventArgs e)
        {
            getData();
            getLoaiSuKien();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgv_SuKien.Columns[0].HeaderText = "Mã sự kiện";
            dgv_SuKien.Columns[0].Width = 50;
            dgv_SuKien.Columns[1].HeaderText = "Nội dung";
            dgv_SuKien.Columns[1].Width = 75;
            dgv_SuKien.Columns[2].HeaderText = "Mã loại sự kiện";
            dgv_SuKien.Columns[2].Width = 50;
            dgv_SuKien.Columns[3].HeaderText = "Loại sự kiện";
            dgv_SuKien.Columns[3].Width = 100;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearText();
            getData();
        }

        public void clearText()
        {
            txtMaSuKien.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaSuKien.Text = "";
            txtNoidung.Text = "";
            txtTimKiem.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "insert into tb_sukien VALUES(N'{0}', '{1}', N'{2}')",
                txtMaSuKien.Text,
                txtNoidung.Text,
                cmbLoaiSuKien.SelectedValue
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
               "update tb_sukien set motasukien = '{1}', loaisukien = '{2}' where masukien = '{0}'",
                txtMaSuKien.Text,
                txtNoidung.Text,
                cmbLoaiSuKien.SelectedValue
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
                "delete from tb_sukien where masukien = '{0}'",
                txtMaSuKien.Text
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
                "select masukien,motasukien,maloaisukien,tenloaisukien from tb_sukien, tb_loaisk where masukien like N'%{0}%' and tb_sukien.loaisukien = tb_loaisk.maloaisukien",
                txtTimKiem.Text
            );
            DataSet ds = kn.LayDuLieu(query);
            dgv_SuKien.DataSource = ds.Tables[0];
            
        }
    }
}
