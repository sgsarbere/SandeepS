using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tron
{
    class Program
    {
        public static void Main(string[] args)
        {

            JoueurS j1 = new JMCTSS(15, 200);
            JoueurS j0 = new JoueurHumainP4();
            PartieS par = new PartieS(j1, j0, new PositionP4S());
            par.Commencer();

            Console.ReadLine();
        }


    }
}
