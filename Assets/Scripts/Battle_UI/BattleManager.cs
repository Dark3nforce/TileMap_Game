using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameManager gm;
    
    public BattleMenu currentMenu;
    [Header("Selection")]
    public GameObject SelectionMenu;
    public GameObject SelectionInfo;
    public Text SelectionInfoText;
    public Text fight;
    private string fightSelected = "> Fight";
    private string fightUnSelected = "Fight";
    public Text bag;
    private string bagSelected = "> Bag";
    private string bagUnSelected = "Bag";
    public Text pokemon;
    private string pokemonSelected = "> Pokemon";
    private string pokemonUnSelected = "Pokemon";
    public Text run;
    private string runSelected = "> Run";
    private string runUnSelected = "Run";

    [Header("Moves")]
    public GameObject movesMenu;
    public GameObject movesDetails;
    public Text PP;
    
    public Text pType;
    public Text Move1;
    public Text Move2;
    public Text Move3;
    public Text Move4;
    private string Move1Selected = "> Move 1";
    private string Move1UnSelected = "Move 1";
    private string Move2Selected = "> Move 2";
    private string Move2UnSelected = "Move 2";
    private string Move3Selected = "> Move 3";
    private string Move3UnSelected = "Move 3";
    private string Move4Selected = "> Move 4";
    private string Move4UnSelected = "Move 4";

    [Header("Info")]
    public GameObject InfoMenu;
    public Text InfoText;

    [Header("Misc")]
    public int currentSelection;

    [Header("ATK/DEF Podium")]
    public Transform defencePodium;
    public Transform attackPodium;

    [Header("Misc")]
    public GameObject emptyPoke;


    public Rarity rarityBM;
    private LongGrass lg;

    // Start is called before the first frame update
    void Start()
    {
        lg = GameObject.Find("Testing_Battles").GetComponent<LongGrass>();
        changeMenu(BattleMenu.Selection);

        // loadBattle(rarity);
       currentSelection = 1;
       rarityBM = lg.raritySet;
       Debug.Log(rarityBM);
       loadBattle(rarityBM);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.DownArrow)) {
            if(currentSelection<4) {
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
       if(currentSelection == 0)
       currentSelection = 1;
       

       switch(currentMenu) {
            case BattleMenu.Fight:
                switch(currentSelection) {
                    case 1:
                        Move1.text = Move1Selected; //Arrow here
                        Move2.text = Move2UnSelected;
                        Move3.text = Move3UnSelected;
                        Move4.text = Move4UnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            Debug.Log("Move1 Selected");
                        } else if(Input.GetKeyDown(KeyCode.Escape)) {
                            changeMenu(BattleMenu.Selection);
                        }
                        break;
                    case 2:
                        Move1.text = Move1UnSelected;
                        Move2.text = Move2Selected; //Arrow here
                        Move3.text = Move3UnSelected;
                        Move4.text = Move4UnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            Debug.Log("Move2 Selected");
                        } else if(Input.GetKeyDown(KeyCode.Escape)) {
                            changeMenu(BattleMenu.Selection);
                        }
                        break;
                    case 3:
                        Move1.text = Move1UnSelected;
                        Move2.text = Move2UnSelected;
                        Move3.text = Move3Selected; //Arrow here
                        Move4.text = Move4UnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            Debug.Log("Move3 Selected");
                        } else if(Input.GetKeyDown(KeyCode.Escape)) {
                            changeMenu(BattleMenu.Selection);
                        }
                        break;
                    case 4:
                        Move1.text = Move1UnSelected;
                        Move2.text = Move2UnSelected;
                        Move3.text = Move3UnSelected;
                        Move4.text = Move4Selected; //Arrow here
                        if(Input.GetKeyDown(KeyCode.Return)){
                            Debug.Log("Move4 Selected");
                        } else if(Input.GetKeyDown(KeyCode.Escape)) {
                            changeMenu(BattleMenu.Selection);
                        }
                        break;               
                }
                break;
            case BattleMenu.Selection:
                switch(currentSelection) {
                    case 1:
                        // Debug.Log("can fight");
                        fight.text = fightSelected; //Arrow here
                        bag.text = bagUnSelected;
                        pokemon.text = pokemonUnSelected;
                        run.text = runUnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            changeMenu(BattleMenu.Fight);
                        }
                        break;
                    case 2:
                        // Debug.Log("can bag");
                        fight.text = fightUnSelected;
                        bag.text = bagSelected; //Arrow here
                        pokemon.text = pokemonUnSelected;
                        run.text = runUnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            // changeMenu(BattleMenu.Bag);
                            Debug.Log("can go to bag");
                        }
                        break;
                    case 3:
                        // Debug.Log("can pokemon");
                        fight.text = fightUnSelected;
                        bag.text = bagUnSelected;
                        pokemon.text = pokemonSelected; //Arrow here
                        run.text = runUnSelected;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            // changeMenu(BattleMenu.Pokemon);
                            Debug.Log("can change pokemon");
                        }
                        break;
                    case 4:
                        // Debug.Log("can run");
                        fight.text = fightUnSelected;
                        bag.text = bagUnSelected;
                        pokemon.text = pokemonUnSelected;
                        run.text = runSelected; //Arrow here
                        // gm.ExitBattle();
                        if(Input.GetKeyDown(KeyCode.Return)){
                            gm.ExitBattle();
                        }
                        break;               
                }
                break;    
       }
    //    if(Input.GetKeyDown(KeyCode.Return)) {
    //         if(currentSelection==1) {
    //             Debug.Log("Fight Selected");
    //             // gm.ExitBattle();
    //             changeMenu(BattleMenu.Fight);
    //         } else if(currentSelection==2) {
    //             Debug.Log("Bag Selected");
    //             changeMenu(BattleMenu.Bag);
    //             // gm.ExitBattle();
    //         } else if(currentSelection==3){
    //             Debug.Log("Pokemon Selected");
    //             changeMenu(BattleMenu.Pokemon);
    //             // gm.ExitBattle();
    //         } else if(currentSelection==4){
    //             Debug.Log("Run Selected");
    //             gm.ExitBattle();
    //         }
    //    }
    }

    public void changeMenu(BattleMenu m) {
        currentMenu = m;
        currentSelection = 1;
        switch(m) {
            case BattleMenu.Selection:
                SelectionMenu.gameObject.SetActive(true);
                SelectionInfo.gameObject.SetActive(true);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                InfoMenu.gameObject.SetActive(false);
                break;
            case BattleMenu.Fight:
                SelectionMenu.gameObject.SetActive(false);
                SelectionInfo.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(true);
                movesDetails.gameObject.SetActive(true);
                InfoMenu.gameObject.SetActive(false);
                break;    
            case BattleMenu.Info:
                SelectionMenu.gameObject.SetActive(true);
                SelectionInfo.gameObject.SetActive(true);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                InfoMenu.gameObject.SetActive(true);
                break;    
        }
    }


    public void loadBattle(Rarity rarity) {
        // public void loadBattle() {
        changeMenu(BattleMenu.Selection);
        BasePokemon battlePokemon = gm.GetRandomPokemonFromList(gm.GetPokemonByRarity(rarity));
        // BasePokemon battlePokemon = gm.GetRandomPokemonFromList(gm.GetPokemonByRarity(Rarity.Common));

        Debug.Log(battlePokemon.name);
        GameObject dPoke = Instantiate(emptyPoke, defencePodium.transform.position, Quaternion.identity) as GameObject;

        dPoke.transform.parent = defencePodium;

        BasePokemon tempPoke = dPoke.AddComponent<BasePokemon>() as BasePokemon;
        tempPoke.AddMember(battlePokemon);

        dPoke.GetComponent<SpriteRenderer>().sprite = battlePokemon.image;

        // changeMenu(BattleMenu.Selection);
    }
}
public enum BattleMenu {
    Selection,
    Pokemon,
    Bag,
    Fight,
    Info
}
