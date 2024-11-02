using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xkldDaiLoan
{
    internal class KetNoi
    {

        //Khởi tạo chuỗi kết nối
        string conStr = @"Data Source=DESKTOP-VB2ARP1\MSSQLSERVER1;Initial Catalog=TuVanNganhNgheHCG;Integrated Security=True";

        //Khởi tạo kết nối đến csdl
        SqlConnection conn;
        public KetNoi()
        {
            conn = new SqlConnection(conStr);
        }
        public DataSet LayDuLieu(string truyvan) // hàm có kiểu dữ liệu trả về là DataSet, DataSet lưu trữ bảng mà truy vấn SQL trả về
        {
            try
            {
                DataSet ds = new DataSet(); // tạo một dataset mới
                SqlDataAdapter da = new SqlDataAdapter(truyvan, conn); // Khởi động SqlDataAdapter với biến kết nối conn và truy vấn truyền vào hàm LayDuLieu(string truyvan), SqlDataAdapter sẽ tự động kết nối và đóng kết nối sau khi truy vấn nên sẽ ko cần conn.Open()
                da.Fill(ds); // biến SqlDataAdapter là da sau khi truy vấn xong sẽ lưu trữ lại trong DataTable, và sẽ lấp đầy (fill) bảng dữ liệu sau khi truy vấn vào DataSet ds 
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public bool ThucThi(string truyvan) //hàm kiểm tra câu lệnh truy vấn có thực thi thành công không
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(truyvan, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r > 0;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }
    }
}
