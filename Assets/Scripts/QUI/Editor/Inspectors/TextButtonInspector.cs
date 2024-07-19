using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(TextButton))]
    [CanEditMultipleObjects]
    public class TextButtonInspector : UnityEditor.Editor
    {
        SerializedProperty _clickedEvent;

        SerializedProperty _buttonImage;
        SerializedProperty _buttonColor;
        
        SerializedProperty _label;
        SerializedProperty _labelColor;
        SerializedProperty _labelSize;
        SerializedProperty _labelFont;

        void OnEnable()
        {
            _clickedEvent = serializedObject.FindProperty("ClickedEvent");
            
            _buttonImage = serializedObject.FindProperty("ButtonImage");
            _buttonColor = serializedObject.FindProperty("ButtonColor");
            
            _label = serializedObject.FindProperty("LabelText");
            _labelColor = serializedObject.FindProperty("LabelColor");
            _labelSize = serializedObject.FindProperty("LabelSize");
            _labelFont = serializedObject.FindProperty("LabelFont");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            QUIEditorUtils.DrawHorizontalGroup(() =>
            {
                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("Button", EditorStyles.boldLabel);
                    QUIEditorUtils.DrawVerticalGroup(() =>
                    {
                        _buttonImage.objectReferenceValue = EditorGUILayout.ObjectField(
                            _buttonImage.objectReferenceValue,
                            typeof(Sprite),
                            false,
                            GUILayout.Height(48), GUILayout.Width(48)
                        ) as Sprite;
                        EditorGUILayout.PropertyField(_buttonColor, GUIContent.none, GUILayout.Height(16), GUILayout.Width(48));
                    });
                });

                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("Label", EditorStyles.boldLabel);
                    QUIEditorUtils.DrawHorizontalGroup(() =>
                    {
                        EditorGUILayout.PropertyField(_label, GUIContent.none);
                        EditorGUILayout.PropertyField(_labelColor, GUIContent.none, GUILayout.Width(48));
                    });
                    QUIEditorUtils.DrawHorizontalGroup(() =>
                    {
                        EditorGUILayout.PropertyField(_labelFont, GUIContent.none);
                        EditorGUILayout.PropertyField(_labelSize, GUIContent.none, GUILayout.Width(48));
                    });
                });
            });
                
            EditorGUILayout.Separator();
            EditorGUILayout.PropertyField(_clickedEvent, new GUIContent("On Clicked"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}