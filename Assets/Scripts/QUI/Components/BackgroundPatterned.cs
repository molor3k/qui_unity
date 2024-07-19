using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class BackgroundPatterned : QUIBaseComponent
    {
        private Sprite _backgroundImageCached;
        public Sprite BackgroundImage;
        
        private Color _backgroundColorCached;
        public Color BackgroundColor;
        
        private Sprite _patternCached;
        public Sprite Pattern;
        
        private Color _patternColorCached;
        public Color PatternColor;
        
        private float _patternSizeCached;
        public float PatternSize = 2.73f;

        [SerializeField] private Image _bgHolder;
        [SerializeField] private Image _patternHolder;



        protected override void Refresh()
        {
            CheckForChanges(BackgroundImage, ref _backgroundImageCached, () => _bgHolder.sprite = BackgroundImage);
            CheckForChanges(BackgroundColor, ref _backgroundColorCached, () => _bgHolder.color = BackgroundColor);
            CheckForChanges(Pattern, ref _patternCached, () => _patternHolder.sprite = Pattern);
            CheckForChanges(PatternColor, ref _patternColorCached, () => _patternHolder.color = PatternColor);
            CheckForChanges(PatternSize, ref _patternSizeCached, () => 
                _patternHolder.pixelsPerUnitMultiplier = PatternSize);
        }
    }
}