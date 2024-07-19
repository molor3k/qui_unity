using TMPro;
using UnityEngine;

namespace QUI.Components
{
    public class TextButton : Button
    {
        private string _labelTextCached;
        public string LabelText;
        
        private Color _labelColorCached;
        public Color LabelColor;
        
        private float _labelSizeCached;
        public float LabelSize;

        private TMP_FontAsset _labelFontCached;
        public TMP_FontAsset LabelFont;
        [SerializeField] private TMP_Text _labelHolder;
        
        
        
        protected override void Refresh()
        {
            base.Refresh();
            
            CheckForChanges(LabelText, ref _labelTextCached, () => _labelHolder.text = LabelText);
            CheckForChanges(LabelColor, ref _labelColorCached, () => _labelHolder.color = LabelColor);
            CheckForChanges(LabelSize, ref _labelSizeCached, () => _labelHolder.fontSize = LabelSize);
            CheckForChanges(LabelFont, ref _labelFontCached, () => _labelHolder.font = LabelFont);
        }
    }
}