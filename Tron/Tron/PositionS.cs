namespace Tron
{
    public abstract class PositionS
    {
        public float Eval { get; protected set; }
        public int NbCoups1 { get; protected set; }
        public int NbCoups0 { get; protected set; }
        public abstract void EffectuerCoup(int i, int j);
        public abstract PositionS Clone();
        public abstract void Affiche();
    }
    
}
