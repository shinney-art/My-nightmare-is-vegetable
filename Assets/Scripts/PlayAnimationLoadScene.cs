using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayAnimationLoadScene : MonoBehaviour
{
    public Animator anim;
    public string animationName;
    public string nextScene;

    public void PlayAndLoad()
    {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        anim.Play(animationName);

        yield return null;

        yield return new WaitForSeconds(
            anim.GetCurrentAnimatorStateInfo(0).length
        );

        SceneManager.LoadScene(nextScene);
    }
}