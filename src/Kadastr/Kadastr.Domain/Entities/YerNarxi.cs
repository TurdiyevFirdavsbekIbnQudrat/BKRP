namespace Kadastr.Domain.Entities
{
    public class YerNarxi
    {
        public int Id { get; set; }
        public string Viloyat { get; set; }
        public int YerNarx { get; set; }
        public IEnumerable<Yer> yer { get; set; }
    }
}
