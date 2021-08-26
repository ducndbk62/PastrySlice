using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleRotation1 : MonoBehaviour
{
    public Vector3 rotateSpeed;
    bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (isStop)
            {
                if (Input.GetMouseButton(0))
                {
                    isStop = false;
                }
            }
            else gameObject.transform.Rotate(rotateSpeed);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        isStop = true;
    }
}
