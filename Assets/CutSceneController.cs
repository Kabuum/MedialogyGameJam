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
        else if (Input.GetKeyDown(KeyCode.Space) && CheckAnimState())
        {
            SceneControl.LoadNextScene();
        }
    }


    bool CheckAnimState()
    {
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetBool("hasPlayed", true);
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("EndState"))
        {
            return hasPlayed = true;
        }
        else { return false; }
    }
}


