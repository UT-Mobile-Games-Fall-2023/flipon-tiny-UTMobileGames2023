using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapUIScript : MonoBehaviour
{  
    // private Button levelOneButton;
    public int numStartingLines;
  public string currentLevelName;
    public bool wonLastGame;
    GameObject canvas;

    // objectives to change
    public int score;
    public int combos;
    public int fourCombos;
    public int powerUps;
    // need crystals one 

    public static MapUIScript mapInstance;

    // method that loads Title Screen Scene on button click 
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("TitleScreen");
        Debug.Log("GO TO MAIN MENU");
    }

    // method that loads the Game Scene on button click and sets a variable for the game settings
    public void PlayLevel(int levelNum)
    {
        /*
        if (levelNum == 1)
        {
            numStartingLines = 1;
        }
        else if (levelNum == 2)
        {
            numStartingLines = 4;
        }
        */ 
        // mapInstance.numStartingLines = numStartingLines;
        mapInstance.currentLevelName = "Level" + levelNum.ToString();
        SceneManager.LoadSceneAsync("Game");
        Debug.Log("PLAY GAME");
    }

    public void Awake()
    {
        // levelOneButton = GameObject.Find("PlayLevel1Button").GetComponent<Button>();
        // levelOneButton.onClick.AddListener(() => PlayLevel(1));

        // get the canvas object so we can reset it to Active when the scene is loaded
        canvas = GameObject.FindWithTag("Canvas");

        if (canvas != null)
        {
            Debug.Log("canvas was found"); // WORKING
            canvas.SetActive(true); // NOT WORKING (going to scene doesn't render the map canvas)

            // note: canvas has to be child of mapManager so that the reference to the button is not destroyed
        }

        // prevents duplicate mapManagers from spawning when running DontDestroyOnLoad()
        if (mapInstance != null)
        {
            // delete itself if it's a duplicate 
            Destroy(gameObject);
            return;
        }
        else
        {
            mapInstance = this;
            // don't destroy the mapManager object so that we can keep info from the level buttons
            DontDestroyOnLoad(gameObject);

        }

        
    }
}
