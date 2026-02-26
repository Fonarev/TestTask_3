using Assets.Test.Scripts.Models;
using Assets.Test.Scripts.Settings;
using Assets.Test.Scripts.ViewModels;

using ObservableCollections;

using System.Collections;

using UnityEngine;

namespace Assets.Test.Scripts.FSM
{
    public class SpinningState : State
    {
        private readonly LootBoxSettings _settings;
        private readonly ObservableList<SlotDisplayViewModel> _slotDisplayViewModels;
        private readonly LootBox _lootBox;

        public SpinningState(FSM fsm, ObservableList<SlotDisplayViewModel> slotDisplayViewModels, LootBox lootBox, LootBoxSettings settings) : base(fsm)
        {
            _slotDisplayViewModels = slotDisplayViewModels;
            _lootBox = lootBox;
            _settings = settings;
        }

        public override void Enter()
        {
            _lootBox.IsSpinning.Value = true;
            CoroutineHandler.StartRoutine(EnableStopButtonAfterDelay(_settings.StopDelay));
        }

        public override void UpDate(float deltaTime)
        {
            _slotDisplayViewModels.ForEach(slotDisplay => slotDisplay.UpData(deltaTime));
        }

        private IEnumerator EnableStopButtonAfterDelay(float stopDelay)
        {
            yield return new WaitForSeconds(stopDelay);
            _lootBox.IsCanStop.Value = true;
        }

    }
}