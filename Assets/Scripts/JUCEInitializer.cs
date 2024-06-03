using UnityEngine;

public class JUCEInitializer : MonoBehaviour
{
    public delegate void JUCEInitialisedDelegate();
    public static event JUCEInitialisedDelegate JUCEInitialised;
    void Start()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
        // Get the Unity Player activity
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            // Get the application context
            AndroidJavaObject context = activity.Call<AndroidJavaObject>("getApplicationContext");

            // Call the initialiseJUCE method
            using (AndroidJavaClass juceJava = new AndroidJavaClass("com.rmsl.juce.Java"))
            {
                juceJava.CallStatic("initialiseJUCE", context);
            }

            // Load the demo synth plugin by calling a method in the DemoSynth class
            DemoSynth.getInstance();
        }
        #else
        Debug.Log("JUCEInitializer: Not on Android, skipping JUCE initialisation");
        #endif
        
        if (JUCEInitialised != null)
        {
            JUCEInitialised();
        }
    }
}