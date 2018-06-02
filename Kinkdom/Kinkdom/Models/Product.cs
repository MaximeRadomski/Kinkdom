using SQLite;

namespace Kinkdom.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc01 { get; set; }
        public string Desc02 { get; set; }
        public string Desc03 { get; set; }
        public string Image01 { get; set; }
        public string Image02 { get; set; }
        public string Image03 { get; set; }
        public int Category01 { get; set; }
        public int? Category02 { get; set; }
        public int? Category03 { get; set; }
        public bool IsFavorite { get; set; }
        public int Level { get; set; }
    }
}