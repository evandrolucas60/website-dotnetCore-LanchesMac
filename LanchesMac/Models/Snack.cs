namespace LanchesMac.Models
{
    public class Snack
    {
        public int SnackId { get; set; }
        public string SnackName { get; set;}
        public string ShortDescription { get; set;}
        public string DetailDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsFavoriteSnack { get; set; }
        public bool InStock { get; set; }

        //foreign key
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}