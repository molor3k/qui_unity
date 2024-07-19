using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class SolidLabel : QUIBaseComponent
    {
        private Sprite _bgImageCached;
        public Sprite BGImage;
        
        private Color _bgColorCached;
        public Color BGColor;
        
        private string _labelTextCached;
        public string LabelText;
        
        private Color _labelColorCached;
        public Color LabelColor;
        
        private float _labelSizeCached;
        public float LabelSize;
        
        private TMP_FontAsset _labelFontCached;
        public TMP_FontAsset LabelFont;
        
        [SerializeField] private Image _bgHolder;
        [SerializeField] private TMP_Text _labelHolder;
        
        
        
        protected override void Refresh()
        {
            CheckForChanges(BGImage, ref _bgImageCached, () => _bgHolder.sprite = BGImage);
            CheckForChanges(BGColor, ref _bgColorCached, () => _bgHolder.color = BGColor);
            CheckForChanges(LabelText, ref _labelTextCached, () => _labelHolder.text = LabelText);
            CheckForChanges(LabelColor, ref _labelColorCached, () => _labelHolder.color = LabelColor);
            CheckForChanges(LabelSize, ref _labelSizeCached, () => _labelHolder.fontSize = LabelSize);
            CheckForChanges(LabelFont, ref _labelFontCached, () => _labelHolder.font = LabelFont);
        }
    }
}