using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class PlayerController2DLion : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10;
    public float jump;

    public float stamina;
    public GameObject manager;

    bool isGrounded = true;

    int jumps = 2;
    // Update is called once per frame
    void Update()
    {
        if (stamina <= 0)
        {
            manager.GetComponent<GameManager>().RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            float angle = transform.eulerAngles.y;
            if (angle != 180)
            {
                transform.Rotate(0, 180, 0);
            }
            stamina -= 1 * Time.deltaTime;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            float angle = transform.eulerAngles.y;
            Debug.Log(angle);
            if (angle == 180)
            {
                transform.Rotate(0, -180, 0);
            }
            stamina -= 1 * Time.deltaTime;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
    public void EatFood()
    {
        stamina += 10;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObstacleDanger"))
        {
            manager.GetComponent<GameManager>().RestartLevel();
            Debug.Log("you is homo");
            //restart
        }
        if (collision.gameObject.CompareTag("ObstacleBlock"))
        {
            //add backwards force
        }
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }

    }
}
