using System;
using UnityEngine;

namespace QUI
{
    [ExecuteInEditMode]
    public class QUIBaseComponent : MonoBehaviour
    {
        private void Awake()
        {
            Refresh();
        }

        private void Update()
        {
            Refresh();
        }
        
        protected virtual void Refresh()
        {
            
        }

        protected bool CheckForChanges<T>(T value, ref T cachedValue, Action callback)
        {
            if (value == null && cachedValue == null) return false;
            
            if (!value.Equals(cachedValue))
            {
                callback?.Invoke();
                cachedValue = value;
                
                return true;
            }

            return false;
        }
    }
}