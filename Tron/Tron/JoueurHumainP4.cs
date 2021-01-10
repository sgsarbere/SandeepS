using System;

namespace Tron
{
    
    public class JoueurHumainP4 : JoueurS
    {
        public override void NouvellePartie()
        {
        }

        public override int Jouer(PositionS p, bool asj1)
        {
            PositionP4S p4 = (PositionP4S)p;

            int k;
            do
            {
                Console.WriteLine("Choisissez la colonne pour les {0} :", asj1 ? "rouges" : "bleus");
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
    }
}
