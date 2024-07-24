namespace GenCore.Domain
{
    public class Weapons
    {
        private bool _equipped;

        public string name { get; set; }
        public string mod { get; set; }
        public decimal attr { get { return new AttributesKnight().strenght; } }
        public bool equipped { get { return _equipped; } set { _equipped = true; } }
    }
}
