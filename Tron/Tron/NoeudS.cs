﻿using System;

namespace Tron
{
    public class NoeudS
    {
        public PositionS p;
        public NoeudS pere;
        public NoeudS[,] fils;
        public int cross;
        public float win;
        public int indiceMeilleurFils1, indiceMeilleurFils0;

        public NoeudS(NoeudS pere, PositionS p)
        {
            this.pere = pere;
            this.p = p;
            fils = new NoeudS[this.p.NbCoups1, this.p.NbCoups0];
        }

        public void CalculMeilleurFils(Func<int, float, float> phi, Random g)
        {
            float s;
            float sM = 0;
            float sw = 0; int sc = 0;

            int i0 = g.Next(p.NbCoups1); indiceMeilleurFils1 = i0;
            sw = 0; sc = 0;
            for (int j = 0; j < p.NbCoups0; j++)
            {
                if (fils[i0, j] != null) { sc += fils[i0, j].cross; sw += fils[i0, j].win; }
            }
            sM = phi(sc, sw);

            for (int i = 0; i < p.NbCoups1; i++)
            {
                sw = 0; sc = 0;
                for (int j = 0; j < p.NbCoups0; j++)
                {
                    if (fils[i, j] != null) { sc += fils[i, j].cross; sw += fils[i, j].win; }
                }
                s = phi(sc, sw);
                if (s > sM) { sM = s; indiceMeilleurFils1 = i; }
            }

            int j0 = g.Next(p.NbCoups0); indiceMeilleurFils0 = j0;
            sw = 0; sc = 0;
            for (int i = 0; i < p.NbCoups1; i++)
            {
                if (fils[i, j0] != null) { sc += fils[i, j0].cross; sw += -fils[i, j0].win; }
            }
            sM = phi(sc, sw);
            for (int j = 0; j < p.NbCoups0; j++)
            {
                sw = 0; sc = 0;
                for (int i = 0; i < p.NbCoups1; i++)
                {
                    if (fils[i, j] != null) { sc += fils[i, j].cross; sw += -fils[i, j].win; }
                }
                s = phi(sc, sw);
                if (s > sM) { sM = s; indiceMeilleurFils0 = j; }
            }
        }

        public NoeudS MeilleurFils()
        {
            if (fils[indiceMeilleurFils1, indiceMeilleurFils0] != null)
            {
                return fils[indiceMeilleurFils1, indiceMeilleurFils0];
            }
            PositionS q = p.Clone();
            q.EffectuerCoup(indiceMeilleurFils1, indiceMeilleurFils0);
            fils[indiceMeilleurFils1, indiceMeilleurFils0] = new NoeudS(this, q);
            return fils[indiceMeilleurFils1, indiceMeilleurFils0];
        }

        public override string ToString()
        {
            string s = "";
            s = s + "indiceMF1 = " + indiceMeilleurFils1 + " indiceMF0 = " + indiceMeilleurFils0 + "\n";
            float sw = 0; int sc = 0;
            for (int j = 0; j < p.NbCoups0; j++)
            {
                if (fils[indiceMeilleurFils1, j] != null) { sc += fils[indiceMeilleurFils1, j].cross; sw += fils[indiceMeilleurFils1, j].win; }
            }
            float note1 = sw / sc;

            sw = 0; sc = 0;
            for (int i = 0; i < p.NbCoups1; i++)
            {
                if (fils[i, indiceMeilleurFils0] != null) { sc += fils[i, indiceMeilleurFils0].cross; sw += fils[i, indiceMeilleurFils0].win; }
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
