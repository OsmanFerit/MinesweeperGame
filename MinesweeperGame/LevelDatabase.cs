using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame
{
    public static class LevelDatabase
    {
        public static List<Settings> DificultySettingsDatabase = new List<Settings>()
        {
            new Settings(){ DifficultyLevel = "Easy", ButtonHeight= 62, ButtonWidth = 62, Buttons = 60, MineCount = 4,rows = 10, cols = 6},
            new Settings(){ DifficultyLevel = "Normal", ButtonHeight= 35, ButtonWidth = 35, Buttons = 170, MineCount = 10,rows = 17, cols = 10},
            new Settings(){ DifficultyLevel = "Hard", ButtonHeight= 33, ButtonWidth = 33, Buttons = 450, MineCount = 20,rows = 25, cols = 18}
        };
    }
}
