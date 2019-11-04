using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameManager gm;
    public Player player;
    
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
    public string Move1CurPP;
    public string Move1MaxPP;
    public string Move1PPDisplay;
    public string Move1Type;
    public Text Move2;
    public string Move2CurPP;
    public string Move2MaxPP;
    public string Move2PPDisplay;
    public string Move2Type;
    public Text Move3;
    public string Move3CurPP;
    public string Move3MaxPP;
    public string Move3PPDisplay;
    public string Move3Type;
    public Text Move4;
    public string Move4CurPP;
    public string Move4MaxPP;
    public string Move4PPDisplay;
    public string Move4Type;
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
        player = GameObject.Find("Player").GetComponent<Player>();
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
       if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            if(currentSelection<4) {
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
                        //setting move1 stats
                        PP.text = Move1PPDisplay;
                        pType.text = Move1Type;
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
                        //setting move2 stats
                        PP.text = Move2PPDisplay;
                        pType.text = Move2Type;
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
                        //setting move3 stats
                        PP.text = Move3PPDisplay;
                        pType.text = Move3Type;
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
                        //setting move4 stats
                        PP.text = Move4PPDisplay;
                        pType.text = Move4Type;
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

        BasePokemon tempDefPoke = dPoke.AddComponent<BasePokemon>() as BasePokemon;
        tempDefPoke.AddMember(battlePokemon);

        dPoke.GetComponent<SpriteRenderer>().sprite = battlePokemon.image;

        //Setting players pokemon to attack podium
        GameObject aPoke = Instantiate(emptyPoke, attackPodium.transform.position, Quaternion.identity) as GameObject;
        aPoke.transform.parent = attackPodium;

        BasePokemon tempAtkPoke = aPoke.AddComponent<BasePokemon>() as BasePokemon;
        //checking player pokemon's health
        //if health is zero,check next and so on
        //if health is not zero, deploy pokemon

        for(int i=0; i<player.ownedPokemon.Count-1;i++) {
            if(healthRemaining(i)) {
                tempAtkPoke.AddMember(player.ownedPokemon[i].pokemon);
                aPoke.GetComponent<SpriteRenderer>().sprite = player.ownedPokemon[i].pokemon.image;
                // player.ownedPokemon[i].moves
                // Move1.text = ;

                //Move1
                if(player.ownedPokemon[i].moves[1].Name != null) {
                    Move1.text = player.ownedPokemon[i].moves[0].Name;
                    Move1CurPP = player.ownedPokemon[i].moves[0].currentPP.ToString();
                    Move1MaxPP = player.ownedPokemon[i].moves[0].PP.ToString();
                    Move1Type = player.ownedPokemon[i].moves[0].moveType.ToString();
                    Move1PPDisplay = Move1CurPP + "/" + Move1MaxPP;
                    Move1Selected = "> " + Move1.text;
                    Move1UnSelected = Move1.text;
                }
                //Move2
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[1].Name != null) {
                    Move2.text = player.ownedPokemon[i].moves[1].Name;
                    Move2CurPP = player.ownedPokemon[i].moves[1].currentPP.ToString();
                    Move2MaxPP = player.ownedPokemon[i].moves[1].PP.ToString();
                    Move2Type = player.ownedPokemon[i].moves[1].moveType.ToString();
                    Move2PPDisplay = Move2CurPP + "/" + Move2MaxPP;
                    Move2Selected = "> " + Move2.text;
                    Move2UnSelected = Move2.text;
                }
                //Move3
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[1].Name != null) {
                    Move3.text = player.ownedPokemon[i].moves[2].Name;
                    Move3CurPP = player.ownedPokemon[i].moves[2].currentPP.ToString();
                    Move3MaxPP = player.ownedPokemon[i].moves[2].PP.ToString();
                    Move3Type = player.ownedPokemon[i].moves[2].moveType.ToString();
                    Move3PPDisplay = Move3CurPP + "/" + Move3MaxPP;
                    Move3Selected = "> " + Move3.text;
                    Move3UnSelected = Move3.text;
                }
                //Move4
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[1].Name != null) {
                    Move4.text = player.ownedPokemon[i].moves[3].Name;
                    Move4CurPP = player.ownedPokemon[i].moves[3].currentPP.ToString();
                    Move4MaxPP = player.ownedPokemon[i].moves[3].PP.ToString();
                    Move4Type = player.ownedPokemon[i].moves[3].moveType.ToString();
                    Move4PPDisplay = Move4CurPP + "/" + Move4MaxPP;
                    Move4Selected = "> " + Move4.text;
                    Move4UnSelected = Move4.text;
                }
            }
        }
        



    }
    public bool healthRemaining(int i) {
        if(player.ownedPokemon[i].pokemon.HP == 0)
            return false;
        else 
            return true;    
    }
}
public enum BattleMenu {
    Selection,
    Pokemon,
    Bag,
    Fight,
    Info
}
