using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(TextRadioButton))]
    [CanEditMultipleObjects]
    public class TextRadioButtonInspector : UnityEditor.Editor
    {
        SerializedProperty _isToggled;
        SerializedProperty _toggleEvent;
        
        SerializedProperty _buttonImage;
        SerializedProperty _buttonColor;
        
        SerializedProperty _statusImage;
        SerializedProperty _statusColor;
        
        SerializedProperty _isToggledLabelSame;
        SerializedProperty _labelToggled;
        SerializedProperty _labelUntoggled;
        SerializedProperty _labelToggledColor;
        SerializedProperty _labelUntoggledColor;
        SerializedProperty _labelIsAutoSize;
        SerializedProperty _labelSize;
        SerializedProperty _labelFont;

        void OnEnable()
        {
            _isToggled = serializedObject.FindProperty("IsToggled");
            _toggleEvent = serializedObject.FindProperty("ToggleEvent");
            
            _buttonImage = serializedObject.FindProperty("ButtonImage");
            _buttonColor = serializedObject.FindProperty("ButtonColor");
            
            _statusImage = serializedObject.FindProperty("StatusImage");
            _statusColor = serializedObject.FindProperty("StatusColor");
            
            _isToggledLabelSame = serializedObject.FindProperty("IsToggledTextTheSame");
            _labelToggled = serializedObject.FindProperty("LabelToggledText");
            _labelToggledColor = serializedObject.FindProperty("LabelToggledColor");
            _labelUntoggled = serializedObject.FindProperty("LabelUntoggledText");
            _labelUntoggledColor = serializedObject.FindProperty("LabelUntoggledColor");
            _labelIsAutoSize = serializedObject.FindProperty("IsLabelAutoSize");
            _labelSize = serializedObject.FindProperty("LabelSize");
            _labelFont = serializedObject.FindProperty("LabelFont");
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

                QUIEditorUtils.DrawLabelSection("Label", () =>
                {
                    EditorGUILayout.PropertyField(_isToggledLabelSame, new GUIContent("Is Active Text The Same"));

                    if (!_isToggledLabelSame.boolValue)
                    {
                        QUIEditorUtils.DrawHorizontalGroup(() =>
                        {
                            EditorGUILayout.PropertyField(_labelToggled, GUIContent.none);
                            EditorGUILayout.PropertyField(_labelToggledColor, GUIContent.none, GUILayout.Width(48));
                        });
                    }
                    
                    QUIEditorUtils.DrawHorizontalGroup(() =>
                    {
                        EditorGUILayout.PropertyField(_labelUntoggled, GUIContent.none);
                        EditorGUILayout.PropertyField(_labelUntoggledColor, GUIContent.none, GUILayout.Width(48));
                    });
                }, _labelFont, _labelIsAutoSize, _labelSize, EditorStyles.helpBox);
            });

            EditorGUILayout.Separator();
            QUIEditorUtils.DrawSection("Actions", () =>
            {
                EditorGUILayout.PropertyField(_isToggled, new GUIContent("Is Toggled"));
                EditorGUILayout.PropertyField(_toggleEvent, new GUIContent("On Toggle"));
            }, EditorStyles.helpBox);

            serializedObject.ApplyModifiedProperties();
        }
    }
}