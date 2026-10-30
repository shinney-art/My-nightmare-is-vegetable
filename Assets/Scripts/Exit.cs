using UnityEngine;

public class Exit : MonoBehaviour
{
    // The method MUST be public so the UI button can see it
    public void QuitGame()
    {
        Debug.Log("Game is exiting..."); // Verifies click in the console

#if UNITY_EDITOR
            // Exits play mode if testing inside the Unity Editor
            UnityEditor.EditorApplication.isPlaying = false; 
#else
        // Closes the actual built application
        Application.Quit();
#endif
    }
}
