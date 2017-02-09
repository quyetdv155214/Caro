using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Player
    {
        private String name; // Ctrl + R + E
        private Image mark;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Image Mark
        {
            get
            {
                return mark;
            }

            set
            {
                mark = value;
            }
        }
        public Player(String name, Image mark)
        {
            this.name = name;
            this.mark = mark;
        }
    }
}
