using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame
{
    public class mine
    {
        public int id { get; set; }
        public bool isMineAround { get; set; }

        public override string ToString()
        {
            return id.ToString();
        }
    }
}
