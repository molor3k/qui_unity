using System;
using UnityEditor;
using UnityEngine;

namespace QUI.Editor
{
    public static class QUIEditorUtils
    {
        public static void DrawHorizontalGroup(Action content = null, GUIStyle style = null)
        {
            style ??= GUIStyle.none;
        
            GUILayout.BeginHorizontal(style);
            content?.Invoke();
            GUILayout.EndHorizontal();
        }
    
        public static void DrawVerticalGroup(Action content = null, GUIStyle style = null)
        {
            style ??= GUIStyle.none;

            GUILayout.BeginVertical(style);
            content?.Invoke();
            GUILayout.EndVertical();
        }
        
        public static void DrawSection(string headerText, Action content, GUIStyle style = null)
        {
            style ??= GUIStyle.none;
            
            DrawVerticalGroup(() =>
            {
                GUILayout.Label(headerText, EditorStyles.largeLabel);
                EditorGUILayout.Separator();
                content?.Invoke();
            }, style);
        }
        
        public static void DrawSpriteColorSection(string headerText, SerializedProperty spriteVar, SerializedProperty colorVar, GUIStyle style = null)
        {
            DrawSection(headerText, () =>
            {
                spriteVar.objectReferenceValue = EditorGUILayout.ObjectField(
                    spriteVar.objectReferenceValue,
                    typeof(Sprite),
                    false,
                    GUILayout.Height(48), 
                    GUILayout.Width(48)
                ) as Sprite;
                    
                EditorGUILayout.PropertyField(
                    colorVar, 
                    GUIContent.none, 
                    GUILayout.Height(16),
                    GUILayout.Width(48)
                );
            }, style);
        }

        public static void DrawLabelSection(string headerText, Action content, 
            SerializedProperty fontVar, SerializedProperty fontIsAutoSizeVar, SerializedProperty fontSizeVar, GUIStyle style = null)
        {
            DrawSection(headerText, () =>
            {
                content?.Invoke();
                
                EditorGUILayout.Separator();
                EditorGUILayout.PropertyField(fontVar);
                EditorGUILayout.PropertyField(fontIsAutoSizeVar, GUILayout.Width(15));
                GUI.enabled = !fontIsAutoSizeVar.boolValue;
                EditorGUILayout.PropertyField(fontSizeVar);
                GUI.enabled = true;
            }, style);
        }
    }
}