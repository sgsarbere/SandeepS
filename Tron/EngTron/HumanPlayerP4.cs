using System;

namespace EngTron
{
    /// <summary>
    /// english version JoueurHumainP4
    /// </summary>
    public class HumanPlayerP4 : Players
    {
        protected float a;
        public int temps, iter;

        Nodes currentNode;

        public override void NewPart()
        {
        }

        public override int Play(Positions p, bool asj1)
        {
            PositionP4S p4 = (PositionP4S)p;
           // currentNode = new Nodes(null, p);
            int k;
            do
            {
                Console.WriteLine("Choose the column for human player {0} :", asj1 ? "red" : "blue");

                string s = Console.ReadLine();
                k = -10;
                if (s.Length == 1)
                {
                    k = s[0] - 'a' + 1;
                }
            }
            while (k < 1 || k > PositionP4S.nbCo || p4.cases[0][-1 + k * PositionP4S.nbLi] || p4.cases[1][-1 + k * PositionP4S.nbLi] || p4.cases[2][-1 + k * PositionP4S.nbLi]);
            k--;
            int rep = 0;
            for (int i = 1; i <= k; i++) //b * nbLi + a
            {
                if (!p4.cases[0][-1 + i * PositionP4S.nbLi] && !p4.cases[1][-1 + i * PositionP4S.nbLi] && !p4.cases[2][-1 + i * PositionP4S.nbLi]) rep++;
            }

            return rep;
        }

        public override void Des()
        {
            //Console.Write("{0} itérations  ", iter);
            //Console.Write(currentNode);
        }
    }
}
