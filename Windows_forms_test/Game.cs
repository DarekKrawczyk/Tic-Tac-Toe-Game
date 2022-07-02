using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_forms_test
{
    public partial class Game : Form
    {
        static int iterator = 0;
        public int flag;
        public int W1=3;
        public int W2=300;
        public int value = 100;
        System.Drawing.Color color_player_1 = Color.Aqua;
        System.Drawing.Color color_player_2 = Color.Crimson;
        public string player_1;
        public string player_2;
        int[,] tab = new int [3,3];
        MessageBoxButtons result = MessageBoxButtons.YesNo;
        public enum State { playing, won_p1, won_p2};
        State game_state = State.playing;

        public Game()
        {
            InitializeComponent();
        }
        
        public Game(string player_1, string player_2)
        {
            InitializeComponent();
            InitializePlayer(ref flag);
            this.player_1 = player_1;
            this.player_2 = player_2;
            label7.Text = player_1;
            label8.Text = player_2;
            playerUpdate();
            InitializeScore();
        }

        public void gameWon()
        {
            if (iterator == 9 && game_state == State.playing)
            {
                label9.Text = $"Tie!";
                DialogResult dialogresult = MessageBox.Show($"Tie! Do you wish to restart the game?", "Game Results", result);
                if (dialogresult == DialogResult.Yes)
                {
                    restartGame();

                }
                else if (dialogresult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else if (game_state == State.won_p1)
            {
                label9.Text = $"Tie";
                DialogResult dialogresult = MessageBox.Show($"Tie! Do you wish to restart the game?", "Game Results", result);
                if (dialogresult == DialogResult.Yes)
                {
                    restartGame();

                }
                else if (dialogresult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else if (game_state == State.won_p2)
            {
                label9.Text = $"{player_2} Won!";
                DialogResult dialogresult = MessageBox.Show($"{player_2} has won! Do you wish to restart the game?", "Game Results", result);
                if (dialogresult == DialogResult.Yes)
                {
                    restartGame();

                }
                else if (dialogresult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }

        public void restartGame()
        {
            iterator = 0;
            pictureBox19.BackColor = Color.LightGray;
            pictureBox20.BackColor = Color.LightGray;
            pictureBox21.BackColor = Color.LightGray;
            pictureBox22.BackColor = Color.LightGray;
            pictureBox23.BackColor = Color.LightGray;
            pictureBox24.BackColor = Color.LightGray;
            pictureBox25.BackColor = Color.LightGray;
            pictureBox26.BackColor = Color.LightGray;
            pictureBox27.BackColor = Color.LightGray;
            game_state = State.playing;
            InitializePlayer(ref flag);
            InitializeScore();
            playerUpdate();
        }

        public void playerUpdate()
        {
            if (flag == 0)
            {
                label9.Text = $"{player_1} move";
                pictureBox34.BackColor = color_player_1;
            }
            else
            {
                label9.Text = $"{player_2} move";
                pictureBox34.BackColor = color_player_2;
            }
            checkState();
        }

        public void checkState()
        {
            int win_1 = 0, win_2 = 0, win_3 = 0, win_4 = 0, win_5 = 0, win_6 = 0, win_7 = 0, win_8 = 0;
            for (int i = 0; i < 3; i++)
            {
                win_1 += tab[i, 0];
                win_2 += tab[i, 1];
                win_3 += tab[i, 2];
                win_4 += tab[0, i];
                win_5 += tab[1, i];
                win_6 += tab[2, i];
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        win_7 += tab[i, j];
                    }
                    if (i + j == 2)
                    {
                        win_8 +=tab[i, j];
                    }
                }
            }
            if (win_1 == W1) game_state = State.won_p1;
            else if (win_1 == W2) game_state = State.won_p2;
            if (win_2 == W1) game_state = State.won_p1;
            else if (win_2 == W2) game_state = State.won_p2;
            if (win_3 == W1) game_state = State.won_p1;
            else if (win_3 == W2) game_state = State.won_p2;
            if (win_4 == W1) game_state = State.won_p1;
            else if (win_4 == W2) game_state = State.won_p2;
            if (win_5 == W1) game_state = State.won_p1;
            else if (win_5 == W2) game_state = State.won_p2;
            if (win_6 == W1) game_state = State.won_p1;
            else if (win_6 == W2) game_state = State.won_p2;
            if (win_7 == W1) game_state = State.won_p1;
            else if (win_7 == W2) game_state = State.won_p2;
            if (win_8 == W1) game_state = State.won_p1;
            else if (win_8 == W2) game_state = State.won_p2;

            gameWon();
        }

        public void InitializeScore()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j=0; j < 3; j++)
                {
                    tab[i,j] = 0;
                }
            }
        }

        public int InitializePlayer(ref int player)
        {
            pictureBox32.BackColor = color_player_1;
            pictureBox33.BackColor = color_player_2;
            Random random = new Random();
            player = random.Next(0, 2);
            return player;
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            iterator++;
            if (this.flag == 0)
            {
                pictureBox19.BackColor = color_player_1;
                tab[0,0] = 1;
                this.flag = 1;
            } else if (this.flag == 1)
            {
                pictureBox19.BackColor = color_player_2;
                tab[0, 0] = value;
                this.flag = 0;
            }
            playerUpdate();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            iterator++;
            if (this.flag == 0)
            {
                pictureBox20.BackColor = color_player_1;
                tab[0, 1] = 1;
                this.flag = 1;
            }
            else if (this.flag == 1)
            {
                pictureBox20.BackColor = color_player_2;
                tab[0, 1] = value;
                this.flag = 0;
            }
            playerUpdate();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            iterator++;
            if (this.flag == 0)
            {
                pictureBox23.BackColor = color_player_1;
                tab[0, 2] = 1;
                this.flag = 1;
            }
            else if (this.flag == 1)
            {
                pictureBox23.BackColor = color_player_2;
                tab[0, 2] = value;
                this.flag = 0;
            }
            playerUpdate();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            iterator++;
            if (this.flag == 0)
            {
                pictureBox21.BackColor = color_player_1;
                tab[1, 0] = 1;
                this.flag = 1;
            }
            else if (this.flag == 1)
            {
                pictureBox21.BackColor = color_player_2;
                tab[1, 0] = value;
                this.flag = 0;
            }
            playerUpdate();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            iterator++;
            if (this.flag == 0)
            {
                pictureBox22.BackColor = color_player_1;
                tab[1, 1] = 1;
                this.flag = 1;
            }
            else if (this.flag == 1)
            {
                pictureBox22.BackColor = color_player_2;
                tab[1, 1] = value;
                this.flag = 0;
            }
            playerUpdate();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            iterator++;
            if (this.flag == 0)
            {
                pictureBox24.BackColor = color_player_1;
                tab[1, 2] = 1;
                this.flag = 1;
            }
            else if (this.flag == 1)
            {
                pictureBox24.BackColor = color_player_2;
                tab[1, 2] = value;
                this.flag = 0;
            }
            playerUpdate();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            iterator++;
            if (this.flag == 0)
            {
                pictureBox25.BackColor = color_player_1;
                tab[2, 0] = 1;
                this.flag = 1;
            }
            else if (this.flag == 1)
            {
                pictureBox25.BackColor = color_player_2;
                tab[2, 0] = value;
                this.flag = 0;
            }
            playerUpdate();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            iterator++;
            if (this.flag == 0)
            {
                pictureBox26.BackColor = color_player_1;
                tab[2, 1] = 1;
                this.flag = 1;
            }
            else if (this.flag == 1)
            {
                pictureBox26.BackColor = color_player_2;
                tab[2, 1] = value;
                this.flag = 0;
            }
            playerUpdate();
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            iterator++;
            if (this.flag == 0)
            {
                pictureBox27.BackColor = color_player_1;
                tab[2, 2] = 1;
                this.flag = 1;
            }
            else if (this.flag == 1)
            {
                pictureBox27.BackColor = color_player_2;
                tab[2, 2] = value;
                this.flag = 0;
            }
            playerUpdate();
        }
    }
}
