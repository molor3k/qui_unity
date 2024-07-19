using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(BackgroundPatterned))]
    [CanEditMultipleObjects]
    public class BackgroundPatternedInspector : UnityEditor.Editor
    {
        SerializedProperty _bgImage;
        SerializedProperty _bgColor;

        SerializedProperty _pattern;
        SerializedProperty _patternColor;
        SerializedProperty _patternSize;

        void OnEnable()
        {
            _bgImage = serializedObject.FindProperty("BackgroundImage");
            _bgColor = serializedObject.FindProperty("BackgroundColor");

            _pattern = serializedObject.FindProperty("Pattern");
            _patternColor = serializedObject.FindProperty("PatternColor");
            _patternSize = serializedObject.FindProperty("PatternSize");
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
                            GUILayout.Height(48),
                            GUILayout.Width(48)
                        );

                        EditorGUILayout.PropertyField(_bgColor, GUIContent.none, GUILayout.Height(16), GUILayout.Width(48));
                    });

                    QUIEditorUtils.DrawVerticalGroup(() =>
                    {
                        GUILayout.Label("Pattern", EditorStyles.boldLabel);
                            _pattern.objectReferenceValue = EditorGUILayout.ObjectField(
                                _pattern.objectReferenceValue,
                                typeof(Sprite),
                                false,
                                GUILayout.Height(48),
                                GUILayout.Width(48)
                            );

                            EditorGUILayout.PropertyField(_patternColor, GUIContent.none, GUILayout.Height(16), GUILayout.Width(48));
                    });

                    QUIEditorUtils.DrawVerticalGroup(() =>
                    {
                        GUILayout.Label("Settings", EditorStyles.boldLabel);
                        EditorGUILayout.PropertyField(_patternSize);
                    });
                });
                
            serializedObject.ApplyModifiedProperties();
        }
    }
}