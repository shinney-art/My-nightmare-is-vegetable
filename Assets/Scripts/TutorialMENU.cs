using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMENU : MonoBehaviour

{
    public GameObject assetsUI;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            assetsUI.SetActive(!assetsUI.activeSelf);
        }
    }
}

