namespace HelloWorlds.Models.Travels
{
    public class PastVisits
    {
        public int Id { get; set; }
        public City City { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}