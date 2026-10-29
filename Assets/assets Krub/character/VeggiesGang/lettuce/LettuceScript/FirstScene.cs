using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScene : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject pointA;
    public GameObject HideDat;
    public GameObject ShowDat;
    public float moveSpeed = 2f;
    public float stopDistance = 0.1f;

    void Update()
    {
        if (pointA == null)
            return;

        // Move enemy toward pointA
        transform.position = Vector2.MoveTowards(
            transform.position,
            pointA.transform.position,
            moveSpeed * Time.deltaTime
        );

        // Hide the object when the enemy reaches pointA
        if (Vector2.Distance(transform.position, pointA.transform.position) < stopDistance)
        {
            if (HideDat != null)
                HideDat.SetActive(false);

            if (ShowDat != null)
                ShowDat.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}