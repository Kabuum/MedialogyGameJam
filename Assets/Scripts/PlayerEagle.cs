using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEagle : MonoBehaviour
{
    public Camera cam;
    public float camX;

    public float maxSpeed;
    public Rigidbody2D rb;
    public float flap;
    public float moveSpeed;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        maxSpeed = 5f;
        flap = 20f; 
        moveSpeed = 10f;
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*flap,ForceMode2D.Impulse);
            anim.Play("eagleAnimation");
        }
        else
        {
 
        }

        if (rb.velocity.magnitude < maxSpeed*-1)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed*-1);
        }
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

        if (Input.GetKey("left"))
        {
            transform.Translate(Vector2.left*(moveSpeed*Time.deltaTime));
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector2.right*(moveSpeed*Time.deltaTime));
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    void FixedUpdate()
    {

    }

    void LateUpdate()
    {

    }
}
