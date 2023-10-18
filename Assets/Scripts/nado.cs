using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nado : MonoBehaviour
{
    GameObject tonado;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.06f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed);
    }

  
}
