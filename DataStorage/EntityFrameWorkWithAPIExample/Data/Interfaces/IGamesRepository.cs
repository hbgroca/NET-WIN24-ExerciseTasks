using Data.Entities;

namespace Data.Interfaces
{
    public interface IGamesRepository
    {
        Task<IEnumerable<GameEntity>> GetAllGamesAsync();
        Task<GameEntity> GetGameByIdAsync(int id);
        Task<GameEntity> GetGameByTitleAsync(string title);
    }
}