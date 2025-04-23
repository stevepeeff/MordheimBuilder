namespace MordheimTableTop.Selection
{
    public abstract class EquipmentViewModel : ViewModelBase
    {
        public virtual string Save { get; } = "-";
        public abstract string Name { get; }

        //private FontWeight mFont = FontWeight.

        //public FontWeight Font
        //{
        //    get { return mFont; }
        //    set
        //    {
        //        if (value != mFont)
        //        {
        //            mFont = value;
        //            NotifiyPropertyChangedEvent();
        //        }
        //    }
        //}

        private bool mCanBeSelected = true;

        public bool CanBeSelected
        {
            get { return mCanBeSelected; }
            set
            {
                if (value != mCanBeSelected)
                {
                    mCanBeSelected = value;
                    NotifiyPropertyChangedEvent();
                }
            }
        }

        public abstract int Costs { get; }

        public abstract string Description { get; }

        public virtual string StrengthModifier { get; } = "-";
        public virtual string ArmourSaveModifier { get; } = "-";

        public virtual int ToHitModifier { get; }

        public virtual int Range { get; }

        public virtual int Strength { get; }
    }
}