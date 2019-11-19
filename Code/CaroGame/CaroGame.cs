using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaroGame.Properties;
using System.IO;
using CaroGame.Properties;

namespace CaroGame
{
    public partial class CaroGame : Form
    {
        private GameControl game_Control;
        public bool computerMode = false;
        private bool playmusic = true;
        public CaroGame()
        {
            InitializeComponent();
            game_Control = new GameControl(this, pnl_BanCo);
        }

        private void CaroGame_Load(object sender, EventArgs e)
        {
            PlayMusic.Instance.OpenMediaFile(@"..\..\Resources\YieArKungFu-DangCapNhat_3cjcw.mp3");
            PlayMusic.Instance.PlayMediaFile(true);
            //lbl_Calculating.Text = "";
            btn_huy.Enabled = false;
            btn_replay.Enabled = false;
        }


        private void btn_PvP_Click(object sender, EventArgs e)
        {
            computerMode = false;
            game_Control.VeBanCo(computerMode);

            groupBox1.Enabled = false;
            btn_PvM.Enabled = false;

            btn_replay.Enabled = true;
            btn_huy.Enabled = true;
        }

        private void btn_PvM_Click(object sender, EventArgs e)
        {
            computerMode = true;
            game_Control.VeBanCo(computerMode);

            groupBox1.Enabled = false;
            btn_PvP.Enabled = false;
            btn_replay.Enabled = true;
            btn_huy.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lawMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Version 1.0\n Performed by\n Nguyen Ngoc Cong,\n Truong Van Khai,\n Do Dang Anh\n Contact:0352765398\n ngoccong.nncpro@gmail.com", "About Me", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy ván?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                game_Control.huyVan();

                groupBox1.Enabled = true;
                btn_PvP.Enabled = true;
                btn_PvM.Enabled = true;

                btn_huy.Enabled = false;
                btn_replay.Enabled = false;
                
            }
        }

        private void btn_replay_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn chơi lại?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                game_Control.huyVan();
                game_Control.VeBanCo(computerMode);
            }
        }

        private void battatnhacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playmusic == true)
            {
                PlayMusic.Instance.ClosePlayer();
                playmusic = false;
            }
            else
            {
                PlayMusic.Instance.OpenMediaFile(@"..\..\Resources\YieArKungFu-DangCapNhat_3cjcw.mp3");
                PlayMusic.Instance.PlayMediaFile(true);
                playmusic = true;
            }
        }
    }
}
