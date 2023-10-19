using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngineInternal;

public class PlayerController2D : MonoBehaviour
{  //Future work. Animals should be made into classes
    public GameObject gameManager;
    public float playerStamina, maxStamina = 8;
    public Rigidbody2D rb;


    [Header("Eagle")]
    public float moveSpeedEagle = 10;
    public float staminaDrainEagle;
    Camera cam;
    float camX;
    public float maxSpeedEagle = 5;


    public float flap = 20f;
    public Animator animEagle;

    [Header("Lion")]
    public float moveSpeedLion = 10;
    public float jumpForce;
    public float staminaDrainLion;

    public Sprite lionSprite;
    public Sprite eagleSprite;

    bool isGrounded = true;
    int jumps = 2;

    bool isLion = true;

    void Start()
    {
        isLion = true;
        cam = Camera.main;
    }
    void Update()
    {
        Debug.Log(isLion);
        Debug.Log(jumps);
        playerStamina -= 1 * Time.deltaTime;
        if (playerStamina < maxStamina)
        {
            playerStamina = maxStamina;
        }

        if (playerStamina <= 0)
        {
            gameManager.GetComponent<GameManager>().RestartLevel();
        }
        if (jumps <= 0 && isLion == true)
        {
           
            AnimalSwap();
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0 && isLion)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
            jumps--;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isLion == false)
        {
            rb.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
            //Afspil et flap
        }
        if ((rb.velocity.magnitude < maxSpeedEagle * -1) && isLion == false)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeedEagle * -1);
        }
        if ((rb.velocity.magnitude > maxSpeedEagle) && isLion == false)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeedEagle);
        }
    }
    public void AnimalSwap()
    {
        if (isLion == false)
        {
            this.gameObject.GetComponent<Animator>().SetBool("Grounded", true);
            this.gameObject.GetComponent<Animator>().SetBool("Eagle", false);
            isLion = true;
        }
        else if (isLion == true)
        {
            this.gameObject.GetComponent<Animator>().SetBool("Eagle", true);
            this.gameObject.GetComponent<Animator>().SetBool("Grounded", false);
            isLion = false;
        }
    }
    public void EatFood()
    {
        // Tilf�j pile der viser ned til maden
        playerStamina += 10;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground") && isLion == true)
        {
            jumps = 2;
        }
        else if (collision.gameObject.CompareTag("Ground") && isLion == false)
        {
           
            jumps = 2;
            AnimalSwap();
        }
    }
}
