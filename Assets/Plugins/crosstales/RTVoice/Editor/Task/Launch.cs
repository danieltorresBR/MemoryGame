using UnityEditor;
using Crosstales.RTVoice.EditorUtil;

namespace Crosstales.RTVoice.EditorTask
{
    /// <summary>Show the configuration window on the first launch.</summary>
    [InitializeOnLoad]
    public static class Launch
    {

        #region Constructor

        static Launch()
        {
            //UnityEngine.Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

            bool launched = EditorPrefs.GetBool(EditorConstants.KEY_LAUNCH);

            if (!launched)
            {
                EditorIntegration.ConfigWindow.ShowWindow(4);
                EditorPrefs.SetBool(EditorConstants.KEY_LAUNCH, true);
            }
        }

        #endregion
    }
}
// © 2017-2019 crosstales LLC (https://www.crosstales.com)