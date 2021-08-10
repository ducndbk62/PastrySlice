using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleRotation1 : MonoBehaviour
{
    public Vector3 rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotateSpeed);
    }
}
