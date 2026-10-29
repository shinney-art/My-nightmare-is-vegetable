using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEm : MonoBehaviour
{
    public GameObject uiToShow;


    public void Show()
    {
        uiToShow.SetActive(true);
    }
}
