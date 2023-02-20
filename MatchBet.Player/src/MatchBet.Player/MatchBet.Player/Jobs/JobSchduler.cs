using MatchBet.Player.Services;
using Quartz;
using System.Reflection.Metadata.Ecma335;

namespace MatchBet.Player.Jobs
{
    public class JobSchduler : IJob
    {
        private readonly IPlayerServices _playerService;
        public JobSchduler(IPlayerServices playerService)
        {
            _playerService = playerService;
        }
        public Task Execute(IJobExecutionContext context)
        {

            _playerService.UpdateAllUserCredit().Wait();
            return Task.CompletedTask;
        }
    }
}
