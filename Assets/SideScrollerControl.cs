using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerControl : MonoBehaviour
{

    public float speed = 2f;


    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(x, 0, 0) * speed * Time.deltaTime);
    }
}
