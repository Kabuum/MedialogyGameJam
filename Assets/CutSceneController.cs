using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CutSceneController : MonoBehaviour
{
    bool hasPlayed;
    public GameObject spaceBar;
    public Sprite endSprite;

    private void Start()
    {
        if (spaceBar != null)
        {
            spaceBar.SetActive(false);
        }
    }
    void Update()
    {
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


