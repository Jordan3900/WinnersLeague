using System.ComponentModel.DataAnnotations;

namespace WinnersLeague.Models.Enums
{
    public enum OddType
    {
        [Display(Name ="Home Win")]
        HomeWin = 1,

        [Display(Name = "Away Win")]
        AwayWin = 2,
        X = 3,
        [Display(Name = "Under 2.5 Goals")]
        U2_5 = 4,
        [Display(Name = "Over 2.5 Goals")]
        O2_5 = 5,
    }
}
