using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNewMinigame
{

    internal class Player
    {
        public string last_key = null;
        public int x = 1;
        public int y = 1;
        public int Xoff = 36;
        public int Yoff = 7;
        public Queue<int> lengthX = new Queue<int>();
        public Queue<int> lengthY = new Queue<int>();
        //public Queue<int> length = new Queue<int>();
        
    }

   

}






