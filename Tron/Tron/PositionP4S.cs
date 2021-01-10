using System;
using System.Collections;

namespace Tron
{
    public class PositionP4S : PositionS
    {
        static Random gen = new Random();
        public static byte lmin1 = 3;
        public static byte lmin2 = lmin1;
        public static byte nbLi = 6;
        public static byte nbCo = 10;
        public static int nbCases = nbLi * nbCo;


        public BitArray[] cases;

        public PositionP4S()
        {
            cases = new BitArray[3];
            cases[2] = new BitArray(nbCases);
            cases[1] = new BitArray(nbCases);
            cases[0] = new BitArray(nbCases);
            Eval = 0;
            NbCoups0 = nbCo; NbCoups1 = nbCo;
        }

        public PositionP4S(PositionP4S p)
        {
            cases = new BitArray[3];
            this.cases[0] = (BitArray)p.cases[0].Clone();
            this.cases[1] = (BitArray)p.cases[1].Clone();
            this.cases[2] = (BitArray)p.cases[2].Clone();
            Eval = p.Eval;
            NbCoups1 = p.NbCoups1; NbCoups0 = p.NbCoups0;
        }


        public override bool Equals(object obj)
        {
            PositionP4S q = (PositionP4S)obj;
            for (int i = 0; i < nbLi; i++)
            {
                for (int j = 0; j < nbCo; j++)
                {
                    if (cases[0][i + j * nbLi] != q.cases[0][i + j * nbLi]) { return false; }
                    if (cases[1][i + j * nbLi] != q.cases[1][i + j * nbLi]) { return false; }
                    if (cases[2][i + j * nbLi] != q.cases[1][i + j * nbLi]) { return false; }
                }
            }
            return true;
        }

        public override PositionS Clone()
        {
            return new PositionP4S(this); ;
        }


        public override void EffectuerCoup(int i, int j)
        {
            int k1 = -1;
            int h = -1;
            do
            {
                do { k1++; }
                while (cases[1][nbLi - 1 + k1 * nbLi] || cases[0][nbLi - 1 + k1 * nbLi] || cases[2][nbLi - 1 + k1 * nbLi]);
                h++;
            }
            while (h < i);

            k1 = nbLi - 1 + k1 * nbLi;
            int ell = 0;
            for (ell = 0; ell < nbLi; ell++)
            {
                if (cases[1][k1 - ell] || cases[0][k1 - ell] || cases[2][k1 - ell]) break;
            }
            k1 = k1 - ell + 1;

            int k0 = -1;
            h = -1;
            do
            {
                do { k0++; }
                while (cases[1][nbLi - 1 + k0 * nbLi] || cases[0][nbLi - 1 + k0 * nbLi] || cases[2][nbLi - 1 + k0 * nbLi]);
                h++;
            }
            while (h < j);

            k0 = nbLi - 1 + k0 * nbLi;
            for (ell = 0; ell < nbLi; ell++)
            {
                if (cases[1][k0 - ell] || cases[0][k0 - ell] || cases[2][k0 - ell]) break;
            }
            k0 = k0 - ell + 1;

            if (k0 == k1)
            {
                cases[2][k0] = true;
                NbCoups0 -= (k0 % nbLi == nbLi - 1) ? 1 : 0; NbCoups1 = NbCoups0;
                return;
            }

            cases[1][k1] = true; cases[0][k0] = true;
            bool[] re = new bool[2] { false, false };
            int[] kt = new int[2] { k0, k1 };

            for (int cou = 0; cou < 2; cou++)
            {
                int x = kt[cou] % nbLi;
                int y = kt[cou] / nbLi;

                for (int dx = -1; dx <= 1 && !re[cou]; dx++)
                {
                    for (int dy = 0; dy <= 1 && !re[cou]; dy++)
                    {
                        if (dx == 0 && dy == 0) { continue; }
                        if (dx == -1 && dy == 0) { continue; }
                        int nb = 1;
                        int a = x + dx; int b = y + dy;

                        while (a < nbLi && a >= 0 && b < nbCo && (cases[cou][b * nbLi + a]))
                        {
                            nb++;
                            a += dx; b += dy;
                        }
                        a = x - dx; b = y - dy;
                        while (a < nbLi && a >= 0 && b >= 0 && (cases[cou][b * nbLi + a]))
                        {
                            nb++;
                            a -= dx; b -= dy;
                        }
                        if (nb >= lmin1)
                        {
                            re[cou] = true;
                        }
                    }
                }
            }

            if (re[0] && re[1])
            {
                NbCoups0 = 0; NbCoups1 = 0; return;
            }

            if (re[0])
            {
                NbCoups0 = 0; NbCoups1 = 0; Eval = -1; return;
            }

            if (re[1])
            {
                NbCoups0 = 0; NbCoups1 = 0; Eval = 1; return;
            }

            NbCoups0 -= (k0 % nbLi == nbLi - 1) ? 1 : 0;
            NbCoups0 -= (k1 % nbLi == nbLi - 1) ? 1 : 0;
            NbCoups1 = NbCoups0;
        }

        public override void Affiche()
        {
            Console.Write("\n| ");
            for (int j = 0; j < nbCo; j++)
            {
                Console.Write(" " + (char)(j + 'a') + " ");
            }
            Console.Write("\n");
            for (int j = 0; j < nbCo; j++)
            {
                Console.Write("---");
            }
            Console.Write("-\n");
            for (int i = nbLi - 1; i >= 0; i--)
            {
                Console.Write("| ");
                for (int j = 0; j < nbCo; j++)
                {
                    int ca = 0;
                    if (cases[1][j * nbLi + i]) ca = 1;
                    if (cases[0][j * nbLi + i]) ca = 2;
                    if (cases[2][j * nbLi + i]) ca = 3;
                    switch (ca)
                    {
                        case (0):
                            Console.Write(" . ");
                            break;
                        case (1):
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" 1 ");
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case (2):
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" 0 ");
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case (3):
                            Console.Write(" * ");
                            break;
                    }
                }
                Console.Write("\n");
            }
            for (int j = 0; j < nbCo; j++)
            {
                Console.Write("---");
            }
            Console.Write("-\n");
        }
    }
}
