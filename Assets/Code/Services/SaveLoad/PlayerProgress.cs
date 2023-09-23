using Services.SaveLoad.Contracts;

namespace Services.SaveLoad
{
    public class PlayerProgress : IPlayerProgress
    {
        public int BestResult { get; set; }
    }
}