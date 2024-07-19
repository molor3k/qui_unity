using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(InputField))]
    [CanEditMultipleObjects]
    public class InputFieldInspector : UnityEditor.Editor
    {
        SerializedProperty _bgImage;
        SerializedProperty _bgColor;
        
        SerializedProperty _text;
        SerializedProperty _textColor;
        SerializedProperty _textSize;
        SerializedProperty _textFont;
        
        SerializedProperty _placeholderText;
        SerializedProperty _placeholderTextColor;

        void OnEnable()
        {
            _bgImage = serializedObject.FindProperty("BGImage");
            _bgColor = serializedObject.FindProperty("BGColor");
            
            _text = serializedObject.FindProperty("InputText");
            _textColor = serializedObject.FindProperty("InputTextColor");
            _textSize = serializedObject.FindProperty("InputTextSize");
            _textFont = serializedObject.FindProperty("InputTextFont");
            
            _placeholderText = serializedObject.FindProperty("PlaceholderText");
            _placeholderTextColor = serializedObject.FindProperty("PlaceholderTextColor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            QUIEditorUtils.DrawHorizontalGroup(() =>
            {
                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("Icon", EditorStyles.boldLabel);
                    
                    _bgImage.objectReferenceValue = EditorGUILayout.ObjectField(
                        _bgImage.objectReferenceValue,
                        typeof(Sprite),
                        false,
                        GUILayout.Height(48), GUILayout.Width(48)
                    ) as Sprite;
                    
                    EditorGUILayout.PropertyField(_bgColor, GUIContent.none, GUILayout.Height(16), GUILayout.Width(48));
                });

                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("Settings", EditorStyles.boldLabel);
                    QUIEditorUtils.DrawHorizontalGroup(() =>
                    {
                        EditorGUILayout.PropertyField(_textFont, GUIContent.none);
                        EditorGUILayout.PropertyField(_textSize, GUIContent.none, GUILayout.Width(48));
                    });
                });
            });
            
            EditorGUILayout.Separator();
            QUIEditorUtils.DrawVerticalGroup(() =>
            {
                QUIEditorUtils.DrawHorizontalGroup(() =>
                {
                    EditorGUILayout.PropertyField(_text, new GUIContent("Input text"));
                    EditorGUILayout.PropertyField(_textColor, GUIContent.none, GUILayout.Width(48));
                });
                QUIEditorUtils.DrawHorizontalGroup(() =>
                {
                    EditorGUILayout.PropertyField(_placeholderText, new GUIContent("Placeholder text"));
                    EditorGUILayout.PropertyField(_placeholderTextColor, GUIContent.none, GUILayout.Width(48));
                });
            });

            serializedObject.ApplyModifiedProperties();
        }
    }
}