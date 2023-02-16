using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame
{
    public class Settings
    {
        public string DifficultyLevel { get; set; }
        public int Buttons { get; set; }
        public int ButtonWidth { get; set; }
        public int ButtonHeight { get; set; }
        public int MineCount { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }
        

        public override string ToString()
        {
            return DifficultyLevel;
        }
    }
}
