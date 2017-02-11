using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class SocketData
    {
        private int command;
        private Point? point;
        string messeage;
        public SocketData(int command,string mess, Point? point)

        {
            this.Messeage = mess;
            this.command = command;
            this.point = point;
        }

        public int Command
        {
            get
            {
                return command;
            }

            set
            {
                command = value;
            }
        }

        public Point? Point
        {
            get
            {
                return point;
            }

            set
            {
                point = value;
            }
        }

        public string Messeage
        {
            get
            {
                return messeage;
            }

            set
            {
                messeage = value;
            }
        }
    }
    public enum SocketCommand
    {
        SEND_POINT, 
        NOTIFY,
        NEW_GAME, 
        UNDO,
        QUIT
    }
}
