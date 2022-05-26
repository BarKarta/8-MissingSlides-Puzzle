using System;
using System.Windows.Forms;

namespace _8_Puzzle_Sliding_Tiles_Puzzle
{
    public partial class MainForm : Form
    {
        // Class Veriables
        private Game game = null;
        private Button[,] btnArray;
        private bool isFirstClick;
        private State.HeuristicType heuristicType;
        private bool gameOver;


        public MainForm()
        {
            InitializeComponent();
            isFirstClick = true;
            heuristicType = State.HeuristicType.Manhattan;

            btnArray = new Button[,]
                        {{location_1,location_2,location_3},
                         {location_4,location_5,location_6},
                         {location_7,location_8,emptyLocation}};

            resetBtn.Enabled = false;
            durigGameLabel.Visible = false;
            gameOver = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        private void SlidingTilesPuzzle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gameOver)
                return;
            
            if (e.KeyChar == ' ' && isFirstClick) // checks if first click
            {
                isFirstClick = false;
                manhattanHeuristicbtn.Enabled = false;
                misplacedHeuristicbtn.Enabled = false;
                resetBtn.Enabled = true;
                this.game = new Game(this.heuristicType, btnArray);
                this.game.updateGame();
                guideLabel.Visible = false;
                durigGameLabel.Visible = true;
                this.Focus();
            }
            else if (e.KeyChar == ' ' && !isFirstClick)
            {
                gameOver = this.game.nextMove();
                this.game.updateGame();
                this.Focus();

                if (gameOver)
                {
                    setButtons(false);
                    MessageBox.Show("Great Succes");
                }

            }
        }

        public void setButtons( bool enable)
        {
            for (int i = 0; i < btnArray.GetLength(0); i++)
            {
                for (int j = 0; j < btnArray.GetLength(1); j++)
                    btnArray[i, j].Enabled = enable;
            }
        }


        private void resetBtn_Click(object sender, EventArgs e)
        {
            game = new Game(heuristicType, btnArray);
            isFirstClick = true;

            manhattanHeuristicbtn.Enabled = true;
            misplacedHeuristicbtn.Enabled = true;
            resetBtn.Enabled = false;
            guideLabel.Visible = true;
            durigGameLabel.Visible = false;
            gameOver = false;

            clearButtonText();
            setButtons(true);
        }

        private void clearButtonText()
        {
            foreach (Button btn in this.btnArray)
                btn.Text = "";
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (manhattanHeuristicbtn.Checked)
                heuristicType = State.HeuristicType.Manhattan;
            if (misplacedHeuristicbtn.Checked)
                heuristicType = State.HeuristicType.Misplaced;
        }
    }
}
