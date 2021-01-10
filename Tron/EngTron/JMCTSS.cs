using System;
using System.Diagnostics;

namespace EngTron
{
    public class JMCTSS : Players
    {
        Random gen = new Random();
        Stopwatch sw = new Stopwatch();

        protected float a;
        public int temps, iter;

        Nodes rootNode;

        public JMCTSS(float a, int temps)
        {
            this.a = a;
            this.temps = temps;
        }

        public override string ToString()
        {
            return string.Format("JMCTSS[{0} - temps={1}]", a, temps);
        }

        /// <summary>
        /// English version
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public virtual float GameChance(Positions p)
        {
            Positions q = p.Clone();
            while (q.NbShots1 > 0 && q.NbShots0 > 0)
            {
                q.Perform(gen.Next(0, q.NbShots1), gen.Next(0, q.NbShots0));
            }
            return q.Eval;
        }

        public override void NewPart() { rootNode = null; }

        public override int Play(Positions p, bool asj1)
        {
            sw.Restart();
            Func<int, float, float> phi = (C, W) => (a + W) / (a + C);
            rootNode = new Nodes(null, p);
            iter = 0;
            while (sw.ElapsedMilliseconds < temps)
            {
                Nodes node = rootNode;

                do // Sélection
                {
                    node.CalculationBestChild(phi, gen);
                    node = node.BestChild();

                } while (node.cross > 0 && node.childNodes.Length > 0);

                float re = GameChance(node.p); // Simulation

                while (node != null) // Backpropagation
                {
                    node.cross += 1;
                    node.win += re;
                    node = node.parentNode;
                }
                iter++;
            }
            rootNode.CalculationBestChild(phi, gen);
            int rep = (asj1) ? rootNode.indexBestChild1 : rootNode.indexBestChild0;
            return rep;
        }

        public override void Des()
        {
            Console.Write("{0} itérations  ", iter);
            Console.Write(rootNode);
        }

        



    }

}
