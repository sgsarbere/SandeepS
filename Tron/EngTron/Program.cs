using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngTron
{
    class Program
    {
        //test
        public static void Main(string[] args)
        {

            Players mctssPlayer = new JMCTSS(15, 200);
            Players humanPlayer = new HumanPlayerP4();
            PartS par = new PartS(mctssPlayer, humanPlayer, new PositionP4S());
            par.Start();

            Console.ReadLine();
        }
    }
}
