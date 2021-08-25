using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject gameFinish;
    public GameObject gameover;
    public GameObject gameShop;
    public GameObject gameSettings;
    public GameObject restartButton;

    public Text textLevelCoins;
    public Text textTotalCoins;

    private int levelCoins;
    private int totalCoins;

    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        scene = SceneManager.GetActiveScene();
        totalCoins = PlayerPrefs.GetInt("TotalCoins");
        textTotalCoins.text = totalCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textLevelCoins.text = levelCoins.ToString();
    }

    public void Play()
    {
        textLevelCoins.gameObject.SetActive(true);
        gameMenu.SetActive(false);
        restartButton.SetActive(true);
        Time.timeScale = 1.1f;
    }

    public void Restart()
    {
        SetTotalCoins();
        SceneManager.LoadScene(scene.buildIndex);
        restartButton.SetActive(false);
    }

    public void NextLevel()
    {
        SetTotalCoins();
        int nextLevel = scene.buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
    }



    public void AddLevelCoins(int coin)
    {
        levelCoins += coin;
    }

    public void MultipleLevelCoins(int multiple)
    {
        levelCoins *= multiple;
    }

    public void ToShop()
    {
        gameMenu.SetActive(false);
        gameShop.SetActive(true);
    }

    public void BackToMenu()
    {
        gameShop.SetActive(false);
        gameSettings.SetActive(false);
        gameMenu.SetActive(true);
    }

    public void ToSettings()
    {
        gameMenu.SetActive(false);
        gameSettings.SetActive(true);
    }

    void SetTotalCoins()
    {
        totalCoins += levelCoins;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        textTotalCoins.text = totalCoins.ToString();
    }
}
