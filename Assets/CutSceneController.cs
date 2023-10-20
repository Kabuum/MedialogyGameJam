using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class CutSceneController : MonoBehaviour
{
    bool hasPlayed;
    public GameObject spaceBar;
    public Sprite endSprite;

    bool doneFade = false;

    private void Start()
    {
        if (spaceBar != null)
        {
            spaceBar.SetActive(false);
        }
        if (SceneControl.GetSceneIndex() == 0)
        {
            Debug.Log(SceneControl.GetSceneIndex());

            Animator anim = this.gameObject.GetComponent<Animator>();
            anim.enabled = false;
        }
    }
    void Update()
    {
        if (CheckAnimState() && SceneControl.GetSceneIndex() == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = endSprite;
            gameObject.GetComponent<Animator>().enabled = false;
            SceneControl.LoadNextScene();
        }

        if (hasPlayed != true)
        {
            hasPlayed = CheckAnimState();
        }
        if (hasPlayed == true)
        {
            if (spaceBar != null)
            {
                spaceBar.SetActive(true);
            }
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = endSprite;
            if (spaceBar == null)
            {
                SceneControl.LoadNextScene();
            }
            else if (spaceBar != null && Input.GetKeyDown(KeyCode.Space))
            {
                SceneControl.LoadNextScene();
            }
        }
        if (SceneControl.GetSceneIndex() == 0)
        {
            spaceBar.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Animator anim = gameObject.GetComponent<Animator>();
                anim.enabled = true;
                
            }
        }
        bool CheckAnimState()
        {
            if (gameObject.GetComponent<Animator>() != null)
            {
                Animator anim = gameObject.GetComponent<Animator>();
                AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
                if (info.IsName("EndState"))
                {
                    return hasPlayed = true;
                }
                else { return false; }
            }
            else
            {
                return true;
            }

        }


    }
}

