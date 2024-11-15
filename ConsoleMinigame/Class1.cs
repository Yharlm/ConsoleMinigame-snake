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
        public string previous_key = null;
        public string last_key = null;
        public int x = 1;
        public int y = 1;
        public int Xoff = 36;
        public int Yoff = 7;
 //       public Queue<int> lengthX = new Queue<int>();
 //       public Queue<int> lengthY = new Queue<int>();

        public Queue<Cordinates> length = new Queue<Cordinates>();
        public void Increse_length()
        {
            Cordinates cordinates = new Cordinates();
            cordinates.X = x;
            cordinates.Y = y;
            
        }

    }
    class Cordinates
    {
        public int X;
        public int Y;
        
    
    }






}
