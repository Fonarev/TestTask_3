using Assets.Test.Scripts.Models;
using Assets.Test.Scripts.ViewModels;

using ObservableCollections;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Test.Scripts.FSM
{
    public class StopSpinningState : State
    {
        private ObservableList<SlotDisplayViewModel> _slotDisplayViewModels;
        private LootBox _lootBox;

        public StopSpinningState(FSM fsm, ObservableList<SlotDisplayViewModel> slotDisplayViewModels, LootBox lootBox) : base(fsm)
        {
            _slotDisplayViewModels = slotDisplayViewModels;
            _lootBox = lootBox;
        }

        public override void Enter()
        {
            _lootBox.IsCanStop.Value = false;
           CoroutineHandler.StartRoutine(StoppingSlotDisplays());
        }

        private IEnumerator StoppingSlotDisplays()
        {
            List<Coroutine> stoppingCoroutines = new();

            foreach (var slotDisplay in _slotDisplayViewModels)
            {
                stoppingCoroutines.Add(CoroutineHandler.StartRoutine(slotDisplay.SmoothStopping())); stoppingCoroutines.Add(CoroutineHandler.StartRoutine(slotDisplay.SmoothStopping()));
            }

            foreach (var coroutine in stoppingCoroutines)
            {
                yield return coroutine;
            }
           
            _fsm.SetState<ResultState>();
        }
    }
}