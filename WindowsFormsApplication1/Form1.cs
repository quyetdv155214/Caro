using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager chessBoard;
        #endregion
        public Form1()
        {
            InitializeComponent();

            chessBoard = new ChessBoardManager(panelChessBoard, playerName, playerMark);
            chessBoard.PlayerMarked
                 += ChessBoard_PlayerMarked;
            chessBoard.EndedGame += ChessBoard_EndedGame;

            newGame();
            setUpUI();

        }
        #region Event
        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            // start timer
            pbCoolDown.Value = 0;
            pbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            timerCooldown.Start();

        }
        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            endGame();
        }
        private void timerCooldown_Tick(object sender, EventArgs e)
        {
            
            
            if (pbCoolDown.Value < pbCoolDown.Maximum)
            {
                pbCoolDown.PerformStep();

            }else
            {
                endGame();
            }

            lbTest.Text = "Bug : "+pbCoolDown.Value +" / "+ pbCoolDown.Maximum ;
           
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerCooldown.Stop();
            if (MessageBox.Show("Exit ?", "Message", MessageBoxButtons.OKCancel)
                 != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
                timerCooldown.Start();
            }

        }
        #endregion



        #region Method

        void setUpUI()
        {
            pbCoolDown.Step = Cons.COOL_DOWN_STEP;
            pbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            pbCoolDown.Value = 0;
            timerCooldown.Interval = Cons.COOL_DOWN_INTERVAL;

        }
        public void endGame()
        {

            timerCooldown.Stop();
            panelChessBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;

            MessageBox.Show("End");
        }
        void newGame()
        {
            pbCoolDown.Value = 0;
            timerCooldown.Stop();
            panelChessBoard.Enabled = true;
            undoToolStripMenuItem.Enabled = false;
            chessBoard.drawChessBar();
        }
        void quit()
        {
            
            Application.Exit();

        }
        void undo()
        {
            chessBoard.undo();
        }
        


        #endregion

      
    }
}
