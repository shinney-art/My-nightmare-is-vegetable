using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InActive : MonoBehaviour

{
    public GameObject uiToHide;


    public void Hide()
    {
        uiToHide.SetActive(false);
    }
}