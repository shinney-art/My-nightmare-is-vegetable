
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class playvideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    void Start()
    {
        videoPlayer.loopPointReached += VideoEnded;
    }

    void VideoEnded(VideoPlayer video)
    {
        SceneManager.LoadScene(0);
    }
}

