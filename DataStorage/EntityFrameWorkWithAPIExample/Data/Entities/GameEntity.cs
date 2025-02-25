namespace Data.Entities
{
    public class GameEntity
    {
        public required int Id { get; set; }
        public string Title { get; set; } = string.Empty;



        // En till En relation 
        // I GameDetails entity så lagrar vi GameId. Detta länkas sedan
        // samma av entity framework automatiskt.
        public GameDetails? Details { get; set; }




        // En till Många relation.
        // Här lagrar vi istället DeveloperId här och berättar för entity
        // framework vilket id i Developer tabellen som ska länkas ihop.
        public int? DeveloperId { get; set; } // Foreign Key
        public DeveloperEntity? Developer { get; set; }




        // Många till Många relation
        // Här länkar vi ihop hela tabellen Genres och länkar ihop.
        // Inuti Genre Entity så länkar vi på andra hållet men med
        // JsonIgnore för att inte skapa en infinite loop.

        // Detta kommer att automatiskt skapa en kopplingstabell 
        // med namnet [GameEntityGenreEntity] där vi länkar samman
        // tabellerna.
        public IEnumerable<GenreEntity>? Genres { get; set; }
    }
}
