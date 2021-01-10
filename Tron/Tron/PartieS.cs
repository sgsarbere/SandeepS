﻿using System;
using System.Threading.Tasks;

namespace Tron
{
    public class PartieS
    {
        PositionS pCourante;
        JoueurS j1, j0;
        public float r;

        public PartieS(JoueurS j1, JoueurS j0, PositionS pInitiale)
        {
            this.j1 = j1;
            this.j0 = j0;
            pCourante = pInitiale.Clone();
        }

        public void NouveauMatch(PositionS pInitiale)
        {
            pCourante = pInitiale.Clone();
        }

        public void Commencer(bool affichage = true)
        {
            j1.NouvellePartie();
            j0.NouvellePartie();
            do
            {
                if (affichage) { pCourante.Affiche(); Console.WriteLine(); }

                Task<int> t1 = Task.Run(() => j1.Jouer(pCourante.Clone(), true));
                Task<int> t0 = Task.Run(() => j0.Jouer(pCourante.Clone(), false));
                t1.Wait(); t0.Wait();
                pCourante.EffectuerCoup(t1.Result, t0.Result);

                //int rep1 = j1.Jouer(pCourante.Clone(), true);
                //int rep0 = j0.Jouer(pCourante.Clone(), false);
                //pCourante.EffectuerCoup(rep1, rep0);

                j1.Des(); j0.Des();

            } while (pCourante.NbCoups1 > 0 && pCourante.NbCoups0 > 0);
            r = pCourante.Eval;
            if (affichage)
            {
                pCourante.Affiche();
                int re = 0; if (r > 0) re = 1; if (r < 0) re = -1;
                switch (re)
                {
                    case 1: Console.WriteLine("j1 {0} a gagné {1}.", j1, r); break;
                    case -1: Console.WriteLine("j0 {0} a gagné {1}.", j0, -r); break;
                    case 0: Console.WriteLine("Partie nulle."); break;
                }
            }
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
