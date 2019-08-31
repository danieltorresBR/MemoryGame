using UnityEditor;
using UnityEngine;

namespace Crosstales.Common.EditorTask
{
    /// <summary>Sets the required .NET API level.</summary>
    [InitializeOnLoad]
    public static class SetApiLevel
    {
        #region Constructor

        static SetApiLevel()
        {
#if UNITY_2018_2_OR_NEWER
            ApiCompatibilityLevel level = ApiCompatibilityLevel.NET_Standard_2_0;
#else
            ApiCompatibilityLevel level = ApiCompatibilityLevel.NET_2_0;
#endif
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            BuildTargetGroup group = BuildPipeline.GetBuildTargetGroup(target);

            //Debug.Log("API level: " + PlayerSettings.GetApiCompatibilityLevel(group));

            if (PlayerSettings.GetApiCompatibilityLevel(group) != level && PlayerSettings.GetApiCompatibilityLevel(group) != ApiCompatibilityLevel.NET_4_6)
            {
                PlayerSettings.SetApiCompatibilityLevel(group, level);

                Debug.Log("API level changed to '" + level + "'");
            }
        }

        #endregion
    }
}
// © 2017-2019 crosstales LLC (https://www.crosstales.com)