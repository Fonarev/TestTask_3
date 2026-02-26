using Assets.Test.Scripts.Models;

using R3;

using UnityEngine;

namespace Assets.Test.Scripts.ViewModels
{
    public class SlotViewModel
    {
        public int ID { get; }
        public ReadOnlyReactiveProperty<Sprite> CurrentSprite { get; }
        public ReadOnlyReactiveProperty<float> Direction { get; }
        public ReadOnlyReactiveProperty<Vector2> Revers { get; }
        public ReadOnlyReactiveProperty<bool> IsEnable { get; }
      
        public SlotViewModel(Slot slot)
        {
            ID = slot.ID;
            CurrentSprite = slot.Sprite;
            Direction = slot.Direction;
            Revers = slot.Revers;
            IsEnable = slot.IsEnable;
        }

    }
}