using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class SpeechWelcome : MonoBehaviour
{
    const string LANG_CODE = "fr_FR";
        [SerializeField]
    Text uiText,speechResult;
   
    void Start()
    {
        Setup(LANG_CODE);
        
        StartSpeaking(uiText.text);
        StartCoroutine(Connexion());

        #if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;

        CheckPermission();
    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }
    public void StartSpeaking(string message)
    {
        TextToSpeech.instance.StartSpeak(message);
    }
     public void StopSpeaking()
    {
        TextToSpeech.instance.StopSpeak();
    }
    
    public IEnumerator Connexion(){

        yield return new WaitForSeconds(4f);
        StartSpeaking("vous souhaiter faire une inscription ou une connexion ?  si vous avez déjà un compte ?");
        
        yield return new WaitForSeconds(5f);
        StartListenning();
        

    }
     void OnSpeakStart()
    {
        Debug.Log("Talking started ...");
    }

    void OnSpeakStop()
    {
        Debug.Log("Talking stopped ");
    }

    #region Speech to Text
        
    public void StartListenning()
    {
        SpeechToText.instance.StartRecording();
    }

    public void StopListenning()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        speechResult.text = result;
    }
    
    void OnPartialSpeechResult(string result)
    {
        speechResult.text = result;

        if(speechResult.text == "ok")
        {
            StartSpeaking("bonjour que puis-je faire pour vous ?" );
        }

    }
#endregion

     void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }
}
