using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class IconLabel : QUIBaseComponent
    {
        private bool _isReversedCached;
        public bool IsReversed;
        
        private Sprite _iconCached;
        public Sprite Icon;
        
        private Color _iconColorCached;
        public Color IconColor;
        
        private String _textCached;
        public String Text;
        
        private Color _textColorCached;
        public Color TextColor;
        
        private float _textSizeCached;
        public float TextSize;
        
        private TMP_FontAsset _textFontCached;
        public TMP_FontAsset TextFont;

        [SerializeField] private HorizontalOrVerticalLayoutGroup _layoutHolder;
        [SerializeField] private Image _iconHolder;
        [SerializeField] private TMP_Text _textHolder;



        protected override void Refresh()
        {
            CheckForChanges(Icon, ref _iconCached, () => _iconHolder.sprite = Icon);
            CheckForChanges(IconColor, ref _iconColorCached, () => _iconHolder.color = IconColor);
            CheckForChanges(Text, ref _textCached, () => _textHolder.text = Text);
            CheckForChanges(TextColor, ref _textColorCached, () => _textHolder.color = TextColor);
            CheckForChanges(TextSize, ref _textSizeCached, () => _textHolder.fontSize = TextSize);
            CheckForChanges(TextFont, ref _textFontCached, () => _textHolder.font = TextFont);
            CheckForChanges(IsReversed, ref _isReversedCached, () => RefreshReversedDependencies());
        }

        private void RefreshReversedDependencies()
        {
            _layoutHolder.reverseArrangement = IsReversed;
            _textHolder.alignment = IsReversed ? TextAlignmentOptions.Right : TextAlignmentOptions.Left;
        }
    }
}