using MatchBet.Player.Contracts;

namespace MatchBet.Player.Services
{
    public interface IPlayerServices
    {
        void ValidateCreatePlayerRequest(CreatePlayerRequest playerRequest);
        Task<Models.Player?> GetPlayerByUsernameAsync(string username);
        Task SavePlayerAsync(CreatePlayerRequest createPlayerRequest);
        Task<Models.Player?> UpdatePlayerScore(int userId, Double score);
        Task<List<Models.Player?>> GetLeaderBoard();
        Task UpdateAllUserCredit();
        Task<Models.Player?> GetPlayerByUserId(int userId);
    }
}
