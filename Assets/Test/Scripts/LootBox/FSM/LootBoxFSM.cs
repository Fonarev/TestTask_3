using Assets.Test.Scripts.Models;
using Assets.Test.Scripts.Settings;
using Assets.Test.Scripts.ViewModels;

using ObservableCollections;

namespace Assets.Test.Scripts.FSM
{
    public class LootBoxFSM : FSM
    {
        public LootBoxFSM(ObservableList<SlotDisplayViewModel> slotDisplayViewModels,LootBox lootBox, LootBoxSettings settings)
        {
            AddState(new IdleState(this));
            AddState(new SpinningState(this, slotDisplayViewModels, lootBox, settings));
            AddState(new StopSpinningState(this, slotDisplayViewModels, lootBox));
            AddState(new ResultState(this, slotDisplayViewModels, lootBox));

            currentState = GetState<IdleState>();
        }

    }
}