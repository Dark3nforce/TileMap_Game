using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartMenuController : MonoBehaviour
{
    public GameObject startMenuUI;
    [Header("Options/Choices Panel")]
    public Image continuePanel;
    public Image newGamePanel;
    public Image optionsPanel;

    [Header("Options/Choices Text")]
    public Text continueTxt;
    public Text newGameTxt;
    public Text optionsTxt;

    [Header("ContinuePaneleInfo")]
    public Text playerNameTxt;
    public Text timePlayedTxt;
    public Text badgesOwnedTxt;
    public Text pokemonOwnedTxt;

    //Selected/Unselected
    private string continueSelected = "> CONTINUE";
    private string continueUnSelected = "CONTINUE";
    private string newGameSelected = "> NEW GAME";
    private string newGameUnSelected = "NEW GAME";
    private string optionsSelected = "> OPTIONS";
    private string optionsUnSelected = "OPTIONS";

    // [Header("ContinuePaneleInfo")]
    //script references
    GameManager gameManager;
    Player player;

    //Misc.
    private int currentSelection;
    private Color tempColor;
    private Color normalColor;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        player = GetComponent<Player>();
        continuePanel = GameObject.Find("ContGamePanel").GetComponent<Image>();
        newGamePanel = GameObject.Find("NewGamePanel").GetComponent<Image>();
        optionsPanel = GameObject.Find("OptionsPanel").GetComponent<Image>();
        tempColor = continuePanel.color;
        normalColor = continuePanel.color;
        tempColor.a = 255f;
        currentSelection = 1;

        //setting Continue panel text to correct information
        playerNameTxt.text = "test";
        timePlayedTxt.text = "test";
        badgesOwnedTxt.text = "test";
        pokemonOwnedTxt.text = "test";
    }

    // Update is called once per frame
    void Update()
    {
        if (startMenuUI.activeInHierarchy) {
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
                if(currentSelection<3) {
                    currentSelection++;
                    Debug.Log(currentSelection);
                }
            } 
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
                if(currentSelection>0) {
                    if(currentSelection == 0)
                        currentSelection = 1;
                    else
                        currentSelection--;
                    Debug.Log(currentSelection);
                }
            }
            // if(Input.GetKeyDown(KeyCode.E)) {
            //     gameManager.toggleMenuUI();
                
            // }

            switch(currentSelection) {
                    case 1:
                        continueTxt.text = continueSelected;
                        continuePanel.color = tempColor;

                        newGameTxt.text = newGameUnSelected;
                        newGamePanel.color = normalColor;

                        optionsTxt.text = optionsUnSelected;
                        optionsPanel.color = normalColor;

                        if(Input.GetKeyDown(KeyCode.Return)){
                            // continueGame();
                            Debug.Log("Continue Game Selected");
                        } 
                        break;
                    case 2:
                        continueTxt.text = continueUnSelected;
                        continuePanel.color = normalColor;

                        newGameTxt.text = newGameSelected;
                        newGamePanel.color = tempColor;

                        optionsTxt.text = optionsUnSelected;
                        optionsPanel.color = normalColor;

                        if(Input.GetKeyDown(KeyCode.Return)){
                            newGame();
                        } 
                        break;
                    case 3:
                        continueTxt.text = continueUnSelected;
                        continuePanel.color = normalColor;

                        newGameTxt.text = newGameUnSelected;
                        newGamePanel.color = normalColor;

                        optionsTxt.text = optionsSelected;
                        optionsPanel.color = tempColor;

                        if(Input.GetKeyDown(KeyCode.Return)){
                            options();
                        } 
                        break;
                }
        }   
    }

    void continueGame() {
        player.LoadPlayer();
    }
    void newGame() {
        Debug.Log("New Game Selected");
    }
    void options() {
        Debug.Log("Options Selected");
    }
}
