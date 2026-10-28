using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public GameObject player;
    void Start()
    {

    }

    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}

