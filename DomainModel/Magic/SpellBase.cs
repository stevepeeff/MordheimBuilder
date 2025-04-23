namespace DomainModel.Magic
{
    public abstract class SpellBase : ISpell
    {
        public string SpellName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public abstract int Difficulty { get; }
        public abstract int GainRequiredRoll { get; }
        public abstract string Description { get; }
    }
}