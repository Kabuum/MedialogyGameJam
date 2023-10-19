using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float smoothtime = 0.3f;
    public Vector3 velocity = Vector3.zero;

    private float YClamp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        YClamp=Mathf.Clamp(target.position.y, 2.8125f, 8.45f);
        Vector3 targetPosition = new Vector3(target.position.x+3f, YClamp, -2f);//target.TransformPoint(new Vector3(5f,2.8125f, -1f));
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothtime);
    }
}
