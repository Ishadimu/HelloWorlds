namespace HelloWorlds.Models.Travels
{
    public class Wishlist
    {
        public int Id { get; set; }
        public City City { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}