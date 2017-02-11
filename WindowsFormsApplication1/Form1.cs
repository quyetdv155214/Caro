using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager chessBoard;
        SocketManager socket;
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

            }
            else
            {
                endGame();
            }

            lbTest.Text = "Bug : " + pbCoolDown.Value + " / " + pbCoolDown.Maximum;

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
        private void btLan_Click(object sender, EventArgs e)
        {
            socket.IP = tbIP.Text;
            if (!socket.connectServer())
            {
                socket.createServer();
               
            }
            else
            {
                listen();

               

            }


        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            tbIP.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(tbIP.Text))
            {
                tbIP.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Ethernet);

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
            socket = new SocketManager();

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
            undoToolStripMenuItem.Enabled = true;
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
        public void listen()
        {

            Thread listenThread = new Thread(() =>
           {
               try
               {
                   SocketData data = (SocketData)socket.receive();
                       //
                       processData(data);
               }
               catch
               {

               }
           });
            listenThread.IsBackground = true;
            listenThread.Start();






        }
        private void processData(SocketData data)
        {
            switch ((int)data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Messeage);
                    break;
                case (int)SocketCommand.NEW_GAME:

                    break;
                case (int)SocketCommand.UNDO:

                    break;
                case (int)SocketCommand.QUIT:

                    break;


            }

        }



        #endregion


    }
}
