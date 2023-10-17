using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10;
    public float jump;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));

        }
        if (Input.GetKey(KeyCode.A))
        {
            float angle = transform.eulerAngles.y;
            if (angle != 180)
            {
                transform.Rotate(0, 180, 0);
            }

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



            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}
