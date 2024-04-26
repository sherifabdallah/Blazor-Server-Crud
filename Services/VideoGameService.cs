using BlazorServerCrudDotNet8.Data;
using BlazorServerCrudDotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCrudDotNet8.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly DataContext _context;

        public VideoGameService(DataContext context)
        {
            _context = context;
        }

        public async Task AddGameAsync(VideoGame game)
        {
            _context.VideoGames.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game != null)
            {
                _context.VideoGames.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<VideoGame>> GetAllGamesAsync()
        {
            var result = await _context.VideoGames.ToListAsync();
            return result;
        }

        public async Task<VideoGame> GetGameByIdAsync(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            return game;
        }

        public async Task UpdateGameAsync(VideoGame game, int id)
        {
            var dbGame = await _context.VideoGames.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.Title = game.Title;
                dbGame.Publisher = game.Publisher;
                dbGame.ReleaseYear = game.ReleaseYear;

                _context.VideoGames.Update(dbGame);
                await _context.SaveChangesAsync();
            }
        }
    }
}
