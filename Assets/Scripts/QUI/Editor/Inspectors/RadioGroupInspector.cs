using QUI.Components;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor.Inspectors
{
    [CustomEditor(typeof(RadioGroup))]
    [CanEditMultipleObjects]
    public class RadioGroupInspector : UnityEditor.Editor
    {
        SerializedProperty _layoutHolder;
        SerializedProperty _selectFirstByDefault;

        void OnEnable()
        {
            _layoutHolder = serializedObject.FindProperty("LayoutHolder");
            _selectFirstByDefault = serializedObject.FindProperty("SelectFirstByDefault");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            QUIEditorUtils.DrawVerticalGroup(() =>
            {
                EditorGUILayout.PropertyField(_layoutHolder, new GUIContent("Layout"));
                if (!_layoutHolder.objectReferenceValue)
                {
                    EditorGUILayout.HelpBox("Assign a Horizontal or Vertical layout group", MessageType.Warning);
                }

                EditorGUILayout.PropertyField(_selectFirstByDefault, new GUIContent("Select First By Default"));
                EditorGUILayout.Separator();
            });

            serializedObject.ApplyModifiedProperties();
        }
    }
}