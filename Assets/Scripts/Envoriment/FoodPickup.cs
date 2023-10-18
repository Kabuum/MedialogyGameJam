using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public float staminaValue;
    public ParticleSystem eatEffect;

    public GameObject lionPlayer;


    private void Start()
    {
       
    }
    void LionEat()
    {
        //eatEffect.Play();
        //Destroy(eatEffect, 4);
        Destroy(this.gameObject);
        lionPlayer.GetComponent<PlayerController2D>().EatFood();


    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lion"))
        {
            LionEat();
        }
    }


}
