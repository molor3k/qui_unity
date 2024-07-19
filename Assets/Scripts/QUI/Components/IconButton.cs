using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class IconButton : Button
    {
        private Sprite _iconImageCached;      
        public Sprite IconImage;        
        
        private Color _iconColorCached;
        public Color IconColor;
        [SerializeField] private Image _iconHolder;
        
        
        
        protected override void Refresh()
        {
            base.Refresh();
            
            CheckForChanges(IconImage, ref _iconImageCached, () => _iconHolder.sprite = IconImage);
            CheckForChanges(IconColor, ref _iconColorCached, () => _iconHolder.color = IconColor);
        }
    }
}