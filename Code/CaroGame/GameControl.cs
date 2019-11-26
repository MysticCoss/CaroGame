using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CaroGame
{
    class GameControl
    {
        private CaroGame form;
        private Panel pnl_BanCo;
        private List<Player> players;
        private Player currentPlayer;
        private Oco[,] matrix;
        private int soNutDaDanh;
        private bool ComputerFirst = false;

        public GameControl(CaroGame form, Panel pnl_BanCo)
        {
            this.form = form;
            this.pnl_BanCo = pnl_BanCo;
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



        //vùng các hàm xử lí game
        #region Function
        public void VeBanCo(bool computerMode)
        {
            matrix = new Oco[SoLieu.CHESS_BOARD_ROW, SoLieu.CHESS_BOARD_COLUMN];

            Point temp = new Point(0, 0);

            for (int i = 0; i < SoLieu.CHESS_BOARD_ROW; i++)
            {
                for (int j = 0; j < SoLieu.CHESS_BOARD_COLUMN; j++)
                {
                    Button btn = new Button()
                    {
                        Width = SoLieu.CHESS_SIZE,
                        Height = SoLieu.CHESS_SIZE,
                        Location = new Point(temp.X + SoLieu.CHESS_SIZE, temp.Y),
                        Tag = String.Format("{0};{1}", i, j)
                    };
                    btn.Click += btn_Click;
                    pnl_BanCo.Controls.Add(btn);
                    temp = btn.Location;
                    matrix[i, j] = new Oco();
                    matrix[i, j].soHang = i;
                    matrix[i, j].soCot = j;
                }
                temp = new Point(0, temp.Y + SoLieu.CHESS_SIZE);


            }
            players = initPlayer(computerMode);
            soNutDaDanh = 0;

            if (ComputerFirst)
            {
                MayDanh();
            }
           
        }

        public void huyVan()
        {
            pnl_BanCo.Controls.Clear();

            form.groupBox1.Enabled = true;
            form.btn_PvM.Enabled = true;
            form.btn_PvP.Enabled = true;

           form.btn_huy.Enabled = false;
           form.btn_replay.Enabled = false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Console.Beep(587, 125);
            Button btn = sender as Button;
            Console.WriteLine("Press: " + btn.Tag);
            if (!currentPlayer.IsComputer)
            {
                if (btn.Text != "") return;
            }
            btn.Text = currentPlayer.Mark;
            btn.ForeColor = currentPlayer.Color;

            String[] vt = btn.Tag.ToString().Split(';');
            int viTriHang = Int32.Parse(vt[0]);
            int viTriCot = Int32.Parse(vt[1]);
           

            //Console.WriteLine("Hang: "+viTriHang+", Cot: "+viTriCot);

            //Lưu nước cờ.
            //if(!currentPlayer.IsComputer)
            matrix[viTriHang, viTriCot].SoHuu = CurrentPlayer;

            if (isEndGame(viTriHang, viTriCot))
            {
                EndGame();
                return;
            }
            ChangePlayer();
            if (form.computerMode && currentPlayer.IsComputer)
            {
               
                MayDanh();
            }
           

        }


        private void EndGame()
        {
            bool temp = players[1].IsComputer;
            Console.Beep(330, 125);
            DialogResult result = MessageBox.Show(currentPlayer.Mark + " thắng! Bạn có muốn chơi lại?", "Xác nhận", MessageBoxButtons.YesNo);
            huyVan();
            if (result == DialogResult.Yes)
            {
                VeBanCo(temp);
                form.groupBox1.Enabled = false;
                form.btn_huy.Enabled = true;
                form.btn_replay.Enabled = true;
                if (temp)
                {
                    form.btn_PvP.Enabled = false;
                }
                else
                {
                    form.btn_PvM.Enabled = false;
                }


            }
            

        }

        //Kiểm tra xem đã kết thúc trận đấu chưa
        #region KiemTraKetQua
        private bool isEndGame(int i, int j)
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
            for (int k = j + 1; k < SoLieu.CHESS_BOARD_COLUMN; k++)
            {
                if (matrix[i, k].SoHuu.Mark == "xxx") break;
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
                if (matrix[i, k].SoHuu.Mark == "xxx") break;
                if (matrix[i, k].SoHuu.Equals(CurrentPlayer))
                {
                    LCount++;
                }
                else
                {
                    break;
                }
            }
            return LCount + RCount >= 5;
        }

        private bool HangDoc(int i, int j)
        {
            int TCount = 0, BCount = 0;

            for (int k = i + 1; k < SoLieu.CHESS_BOARD_ROW; k++)
            {
                if (matrix[k, j].SoHuu.Mark == "xxx") break;
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
                if (matrix[k, j].SoHuu.Mark == "xxx") break;
                if (matrix[k, j].SoHuu.Equals(CurrentPlayer))
                {
                    TCount++;
                }
                else
                {
                    break;
                }
            }

            return TCount + BCount >= 5;
        }

        private bool CheoChinh(int i, int j)
        {
            int RCount = 0;
            int l = j;
            for (int k = i; k < SoLieu.CHESS_BOARD_ROW; k++)
            {
                if (l >= SoLieu.CHESS_BOARD_COLUMN) break;
                if (matrix[k, l].SoHuu.Mark == "xxx") break;
                if (!matrix[k, l].SoHuu.Equals(currentPlayer)) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    RCount++;
                }
                l++;
            }
            l = j;
            int LCount = -1;
            for (int k = i; k >= 0; k--)
            {
                if (l < 0) break;
                if (matrix[k, l].SoHuu.Mark == "xxx") break;
                if (!matrix[k, l].SoHuu.Equals(currentPlayer)) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    LCount++;
                }
                l--;
            }

            return LCount + RCount >= 5;
        }

        private bool CheoPhu(int i, int j)
        {
            int LCount = 0;
            int l = j;
            for (int k = i; k < SoLieu.CHESS_BOARD_ROW; k++)
            {
                if (l < 0) break;
                if (matrix[k, l].SoHuu.Mark == "xxx") break;
                if (!matrix[k, l].SoHuu.Equals(currentPlayer)) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    LCount++;
                }
                l--;
            }
            int RCount = -1;
            l = j;
            for (int k = i; k >= 0; k--)
            {
                if (l >= SoLieu.CHESS_BOARD_COLUMN) break;
                if (matrix[k, l].SoHuu.Mark == "xxx") break;
                if (!matrix[k, l].SoHuu.Equals(currentPlayer)) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    RCount++;
                }
                l++;
            }

            return LCount + RCount >= 5;
        }
        #endregion
        private void ChangePlayer()
        {
            currentPlayer = currentPlayer.Id == players[0].Id ? players[1] : players[0];
            form.lblLuotDi.Text = currentPlayer.Mark;
            form.lblLuotDi.ForeColor = currentPlayer.Color;
            soNutDaDanh++;   
        }

        private List<Player> initPlayer(bool computerMode)
        {
            Player player1;
            Player player2;

            List<Player> players = new List<Player>();
            if (form.getRadioButonX().Checked == true)
            {
                player1 = new Player(0, "X");
                player2 = new Player(1, "O");

            }
            else
            {
                player1 = new Player(1, "O");
                player2 = new Player(0, "X");
            }

            players.Add(player1);
            players.Add(player2);
            currentPlayer = players[0];
            
            if (computerMode)
            {
                player2.IsComputer = true;
                Random rd = new Random();
                ComputerFirst = rd.Next(3, 50) % 2 == 1;
                if (ComputerFirst)
                {
                    currentPlayer = players[1];
                }

            }
            form.lblLuotDi.Text = currentPlayer.Mark;
            form.lblLuotDi.ForeColor = currentPlayer.Color;
            return players;
        }
        public void MayQuyetDinhDanh(int i, int j)
        {
            string tag = string.Format("{0};{1}", i, j);
            Console.WriteLine(tag);
            foreach (Button control in pnl_BanCo.Controls)
            {
                if (control.Tag.Equals(tag))
                {
                    control.PerformClick();
                    break;
                }
            }
        }
        #endregion


        
        //vùng thuật toán AI
        #region AI
        private void MayDanh()
        {
            int diemMax = 0;
            int diemPhongNgu = 0;
            int diemTanCong = 0;
            int imax = 0;
            int jmax = 0;

            //biến chỉ để in ra màn hình kiểm tra điểm
            int tempTC = 0, tempPN = 0;

            if (soNutDaDanh == 0)
            {
                MayQuyetDinhDanh(new Random().Next(5, 10), new Random().Next(7, 12));
                return;
            }
            //tính giờ
            Stopwatch st = new Stopwatch();
            st.Reset();
            st.Start();
            //giải thuật minimax
            for (int i = 0; i < SoLieu.CHESS_BOARD_ROW; i++)
            {
                for (int j = 0; j < SoLieu.CHESS_BOARD_COLUMN; j++)
                {
                    if (matrix[i, j].SoHuu.Mark == "xxx" && !CatTia(matrix[i, j]))
                    {
                        int diemTam;
                        diemTanCong = duyetTCNgang(i, j) + duyetTCDoc(i, j) + duyetTCCheoChinh(i, j) + duyetTCCheoPhu(i, j);

                        diemPhongNgu = duyetPNNgang(i, j) + duyetPNDoc(i, j) + duyetPNCheoChinh(i, j) + duyetPNCheoPhu(i, j);
                        if (diemPhongNgu > diemTanCong)
                        {
                            diemTam = diemPhongNgu;
                        }
                        else
                        {
                            diemTam = diemTanCong;
                        }

                        if (diemMax < diemTam)
                        {
                            diemMax = diemTam;
                            imax = i;
                            jmax = j;

                            //biến chỉ để in ra màn hình kiểm tra điểm
                            tempTC = diemTanCong;
                            tempPN = diemPhongNgu;
                        }
                    }
                }

            }
            st.Stop();
            Console.WriteLine("time: " + st.ElapsedMilliseconds.ToString());
            Console.WriteLine("Tan Cong: " + tempTC + ", Phong ngu: " + tempPN);
            Console.WriteLine("I max: "+imax+", J max: "+jmax+", Diem Max: " +diemMax);
            MayQuyetDinhDanh(imax, jmax);

        }








        //mảng điểm tấn công, phòng ngự:
        //root
        private int[] MangDiemTanCong = new int[7] { 0, 4, 25, 246, 7300, 16561, 59049 };
        private int[] MangDiemPhongNgu = new int[7] { 0, 3, 24, 243, 2197, 19773, 177957 };

        //nnc
        //private int[] MangDiemPhongNgu = new int[7] { 0, 1, 9, 81, 729, 6561, 59049 };
        // private int[] MangDiemPhongNgu = new int[7] { 0, 7, 50 , 350,1750,7860,210000 };
        //private int[] MangDiemTanCong = new int[7] { 0, 3, 24, 243, 2197, 19773, 177957 };

       // private int[] MangDiemTanCong = new int[7] { 0, 3, 24, 192, 1536, 12288, 98304 };
       // private int[] MangDiemPhongNgu = new int[7] { 0, 1, 9, 81, 729, 6561, 59049 };


        //các hàm duyệt tấn công
        #region Tấn Công
        private int duyetTCNgang(int dongHT, int cotHT)

        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichPhai = 0;
            int SoQuanDichTrai = 0;
            int KhoangChong = 0;

            //bên phải
            for (int dem = 1; dem <= 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5; dem++)
            {

                if (matrix[dongHT, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;
                }
                else
                    if (matrix[dongHT, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichPhai++;
                    break;
                }
                else KhoangChong++;
            }
            //bên trái
            for (int dem = 1; dem <= 4 && cotHT > 4; dem++)
            {
                if (matrix[dongHT, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichTrai++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichPhai > 0 && SoQuanDichTrai > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichPhai + SoQuanDichTrai];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        private int duyetTCDoc(int dongHT, int cotHT)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichTren = 0;
            int SoQuanDichDuoi = 0;
            int KhoangChong = 0;

            //bên trên
            for (int dem = 1; dem <= 4 && dongHT >= 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT - dem, cotHT].SoHuu.Equals(players[0]))
                {
                    SoQuanDichTren++;
                    break;
                }
                else KhoangChong++;
            }
            //bên dưới
            for (int dem = 1; dem <= 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5; dem++)
            {
                if (matrix[dongHT + dem, cotHT].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT + dem, cotHT].SoHuu.Equals(players[0]))
                {
                    SoQuanDichDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichTren > 0 && SoQuanDichDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichTren + SoQuanDichDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        private int duyetTCCheoChinh(int dongHT, int cotHT)
        {
            int DiemTanCong = 1;
            int SoQuanTa = 0;
            int SoQuanDichCheoTren = 0;
            int SoQuanDichCheoDuoi = 0;
            int KhoangChong = 0;

            //bên chéo xuôi xuống
            for (int dem = 1; dem <= 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5 && dongHT < SoLieu.CHESS_BOARD_ROW - 5; dem++)
            {
                if (matrix[dongHT + dem, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT + dem, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichCheoTren++;
                    break;
                }
                else KhoangChong++;
            }
            //chéo xuôi lên
            for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT > 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT - dem, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichCheoDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        private int duyetTCCheoPhu(int dongHT, int cotHT)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichCheoTren = 0;
            int SoQuanDichCheoDuoi = 0;
            int KhoangChong = 0;

            //chéo ngược lên
            for (int dem = 1; dem <= 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5 && dongHT > 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT - dem, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichCheoTren++;
                    break;
                }
                else KhoangChong++;
            }
            //chéo ngược xuống
            for (int dem = 1; dem <= 4 && cotHT > 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5; dem++)
            {
                if (matrix[dongHT + dem, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT + dem, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichCheoDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }
        #endregion



        //các hàm duyệt phòng thủ
        #region Phòng Thủ
        private int duyetPNNgang(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongPhai = 0;
            int KhoangChongTrai = 0;
            bool ok = false;


            for (int dem = 1; dem <= 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5; dem++)
            {
                if (matrix[dongHT, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongPhai++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongPhai == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;

            for (int dem = 1; dem <= 4 && cotHT > 4; dem++)
            {
                if (matrix[dongHT, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTrai++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTrai == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTrai + KhoangChongPhai + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }

        private int duyetPNDoc(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && dongHT > 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;

                }
                else
                    if (matrix[dongHT - dem, cotHT].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;
            //xuống
            for (int dem = 1; dem <= 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5; dem++)
            {
                //gặp quân địch
                if (matrix[dongHT + dem, cotHT].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT + dem, cotHT].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];
            return DiemPhongNgu;
        }
        private int duyetPNCheoChinh(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5; dem++)
            {
                if (matrix[dongHT + dem, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT + dem, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;
            //xuống
            for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT > 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT - dem, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaTrai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }

        private int duyetPNCheoPhu(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5; dem++)
            {

                if (matrix[dongHT - dem, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT - dem, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }


            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;

            //xuống
            for (int dem = 1; dem <= 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5 && cotHT > 4; dem++)
            {
                if (matrix[dongHT + dem, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT + dem, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }
        #endregion
        //các hàm phục vụ thuật toán alpha-beta pruning
        #region Bổ sung Cắt tỉa Alpha-Beta
        private bool CatTia(Oco oCo)
        {
            if (catTiaNgang(oCo) && catTiaDoc(oCo) && catTiaCheoChinh(oCo) && catTiaCheoPhu(oCo))
            {
                return true;
            }
            return false;
        }

        private bool catTiaCheoPhu(Oco oCo)
        {
            //duyệt từ trên xuống
            if (oCo.soHang <= SoLieu.CHESS_BOARD_ROW - 5 && oCo.soCot <= SoLieu.CHESS_BOARD_COLUMN - 5)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang + i, oCo.soCot + i].SoHuu.Mark != "")//nếu có nước cờ thì không cắt tỉa
                        return false;

            //duyệt từ giưới lên
            if (oCo.soCot >= 4 && oCo.soHang >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang - i, oCo.soCot - i].SoHuu.Mark != "")//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }

        private bool catTiaCheoChinh(Oco oCo)
        {
            //duyệt từ trên xuống
            if (oCo.soHang <= SoLieu.CHESS_BOARD_ROW - 5 && oCo.soCot >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang + i, oCo.soCot - i].SoHuu.Mark != "")//nếu có nước cờ thì không cắt tỉa
                        return false;

            //duyệt từ giưới lên
            if (oCo.soCot <= SoLieu.CHESS_BOARD_COLUMN - 5 && oCo.soHang >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang - i, oCo.soCot + i].SoHuu.Mark != "")//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }
         
        private bool catTiaDoc(Oco oCo)
        {
            //duyệt phía dưới
            if (oCo.soHang <= SoLieu.CHESS_BOARD_ROW - 5)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang + i, oCo.soCot].SoHuu.Mark != "")//nếu có nước cờ thì không cắt tỉa
                        return false;

            //duyệt phía trên
            if (oCo.soHang >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang - i, oCo.soCot].SoHuu.Mark != "")//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }

        private bool catTiaNgang(Oco oCo)
        {
            //duyệt phải
            if (oCo.soCot <= SoLieu.CHESS_BOARD_COLUMN - 5)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang, oCo.soCot + i].SoHuu.Mark != "")//nếu có nước cờ thì không cắt tỉa
                        return false;
            //duyệt trái
            if (oCo.soCot >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang, oCo.soCot - i].SoHuu.Mark != "")//nếu có nước cờ thì không cắt tỉa
                        return false;
            return true;
        }
        #endregion

        #endregion

    }
}
