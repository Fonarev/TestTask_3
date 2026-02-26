using Assets.Test.Scripts.Settings;

using ObservableCollections;

using R3;

using UnityEngine;

namespace Assets.Test.Scripts.Models
{
    public class SlotDisplay 
    {
        public readonly int ID;
        public readonly ObservableList<Slot> Slots = new();
        public readonly ReactiveProperty<float> CurrentScrollSpeed = new(0);

        public SlotDisplay(int id, LootBoxSettings settings)
        {
            ID = id;
            CreateSlotProxy(settings);
        }

        private void CreateSlotProxy(LootBoxSettings settings)
        {
            for (int i = 0; i < settings.SlotVerticalAmount; i++)
            { 
                int randomIndex = Random.Range(0, settings.SlotSymbols.Length);
                Slots.Add(new Slot(i, settings.SlotSymbols[randomIndex], true));
            }
        }
    }
}