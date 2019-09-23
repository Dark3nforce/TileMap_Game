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
    private string fightT;
    public Text bag;
    private string bagT;
    public Text pokemon;
    private string pokemonT;
    public Text run;
    private string runT;

    [Header("Moves")]
    public GameObject movesMenu;
    public GameObject movesDetails;
    public Text PP;
    
    public Text pType;
    public Text Move1;
    private string Move1T;
    public Text Move2;
    private string Move2T;
    public Text Move3;
    private string Move3T;
    public Text Move4;
    private string Move4T;

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
       fightT = fight.text;
       bagT = bag.text; 
       pokemonT = pokemon.text;
       runT = run.text;

       Move1T = Move1.text;
       Move2T = Move2.text;
       Move3T = Move3.text;
       Move4T = Move4.text;
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
                        Move1T = "> " + Move1.text;
                        Move2T = Move2.text;
                        Move3T = Move3.text;
                        Move4T = Move4.text;
                        break;
                    case 2:
                        Move1T = Move1.text;
                        Move2T = "> " + Move2.text;
                        Move3T = Move3.text;
                        Move4T = Move4.text;
                        break;
                    case 3:
                        Move1T = Move1.text;
                        Move2T = Move2.text;
                        Move3T = "> " + Move3.text;
                        Move4T = Move4.text;
                        break;
                    case 4:
                        Move1T = Move1.text;
                        Move2T = Move2.text;
                        Move3T = Move3.text;
                        Move4T = "> " + Move4.text;
                        break;               
                }
                break;
            case BattleMenu.Selection:
                switch(currentSelection) {
                    case 1:
                        // Debug.Log("can fight");
                        fightT = "> " + fight.text;
                        bagT = bag.text;
                        pokemonT = pokemon.text;
                        runT = run.text;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            changeMenu(BattleMenu.Fight);
                        }
                        break;
                    case 2:
                        // Debug.Log("can bag");
                        fightT = fight.text;
                        bagT = "> " + bag.text;
                        pokemonT = pokemon.text;
                        runT = run.text;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            changeMenu(BattleMenu.Bag);
                        }
                        break;
                    case 3:
                        // Debug.Log("can pokemon");
                        fightT = fight.text;
                        bagT = bag.text;
                        pokemonT = "> " + pokemon.text;
                        runT = run.text;
                        if(Input.GetKeyDown(KeyCode.Return)){
                            // changeMenu(BattleMenu.Pokemon);
                            Debug.Log("can change pokemon");
                        }
                        break;
                    case 4:
                        // Debug.Log("can run");
                        fightT = fight.text;
                        bagT = bag.text;
                        pokemonT = pokemon.text;
                        runT = "> " + run.text;
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
