using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;
    public static Vector2 lastCheckPointPos = new Vector2(-4, 0);
    public static bool isGameOver;
    public static bool isGameComplete;
    public GameObject gameOverPanel;
    public GameObject LevelCompletePanel;
   

    private void Awake()
    {
      isGameOver = false;
      isGameComplete = false;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // Instantiate the player and store its transform
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
    
    }
    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();

        if (isGameOver)
        {
          gameOverPanel.SetActive(true);
        }

        if (isGameComplete)
        {
          LevelCompletePanel.SetActive(true);
        }
    }

    
}
