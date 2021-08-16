using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinController : MonoBehaviour
{
    public int price;
    public GameObject imgPrice;
    public Text textTotalCoins;
    public GameObject knife;
    //public CinemachineVirtualCamera camera; 

    private int totalCoins;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(gameObject.name, 0); 
        if (PlayerPrefs.GetInt(gameObject.name) == 1) imgPrice.SetActive(false);

        totalCoins = PlayerPrefs.GetInt("TotalCoins");
        textTotalCoins.text = totalCoins.ToString();
    }

    // Update is called once per frame
    public void OnClickSkin()
    {
        if (PlayerPrefs.GetInt(gameObject.name) == 0) //neu player chua so huu skin nay
        {
            if (totalCoins >= price)
            {
                totalCoins -= price;
                imgPrice.SetActive(false);
                PlayerPrefs.SetInt("TotalCoins", totalCoins);
                PlayerPrefs.SetInt(gameObject.name, 1); //player da so huu skin nay
                textTotalCoins.text = totalCoins.ToString();
            }
        }
        GameObject currentKnife = GameObject.FindWithTag("Knife");
        Instantiate(knife, currentKnife.transform.position, Quaternion.Euler(new Vector3(0, 0, -60)));
        Destroy(currentKnife);
        //camera.Follow = knife.transform;
        //camera.LookAt = knife.transform;
    }
}
