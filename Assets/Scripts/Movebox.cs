using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movebox : MonoBehaviour
{
    private float speed = 1;
    private bool flag;

    void Update()
    {
        if (transform.position.y >= 2)
            flag = true;

        else if (transform.position.y <= 0.5f)
            flag = false;

        if (flag)
            transform.position =
            Vector3.MoveTowards(transform.position, new Vector3(9, 0.5f, 14), speed * Time.deltaTime);

        else if (!flag)
            transform.position =
            Vector3.MoveTowards(transform.position, new Vector3(9, 2, 14), speed * Time.deltaTime);
    }
}