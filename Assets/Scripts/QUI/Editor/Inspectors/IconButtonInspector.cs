using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(IconButton))]
    [CanEditMultipleObjects]
    public class IconButtonInspector : UnityEditor.Editor
    {
        SerializedProperty _clickedEvent;
        
        SerializedProperty _buttonImage;
        SerializedProperty _buttonColor;
        
        SerializedProperty _iconImage;
        SerializedProperty _iconColor;

        void OnEnable()
        {
            _clickedEvent = serializedObject.FindProperty("ClickedEvent");
            
            _buttonImage = serializedObject.FindProperty("ButtonImage");
            _buttonColor = serializedObject.FindProperty("ButtonColor");
            
            _iconImage = serializedObject.FindProperty("IconImage");
            _iconColor = serializedObject.FindProperty("IconColor");
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
                    GUILayout.Label("Icon", EditorStyles.boldLabel);
                    QUIEditorUtils.DrawVerticalGroup(() =>
                    {
                        _iconImage.objectReferenceValue = EditorGUILayout.ObjectField(
                            _iconImage.objectReferenceValue,
                            typeof(Sprite),
                            false,
                            GUILayout.Height(48), GUILayout.Width(48)
                        ) as Sprite;
                        EditorGUILayout.PropertyField(_iconColor, GUIContent.none, GUILayout.Height(16), GUILayout.Width(48));
                    });
                });
                
                QUIEditorUtils.DrawVerticalGroup(() =>
                {
                    GUILayout.Label("Events", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(_clickedEvent, new GUIContent("On Clicked"));
                });
            });

            serializedObject.ApplyModifiedProperties();
        }
    }
}