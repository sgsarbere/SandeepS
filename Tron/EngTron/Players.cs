namespace EngTron
{
    /// <summary>
    /// English version
    /// </summary>
    public abstract class Players
    {
        public abstract int Play(Positions p, bool asj1);
        public virtual void NewPart() { }
        public virtual void Des() { }
    }

    public class PlayerHumanTron : Players
    {
        public override int Play(Positions p, bool asj1)
        {
            throw new System.NotImplementedException();
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
