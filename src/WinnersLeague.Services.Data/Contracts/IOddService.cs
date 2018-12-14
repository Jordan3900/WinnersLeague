namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Services.Models;

    public interface IOddService
    {
        IEnumerable<OddViewModel> GetAll();

        bool IsOddIdValid(string oddId);
    }
}
