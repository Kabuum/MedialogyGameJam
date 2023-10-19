using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public int waitTime;
    float time = 0;
    public GameObject btn;

    private void Start()
    {
        btn.SetActive(false);
    }
    void Update()
    {
        time += 1 * Time.deltaTime;
        if (time >= waitTime && btn.activeSelf == false)
        {
            ShowBtn();
        }
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.activeSelf == true)
        {
            Exit();
        }
    }
    void ShowBtn()
    {
        btn.SetActive(true);
    }
    void Exit()
    {
        Application.Quit();
    }
}
