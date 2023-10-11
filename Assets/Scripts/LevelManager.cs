using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel",1);
        for(int i =0; i<buttons.Length ;i++)
        {
            buttons[i].interactable = false;
        }
        for(int i =0;i<unlockedLevel;i++)
        {
            buttons[i].interactable = true;
        }
    }


    public void PlayLevel(int levelId)
    {
        string levelName ="Level" +levelId;
       
        SceneManager.LoadScene(levelName);
    }
}
