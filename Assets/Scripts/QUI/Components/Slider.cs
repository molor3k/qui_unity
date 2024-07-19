using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class Slider : QUIBaseComponent
    {        
        private UnityEngine.UI.Slider.SliderEvent _sliderEventCached;
        public UnityEngine.UI.Slider.SliderEvent SliderEvent;

        private Sprite _backgroundImageCached;
        public Sprite BackgroundImage;
        
        private Color _backgroundColorCached;
        public Color BackgroundColor;
        
        private Sprite _handleImageCached;
        public Sprite HandleImage;
        
        private Color _handleColorCached;
        public Color HandleColor;

        private float _sliderValueCached;
        public float SliderValue;
        
        private float _sliderMinValueCached;
        public float SliderMinValue;
        
        private float _sliderMaxValueCached;
        public float SliderMaxValue;
        
        [SerializeField] private UnityEngine.UI.Slider _sliderHolder;
        [SerializeField] private Image _bgHolder;
        [SerializeField] private Image _handleHolder;
        
        
        
        protected override void Refresh()
        {
            CheckForChanges(BackgroundImage, ref _backgroundImageCached, () => _bgHolder.sprite = BackgroundImage);
            CheckForChanges(BackgroundColor, ref _backgroundColorCached, () => _bgHolder.color = BackgroundColor);
            CheckForChanges(HandleImage, ref _handleImageCached, () => _handleHolder.sprite = HandleImage);
            CheckForChanges(HandleColor, ref _handleColorCached, () => _handleHolder.color = HandleColor);
            CheckForChanges(SliderValue, ref _sliderValueCached, () => _sliderHolder.value = SliderValue);
            CheckForChanges(SliderEvent, ref _sliderEventCached, () => _sliderHolder.onValueChanged = SliderEvent);
            CheckForChanges(SliderMinValue, ref _sliderMinValueCached, () => _sliderHolder.minValue = SliderMinValue);
            CheckForChanges(SliderMaxValue, ref _sliderMaxValueCached, () => _sliderHolder.maxValue = SliderMaxValue);
        }
    }
}