using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class RadioButton : QUIBaseComponent
    {
        public UnityEngine.UI.Button Interactable => _interactableHolder;
        
        private bool _isToggledCached;
        public bool IsToggled;

        private UnityEngine.UI.Button.ButtonClickedEvent _toggleEventCached;
        public UnityEngine.UI.Button.ButtonClickedEvent ToggleEvent;
        
        private Sprite _buttonImageCached;
        public Sprite ButtonImage;
        
        private Color _buttonColorCached;
        public Color ButtonColor;
        
        private Sprite _statusImageCached;
        public Sprite StatusImage;
        
        private Color _statusColorCached;
        public Color StatusColor;
        
        [SerializeField] private UnityEngine.UI.Button _interactableHolder;
        [SerializeField] private Image _bgHolder;
        [SerializeField] private Image _statusHolder;

        
        
        private void OnToggledChanged()
        {
            if (IsToggled) return;
                    
            IsToggled = true;
            ToggleEvent?.Invoke();
        }
        
        protected override void Refresh()
        {
            CheckForChanges(ToggleEvent, ref _toggleEventCached, () =>
            {
                _interactableHolder.onClick.RemoveListener(() => OnToggledChanged());
                _interactableHolder.onClick.AddListener(() => OnToggledChanged());
            });
            
            CheckForChanges(IsToggled, ref _isToggledCached, () => OnToggle());
            CheckForChanges(ButtonImage, ref _buttonImageCached, () => _bgHolder.sprite = ButtonImage);
            CheckForChanges(ButtonColor, ref _buttonColorCached, () => _bgHolder.color = ButtonColor);
            CheckForChanges(StatusImage, ref _statusImageCached, () => _statusHolder.sprite = StatusImage);
            CheckForChanges(StatusColor, ref _statusColorCached, () => _statusHolder.color = StatusColor);
        }

        protected virtual void OnToggle()
        {
            _statusHolder.gameObject.SetActive(IsToggled);
        }
    }
}