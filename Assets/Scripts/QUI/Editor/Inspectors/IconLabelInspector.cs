using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(IconLabel))]
    [CanEditMultipleObjects]
    public class IconLabelInspector : UnityEditor.Editor
    {
        SerializedProperty _isReversed;
        SerializedProperty _icon;
        SerializedProperty _iconColor;
        
        SerializedProperty _text;
        SerializedProperty _textColor;
        SerializedProperty _textSize;
        SerializedProperty _textFont;

        void OnEnable()
        {
            _isReversed = serializedObject.FindProperty("IsReversed");
            
            _icon = serializedObject.FindProperty("Icon");
            _iconColor = serializedObject.FindProperty("IconColor");
            
            _text = serializedObject.FindProperty("Text");
            _textColor = serializedObject.FindProperty("TextColor");
            _textSize = serializedObject.FindProperty("TextSize");
            _textFont = serializedObject.FindProperty("TextFont");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            QUIEditorUtils.DrawHorizontalGroup(() =>
            {
                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("Icon", EditorStyles.boldLabel);
                    
                    _icon.objectReferenceValue = EditorGUILayout.ObjectField(
                        _icon.objectReferenceValue,
                        typeof(Sprite),
                        false,
                        GUILayout.Height(48), GUILayout.Width(48)
                    ) as Sprite;
                    
                    EditorGUILayout.PropertyField(_iconColor, GUIContent.none, GUILayout.Height(16), GUILayout.Width(48));
                });

                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("Label", EditorStyles.boldLabel);
                    QUIEditorUtils.DrawHorizontalGroup(() =>
                    {
                        EditorGUILayout.PropertyField(_text, GUIContent.none);
                        EditorGUILayout.PropertyField(_textColor, GUIContent.none, GUILayout.Width(48));
                    });
                    QUIEditorUtils.DrawHorizontalGroup(() =>
                    {
                        EditorGUILayout.PropertyField(_textFont, GUIContent.none);
                        EditorGUILayout.PropertyField(_textSize, GUIContent.none, GUILayout.Width(48));
                    });
                });
            });

            _isReversed.boolValue = EditorGUILayout.Toggle("Is Order Reversed", _isReversed.boolValue);

            serializedObject.ApplyModifiedProperties();
        }
    }
}