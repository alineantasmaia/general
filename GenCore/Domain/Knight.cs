namespace GenCore.Domain
{
    public class Knight
    {        
        public decimal Id { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public decimal birthday { get; set; }
        public List<Weapons> weapons { get; set; }
        public List<AttributesKnight> atributes { get; set; }
        public decimal keyAttribute { get { return new AttributesKnight().strenght; } }
    }
}
