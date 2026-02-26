using R3;

using UnityEngine;

namespace Assets.Test.Scripts.Models
{
    public class Slot 
    {
        public readonly int ID;
        public readonly ReactiveProperty<Sprite> Sprite;
        public readonly ReactiveProperty<float> Direction;
        public readonly ReactiveProperty<Vector2> Revers;
        public readonly ReactiveProperty<bool> IsEnable;

        public Slot(int id,Sprite spritePath, bool isEnable)
        {
            ID = id;
            Sprite = new(spritePath);
            Direction = new();
            Revers = new();
            IsEnable = new(isEnable);
        }
    }
}