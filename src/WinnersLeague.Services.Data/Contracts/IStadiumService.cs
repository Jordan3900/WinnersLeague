namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Services.Models;

    public interface IStadiumService
    {
        IEnumerable<StadiumViewModel> GetAll();

        bool IsStadiumIdValid(string stadiumId);

        string GetStadiumId(string name);
    }
}
