namespace GenCore.Domain
{
    public class AttributesKnight
    {
        private decimal _strenght;
        private decimal _dexterite;
        private decimal _constitution;
        private decimal _intelligence;
        private decimal _wisdon;
        private decimal _charisma;


        public decimal strenght
        {
            get { return _strenght; }
            set { _strenght = 0; }
        }


        public decimal dexterite
        {
            get { return _dexterite; }
            set { _dexterite = 0; }
        }


        public decimal constitution
        {
            get { return _constitution; }
            set { _constitution = 0; }
        }

        public decimal intelligence { get { return _intelligence; } set { _intelligence = 0; } }
        public decimal wisdon { get { return _wisdon; } set { _wisdon = 0; } }
        public decimal charisma { get { return _charisma; } set { _charisma = 0; } }
    }
}
