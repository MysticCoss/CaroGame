using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    class Player
    {
        private int id;
        private string mark;
        private Color color;
        private bool isComputer = false;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        public Color Color
        {
            get { return this.color; }
            set { color = value; }
        }
        public bool IsComputer
        {
            get { return isComputer; }
            set { isComputer = value; }
        }
        public Player ( int id, string mark)
        {
            this.id = id;
            this.mark = mark;
            if (mark.Equals("X")==true)
            {
                color = Color.Green;
            }
            else color = Color.Red;
        } 
    }
}
