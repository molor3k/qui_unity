using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(Toggle))]
    [CanEditMultipleObjects]
    public class ToggleInspector : UnityEditor.Editor
    {
        SerializedProperty _isToggled;
        SerializedProperty _toggleEvent;
        
        SerializedProperty _buttonImage;
        SerializedProperty _buttonColor;
        
        SerializedProperty _statusImage;
        SerializedProperty _statusColor;

        void OnEnable()
        {
            _isToggled = serializedObject.FindProperty("IsToggled");
            _toggleEvent = serializedObject.FindProperty("ToggleEvent");
            
            _buttonImage = serializedObject.FindProperty("ButtonImage");
            _buttonColor = serializedObject.FindProperty("ButtonColor");
            
            _statusImage = serializedObject.FindProperty("StatusImage");
            _statusColor = serializedObject.FindProperty("StatusColor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            QUIEditorUtils.DrawHorizontalGroup(() =>
            {
                QUIEditorUtils.DrawHorizontalGroup(() =>
                {
                    QUIEditorUtils.DrawSpriteColorSection("Button", _buttonImage, _buttonColor);
                    QUIEditorUtils.DrawSpriteColorSection("Status", _statusImage, _statusColor);
                }, EditorStyles.helpBox);
                
                QUIEditorUtils.DrawSection("Actions", () =>
                {
                    EditorGUILayout.PropertyField(_isToggled, new GUIContent("Is Toggled"));
                    EditorGUILayout.PropertyField(_toggleEvent, new GUIContent("On Toggle"));
                }, EditorStyles.helpBox);
            });

            serializedObject.ApplyModifiedProperties();
        }
    }
}