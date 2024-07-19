using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class Toggle : QUIBaseComponent
    {
        public UnityEngine.UI.Toggle Interactable => _interactableHolder;
        
        private bool _isToggledCached;
        public bool IsToggled;

        private UnityEngine.UI.Toggle.ToggleEvent _toggleEventCached;
        public UnityEngine.UI.Toggle.ToggleEvent ToggleEvent;
        
        private Sprite _buttonImageCached;
        public Sprite ButtonImage;
        
        private Color _buttonColorCached;
        public Color ButtonColor;
        
        public Sprite _statusImageCached;
        public Sprite StatusImage;
        
        public Color _statusColorCached;
        public Color StatusColor;
        
        [SerializeField] private UnityEngine.UI.Toggle _interactableHolder;
        [SerializeField] private Image _bgHolder;
        [SerializeField] private Image _statusHolder;


        
        protected override void Refresh()
        {
            CheckForChanges(IsToggled, ref _isToggledCached, () => _interactableHolder.isOn = IsToggled);
            CheckForChanges(ToggleEvent, ref _toggleEventCached, () =>
            {
                _interactableHolder.onValueChanged.RemoveListener((isActive) =>
                {
                    _toggleEventCached?.Invoke(isActive);
                });
                
                _interactableHolder.onValueChanged.AddListener((isActive) =>
                {
                    ToggleEvent?.Invoke(isActive);
                });
            });
            
            CheckForChanges(ButtonImage, ref _buttonImageCached, () => _bgHolder.sprite = ButtonImage);
            CheckForChanges(ButtonColor, ref _buttonColorCached, () => _bgHolder.color = ButtonColor);
            CheckForChanges(StatusImage, ref _statusImageCached, () => _statusHolder.sprite = StatusImage);
            CheckForChanges(StatusColor, ref _statusColorCached, () => _statusHolder.color = StatusColor);
        }
    }
}