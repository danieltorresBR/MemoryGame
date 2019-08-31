using UnityEngine;
using UnityEngine.UI;
using Crosstales.RTVoice.Model;

namespace Crosstales.RTVoice.Demo
{
    /// <summary>Wrapper for the dynamic speakers.</summary>
    [RequireComponent(typeof(AudioSource))]
    [HelpURL("https://www.crosstales.com/media/data/assets/rtvoice/api/class_crosstales_1_1_r_t_voice_1_1_demo_1_1_speak_wrapper.html")]
    public class SpeakWrapper : MonoBehaviour
    {

        #region Variables

        public Voice SpeakerVoice;
        public InputField Input;
        public Text Label;
        public AudioSource Audio;

        private string uid = string.Empty;

        #endregion


        #region MonoBehaviour methods

        public void Start()
        {
            Audio = GetComponent<AudioSource>();
        }

        #endregion


        #region Public methods

        public void Speak()
        {
            Speaker.Silence(uid);

            if (GUISpeech.isNative)
            {
                uid = Speaker.SpeakNative(Input.text, SpeakerVoice, GUISpeech.Rate, GUISpeech.Pitch, GUISpeech.Volume);
            }
            else
            {
                uid = Speaker.Speak(Input.text, Audio, SpeakerVoice, true, GUISpeech.Rate, GUISpeech.Pitch, GUISpeech.Volume);
            }
        }

        #endregion
    }
}
// © 2015-2019 crosstales LLC (https://www.crosstales.com)