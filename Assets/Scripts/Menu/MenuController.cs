using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuController : MonoBehaviour
{

    public GameObject inventory;
    public Text inventoryText;
    public GameObject menuUI;
    private int currentSelection;
    public Text PokeDexTxt;
    private string PokeDexSelected = "> PokeDex";
    private string PokeDexUnSelected = "PokeDex";
    public Text PokeTxt;
    private string PokeSelected = "> Pokemon";
    private string PokeUnSelected = "Pokemon";
    public Text BagTxt;
    private string BagSelected = "> Bag";
    private string BagUnSelected = "Bag";
    public Text CardTxt;
    private string CardSelected = "> TrainerCard";
    private string CardUnSelected = "TrainerCard";
    public Text SaveTxt;
    private string SaveSelected = "> Save";
    private string SaveUnSelected = "Save";
    public Text SettingsTxt;
    private string SetSelected = "> Settings";
    private string SetUnSelected = "Settings";


    private GameManager gm;

    
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        currentSelection = 1;

    }

    // Update is called once per frame
    void Update()
    {
       

        if (menuUI.activeInHierarchy) {
            if(Input.GetKeyDown(KeyCode.DownArrow)) {
                if(currentSelection<6) {
                    currentSelection++;
                    Debug.Log(currentSelection);
                }
            } 
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                if(currentSelection>0) {
                    if(currentSelection == 0)
                        currentSelection = 1;
                    else
                        currentSelection--;
                    Debug.Log(currentSelection);
                }
            }
            if(Input.GetKeyDown(KeyCode.E)) {
                gm.toggleMenuUI();
                
            }

            switch(currentSelection) {
                    case 1:
                        PokeDexTxt.text = PokeDexSelected; //Arrow here
                        PokeTxt.text = PokeUnSelected;
                        BagTxt.text = BagUnSelected;
                        CardTxt.text = CardUnSelected;
                        SaveTxt.text = SaveUnSelected;
                        SettingsTxt.text = SetUnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            goToPokeDex();
                        } 
                        break;
                    case 2:
                        PokeDexTxt.text = PokeDexUnSelected; 
                        PokeTxt.text = PokeSelected;
                        BagTxt.text = BagUnSelected;
                        CardTxt.text = CardUnSelected;
                        SaveTxt.text = SaveUnSelected;
                        SettingsTxt.text = SetUnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            goToPokeParty();
                        } 
                        break;
                    case 3:
                        PokeDexTxt.text = PokeDexUnSelected; 
                        PokeTxt.text = PokeUnSelected;
                        BagTxt.text = BagSelected;
                        CardTxt.text = CardUnSelected;
                        SaveTxt.text = SaveUnSelected;
                        SettingsTxt.text = SetUnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            goToBag();
                        } 
                        break;
                    case 4:
                        PokeDexTxt.text = PokeDexUnSelected; 
                        PokeTxt.text = PokeUnSelected;
                        BagTxt.text = BagUnSelected;
                        CardTxt.text = CardSelected;
                        SaveTxt.text = SaveUnSelected;
                        SettingsTxt.text = SetUnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            goToTrainerCard();
                        } 
                        break;
                    case 5:
                        PokeDexTxt.text = PokeDexUnSelected; 
                        PokeTxt.text = PokeUnSelected;
                        BagTxt.text = BagUnSelected;
                        CardTxt.text = CardUnSelected;
                        SaveTxt.text = SaveSelected;
                        SettingsTxt.text = SetUnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            saveState();
                        } 
                        break;             
                    case 6:
                        PokeDexTxt.text = PokeDexUnSelected; 
                        PokeTxt.text = PokeUnSelected;
                        BagTxt.text = BagUnSelected;
                        CardTxt.text = CardUnSelected;
                        SaveTxt.text = SaveUnSelected;
                        SettingsTxt.text = SetSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            goToSettings();
                        } 
                        break;          
                }
        }

    }

    public void goToPokeDex() {
        Debug.Log("Go to PokeDex");
    }
    public void goToPokeParty() {
        Debug.Log("Go to Party");
    }
    public void goToBag() {
        inventory.SetActive(true);
        Debug.Log("Go to Bag");

    }
    public void goToTrainerCard() {
        Debug.Log("Go to TranerCard");
    }
    public void saveState() {
        Debug.Log("Go to Save");
    }
    public void goToSettings() {
        Debug.Log("Go to Settings");
    }

}
