using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace QUI.Editor
{
    public class QUIEditorWindow : EditorWindow
    {
        private Vector2 _windowScrollPosition;
        
        private static Dictionary<string, Object> _basic;
        private static Dictionary<string, Object> _containers;
        private static Dictionary<string, Object> _visuals;
        private static Dictionary<string, Object> _buttons;
        private static Dictionary<string, Object> _radio;
        private static Dictionary<string, Object> _sliders;
        private static Dictionary<string, Object> _misc;


        [MenuItem("Tools/QUI")]
        public static void ShowWindow()
        {
            QUIEditorWindow wnd = GetWindow<QUIEditorWindow>();
            wnd.titleContent = new GUIContent("QUI", Resources.Load<Texture>("QUI/Textures/qui_tool_icon"));
        }

        private void OnEnable()
        {
            LoadAllComponents();
        }

        private void OnGUI()
        {
            var style = new GUIStyle();
            style.margin = new RectOffset(10, 10, 10, 10);
            
            _windowScrollPosition = GUILayout.BeginScrollView(_windowScrollPosition);

            QUIEditorUtils.DrawVerticalGroup(() =>
            {
                GUILayout.Label("Basic", EditorStyles.boldLabel);
                DrawComponentsList(_basic, false);
                GUILayout.Space(10);
                
                GUILayout.Label("Containers", EditorStyles.boldLabel);
                DrawComponentsList(_containers, true);
                GUILayout.Space(10);

                GUILayout.Label("Visual Components", EditorStyles.boldLabel);
                DrawComponentsList(_visuals);
                GUILayout.Space(10);
                
                GUILayout.Label("Buttons and Fields", EditorStyles.boldLabel);
                DrawComponentsList(_buttons);
                GUILayout.Space(10);
                
                GUILayout.Label("Radio", EditorStyles.boldLabel);
                DrawComponentsList(_radio);
                GUILayout.Space(10);
                
                GUILayout.Label("Sliders", EditorStyles.boldLabel);
                DrawComponentsList(_sliders);
                GUILayout.Space(10);

                GUILayout.Label("Misc. Components", EditorStyles.boldLabel);
                DrawComponentsList(_misc);
            }, style);
            
            GUILayout.EndScrollView();
        }
        
        private void DrawComponentsList(Dictionary<string, Object> components, bool removePrefix = false)
        {
            var buttonWidth = 82.0f;
            var componentsList = new List<KeyValuePair<string, Object>>();
            foreach (var component in components)
            {
                componentsList.Add(component);
            }

            DrawResponsiveGrid((index) =>
            {
                var component = componentsList[index];
                var icon = AssetPreview.GetMiniThumbnail(component.Value);
                var content = new GUIContent(ComponentFormatName(component.Key, removePrefix), icon);

                DrawButton(content, () => { InstantiatePrefab(component.Value); });
            }, components.Count, buttonWidth);
        }

        #region Draw Components
        
        private void DrawButton(GUIContent content, Action onClick = null, GUIStyle style = null)
        {
            if (style == null)
            {
                style = new GUIStyle(GUI.skin.button);
                style.imagePosition = ImagePosition.ImageAbove;
                style.stretchHeight = true;
                style.alignment = TextAnchor.LowerCenter;
                style.wordWrap = true;
                style.fontSize = 9;
                style.fontStyle = FontStyle.Bold;
                style.fixedHeight = 64;
                style.fixedWidth = 64;
            }
            
            if (GUILayout.Button(content, style))
            {
                onClick?.Invoke();
            }
        }

        private void DrawResponsiveGrid(Action<int> renderCallback, int componentsAmount, float componentWidth)
        {
            var windowWidth = position.width;
            var currentComponentId = 0;
            
            var columnsNumber = windowWidth / componentWidth;
            var rowsNumber = (int) Math.Ceiling(componentsAmount / columnsNumber);
            
            
            QUIEditorUtils.DrawVerticalGroup(() =>
            {
                for (int i = 0; i < rowsNumber; i++)
                {
                    QUIEditorUtils.DrawHorizontalGroup(() =>
                    {
                        for (int j = 0; j < columnsNumber; j++)
                        {
                            if (componentsAmount > currentComponentId)
                            {
                                renderCallback.Invoke(currentComponentId);
                                currentComponentId++;
                            }
                        }
                    });
                }
            });
        }
        
        #endregion

        #region Manage Components

        private string ComponentFormatName(string componentName, bool removePrefix = false)
        {
            var nameSplitted = Regex.Split(componentName, @"(?<!^)(?=[A-Z])");
            var name = "";
            for (int i = 0; i < nameSplitted.Length; i++)
            {
                if (removePrefix)
                {
                    if (i != 0) name += $"{nameSplitted[i]} ";
                }
                else
                {
                    name += $"{nameSplitted[i]} ";
                }
            }

            return name;
        }

        #endregion

        #region Utils
        private void InstantiatePrefab(Object asset)
        {
            var prefab = PrefabUtility.InstantiatePrefab(asset);
            Undo.RegisterCreatedObjectUndo(prefab, $"Instantiated {asset.name}");
            
            prefab.GetComponent<Transform>().SetParent(Selection.activeTransform, false);
            PrefabUtility.RecordPrefabInstancePropertyModifications(prefab.GetComponent<Transform>());

            EditorGUIUtility.PingObject(prefab);
        }

        #endregion

        #region Load data
        
        private static void LoadAllComponents()
        {
            _basic = LoadComponents("QUI/Components/Basic/");
            _containers = LoadComponents("QUI/Components/Containers/");
            _visuals = LoadComponents("QUI/Components/Visuals/");
            _buttons = LoadComponents("QUI/Components/Buttons/");
            _radio = LoadComponents("QUI/Components/Radio/");
            _sliders = LoadComponents("QUI/Components/Sliders/");
            _misc = LoadComponents("QUI/Components/Misc/");
        }

        private static Dictionary<string, Object> LoadComponents(string path)
        {
            var assets = Resources.LoadAll(path);

            var dictionary = new Dictionary<string, Object>();
            foreach (var asset in assets)
            {
                dictionary.Add(asset.name, asset);
            }

            return dictionary;
        }

        #endregion
    }
}
