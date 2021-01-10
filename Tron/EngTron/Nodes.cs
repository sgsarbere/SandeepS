using System;

namespace EngTron
{
    /// <summary>
    /// Noeuds
    /// </summary>
    public class Nodes
    {
        public Positions p;
        public Nodes parentNode;
        public Nodes[,] childNodes;
        public int cross;
        public float win;
        public int indexBestChild1, indexBestChild0;

        public Nodes(Nodes parentNode, Positions p)
        {
            this.parentNode = parentNode;
            this.p = p;
            childNodes = new Nodes[this.p.NbShots1, this.p.NbShots0];
        }

        public void CalculationBestChild(Func<int, float, float> phi, Random g)
        {
            float s;
            float sM = 0;
            float sw = 0; int sc = 0;

            int i0 = g.Next(p.NbShots1); indexBestChild1 = i0;
            sw = 0; sc = 0;
            for (int j = 0; j < p.NbShots0; j++)
            {
                if (childNodes[i0, j] != null) { sc += childNodes[i0, j].cross; sw += childNodes[i0, j].win; }
            }
            sM = phi(sc, sw);

            for (int i = 0; i < p.NbShots1; i++)
            {
                sw = 0; sc = 0;
                for (int j = 0; j < p.NbShots0; j++)
                {
                    if (childNodes[i, j] != null) { sc += childNodes[i, j].cross; sw += childNodes[i, j].win; }
                }
                s = phi(sc, sw);
                if (s > sM) { sM = s; indexBestChild1 = i; }
            }

            int j0 = g.Next(p.NbShots0); indexBestChild0 = j0;
            sw = 0; sc = 0;
            for (int i = 0; i < p.NbShots1; i++)
            {
                if (childNodes[i, j0] != null) { sc += childNodes[i, j0].cross; sw += -childNodes[i, j0].win; }
            }
            sM = phi(sc, sw);
            for (int j = 0; j < p.NbShots0; j++)
            {
                sw = 0; sc = 0;
                for (int i = 0; i < p.NbShots1; i++)
                {
                    if (childNodes[i, j] != null) { sc += childNodes[i, j].cross; sw += -childNodes[i, j].win; }
                }
                s = phi(sc, sw);
                if (s > sM) { sM = s; indexBestChild0 = j; }
            }
        }

        public Nodes BestChild()
        {
            if (childNodes[indexBestChild1, indexBestChild0] != null)
            {
                return childNodes[indexBestChild1, indexBestChild0];
            }
            Positions q = p.Clone();
            q.Perform(indexBestChild1, indexBestChild0);
            childNodes[indexBestChild1, indexBestChild0] = new Nodes(this, q);
            return childNodes[indexBestChild1, indexBestChild0];
        }

        public override string ToString()
        {
            string s = "";
            s = s + "indiceMF1 = " + indexBestChild1 + " indiceMF0 = " + indexBestChild0 + "\n";
            float sw = 0; int sc = 0;
            for (int j = 0; j < p.NbShots0; j++)
            {
                if (childNodes[indexBestChild1, j] != null) { sc += childNodes[indexBestChild1, j].cross; sw += childNodes[indexBestChild1, j].win; }
            }
            float note1 = sw / sc;

            sw = 0; sc = 0;
            for (int i = 0; i < p.NbShots1; i++)
            {
                if (childNodes[i, indexBestChild0] != null) { sc += childNodes[i, indexBestChild0].cross; sw += childNodes[i, indexBestChild0].win; }
            }
            float note0 = sw / sc;

            s += String.Format("note1= {0} note0={1} \n", note1, note0);
            s += "\n";
            return s;
        }
    }

    //public abstract class PositionS
    //{
    //    public float Eval { get; protected set; }
    //    //public int NbCoups1 { get; protected set; }
    //    //public int NbCoups0 { get; protected set; }
    //    public int NbShots1 { get; protected set; }
    //    public int NbShots0 { get; protected set; }
    //    //public abstract void EffectuerCoup(int i, int j);
    //    public abstract void Perform(int i, int j);
    //    public abstract PositionS Clone();
    //    //public abstract void Affiche();
    //    public abstract void Poster();
    //}

    ////Players=JoueurS
    ////public abstract class JoueurS
    //public abstract class Players
    //{
    //    //public abstract int Jouer(PositionS p, bool asj1);
    //    public abstract int Play(PositionS p, bool asj1);
    //    //public virtual void NouvellePartie() { }
    //    public virtual void NewPart() { }
    //    //public virtual void Des() { }
    //    public virtual void Of() { }
    //}

    //public class JH : Players
    //{
    //    Random gen = new Random();
    //    //Jouer-To play
    //    public override int Play(PositionS p, bool asj1)
    //    {
    //        return asj1 ? gen.Next(p.NbShots1) : gen.Next(p.NbShots0);
    //    }
    //}


}
