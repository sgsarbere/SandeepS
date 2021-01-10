using System;
using System.Threading.Tasks;

namespace EngTron
{
    /// <summary>
    /// english of PartieS
    /// </summary>
    public class PartS
    {
        Positions pCurrent;
        Players _mctssPlayer, _humanPlayer;
        public float r;

        public PartS(Players mctssPlayer, Players humanPlayer, Positions pInitiale)
        {
            this._mctssPlayer = mctssPlayer;
            this._humanPlayer = humanPlayer;
            pCurrent = pInitiale.Clone();
        }

        public void NewMatch(Positions pInitiale)
        {
            pCurrent = pInitiale.Clone();
        }

        public void Start(bool display = true)
        {
            _mctssPlayer.NewPart();
            _humanPlayer.NewPart();
            do
            {
                if (display) { pCurrent.Poster(); Console.WriteLine(); }

                Task<int> t1 = Task.Run(() => _mctssPlayer.Play(pCurrent.Clone(), true));
                Task<int> t0 = Task.Run(() => _humanPlayer.Play(pCurrent.Clone(), false));
                t1.Wait(); t0.Wait();
                pCurrent.Perform(t1.Result, t0.Result);

                //int rep1 = j1.Jouer(pCourante.Clone(), true);
                //int rep0 = j0.Jouer(pCourante.Clone(), false);
                //pCourante.EffectuerCoup(rep1, rep0);

                _mctssPlayer.Des();
                _humanPlayer.Des();

            } while (pCurrent.NbShots1 > 0 && pCurrent.NbShots0 > 0);
            r = pCurrent.Eval;
            if (display)
            {
                pCurrent.Poster();
                int re = 0;
                if (r > 0)
                {
                    re = 1;
                }
                if (r < 0)
                {
                    re = -1;
                }
                switch (re)
                {
                    case 1: Console.WriteLine("MCTS Player {0} won {1}.", _mctssPlayer, r); break;
                    case -1: Console.WriteLine("Human Player {0} won {1}.", _humanPlayer, -r); break;
                    case 0: Console.WriteLine("Drawn game."); break;
                    default: Console.WriteLine("Default."); break;
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
