#if UNITY_ANDROID || CT_ENABLED
using UnityEditor;
using UnityEngine;

namespace Crosstales.Common.EditorTask
{
    /// <summary>Sets the required build parameters for Android.</summary>
    [InitializeOnLoad]
    public static class SetAndroid
    {

        #region Constructor

        static SetAndroid()
        {
            if (!PlayerSettings.Android.forceInternetPermission)
            {
                PlayerSettings.Android.forceInternetPermission = true;

                Debug.Log("Android: 'forceInternetPermission' set to true");
            }

            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            BuildTargetGroup group = BuildPipeline.GetBuildTargetGroup(target);

#if UNITY_2018_3_OR_NEWER
            ManagedStrippingLevel level = ManagedStrippingLevel.Disabled;

            if (PlayerSettings.GetScriptingBackend(group) == ScriptingImplementation.Mono2x && PlayerSettings.GetManagedStrippingLevel(group) != level)
            {
                PlayerSettings.SetManagedStrippingLevel(group, level);

                Debug.Log("Android: stripping level changed to '" + level + "'");
            }
#else
            StrippingLevel level = StrippingLevel.Disabled;

            if (PlayerSettings.GetScriptingBackend(group) == ScriptingImplementation.Mono2x && PlayerSettings.strippingLevel != level)
            {
                PlayerSettings.strippingLevel = level;

                Debug.Log("Android: stripping level changed to '" + level + "'");
            }
#endif
        }

        #endregion
    }
}
#endif
// © 2017-2019 crosstales LLC (https://www.crosstales.com)