using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(SolidLabel))]
    [CanEditMultipleObjects]
    public class SolidLabelInspector : UnityEditor.Editor
    {
        SerializedProperty _bgImage;
        SerializedProperty _bgColor;
        
        SerializedProperty _label;
        SerializedProperty _labelColor;
        SerializedProperty _labelSize;
        SerializedProperty _labelFont;

        void OnEnable()
        {
            _bgImage = serializedObject.FindProperty("BGImage");
            _bgColor = serializedObject.FindProperty("BGColor");
            
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
                    GUILayout.Label("BG", EditorStyles.boldLabel);
                    
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

            serializedObject.ApplyModifiedProperties();
        }
    }
}