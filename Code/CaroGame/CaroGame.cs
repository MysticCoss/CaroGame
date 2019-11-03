using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    public partial class CaroGame : Form
    {
        private GameControl game_Control;
        public CaroGame()
        {
            InitializeComponent();
            game_Control = new GameControl(this,pnl_BanCo);
        }

        private void CaroGame_Load(object sender, EventArgs e)
        {
        }
       

        private void btn_PvP_Click(object sender, EventArgs e)
        {
            game_Control.VeBanCo();
        }

        private void btn_PvM_Click(object sender, EventArgs e)
        {
            game_Control.VeBanCo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lawMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0\n Performed by\n Nguyen Ngoc Cong,\n Truong Van Khai,\n Do Dang Anh\n Contact:0352765398\n ngoccong.nncpro@gmail.com","About Me",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public RadioButton getRadioButonX()
        {
            return radioX;
        }
        public RadioButton getRadioButonO()
        {
            return radioO;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy ván?", "Xác nhận", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                game_Control.huyVan();
            }
        }

        private void btn_replay_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn chơi lại?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                game_Control.huyVan();
                game_Control.VeBanCo();
            }
        }
     
    }
}
