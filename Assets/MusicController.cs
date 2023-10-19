using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("Hurt sfx");
        if (g!= null)
        {
            Destroy(g);
              
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
