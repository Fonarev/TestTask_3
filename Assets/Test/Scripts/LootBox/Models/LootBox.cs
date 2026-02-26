using R3;

namespace Assets.Test.Scripts.Models
{
    public class LootBox
    {
        public readonly ReactiveProperty<bool> IsSpinning;
        public readonly ReactiveProperty<bool> IsCanStop;
        public readonly ReactiveProperty<ResultLoot> ResultLoot;

        public LootBox()
        {
            IsSpinning = new();
            IsCanStop = new();
            ResultLoot = new();
        }
    }
}