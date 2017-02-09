﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ChessBoardManager
    {
        #region Properties
        List<List<Button>> matrixButton;
        private Panel panelChessBoard;
        private List<Player> players;
        private int currentPlayer;
        private TextBox playerName;
        private PictureBox playerMark;
        #endregion
        #region initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox pbMark)
        {
            this.panelChessBoard = chessBoard;
            this.players = new List<Player>()
            {
                new Player("player 1 ", Image.FromFile(Application.StartupPath + "\\Resources\\o.png")),
                new Player("player 2 ", Image.FromFile(Application.StartupPath + "\\Resources\\x.png"))
            };
            this.PlayerName = playerName;
            this.playerMark = pbMark;
            //
            currentPlayer = 0;
            //
            changePlayer();

        }

        internal List<Player> Players
        {
            get
            {
                return players;
            }

            set
            {
                players = value;
            }
        }

        public TextBox PlayerName
        {
            get
            {
                return playerName;
            }

            set
            {
                playerName = value;
            }
        }

        public PictureBox PlayerMark
        {
            get
            {
                return playerMark;
            }

            set
            {
                playerMark = value;
            }
        }

        public List<List<Button>> MatrixButton
        {
            get
            {
                return matrixButton;
            }

            set
            {
                matrixButton = value;
            }
        }
        #endregion


        #region Methods
        public void drawChessBar()
        {
            //  initialize matrix Button 
            MatrixButton = new List<List<Button>>();

            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.NUM_OF_ROW; i++)
            {
                MatrixButton.Add(new List<Button>());
                
                for (int j = 0; j < Cons.NUM_OF_COL; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y)
                        , BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString() // save num row of button

                    };
                    btn.Click += Btn_Click;

                    oldButton = btn;
                    panelChessBoard.Controls.Add(btn);
                    // add button to list
                    MatrixButton[i].Add(btn);

                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;

            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // check button da duoc bam 
            if (btn.BackgroundImage != null)
                return;
            mark(btn);
            changePlayer();
            // check endGame;
            if (isEndGame(btn))
            {
                endGame();
            }

        }
        private void mark(Button btn)
        {
            // change button mark
            btn.BackgroundImage = players[currentPlayer].Mark;
            // change player
            currentPlayer = currentPlayer == 1 ? 0 : 1;
        }
        private void changePlayer()
        {
            
            playerName.Text = players[currentPlayer].Name;
            playerMark.Image = players[currentPlayer].Mark;
        }
        #endregion
        private bool isEndGame(Button btn)
        {
            return isEndGameHorizontal(btn) || isEndGameVertical(btn) 
                || isEndGameSub(btn) || isEndGamePrimary(btn);
        }
        // get chess location 
        private Point getChessPoint(Button btn)
        {
            
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = MatrixButton[vertical].IndexOf(btn);
           Point point = new Point(horizontal, vertical);
            return point;

        }
        private bool isEndGameHorizontal(Button btn)
        {
            Point point = getChessPoint(btn);
            // Count left 
            int countLeft = 0;

            for(int i = point.X; i >= 0; i--)
            {
                if(MatrixButton[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;

                }else
                {
                    break;

                }
            }
            // count right 
            int countRight = 0;
            for (int i = point.X+1; i < Cons.CHESS_WIDTH; i++)
            {
                if (MatrixButton[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;

                }
                else
                {
                    break;

                }
            }



            return (countLeft + countRight) == 5;
        }
        private bool isEndGameVertical(Button btn)
        {
            Point point = getChessPoint(btn);
            // Count top 
            int countTop = 0;

            for (int i = point.Y; i >= 0; i--)
            {
                if (MatrixButton[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;

                }
                else
                {
                    break;

                }
            }
            // count button 
            int countButton = 0;
            for (int i = point.Y + 1; i <= Cons.CHESS_HEIGHT; i++)
            {
                if (MatrixButton[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countButton++;

                }
                else
                {
                    break;

                }
            }

            return (countTop + countButton) == 5;
        }
        private bool isEndGamePrimary(Button btn)
        {

            Point point = getChessPoint(btn);
            // Count top 
            int countTop = 0;

            for (int i = 0; i <= point.X ; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                {
                    break;
                }
                if (MatrixButton[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;

                }
                else
                {
                    break;

                }
            }
            // count button 
            int countButton = 0;
            for (int i =1; i <= Cons.CHESS_WIDTH - point.X; i++)
            {
                if(point.X + i >= Cons.CHESS_WIDTH || point.Y -i >= Cons.CHESS_HEIGHT)
                {
                    break;
                }
                if (MatrixButton[point.Y + i][point.X+ i].BackgroundImage == btn.BackgroundImage)
                {
                    countButton++;

                }
                else
                {
                    break;

                }
            }

            return (countTop + countButton) == 5;
            
        }
        private bool isEndGameSub(Button btn)
        {

            Point point = getChessPoint(btn);
            // Count top 
            int countTop = 0;

            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >Cons.CHESS_WIDTH || point.Y - i < 0)
                {
                    break;
                }
                if (MatrixButton[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;

                }
                else
                {
                    break;

                }
            }
            // count button 
            int countButton = 0;
            for (int i = 1; i <= Cons.CHESS_WIDTH - point.X; i++)
            {
                if (point.X + i < 0 || point.Y - i >= Cons.CHESS_HEIGHT)
                {
                    break;
                }
                if (MatrixButton[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countButton++;

                }
                else
                {
                    break;

                }
            }

            return (countTop + countButton) == 5;
        }
        private void endGame()
        {
            MessageBox.Show("End Game");
        }



    }
}
