using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController(IGamesRepository _gamesRepository) : ControllerBase
    {
        [HttpGet("allgames")]
        public async Task <ActionResult<IEnumerable<GameEntity>>> GetGamesAsync()
        {
            var games = await _gamesRepository.GetAllGamesAsync();
            if (games is null)
                return BadRequest("Inga spel i databas.");

            return Ok(games);
        }

        [HttpGet("gamebyid/{id}")]
        public async Task<ActionResult<IEnumerable<GameEntity>>> GetGameByIdAsync(int id)
        {
            var games = await _gamesRepository.GetGameByIdAsync(id);
            if (games is null)
                return BadRequest("Spelet hittades inte");

            return Ok(games);
        }

        [HttpGet("gamebyname/{title}")]
        public async Task<ActionResult<IEnumerable<GameEntity>>> GetGameByTitleAsync(string title)
        {
            var games = await _gamesRepository.GetGameByTitleAsync(title);
            if (games is null)
                return BadRequest("Spelet hittades inte");

            return Ok(games);
        }
    }
}
