using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,100));
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }
}
