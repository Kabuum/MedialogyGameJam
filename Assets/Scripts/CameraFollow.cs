using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float camSpeed;
    public Vector3 offests;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = transform.position + offests * camSpeed * Time.deltaTime;
    }
}
