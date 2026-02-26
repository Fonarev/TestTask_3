using Assets.Test.Scripts.FSM;
using Assets.Test.Scripts.Models;
using Assets.Test.Scripts.Settings;

using ObservableCollections;

using R3;

using System.Collections.Generic;

namespace Assets.Test.Scripts.ViewModels
{
    public class LootBoxViewModel
    {
        private readonly LootBox _lootBox;
        private readonly LootBoxFSM _lootBoxFSM;
        private readonly ObservableList<SlotDisplay> _slotDisplays = new();
        private readonly ObservableList<SlotDisplayViewModel> _slotDisplayViewModels = new();
        private readonly Dictionary<int, SlotDisplayViewModel> _slotDisplayViewModelsLink = new();

        public ReadOnlyReactiveProperty<bool> IsSpinning { get; }
        public ReadOnlyReactiveProperty<bool> IsCanStop { get; }
        public ReadOnlyReactiveProperty<ResultLoot> ResultLoot { get; }
        public IObservableCollection<SlotDisplayViewModel> SlotDisplayViewModels => _slotDisplayViewModels;
       
        public LootBoxViewModel(LootBox lootBox, LootBoxSettings settings)
        {
            if (settings == null) return;// При Тесте

            _lootBox = lootBox;

            IsSpinning = _lootBox.IsSpinning;
            IsCanStop = _lootBox.IsCanStop;
            ResultLoot = _lootBox.ResultLoot;

            for (int i = 0; i < settings.SlotDisplayAmount; i++)
            {
                SlotDisplay slotDisplay = new(i, settings);
                _slotDisplays.Add(slotDisplay);

                SlotDisplayViewModel viewModel = new(slotDisplay, settings);
                _slotDisplayViewModels.Add(viewModel);
                _slotDisplayViewModelsLink[viewModel.ID] = viewModel;
            }

            _lootBoxFSM = new(_slotDisplayViewModels, _lootBox, settings);
        }

        public void Start()
        {
            _lootBoxFSM.SetState<SpinningState>();
        }

        public void Stop()
        {
            _lootBoxFSM.SetState<StopSpinningState>();
        }

        public void UpData(float deltaTime)
        {
            _lootBoxFSM?.UpData(deltaTime);
        }
       
    }
}