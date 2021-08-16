using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleRotation1 : MonoBehaviour
{
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            if (rotateSpeed == 0)
            {
                if (Input.GetMouseButton(0))
                {
                    rotateSpeed = 2;
                }
            } else gameObject.transform.Rotate(new Vector3(0, 0, rotateSpeed));
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        rotateSpeed = 0;
    }
}
