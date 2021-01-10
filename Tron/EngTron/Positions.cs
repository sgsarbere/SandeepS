namespace EngTron
{
    //English version
    public abstract class Positions
    {
        public float Eval { get; protected set; }        
        public int NbShots1 { get; protected set; }
        public int NbShots0 { get; protected set; }        
        public abstract void Perform(int i, int j);
        public abstract Positions Clone();        
        public abstract void Poster();
    }

    public class PositionTron : Positions
    {
        public override Positions Clone()
        {
            throw new System.NotImplementedException();
        }

        public override void Perform(int i, int j)
        {
            throw new System.NotImplementedException();
        }

        public override void Poster()
        {
            throw new System.NotImplementedException();
        }
    }
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
