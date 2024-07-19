using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(Slider))]
    [CanEditMultipleObjects]
    public class SliderInspector : UnityEditor.Editor
    {
        SerializedProperty _sliderEvent;
        
        SerializedProperty _backgroundImage;
        SerializedProperty _backgroundColor;
        SerializedProperty _handleImage;
        SerializedProperty _handleColor;
        
        SerializedProperty _sliderValue;
        SerializedProperty _sliderMinValue;
        SerializedProperty _sliderMaxValue;

        void OnEnable()
        {
            _sliderEvent = serializedObject.FindProperty("SliderEvent");
            
            _backgroundImage = serializedObject.FindProperty("BackgroundImage");
            _backgroundColor = serializedObject.FindProperty("BackgroundColor");
            _handleImage = serializedObject.FindProperty("HandleImage");
            _handleColor = serializedObject.FindProperty("HandleColor");
            
            _sliderValue = serializedObject.FindProperty("SliderValue");
            _sliderMinValue = serializedObject.FindProperty("SliderMinValue");
            _sliderMaxValue = serializedObject.FindProperty("SliderMaxValue");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            QUIEditorUtils.DrawHorizontalGroup(() =>
            {
                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("BG", EditorStyles.boldLabel);
                    QUIEditorUtils.DrawVerticalGroup(() =>
                    {
                        _backgroundImage.objectReferenceValue = EditorGUILayout.ObjectField(
                            _backgroundImage.objectReferenceValue,
                            typeof(Sprite),
                            false,
                            GUILayout.Height(48), GUILayout.Width(48)
                        ) as Sprite;
                        EditorGUILayout.PropertyField(_backgroundColor, GUIContent.none, GUILayout.Height(16), GUILayout.Width(48));
                    });
                });

                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("Handle", EditorStyles.boldLabel);
                    QUIEditorUtils.DrawVerticalGroup(() =>
                    {
                        _handleImage.objectReferenceValue = EditorGUILayout.ObjectField(
                            _handleImage.objectReferenceValue,
                            typeof(Sprite),
                            false,
                            GUILayout.Height(48), GUILayout.Width(48)
                        ) as Sprite;
                        EditorGUILayout.PropertyField(_handleColor, GUIContent.none, GUILayout.Height(16), GUILayout.Width(48));
                    });
                });
                
                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("Slider", EditorStyles.boldLabel);
                    QUIEditorUtils.DrawVerticalGroup(() =>
                    {
                        _sliderValue.floatValue = EditorGUILayout.Slider(
                            _sliderValue.floatValue,
                            _sliderMinValue.floatValue, 
                            _sliderMaxValue.floatValue
                        );
                        
                        QUIEditorUtils.DrawVerticalGroup(() =>
                        {
                            EditorGUILayout.PropertyField(_sliderMinValue);
                            EditorGUILayout.PropertyField(_sliderMaxValue);
                        });
                    });
                });
            });
            
            EditorGUILayout.Separator();
            EditorGUILayout.PropertyField(_sliderEvent, new GUIContent("On Value Changed"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}