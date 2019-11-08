using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    class Oco
    {
        private Player sohuu;
        private int i;
        private int j;

        public Player SoHuu
        {
            get { return sohuu; }
            set { sohuu = value; }
        }
        public int soHang
        {
            get { return i; }
            set { i = value; }
        }
        public int soCot
        {
            get { return j; }
            set { j = value; }
        }
        public Oco()
        {
            SoHuu = new Player(0,"xxx");
        }
    }
}
