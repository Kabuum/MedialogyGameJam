using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public GameObject eatEffect;

    public GameObject foodObject;

    private void Start()
    {

    }
    public void Eaten()
    {
        Debug.Log("Hello");
        Destroy(foodObject);
        
        eatEffect.SetActive(true);
        //spil lydeffect
    }
}
