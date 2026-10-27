using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // This function can be called by your button
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}