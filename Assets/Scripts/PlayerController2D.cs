using UnityEngine;
using UnityEngine.Playables;

public class PlayerController2D : MonoBehaviour
{  //Future work. Animals should be made into classes
    public GameObject gameManager;
    public float playerStamina, maxStamina = 8;
    public Rigidbody2D rb;


    [Header("Eagle")]
    public float moveSpeedEagle = 10;
    public float maxSpeedEagle = 5;


    public float flap = 20f;
    public Animator animEagle;

    [Header("Lion")]
    public float moveSpeedLion = 10;
    public float jumpForce;

    public float staminaDrainLion;

    int jumps = 2;

    bool isLion = true;

    public GameObject keyboardTutorial;

    public AudioSource jumpSound;
    public AudioSource hurtSound;

    public GameObject poofEffect;



    void Start()
    {
        isLion = true;
        keyboardTutorial.SetActive(false);
        poofEffect.SetActive(false);
    }
    void Update()
    {
        playerStamina -= 1 * Time.deltaTime;
        if (playerStamina > maxStamina)
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
            jumps--;
            jumpSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isLion == false)
        {
            rb.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
            jumpSound.Play();
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
        poofEffect.SetActive(false);
        poofEffect.SetActive(true);
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
        
        playerStamina += 10;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RockTutorialTriggerZone"))
        {
            keyboardTutorial.SetActive(true);
            Destroy(keyboardTutorial, 1);
        }
        if (collision.gameObject.CompareTag("FoodPickup"))
        {
            EatFood();
            collision.gameObject.GetComponent<FoodPickup>().Eaten();
        }
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
        if (collision.gameObject.CompareTag("ObstacleDanger"))
        {
            gameManager.GetComponent<GameManager>().RestartLevel();

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerStamina--;
        }
    } 
}
