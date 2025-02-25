namespace Data.Entities
{
    public class GameDetails
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateOnly? ReleaseDate { get; set; }


        // En till En relation
        // Kan vara bra ide att skriva ett tydligt namn så att
        // entity framework förstår att vi vill koppla ihop med
        // GameEntityId.
        public int GameEntityId { get; set; } // Foreign Key
    }
}
