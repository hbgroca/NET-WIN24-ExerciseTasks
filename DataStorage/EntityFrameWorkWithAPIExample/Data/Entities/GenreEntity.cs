using System.Text.Json.Serialization;

namespace Data.Entities;

public class GenreEntity
{
    public required int Id { get; set; }
    public string Genre { get; set; } = string.Empty;


    // Många till Många relation.
    // Vi markerar den med Json Ignore för att inte det ska bli
    // en infinite loop. Där GameEntity hämtar in GenreEntity
    // och Genre Entity hämtar in GameEntity och GameEntity hämtar
    // in GenreEntity osv...
    [JsonIgnore]
    public IEnumerable<GameEntity>? Games { get; set; }
}
