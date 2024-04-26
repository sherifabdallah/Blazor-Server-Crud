using BlazorServerCrudDotNet8.Models;


namespace BlazorServerCrudDotNet8.Services
{
    public interface IVideoGameService
    {
        Task<List<VideoGame>> GetAllGamesAsync();
        Task<VideoGame> GetGameByIdAsync(int id);
        Task AddGameAsync(VideoGame game);
        Task UpdateGameAsync(VideoGame game, int id);
        Task DeleteGameAsync(int id);
    }
}
