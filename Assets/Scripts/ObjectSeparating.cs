using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSeparating : MonoBehaviour
{
    public GameObject half1;
    public GameObject half2;
    Rigidbody rb_Half1;
    Rigidbody rb_Half2;

    public Vector3 force = new Vector3(0, 0, 200);

    // Start is called before the first frame update
    void Start()
    {
        rb_Half1 = half1.GetComponent<Rigidbody>();
        rb_Half2 = half2.GetComponent<Rigidbody>();
        rb_Half1.AddForce(force);
        rb_Half2.AddForce(-force);
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}
