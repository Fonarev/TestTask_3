using Assets.Test.Scripts.ViewModels;

using R3;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Test.Scripts.Binders
{
    public class SlotBinder : MonoBehaviour
    {
        [SerializeField] private Image slot;
        [SerializeField] private RectTransform rectTransform;

        private SlotViewModel _viewModel;
        private readonly CompositeDisposable disposables = new();

        public void Bind(SlotViewModel viewModel)
        {
            _viewModel = viewModel;
            slot.sprite = viewModel.CurrentSprite.CurrentValue;

            _viewModel.CurrentSprite.Subscribe(c => slot.sprite = c).AddTo(disposables);
            _viewModel.Direction.Subscribe(c => Move(c)).AddTo(disposables);
            _viewModel.Revers.Subscribe(c => Reverse(c)).AddTo(disposables);
        }

        private void Reverse(Vector2 pos)
        {
           if(pos.y > 0)
           {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + pos.y);
           }
        }

        private void Move(float direction)
        {
            rectTransform.anchoredPosition -= new Vector2(0, direction) ; 
        }

        private void OnDestroy()
        {
            disposables?.Dispose();
        }
    }
}