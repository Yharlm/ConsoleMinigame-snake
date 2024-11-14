using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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
        
        public Queue<string> length = new Queue<string>();
        public void Increse_length()
        {
            lengthX.Enqueue(x);
            lengthY.Enqueue(y);
            //length.Enqueue(x,y);
        }

    }
    class Cordinates : Player
    {
        private int X;
        private int Y;
        public int Cordeinates(int x, int y) 
        {
            return x = X; y = Y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }

    
    



}





