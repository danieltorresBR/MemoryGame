using UnityEditor;
using Crosstales.RTVoice.EditorUtil;

namespace Crosstales.RTVoice.EditorTask
{
    /// <summary>Gather some tracing data for the asset.</summary>
    [InitializeOnLoad]
    public static class Tracer
    {
        #region Constructor

        static Tracer()
        {
            //UnityEngine.Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

            string lastDate = EditorPrefs.GetString(EditorConstants.KEY_TRACER_DATE);

            string date = System.DateTime.Now.ToString("yyyyMMdd"); // every day
            //string date = System.DateTime.Now.ToString("yyyyMMddHHmm"); // every minute (for tests)

            if (!date.Equals(lastDate))
            {
                GAApi.Event(typeof(Tracer).Name, "Startup");

                EditorPrefs.SetString(EditorConstants.KEY_TRACER_DATE, date);
            }
        }

        #endregion

    }
}
// © 2017-2019 crosstales LLC (https://www.crosstales.com)