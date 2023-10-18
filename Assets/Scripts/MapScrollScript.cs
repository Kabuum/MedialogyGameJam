using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapScrollScript: MonoBehaviour
{
    public float camSpeed;
    public Vector3 offests;
    void Start()
    {

    }
    void Update()
    {
        transform.position = transform.position + offests * camSpeed * Time.deltaTime;
    }
}
