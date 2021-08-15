using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyExplosion : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
