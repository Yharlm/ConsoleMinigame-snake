using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNewMinigame
{

    internal class Player
    {
        public bool God_Mode = false;
        public bool Is_alive = true;
        public string last_key = null;
        public int x = 1;
        public int y = 1;
        public int Xoff = 36;
        public int Yoff = 7;
        public Queue<int> lengthX = new Queue<int>();
        public Queue<int> lengthY = new Queue<int>();
        //public Queue<int> length = new Queue<int>();
        public void Increse_length()
        {
            lengthX.Enqueue(x);
            lengthY.Enqueue(y);
            
        }
    }

    
    



}





