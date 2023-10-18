using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngineInternal;

public class PlayerController2D : MonoBehaviour
{  //Future work. Animals should be made into classes
    public GameObject gameManager;
    public float playerStamina;

    [Header("Eagle")]
    public float moveSpeedEagle = 10;
    public float staminaDrainEagle;
    Camera cam;
    float camX;
    public float maxSpeedEagle = 5;
    public Rigidbody2D rbEagle;
    public float flap = 20f;
    public Animator animEagle;


    [Header("Lion")]
    public float moveSpeedLion = 10;
    public float jumpForce;
    public float staminaDrainLion;
    public Rigidbody2D rbLion;







    public GameObject eagle;
    public GameObject lion;

    bool isGrounded = true;

    int jumps = 2;

    bool isLion = true;


    //eagle part


    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        if (this.gameObject.name == "Eagle")
        {
            isLion = false;
        }
        else if (this.gameObject.name == "Lion")
        {
            isLion = true;
        }

        eagle.SetActive(false);
    }

    void Update()
    {

        if (playerStamina <= 0)
        {
            gameManager.GetComponent<GameManager>().RestartLevel();
        }
        #region LionControls
        if (jumps <= 0 && isLion == true)
        {
            SwapAnimal(lion, eagle);

        }
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0 && isLion)
        {
            rbLion.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
            jumps--;
        }
        if (Input.GetKey(KeyCode.A) && isLion)
        {
            float angle = transform.eulerAngles.y;
            if (angle != 180)
            {
                transform.Rotate(0, 180, 0);
            }
            playerStamina -= 1 * Time.deltaTime;
            transform.Translate(Vector2.right * moveSpeedLion * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && isLion)
        {
            float angle = transform.eulerAngles.y;
            Debug.Log(angle);
            if (angle == 180)
            {
                transform.Rotate(0, -180, 0);
            }
            playerStamina -= 1 * Time.deltaTime;
            transform.Translate(Vector2.right * moveSpeedLion * Time.deltaTime);
        }
        #endregion

        #region EagleControls

        if (Input.GetKeyDown(KeyCode.Space) && !isLion)
        {
            rbLion.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
            animEagle.Play("eagleAnimation");
        }

        if ((rbEagle.velocity.magnitude < maxSpeedEagle * -1) && !isLion)
        {
            rbEagle.velocity = Vector2.ClampMagnitude(rbEagle.velocity, maxSpeedEagle * -1);
        }
        if ((rbEagle.velocity.magnitude > maxSpeedEagle) && !isLion)
        {
            rbEagle.velocity = Vector2.ClampMagnitude(rbEagle.velocity, maxSpeedEagle);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isLion)
        {
            transform.Translate(Vector2.left * (moveSpeedEagle * Time.deltaTime));
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !isLion)
        {
            transform.Translate(Vector2.right * (moveSpeedEagle * Time.deltaTime));
            GetComponent<SpriteRenderer>().flipX = false;
        }
        #endregion
    }

    public void SwapAnimal(GameObject currentAnimal, GameObject nextAnimal)
    {
        currentAnimal.SetActive(false);
        Debug.Log(nextAnimal);
        nextAnimal.SetActive(true);
    }
    public void EatFood()
    {
        playerStamina += 10;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObstacleDanger"))
        {
            gameManager.GetComponent<GameManager>().RestartLevel();
            //restart
        }
        if (collision.gameObject.CompareTag("ObstacleBlock"))
        {
            //add backwards force
        }
        if (collision.gameObject.CompareTag("Ground") && isLion == true)
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Ground") && isLion == false)
        {
            isGrounded = true;
            isLion = true;
        }

    }
}
