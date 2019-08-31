using UnityEngine;
using UnityEditor;
using Crosstales.RTVoice.EditorUtil;

namespace Crosstales.RTVoice.EditorExtension
{
    /// <summary>Custom editor for the 'Paralanguage'-class.</summary>
    [CustomEditor(typeof(Tool.Paralanguage))]
    [CanEditMultipleObjects]
    public class ParalanguageEditor : Editor
    {

        #region Variables

        private Tool.Paralanguage script;

        #endregion


        #region Editor methods

        public void OnEnable()
        {
            script = (Tool.Paralanguage)target;
        }

        public void OnDisable()
        {
            if (Util.Helper.isEditorMode)
            {
                Speaker.Silence();
            }
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (script.isActiveAndEnabled)
            {
                if (!string.IsNullOrEmpty(script.Text))
                {
                    if (Speaker.isTTSAvailable && EditorHelper.isRTVoiceInScene)
                    {
                        //TODO add stuff if needed
                    }
                    else
                    {
                        EditorHelper.NoVoicesUI();
                    }
                }
                else
                {
                    EditorGUILayout.HelpBox("Please enter a 'Text'!", MessageType.Warning);
                }
            }
            else
            {
                EditorGUILayout.HelpBox("Script is disabled!", MessageType.Info);
            }
        }

        #endregion
    }
}
// © 2016-2019 crosstales LLC (https://www.crosstales.com)