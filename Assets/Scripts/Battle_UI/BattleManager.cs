using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameManager gm;

    //need to get the player script from the scene that started the battle
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

    [Header("Attacker Status Info")]
    public Text playerPokemonName;
    public Text playerPokemonLevel;
    public Text HPInfo; //ex 100/100
    public Image HPForeground;
    [Header("Defender Status Info")]
    public Text enemyPokemonName;
    public Text enemyPokemonLevel;
    public Image enemyHPForeground;

    [Header("Moves")]
    public GameObject movesMenu;
    public GameObject movesDetails;
    public Text PP;
    
    public Text pType;
    public Text Move1;
    int Move1CurPP;
    string Move1MaxPP;
    string Move1PPDisplay;
    string Move1Type;
    public Text Move2;
    int Move2CurPP;
    string Move2MaxPP;
    string Move2PPDisplay;
    string Move2Type;
    public Text Move3;
    int Move3CurPP;
    string Move3MaxPP;
    string Move3PPDisplay;
    string Move3Type;
    public Text Move4;
    int Move4CurPP;
    string Move4MaxPP;
    string Move4PPDisplay;
    string Move4Type;
    private string Move1Selected = "> Move 1";
    private string Move1UnSelected = "Move 1";
    private string Move2Selected = "> Move 2";
    private string Move2UnSelected = "Move 2";
    private string Move3Selected = "> Move 3";
    private string Move3UnSelected = "Move 3";
    private string Move4Selected = "> Move 4";
    private string Move4UnSelected = "Move 4";

    string enemyName;
    float enemyHealth;
    float enemyFullHealth;
    float enemyLevel;
    float enemySpeed;

    string playerName;
    float playerHealth;
    float playerFullHealth;
    float playerLevel;
    float playerSpeed;
    float move1Accuracy;
    float move1Power;
    float move2Accuracy;
    float move2Power;
    float move3Accuracy;
    float move3Power;
    float move4Accuracy;
    float move4Power;

    [Header("Info")]
    public GameObject InfoMenu;
    public Text InfoText;

    [Header("Misc")]
    int currentSelection;

    [Header("ATK/DEF Podium")]
    public Transform defencePodium;
    public Transform attackPodium;

    [Header("Misc")]
    public GameObject emptyPoke;


    public Rarity rarityBM;
    private LongGrass lg;

    int i=0;
    int j;
    int k;

    // Start is called before the first frame update
    void Start()
    {
        lg = GameObject.FindGameObjectWithTag("Long_Grass").GetComponent<LongGrass>();
        player = GameObject.Find("Player").GetComponent<Player>();
        print(player);
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
                            battle(playerHealth,enemyHealth,move1Accuracy,move1Power);
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
                            battle(playerHealth,enemyHealth,move2Accuracy,move2Power);
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
                            battle(playerHealth,enemyHealth,move3Accuracy,move3Power);
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
                            battle(playerHealth,enemyHealth,move4Accuracy,move4Power);
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
        changeMenu(BattleMenu.Selection);
        print("wildPokemon count: "+lg.wildPokemon.Count);
        // print("ownedPokemon count: "+player.ownedPokemon.Count);
        j = Random.Range(0,lg.wildPokemon.Count);
        // j=0;
        // print("Rarity loadBattle: " + rarity);
        //--------------Enemy----------------------
        // WildPokemon battlePokemon = gm.GetRandomPokemonFromList(gm.GetPokemonByRarity(rarity));

        WildPokemon battlePokemon = lg.wildPokemon[j];

        // Debug.Log(battlePokemon.name);
        GameObject dPoke = Instantiate(emptyPoke, defencePodium.transform.position, Quaternion.identity) as GameObject;

        dPoke.transform.parent = defencePodium;

        BasePokemon tempDefPoke = dPoke.AddComponent<BasePokemon>() as BasePokemon;
        tempDefPoke.AddMember(battlePokemon.pokemon);

        dPoke.GetComponent<SpriteRenderer>().sprite = battlePokemon.pokemon.image;
        enemyHealth = battlePokemon.pokemon.HP;
        enemyFullHealth = battlePokemon.pokemon.HP;
        enemySpeed = battlePokemon.pokemon.pokemonStats.SpeedStat;
        enemyName = battlePokemon.pokemon.PName;
        enemyHPForeground.fillAmount = enemyFullHealth;
        // enemyLevel = battlePokemon.level;


        //---------------Player---------------------
        //Setting players pokemon to attack podium
        GameObject aPoke = Instantiate(emptyPoke, attackPodium.transform.position, Quaternion.identity) as GameObject;
        aPoke.transform.parent = attackPodium;

        BasePokemon tempAtkPoke = aPoke.AddComponent<BasePokemon>() as BasePokemon;
        //checking player pokemon's health
        //if health is zero,check next and so on
        //if health is not zero, deploy pokemon
        i = 0;
        print("ownedPokemon count: "+player.ownedPokemon.Count);
        while(i<player.ownedPokemon.Count) {
            print(player.ownedPokemon[i].pokemon.name);
            if(healthRemaining(i)) {
                tempAtkPoke.AddMember(player.ownedPokemon[i].pokemon);
                aPoke.GetComponent<SpriteRenderer>().sprite = player.ownedPokemon[i].pokemon.image;
                playerHealth = player.ownedPokemon[i].pokemon.HP;
                playerFullHealth = player.ownedPokemon[i].pokemon.HP;
                playerSpeed = player.ownedPokemon[i].pokemon.pokemonStats.SpeedStat;
                playerName = player.ownedPokemon[i].pokemon.PName;
                HPForeground.fillAmount = playerFullHealth;
                // playerLevel = player.ownedPokemon[i].pokemon.level;
                    
                // player.ownedPokemon[i].moves
                // Move1.text = ;

                //Move1
                if(player.ownedPokemon[i].moves[0].Name != null) {
                    Move1.text = player.ownedPokemon[i].moves[0].Name;
                    Move1CurPP = player.ownedPokemon[i].moves[0].currentPP;
                    Move1MaxPP = player.ownedPokemon[i].moves[0].PP.ToString();
                    Move1Type = player.ownedPokemon[i].moves[0].moveType.ToString();
                    Move1PPDisplay = Move1CurPP + "/" + Move1MaxPP;
                    Move1Selected = "> " + Move1.text;
                    Move1UnSelected = Move1.text;
                    move1Accuracy = player.ownedPokemon[i].moves[0].accuracy;
                    move1Power = player.ownedPokemon[i].moves[0].power;
                }
                //Move2
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[1].Name != null) {
                    Move2.text = player.ownedPokemon[i].moves[1].Name;
                    Move2CurPP = player.ownedPokemon[i].moves[1].currentPP;
                    Move2MaxPP = player.ownedPokemon[i].moves[1].PP.ToString();
                    Move2Type = player.ownedPokemon[i].moves[1].moveType.ToString();
                    Move2PPDisplay = Move2CurPP + "/" + Move2MaxPP;
                    Move2Selected = "> " + Move2.text;
                    Move2UnSelected = Move2.text;
                    move2Accuracy = player.ownedPokemon[i].moves[1].accuracy;
                    move2Power = player.ownedPokemon[i].moves[1].power;
                }
                //Move3
                //Need to add else condition for null
                print(i + ","+ player.ownedPokemon.Count+ ",");
                if(player.ownedPokemon[i].moves[2].Name != null) {
                    Move3.text = player.ownedPokemon[i].moves[2].Name;
                    Move3CurPP = player.ownedPokemon[i].moves[2].currentPP;
                    Move3MaxPP = player.ownedPokemon[i].moves[2].PP.ToString();
                    Move3Type = player.ownedPokemon[i].moves[2].moveType.ToString();
                    Move3PPDisplay = Move3CurPP + "/" + Move3MaxPP;
                    Move3Selected = "> " + Move3.text;
                    Move3UnSelected = Move3.text;
                    move3Accuracy = player.ownedPokemon[i].moves[2].accuracy;
                    move3Power = player.ownedPokemon[i].moves[2].power;
                } else {

                }
                //Move4
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[3].Name != null) {
                    Move4.text = player.ownedPokemon[i].moves[3].Name;
                    Move4CurPP = player.ownedPokemon[i].moves[3].currentPP;
                    Move4MaxPP = player.ownedPokemon[i].moves[3].PP.ToString();
                    Move4Type = player.ownedPokemon[i].moves[3].moveType.ToString();
                    Move4PPDisplay = Move4CurPP + "/" + Move4MaxPP;
                    Move4Selected = "> " + Move4.text;
                    Move4UnSelected = Move4.text;
                    move4Accuracy = player.ownedPokemon[i].moves[3].accuracy;
                    move4Power = player.ownedPokemon[i].moves[3].power;
                } else {
                    
                }
                break;
            } else {
                i++;
            }
        }
        updateBattleStatus(playerHealth,playerFullHealth,playerLevel,enemyHealth,enemyFullHealth,enemyLevel);



    }
    public bool healthRemaining(int i) {
        if(player.ownedPokemon[i].pokemon.HP == 0)
            return false;
        else 
            return true;    
    }

    //needs to be improved upon
    public void battle(float playerHealth, float enemyHealth, float accuracy, float power) {
        print("battle called");
        k = Random.Range(0, lg.wildPokemon[j].moves.Count);
        float enemyAttack;
        if(playerSpeed >= enemySpeed) { //player speed > enemy speed
            print("power" + power +", enemy health" + enemyHealth);
            enemyHealth -= power;
            print("enemyHealth" + enemyHealth);
            //----------------------------------------------------
            //need to rework this to check it the current PP of a move != 0
                enemyAttack = lg.wildPokemon[j].moves[k].power;
                lg.wildPokemon[j].moves[k].currentPP--;
            //-----------------------------------------------------    
            playerHealth -= enemyAttack;
            print("PlayerHealth"+playerHealth);
            updateBattleStatus(playerHealth,playerFullHealth,playerLevel,enemyHealth,enemyFullHealth,enemyLevel);
            changeMenu(BattleMenu.Selection);
        } else if(playerSpeed < enemySpeed) { //player speed < enemy speed
            //add enemy  attack code
            changeMenu(BattleMenu.Selection);
        }
    }
    public void updateBattleStatus(float playerHealth, float playerFullHealth,float playerLevel, float enemyHealth, float enemyFullHealth, float enmeyLevel) {
        print("update battle UI entered");
        
        //updating player status
        playerPokemonName.text = playerName;
        // playerPokemonLevel.text = playerLevel.ToString();
        HPInfo.text = playerHealth + "/" + playerFullHealth;
        // HPForeground.fillAmount = playerHealth/playerFullHealth;
        HPForeground.fillAmount = playerHealth;
        // print("Player HP" + playerHealth/playerFullHealth);
        

        //updating enemy status
        enemyPokemonName.text  = enemyName;
        // enemyPokemonLevel.text = enmeyLevel.ToString();
        enemyHPForeground.fillAmount = enemyHealth;
        print("Enemy HP" + enemyHealth);
        
        //need to create method when player is faints
        //playerFaint();
        //need to create method when enemy is faints
        //enemyFaint();
        //need to create method when both faint at same time
        if(playerHealth == 0 && enemyHealth == 0) {
            Debug.Log("Both Pokemon Fainted");
        } else if (enemyHealth == 0) {
            
            enemyFainted();
        } else if(playerHealth == 0) {
            
            playerFainted();
        }
        print("update battle UI exited");
    }
    void bothFainted() {
        Debug.Log("Both Pokemon Fainted");

    }
    void enemyFainted() {
        Debug.Log("Enemy Fainted");
        //need to add experience gained and update player stats
        player.ownedPokemon[i].pokemon.HP = (int)playerHealth;

            //Move1
            if(player.ownedPokemon[i].moves[0].Name != null) {
                    
                    player.ownedPokemon[i].moves[0].currentPP = Move1CurPP;
                }
                //Move2
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[1].Name != null) {
                    player.ownedPokemon[i].moves[1].currentPP = Move2CurPP;
                }
                //Move3
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[2].Name != null) {
                    player.ownedPokemon[i].moves[2].currentPP = Move3CurPP;
                }
                //Move4
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[3].Name != null) {
                    player.ownedPokemon[i].moves[3].currentPP = Move4CurPP;
                }
        gm.ExitBattle();
    }
    void playerFainted() {
        Debug.Log("Player Fainted");
    }
}
public enum BattleMenu {
    Selection,
    Pokemon,
    Bag,
    Fight,
    Info
}
