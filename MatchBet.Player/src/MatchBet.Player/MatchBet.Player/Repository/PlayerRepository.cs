using MatchBet.Player.Data;
using Microsoft.EntityFrameworkCore;

namespace MatchBet.Player.Repository
{
    public class PlayerRepository: IPlayerRepository
    {
        private readonly DataContext _dataContext;
        public PlayerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Models.Player?> GetPlayerByUserNameAsync(string username)
        {
            return await _dataContext.Players.FirstOrDefaultAsync(q => q.UserName == username);
;       }
        public async Task<Models.Player?> GetPlayerByUserIdAsync(int id)
        {
            return await _dataContext.Players.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task SavePlayerAsync(Models.Player player)
        {
            await _dataContext.Players.AddAsync(player);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<Models.Player> UpdatePlayer(Models.Player player)
        {
            _dataContext.Players.Update(player);
            await _dataContext.SaveChangesAsync();
            return player;
        }

        public async Task<List<Models.Player>> GetLeaderBoard()
        {
            var leaderBoard = _dataContext.Players.OrderByDescending(q=>q.Score).Take(10);
            return await leaderBoard.ToListAsync();
        }
        public async Task UpdateAllUserCredit()
        {
            await _dataContext.Players.ForEachAsync(p => { p.Credit = 3; });
            await _dataContext.SaveChangesAsync();
        }
    }
}

