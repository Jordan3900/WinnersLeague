namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using WinnersLeague.Models;

    public interface IBetService
    {
        ICollection<Bet> GetAll();
        Task AddingAmountOfWin(string username);
        Bet GetCurrentBet(string username);
    }
}
