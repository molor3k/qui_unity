using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class ProgressBar : QUIBaseComponent
    {
        private UnityEngine.UI.Slider.SliderEvent _sliderEventCached;
        public UnityEngine.UI.Slider.SliderEvent SliderEvent;
        
        private Sprite _backgroundImageCached;
        public Sprite BackgroundImage;
        
        private Color _backgroundColorCached;
        public Color BackgroundColor;
        
        private Sprite _fillImageCached;
        public Sprite FillImage;
        
        private Color _fillColorCached;
        public Color FillColor;

        private float _sliderValueCached;
        public float SliderValue;
        
        private float _sliderMinValueCached;
        public float SliderMinValue;
        
        private float _sliderMaxValueCached;
        public float SliderMaxValue;
        
        [SerializeField] private UnityEngine.UI.Slider _sliderHolder;
        [SerializeField] private Image _bgHolder;
        [SerializeField] private Image _fillHolder;
        
        
        
        protected override void Refresh()
        {
            CheckForChanges(BackgroundImage, ref _backgroundImageCached, () => _bgHolder.sprite = BackgroundImage);
            CheckForChanges(BackgroundColor, ref _backgroundColorCached, () => _bgHolder.color = BackgroundColor);
            CheckForChanges(FillImage, ref _fillImageCached, () => _fillHolder.sprite = FillImage);
            CheckForChanges(FillColor, ref _fillColorCached, () => _fillHolder.color = FillColor);
            CheckForChanges(SliderValue, ref _sliderValueCached, () => _sliderHolder.value = SliderValue);
            CheckForChanges(SliderEvent, ref _sliderEventCached, () => _sliderHolder.onValueChanged = SliderEvent);
            CheckForChanges(SliderMinValue, ref _sliderMinValueCached, () => _sliderHolder.minValue = SliderMinValue);
            CheckForChanges(SliderMaxValue, ref _sliderMaxValueCached, () => _sliderHolder.maxValue = SliderMaxValue);
        }
    }
}