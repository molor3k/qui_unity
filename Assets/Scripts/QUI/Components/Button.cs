using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class Button : QUIBaseComponent
    {
        public bool IsInteractable => _interactableHolder.interactable;
        
        private UnityEngine.UI.Button.ButtonClickedEvent _clickedEventCached;
        public UnityEngine.UI.Button.ButtonClickedEvent ClickedEvent;
        
        private Sprite _buttonImageCached;
        public Sprite ButtonImage;
        
        private Color _buttonColorCached;
        public Color ButtonColor;
        
        [SerializeField] private UnityEngine.UI.Button _interactableHolder;
        [SerializeField] private Image _bgHolder;
        
        
        
        protected override void Refresh()
        {
            CheckForChanges(ClickedEvent, ref _clickedEventCached, () =>
            {
                _interactableHolder.onClick.RemoveListener(() => _clickedEventCached?.Invoke());
                _interactableHolder.onClick.AddListener(() => ClickedEvent?.Invoke());
            });
            
            CheckForChanges(ButtonImage, ref _buttonImageCached, () => _bgHolder.sprite = ButtonImage);
            CheckForChanges(ButtonColor, ref _buttonColorCached, () => _bgHolder.color = ButtonColor);
        }

        public void SetInteractable(bool isInteractable)
        {
            _interactableHolder.interactable = isInteractable;
            _bgHolder.color = isInteractable ? ButtonColor : Color.gray;
        }
    }
}