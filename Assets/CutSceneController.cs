using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class CutSceneController : MonoBehaviour
{
    bool hasPlayed;
    public GameObject spaceBar;

    private void Start()
    {
        spaceBar.SetActive(false);
    }
    void Update()
    {
        if (CheckAnimState())
        {
            spaceBar.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && CheckAnimState())
        {
            SceneControl.LoadNextScene();
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
        } else
        {
            return true;
        }
       
    }
}


