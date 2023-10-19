using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.MemoryProfiler;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject mainPlayer;
    public GameObject lion;

    public Sprite[] foodbarSprites;
    public SpriteRenderer foodBar;
    //  public GameObject effect;


    void Start()
    {
        // effect.GetComponent<Animator>().Play("Idle");
        // effect.SetActive(false);
        // lion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

       
        int stamina = (int)Mathf.Ceil(lion.GetComponent<PlayerController2D>().playerStamina);
        Debug.Log("int " + stamina);
        if (stamina > 9)
        {
            stamina = 9;
        }
        foodBar.sprite = foodbarSprites[stamina - 1 ];
        /* if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerTransformation(0);
        }
    }

    void PlayerTransformation(int playerStateIndex)
    {
        effect.SetActive(true);

        if (mainPlayer.activeSelf == true)
        {   
            effect.GetComponent<Animator>().Play("Entry");
            mainPlayer.SetActive(false);
            lion.SetActive(true);
        }
        else if (mainPlayer.activeSelf == false)
        {
            effect.GetComponent<Animator>().Play("Entry");
            lion.SetActive(false);
            mainPlayer.SetActive(true);
        }
     
       */
    }




    public void RestartLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }
}
