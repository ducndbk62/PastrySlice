using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSlicing : MonoBehaviour
{
    public GameObject slicedObject;
    public int coin;
    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Blade")
        {            
            Instantiate(slicedObject, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform.parent);
            Destroy(gameObject);
            gameController.GetComponent<GameController>().AddLevelCoins(coin);           
        }
    }
}