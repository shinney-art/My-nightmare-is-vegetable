using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogVer3 : MonoBehaviour
{
    public int scene = 0;
    public GameObject button;
    public GameObject cutscene;
    public GameObject sn0, sn1, sn2, sn3;

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
            button.SetActive(false);
            cutscene.SetActive(false);

        }
    }

    public void NextScene()
    {
        scene++;
    }

}