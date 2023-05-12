using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movebox1 : MonoBehaviour
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
            Vector3.MoveTowards(transform.position, new Vector3(-5, 0.5f, 21), speed * Time.deltaTime);

        else if (!flag)
            transform.position =
            Vector3.MoveTowards(transform.position, new Vector3(-5, 2, 21), speed * Time.deltaTime);
    }
}