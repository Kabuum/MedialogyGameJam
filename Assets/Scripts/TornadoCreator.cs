using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoCreator : MonoBehaviour
{
    public GameObject tornadoPrefab;
    public Camera cam;

    public float yPos;
    public float xPos;
    public float spawnTimer;
    public float spawnTimerMax;
    public float camHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        spawnTimerMax = 2f;
        spawnTimer = spawnTimerMax;
        camHeight = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(cam.transform.position.x-15,0+3);
        yPos = Random.Range(6f,11f);
        xPos = cam.transform.position.x+20;
    }

    void FixedUpdate()
     {
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            Instantiate(tornadoPrefab,new Vector3(xPos,yPos,0),Quaternion.identity);
            spawnTimer = spawnTimerMax;
        }
     }
}
