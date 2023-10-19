using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nado : MonoBehaviour
{
    GameObject tonado;
    public float speed;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.06f;
        lifetime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed);
    }

    void FixedUpdate()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
  
}
