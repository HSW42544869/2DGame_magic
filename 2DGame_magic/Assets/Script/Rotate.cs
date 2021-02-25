using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float Rotatespeed = 50;
    public float DestroyTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(gameObject.transform.up);
    }
}
