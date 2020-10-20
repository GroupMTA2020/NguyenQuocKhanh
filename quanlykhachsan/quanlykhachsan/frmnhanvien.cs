using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace quanlykhachsan
{
    public partial class frmnhanvien : Form
    {
        public frmnhanvien()
        {
            InitializeComponent();
        }
        int temp;
        private void hienthi()
        {
            nhanvienBLL pbll = new nhanvienBLL();
            dataGridView1.DataSource = pbll.hienthinhanvien();
        }
        private void trangthai(bool t)
        {
          //  txtmanv.Enabled = t;
            txttennv.Enabled = t;
            txtscm.Enabled = t;
            txtsdt.Enabled = t;
            txtdiachi.Enabled = t;
            dtngaysinh.Enabled = t;
            dtngayvaolam.Enabled = t;
            cbgioitinh.Enabled = t;

        }

        private void frm_load(object sender, EventArgs e)
        {
            //hienthi();
            nhanvienBLL pbll = new nhanvienBLL();
            dataGridView1.DataSource = pbll.hienthinhanvien();
            trangthai(false);
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            trangthai(true);
            temp = 1;
            txtmanv.Clear();
            txttennv.Clear();
            txtsdt.Clear();
            txtscm.Clear();
            txtdiachi.Clear();
            cbgioitinh.ResetText();
            dtngaysinh.ResetText();
            dtngayvaolam.ResetText();
            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            trangthai(true);
            temp = 2;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
        }
        private bool travegioitinh()
        {
            if (cbgioitinh.Text == "Nam")
                return true;
            else
                return false;   
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            nhanvienBLL nvBLL = new nhanvienBLL();
            DialogResult luu = MessageBox.Show("Bạn chắc chắn xóa??", "Thông báo thêm mới", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (luu == DialogResult.Yes)
            {
                nvBLL.xoa_nhanvien(int.Parse(txtmanv.Text));
                hienthi();
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = false;
            btnsua.Enabled = true;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            trangthai(false);

        }
    }
}
