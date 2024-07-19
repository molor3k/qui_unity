using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace QUI.Components
{
    public class RadioGroup : QUIBaseComponent
    {
        public int SelectedIndex => GetSelectedIndex();
        public Action<int> ToggleEvent;
        
        private RadioButton _selectedButtonCached; 
        private RadioButton _selectedButton;
        
        private bool _selectFirstByDefaultCached;
        public bool SelectFirstByDefault;
        
        private HorizontalOrVerticalLayoutGroup _layoutHolderCached;
        public HorizontalOrVerticalLayoutGroup LayoutHolder;
        
        private List<RadioButton> _buttonsListCached;
        public List<RadioButton> ButtonsList;



        public void ForceRefresh()
        {
            if (!LayoutHolder) return;
            if (!ButtonsList.Any())
            {
                ButtonsList = new List<RadioButton>();
                _buttonsListCached = new List<RadioButton>();
            }
            
            ReassignLayoutButtons();
        }

        public void ForceRefreshButtonToggle()
        {
            RefreshButtonsToggle();
        }

        protected override void Refresh()
        {
            if (!LayoutHolder) return;
            if (!ButtonsList.Any())
            {
                ButtonsList = new List<RadioButton>();
                _buttonsListCached = new List<RadioButton>();
            }
            
            CheckForChanges(LayoutHolder, ref _layoutHolderCached, () => ReassignLayoutButtons());
            CheckForChanges(ButtonsList, ref _buttonsListCached, () => 
                ReloadButtonsList(_buttonsListCached, ButtonsList));
            CheckForChanges(SelectFirstByDefault, ref _selectFirstByDefaultCached, () => RefreshButtonsToggle());
            
            CheckForChangesInButtons();
        }
        
        private void ReassignLayoutButtons()
        {
            // Remove onclick listeners from radio buttons and clear the list
            if (ButtonsList != null) RemoveButtonListeners(ButtonsList);
            ButtonsList.Clear();

            // Detect radio buttons and add them to the list
            foreach (Transform child in LayoutHolder.transform)
            {
                var radioButton = child.gameObject.GetComponent<RadioButton>();
                if (!radioButton) continue;

                ButtonsList.Add(radioButton);
            }
            
            // Add onclick listeners to all radio buttons
            AssignButtonListeners(ButtonsList);
        }

        private void ReloadButtonsList(List<RadioButton> oldList, List<RadioButton> list)
        {
            RemoveButtonListeners(oldList);
            AssignButtonListeners(list);
        }

        private void CheckForChangesInButtons()
        {
            CheckForChanges(_selectedButton, ref _selectedButtonCached, () =>
            {
                RefreshButtonsToggle();
            });
        }

        #region Utils

        private void SelectRadioButton(RadioButton button)
        {
            if (button == null) return;
            if (_selectedButton == button) return;
            
            _selectedButton = button;
            ToggleEvent?.Invoke(SelectedIndex);
        }

        private void RefreshButtonsToggle()
        {
            TryToSelectFirstRadioButton();

            foreach (var button in ButtonsList)
            {
                var prevState = button.IsToggled;
                button.IsToggled = button.Equals(_selectedButton);
                
                if (prevState != button.IsToggled) button.ToggleEvent?.Invoke();
            }
        }

        private void TryToSelectFirstRadioButton()
        {
            if (!SelectFirstByDefault) return;
            if (ButtonsList == null) return;
            if (ButtonsList.Count <= 0) return;
            if (_selectedButton) return;

            SelectRadioButton(ButtonsList[0]);
        }
        
        private int GetSelectedIndex()
        {
            for (int i = 0; i < ButtonsList.Count; i++)
            {
                var button = ButtonsList[i];
                if (button == _selectedButton) return i;
            }

            return -1;
        }

        private void AssignButtonListeners(List<RadioButton> list)
        {
            if (list == null) return;
            
            foreach (var button in list)
            {
                if (!button) continue;
                
                var toggleComponent = button.Interactable;
                toggleComponent.onClick.AddListener(() => SelectRadioButton(button));
            }
        }
        
        private void RemoveButtonListeners(List<RadioButton> list)
        {
            if (list == null) return;
            
            foreach (var button in list)
            {
                if (!button) continue;
                
                var toggleComponent = button.Interactable;
                toggleComponent.onClick.RemoveListener(() => SelectRadioButton(button));
            }
        }

        #endregion
    }
}