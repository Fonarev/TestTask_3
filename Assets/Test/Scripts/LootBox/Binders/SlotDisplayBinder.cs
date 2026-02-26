using Assets.Test.Scripts.Settings;
using Assets.Test.Scripts.ViewModels;

using System.Collections.Generic;

using UnityEngine;

namespace Assets.Test.Scripts.Binders
{
    public class SlotDisplayBinder : MonoBehaviour
    {
        [SerializeField] private SlotBinder slotBinderPrefab;
        [SerializeField] private RectTransform rectTransform;

        private readonly List<SlotBinder> slotBinders = new();

        public void Bind(SlotDisplayViewModel viewModel,LootBoxSettings settings)
        {
            foreach (var binder in viewModel.SlotsViewModel)
            {
                CreateSlotBinder(binder);
            }
        }

        private void CreateSlotBinder(SlotViewModel viewModel)
        {
            SlotBinder createdSlotBinder = Instantiate(slotBinderPrefab, transform);
            createdSlotBinder.Bind(viewModel);

            slotBinders.Add(createdSlotBinder);
        }

    }
}