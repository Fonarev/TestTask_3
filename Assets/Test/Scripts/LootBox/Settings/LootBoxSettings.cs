using UnityEngine;

namespace Assets.Test.Scripts.Settings
{
    [CreateAssetMenu(fileName = "LootBoxSettings", menuName = "Test/LootBox Settings")]
    public class LootBoxSettings : ScriptableObject
    {
        [field: SerializeField] public int SlotDisplayAmount { get; private set; } = 3;
        [field: SerializeField] public int SlotVerticalAmount { get; private set; } = 5;
        [field: SerializeField] public float DisplayHeight { get; private set; } = 500f;
        [field:SerializeField] public Sprite[] SlotSymbols { get; private set; }
        [field: SerializeField] public float ScrollSpeed { get; private set; } = 500f; 
        [field: SerializeField] public float MaxScrollSpeed { get; private set; } = 1500f; 
        [field: SerializeField] public float Acceleration { get; private set; } = 800f; 
        [field: SerializeField] public float StoppingDeceleration { get; private set; } = 1200f; 
        [field: SerializeField] public float StopDelay { get; private set; } = 3f;
    }
}