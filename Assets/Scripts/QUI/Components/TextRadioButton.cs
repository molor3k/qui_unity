using TMPro;
using UnityEngine;

namespace QUI.Components
{
    public class TextRadioButton : RadioButton
    {
        private bool _isToggledTextTheSameCached;
        public bool IsToggledTextTheSame;
        
        private string _labelToggledTextCached;
        public string LabelToggledText;
        
        private Color _labelToggledColorCached;
        public Color LabelToggledColor;
        
        private string _labelUntoggledTextCached;
        public string LabelUntoggledText;
        
        private Color _labelUntoggledColorCached;
        public Color LabelUntoggledColor;
        
        private bool _isLabelAutoSizeCached;
        public bool IsLabelAutoSize;
        
        private float _labelSizeCached;
        public float LabelSize;

        private TMP_FontAsset _labelFontCached;
        public TMP_FontAsset LabelFont;
        
        [SerializeField] private TMP_Text _labelHolder;


        protected override void Refresh()
        {
            base.Refresh();
            
            CheckForChanges(LabelToggledText, ref _labelToggledTextCached, () =>
            {
                _isToggledTextTheSameCached = !IsToggledTextTheSame;
                UpdateLabelTextColor();
            });
            
            CheckForChanges(LabelUntoggledText, ref _labelUntoggledTextCached, () =>
            {
                _isToggledTextTheSameCached = !IsToggledTextTheSame;
                UpdateLabelTextColor();
            });
            
            CheckForChanges(IsToggledTextTheSame, ref _isToggledTextTheSameCached, () =>
            {
                LabelToggledText = LabelUntoggledText;
                LabelToggledColor = LabelUntoggledColor;

                UpdateLabelTextColor();
            });
            
            CheckForChanges(IsLabelAutoSize, ref _isLabelAutoSizeCached, () => 
                _labelHolder.enableAutoSizing = IsLabelAutoSize);
            
            CheckForChanges(LabelSize, ref _labelSizeCached, () => _labelHolder.fontSize = LabelSize);
            CheckForChanges(LabelFont, ref _labelFontCached, () => _labelHolder.font = LabelFont);
        }

        protected override void OnToggle()
        {
            base.OnToggle();
            UpdateLabelTextColor();
        } 

        private void UpdateLabelTextColor()
        {
            _labelHolder.text = IsToggled ? LabelToggledText : LabelUntoggledText;
            _labelHolder.color = IsToggled ? LabelToggledColor : LabelUntoggledColor;
        }
    }
}