using UnityEditor;
using UnityEngine;

namespace Crosstales.RTVoice.EditorTask
{
    /// <summary>Sets the required .NET API level.</summary>
    [InitializeOnLoad]
    public static class SetApiLevel
    {
        #region Constructor

        static SetApiLevel()
        {
#if UNITY_2018_2_OR_NEWER && UNITY_STANDALONE
            ApiCompatibilityLevel level = ApiCompatibilityLevel.NET_4_6;

            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            BuildTargetGroup group = BuildPipeline.GetBuildTargetGroup(target);

            //Debug.Log("API level: " + PlayerSettings.GetApiCompatibilityLevel(group));

            if (PlayerSettings.GetApiCompatibilityLevel(group) != level)
            {
                PlayerSettings.SetApiCompatibilityLevel(group, level);

                Debug.Log("API level changed to '" + level + "'");
            }
#endif
        }

        #endregion
    }
}
// © 2019 crosstales LLC (https://www.crosstales.com)