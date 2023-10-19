using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public GameObject eatEffect;
    public GameObject foodObject;
    public void Eaten()
    {
        
        Destroy(foodObject);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        eatEffect.SetActive(true);
        //spil lydeffect
    }
}
