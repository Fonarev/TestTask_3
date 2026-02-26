using Assets.Test.Scripts.Models;
using Assets.Test.Scripts.ViewModels;

using ObservableCollections;

using System.Collections.Generic;

using UnityEngine;

namespace Assets.Test.Scripts.FSM
{
    public class ResultState : State
    {
        private readonly ObservableList<SlotDisplayViewModel> _slotDisplayViewModels;
        private readonly LootBox _lootBox;
        private const int ficsIndexResult = 1;

        public ResultState(FSM fsm, ObservableList<SlotDisplayViewModel> slotDisplayViewModels, LootBox lootBox) : base(fsm)
        {
            _slotDisplayViewModels = slotDisplayViewModels;
            _lootBox = lootBox;
        }

        public override void Enter()
        {
             List<Sprite>listResult = new();

            _slotDisplayViewModels.ForEach(r => 
            {
                listResult.Add(r.GetSlot(ficsIndexResult));
            });

            _lootBox.ResultLoot.Value = new ResultLoot(listResult);

            _lootBox.IsSpinning.Value = false;
        }

    }
}