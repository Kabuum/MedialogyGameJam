using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject mainPlayer;
    public GameObject lion;
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
