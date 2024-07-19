using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class InputField : QUIBaseComponent
    {
        private Sprite _bGImageCached;
        public Sprite BGImage;
        
        private Color _bGColorCached;
        public Color BGColor;
        
        private string _inputTextCached;
        public string InputText;
        
        private Color _inputTextColorCached;
        public Color InputTextColor;
        
        private float _inputTextSizeCached;
        public float InputTextSize;
        
        private TMP_FontAsset _inputTextFontCached;
        public TMP_FontAsset InputTextFont;
        
        private string _placeholderTextCached;
        public string PlaceholderText;
        
        private Color _placeholderTextColorCached;
        public Color PlaceholderTextColor;
        
        [SerializeField] private Image _bgHolder;
        [SerializeField] private TMP_InputField _interactableHolder;
        [SerializeField] private TMP_Text _placeholderHolder;
        [SerializeField] private TMP_Text _labelHolder;
        
        
        
        protected override void Refresh()
        {
            CheckForChanges(BGImage, ref _bGImageCached, () => _bgHolder.sprite = BGImage);
            CheckForChanges(BGColor, ref _bGColorCached, () => _bgHolder.color = BGColor);
            CheckForChanges(InputText, ref _inputTextCached, () => _interactableHolder.text = InputText);
            
            CheckForChanges(InputTextColor, ref _inputTextColorCached, () => 
                _labelHolder.color = InputTextColor);
            CheckForChanges(InputTextSize, ref _inputTextSizeCached, () => 
                _interactableHolder.pointSize = InputTextSize);
            CheckForChanges(InputTextFont, ref _inputTextFontCached, () => 
                _interactableHolder.fontAsset = InputTextFont);
            CheckForChanges(PlaceholderText, ref _placeholderTextCached, () => 
                _placeholderHolder.text = PlaceholderText);
            CheckForChanges(PlaceholderTextColor, ref _placeholderTextColorCached, () => 
                _placeholderHolder.color = PlaceholderTextColor);
        }
    }
}