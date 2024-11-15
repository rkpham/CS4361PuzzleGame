using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timeToWait = 3.0f;
    MeshRenderer renderer;
    Rigidbody  rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        if(Time.time > timeToWait)
        {
            //Debug.Log("3 seconds has elasped");
            renderer.enabled = true;
            rigidbody.useGravity = true;
        }
    }
}
