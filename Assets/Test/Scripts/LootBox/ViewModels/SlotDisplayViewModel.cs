using Assets.Test.Scripts.Models;
using Assets.Test.Scripts.Settings;

using ObservableCollections;

using System.Collections;

using UnityEngine;


namespace Assets.Test.Scripts.ViewModels
{
    public class SlotDisplayViewModel
    {
        private readonly SlotDisplay _slotDisplay;
        private readonly LootBoxSettings _settings;
        private readonly ObservableList<Slot> slots;
        private readonly ObservableList<SlotViewModel> _slotsViewModel = new();

        private float downSlotY;

        public int ID => _slotDisplay.ID;
        public IObservableCollection<SlotViewModel> SlotsViewModel => _slotsViewModel;

        public SlotDisplayViewModel(SlotDisplay slotDisplay,LootBoxSettings settings)
        {
            _slotDisplay = slotDisplay;
            _settings = settings;
            slots = _slotDisplay.Slots;
            slots.ForEach(CreateSlotViewModel);
        }

        public void UpData(float deltaTime)
        {
            if (_slotDisplay.CurrentScrollSpeed.CurrentValue < _settings.MaxScrollSpeed)
            {
                _slotDisplay.CurrentScrollSpeed.Value += _settings.Acceleration * _settings.ScrollSpeed * deltaTime;
                _slotDisplay.CurrentScrollSpeed.Value = Mathf.Min(_slotDisplay.CurrentScrollSpeed.CurrentValue, _settings.MaxScrollSpeed);
            }

            MovingSlots();
        }

        public IEnumerator SmoothStopping()
        {
            while (_slotDisplay.CurrentScrollSpeed.CurrentValue > 0.1f)
            {
                _slotDisplay.CurrentScrollSpeed.Value -= _settings.StoppingDeceleration * _settings.ScrollSpeed * Time.deltaTime;

                MovingSlots();

                yield return null;
            }
        }

        public Sprite GetSlot(int index)
        {
           return slots[index].Sprite.CurrentValue;
        }

        private void MovingSlots()
        {
            foreach (var slot in slots)
            {
                slot.Direction.Value =  _slotDisplay.CurrentScrollSpeed.CurrentValue * Time.deltaTime;
            }

            Slot slotOne = slots[^1];
            downSlotY += slotOne.Direction.CurrentValue;

            if ( downSlotY >= _settings.DisplayHeight / _settings.SlotVerticalAmount)
            {
                slots.RemoveAt(slots.Count-1);
            
                slotOne.Revers.Value = new Vector2(0, _settings.DisplayHeight);
                slotOne.Sprite.Value = _settings.SlotSymbols[Random.Range(0, _settings.SlotSymbols.Length)];
                slotOne.Revers.Value = Vector2.zero;

                slots.Insert(0,slotOne);
                downSlotY -= _settings.DisplayHeight / _settings.SlotVerticalAmount;
            }

        }

        private void CreateSlotViewModel(Slot slotProxy)
        {
            SlotViewModel createdSlotViewModel = new(slotProxy);
            _slotsViewModel.Add(createdSlotViewModel);
        }

    }
}