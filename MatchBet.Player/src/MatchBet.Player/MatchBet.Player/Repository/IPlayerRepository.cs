namespace MatchBet.Player.Repository
{
    public interface IPlayerRepository
    {
        Task<Models.Player?> GetPlayerByUserNameAsync(string username);
        Task SavePlayerAsync(Models.Player player);
        Task<Models.Player> UpdatePlayer(Models.Player player);
        Task<List<Models.Player>> GetLeaderBoard();
        Task UpdateAllUserCredit();
        Task<Models.Player?> GetPlayerByUserIdAsync(int id);
    }
}

