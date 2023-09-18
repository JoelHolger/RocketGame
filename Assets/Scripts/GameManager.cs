using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GlobalGameManager = null; // can be called "Instance"

    public int CurrentLevel = -1337; //cuz why not, start on nothing
    private int StartingLevel = 1; //Cuz we gonna start in the menu (scene 1)
    private int MenuIndex = 0;


    public void Awake()
    {
        if (GameManager.GlobalGameManager == null)
        {
            GlobalGameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && CurrentLevel != MenuIndex)
        {
            ToMenu();
        }
    }

    public void OnStartAtFirstLevel()
    {
        CurrentLevel = StartingLevel;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void OnLoadLevel(int aLevelBuildIndexToLoad)
    {
        CurrentLevel = aLevelBuildIndexToLoad;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void ToMenu()
    {
        CurrentLevel = MenuIndex;
        SceneManager.LoadScene(CurrentLevel);
    }
}
