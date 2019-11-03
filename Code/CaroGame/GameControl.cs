using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    class GameControl
    {
        private CaroGame form;
        private Panel pnl_BanCo;
        private List<Player> players;
        private Player currentPlayer;
        private Oco[,] matrix;

        public GameControl(CaroGame form,Panel pnl_BanCo)
        {
            this.form = form;
            this.pnl_BanCo =pnl_BanCo;
        }

        #region properties
        public Panel Pnl_BanCo
        {
            get
            {
                return this.pnl_BanCo;
            }
            set
            {
                this.pnl_BanCo = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }

            set
            {
                currentPlayer = value;
            }
        }
        #endregion




        #region Function
        public void VeBanCo()
        {
            matrix = new Oco[SoLieu.CHESS_BOARD_ROW,SoLieu.CHESS_BOARD_COLUMN];

            Button temp = new Button() { Width = 0, Height = 0, Location = new Point(0, 0) };

            for (int i = 0; i < SoLieu.CHESS_BOARD_ROW; i++)
            {
                for (int j = 0; j < SoLieu.CHESS_BOARD_COLUMN; j++)
                {
                    Button btn = new Button()
                    {
                        Width = SoLieu.CHESS_SIZE, Height = SoLieu.CHESS_SIZE,
                        Location = new Point(temp.Location.X + temp.Width, temp.Location.Y),
                        Tag = String.Format("{0};{1}", i, j)
                    };
                    btn.Click += btn_Click;
                    pnl_BanCo.Controls.Add(btn);
                    temp = btn;
                    matrix[i, j] = new Oco();
                }
                temp.Location = new Point(0, temp.Location.Y + temp.Height);
                temp.Width = 0;
                temp.Height = 0;

            }
            players = initPlayer();
        }

        public void huyVan()
        {
            pnl_BanCo.Controls.Clear();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text != "") return;
            btn.Text = currentPlayer.Mark;
            btn.ForeColor = currentPlayer.Color;

            String[] vt = btn.Tag.ToString().Split(';');
            int viTriHang = Int32.Parse(vt[0]);
            int viTriCot = Int32.Parse(vt[1]);

            //Console.WriteLine("Hang: "+viTriHang+", Cot: "+viTriCot);

            //Lưu nước cờ.
            matrix[viTriHang, viTriCot].SoHuu = CurrentPlayer;

            if (isEndGame(viTriHang,viTriCot))
            {
                EndGame();
                return;
            }
            ChangePlayer();
        }
        private void EndGame()
        {
            MessageBox.Show(currentPlayer.Mark + " thắng!");
            huyVan();
            VeBanCo();
        }

        //Kiểm tra xem đã kết thúc trận đấu chưa
        #region KiemTraKetQua
        private bool isEndGame(int i,int j)
        {
            if (HangNgang(i, j) || HangDoc(i, j) || CheoChinh(i, j) || CheoPhu(i, j))
            {
                return true;
            }
            return false;
        }
        private bool HangNgang(int i, int j)
        {
            int LCount = 0, RCount = 0;
            for(int k = j+1; k < SoLieu.CHESS_BOARD_COLUMN; k++)
            {
                if (matrix[i, k].SoHuu == null) break;
                if (matrix[i, k].SoHuu.Equals(CurrentPlayer))
                {
                    RCount++;
                }
                else
                {
                    break;
                }
            }

            for (int k = j; k >= 0; k--)
            {
                if (matrix[i, k].SoHuu == null) break;
                if (matrix[i, k].SoHuu.Equals(CurrentPlayer))
                {
                    LCount++;
                }
                else
                {
                    break;
                }
            }
            return LCount + RCount == 5;
        }

        private bool HangDoc(int i, int j)
        {
            int TCount = 0, BCount = 0;

            for (int k = i + 1; k < SoLieu.CHESS_BOARD_ROW; k++)
            {
                if (matrix[k, j].SoHuu == null) break;
                if (matrix[k, j].SoHuu.Equals(CurrentPlayer))
                {
                    BCount++;
                }
                else
                {
                    break;
                }
            }

            for (int k = i; k >= 0; k--)
            {
                if (matrix[k,j].SoHuu == null) break;
                if (matrix[k,j].SoHuu.Equals(CurrentPlayer))
                {
                    TCount++;
                }
                else
                {
                    break;
                }
            }

            return TCount + BCount == 5;
        }

        private bool CheoChinh(int i, int j)
        {
            int RCount = 0;
            int l = j;
            for(int k = i; k < SoLieu.CHESS_BOARD_ROW; k++)
            {
                if (l >= SoLieu.CHESS_BOARD_COLUMN) break;
                if (matrix[k, l].SoHuu == null) break;
                if ( matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    RCount++;
                }
                l++;
            }
            l = j;
            int LCount = -1;
            for(int k = i; k >= 0; k--)
            {
                if (l < 0) break;
                if (matrix[k, l].SoHuu == null) break;
                if ( matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    LCount++;
                }
                l--;
            }

            return LCount + RCount == 5;
        }

        private bool CheoPhu(int i, int j)
        {
            int LCount = 0;
            int l = j;
            for(int k = i; k < SoLieu.CHESS_BOARD_ROW; k++)
            {
                if (l < 0) break;
                if (matrix[k, l].SoHuu == null) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    LCount++;
                }
                l--;
            }
            int RCount = -1;
            l = j;
            for(int k = i; k >= 0; k--)
            {
                if (l >= SoLieu.CHESS_BOARD_COLUMN) break;
                if (matrix[k, l].SoHuu == null) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    RCount++;
                }
                l++;
            }

            return LCount + RCount == 5;
        }
        #endregion
        private void ChangePlayer()
        {
            currentPlayer = currentPlayer.Id == players[0].Id ? players[1] : players[0];
            form.lblLuotDi.Text = currentPlayer.Mark;
            form.lblLuotDi.ForeColor = currentPlayer.Color;
        }

        private List<Player> initPlayer()
        {
            Player player1;
            Player player2;
            List<Player> players = new List<Player>();
            if (form.getRadioButonX().Checked == true)
            {
                 player1 = new Player(0, "X");
                 player2 = new Player(1, "O");
            }else
            {
                 player1 = new Player(1, "O");
                 player2 = new Player(0, "X");
            }
            players.Add(player1);
            players.Add(player2);
            currentPlayer = players[0];
            form.lblLuotDi.Text = currentPlayer.Mark;
            form.lblLuotDi.ForeColor = currentPlayer.Color;
            return players;
        }
        #endregion
    }
}
