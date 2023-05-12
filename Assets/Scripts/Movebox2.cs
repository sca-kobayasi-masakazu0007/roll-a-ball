using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movebox2 : MonoBehaviour
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
            Vector3.MoveTowards(transform.position, new Vector3(1, 0.5f, 13), speed * Time.deltaTime);

        else if (!flag)
            transform.position =
            Vector3.MoveTowards(transform.position, new Vector3(1, 2, 13), speed * Time.deltaTime);
    }
}