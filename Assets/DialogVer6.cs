using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogVer6 : MonoBehaviour
{
    public int scene = 0;
    public GameObject sn0, sn1, sn2, sn3, sn4, sn5, sn6, sn7, sn8, sn9;

    void Start()
    {

    }


    void Update()
    {
        if (scene == 1)
        {
            sn1.SetActive(true);
            sn0.SetActive(false);
        }
        else if (scene == 2)
        {
            sn1.SetActive(false);
            sn2.SetActive(true);
        }
        else if (scene == 3)
        {
            sn2.SetActive(false);
            sn3.SetActive(true);
        }
        else if (scene == 4)
        {
            sn3.SetActive(false);
            sn4.SetActive(true);
        }
        else if (scene == 5)
        {
            sn4.SetActive(false);
            sn5.SetActive(true);
        }
        else if (scene == 6)
        {
            sn5.SetActive(false);
            sn6.SetActive(true);
        }
        else if (scene == 7)
        {
            sn6.SetActive(false);
            sn7.SetActive(true);
        }
        else if (scene == 8)
        {
            sn7.SetActive(false);
            sn8.SetActive(true);
        }
        else if (scene == 9)
        {
            sn8.SetActive(false);
            sn9.SetActive(true);
        }
        else if (scene == 10)
        {
            SceneManager.LoadScene(8);
        }
    }

    public void NextScene()
    {
        scene++;
    }

}