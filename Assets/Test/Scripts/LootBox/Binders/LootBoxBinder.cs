using Assets.Test.Scripts.Binders;
using Assets.Test.Scripts.Models;
using Assets.Test.Scripts.Settings;
using Assets.Test.Scripts.ViewModels;

using ObservableCollections;

using R3;

using System.Collections;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Test.Scripts
{
    public class LootBoxBinder : MonoBehaviour
    {
        [SerializeField] private LootBoxSettings settings;
        [SerializeField] private ParticleSystem effectResultLootPrefab;
        [SerializeField] private SlotDisplayBinder slotDisplayBinderPrefab;
        [SerializeField] private Transform displaySlotContainer;
        [SerializeField] private Button startButton;
        [SerializeField] private Button stopButton;

        private LootBoxViewModel _viewModel;
        private ParticleSystem createdEffectPrefab;
        private readonly ObservableList<SlotDisplayBinder> _slotDisplayBinder = new();
        private readonly CompositeDisposable _disposables = new();

        // For Test
        private IEnumerator Start()
        {
            LootBox lootBox = new();
            while (settings == null)
                yield return new WaitForSeconds(1);
            LootBoxViewModel viewModel = new(lootBox, settings);
            Bind(viewModel, settings);
        }
        // For Test
        private void Update()
        {
            _viewModel?.UpData(Time.deltaTime);
        }

        public void Bind(LootBoxViewModel viewModel, LootBoxSettings settings)
        {
            _viewModel = viewModel;
          
            foreach (var slotDisplayViewModel in viewModel.SlotDisplayViewModels)
            {
                SlotDisplayBinder slotDisplaybinder = Instantiate(slotDisplayBinderPrefab, displaySlotContainer);
                slotDisplaybinder.Bind(slotDisplayViewModel, settings);
                _slotDisplayBinder.Add(slotDisplaybinder);
            }

            _viewModel.IsSpinning.Subscribe(c => OnSpinning(c)).AddTo(_disposables);
            _viewModel.IsCanStop.Subscribe(c => OnCanStop(c)).AddTo(_disposables);
            _viewModel.ResultLoot.Subscribe(c => OnResultLoot(c)).AddTo(_disposables);

            startButton.onClick.AddListener(() => StartSpinning());
            stopButton.onClick.AddListener(() => StopSpinning());
        }

        public void StartSpinning()
        {
            if (createdEffectPrefab != null)
            {
                Destroy(createdEffectPrefab.gameObject);
            }
            _viewModel.Start();
        }

        public void StopSpinning()
        {
           _viewModel.Stop();
        }

        private void OnCanStop(bool value)
        {
            stopButton.interactable = value;
        }

        private void OnSpinning(bool value)
        {
            startButton.interactable = !value;
        }

        private void OnResultLoot(ResultLoot resultLoot)
        {
            if (resultLoot == null) return;
            createdEffectPrefab = Instantiate(effectResultLootPrefab);
            Debug.Log("Show Result Loot + effect");
        }

        private void OnDestroy()
        {
            _disposables?.Dispose();
           
            startButton.onClick.RemoveAllListeners();
            stopButton.onClick.RemoveAllListeners();

            if (createdEffectPrefab != null)
            {
                Destroy(createdEffectPrefab.gameObject);
            }
        }

    }
}