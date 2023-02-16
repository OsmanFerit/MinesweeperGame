using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame
{
    public partial class FirstScreen : Form
    {
        public FirstScreen()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (cmbLevels.SelectedItem != null)
            {
                object o1 = cmbLevels.SelectedItem;
                Settings settings = (Settings)o1;
                MinesweeperForm minesweeper = new MinesweeperForm(settings);
                minesweeper.ShowDialog();

            }
        }

        void FillComboBox ()
        {
            cmbLevels.DataSource = LevelDatabase.DificultySettingsDatabase;
        }

        private void FirstScreen_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            GuideForm openGuide = new GuideForm();
            openGuide.ShowDialog();
        }
    }
}
