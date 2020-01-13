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
    public BattleMessageType currentMessageType;
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
    PokemonType Move1Type;
    MoveType Move1Category;
    public Text Move2;
    int Move2CurPP;
    string Move2MaxPP;
    string Move2PPDisplay;
    PokemonType Move2Type;
    MoveType Move2Category;
    public Text Move3;
    int Move3CurPP;
    string Move3MaxPP;
    string Move3PPDisplay;
    PokemonType Move3Type;
    MoveType Move3Category;
    public Text Move4;
    int Move4CurPP;
    string Move4MaxPP;
    string Move4PPDisplay;
    PokemonType Move4Type;
    MoveType Move4Category;
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
    float enemyCurHealth;
    float enemyFullHealth;
    float enemyLevel;
    float enemySpeed;

    string playerName;
    float playerHealth;
    float playerCurHealth;
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
    //Message/Info Panel
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
    double typeMultiplier;
    bool isWeatherEffectActive = false;


    //Pokemon Stats Player
    float attackStat;
    float specAttackStat;
    float defenseStat;
    float specDefenseStat;
    PokemonType playerType;

    //Pokemon Stats Enemy
    float attackStatEnemy;
    float specAttackStatEnemy;
    float defenseStatEnemy;
    float specDefenseStatEnemy;
    PokemonType enemyType;

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
       enemyCurHealth = enemyHealth;
       playerCurHealth = playerHealth;
       updateBattleStatus();
    }

    // Update is called once per frame
    void Update()
    {
        // HPForeground.fillAmount = playerHealth/playerFullHealth;
        // enemyHPForeground.fillAmount = enemyHealth/enemyFullHealth;
        // updateBattleStatus(playerHealth,playerFullHealth,playerLevel,enemyHealth,enemyFullHealth,enemyLevel);

        // HPForeground.rectTransform.localScale = new Vector3(playerHealth/playerFullHealth,1,1);
        // enemyHPForeground.rectTransform.localScale = new Vector3((enemyHealth)/enemyFullHealth,1,1);

        // do {
        //     enemyHPForeground.rectTransform.localScale = new Vector3(enemyCurHealth/enemyFullHealth,1,1);
        //     enemyCurHealth--;
        // } while(enemyHealth<=enemyCurHealth);

        // do {
        //     HPForeground.rectTransform.localScale = new Vector3(playerCurHealth/playerFullHealth,1,1);
        //     playerCurHealth--;
        // } while(playerHealth<=playerCurHealth);

        // if(enemyHealth < enemyCurHealth) {
        //     float enemyHealthDif = enemyCurHealth-enemyHealth;
        //     // enemyHPForeground.rectTransform.localScale = new Vector3(enemyHealth/enemyFullHealth,1,1);
        //     // enemyHPForeground.fillAmount = Mathf.Lerp(enemyCurHealth/enemyFullHealth, enemyHealth/enemyFullHealth, Time.deltaTime);
        //     enemyHPForeground.fillAmount = enemyCurHealth/enemyFullHealth;
        // }
        // if(playerHealth < playerCurHealth) {
        //     HPForeground.rectTransform.localScale = new Vector3(playerHealth/playerFullHealth,1,1);
        //     // HPForeground.fillAmount = Mathf.Lerp(playerCurHealth/playerFullHealth,playerHealth/playerFullHealth, Time.deltaTime * 10f);
        // }

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
                        pType.text = Move1Type.ToString();
                        if(Input.GetKeyDown(KeyCode.Return)){
                            Debug.Log("Move1 Selected");
                            battle(move1Power,Move1Category,Move1Type,move1Power);
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
                        pType.text = Move2Type.ToString();
                        if(Input.GetKeyDown(KeyCode.Return)){
                            Debug.Log("Move2 Selected");
                            battle(move2Power,Move2Category,Move2Type,move2Power);
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
                        pType.text = Move3Type.ToString();
                        if(Input.GetKeyDown(KeyCode.Return)){
                            Debug.Log("Move3 Selected");
                            battle(move3Power,Move3Category,Move3Type,move3Power);
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
                        pType.text = Move4Type.ToString();
                        if(Input.GetKeyDown(KeyCode.Return)){
                            Debug.Log("Move4 Selected");
                            battle(move4Power,Move4Category,Move4Type,move4Power);
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
                SelectionMenu.gameObject.SetActive(false);
                SelectionInfo.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                InfoMenu.gameObject.SetActive(true);
                break;    
        }
    }


    //Messages to be displayed at the end or beginning of a round or battle
    //not being used yet
    public void battleStatusTextOptions(BattleMessageType t, string playerMoveUsed, string enemyMoveUsed) {
        currentMessageType = t;
        string outputMessage = "";
        switch(t) {
            case BattleMessageType.StatusEffect:
                //needs to check for status effects at end of battle round and update health
                //then display who and what type of status
                outputMessage = "(Pokemon) is (Effect)! \n";
                updateMessageStatus(outputMessage);
                break;
            case BattleMessageType.WeatherEffect:
                if(isWeatherEffectActive) {
                    // outputMessage = ""
                    //output message based on weather active
                } else {
                    break;
                }
                break;
            case BattleMessageType.StartTrainerBattle:
                //starting a battle with trainer needs to be made first
                break;
            case BattleMessageType.StartWildBattle:
                outputMessage = "Wild " + enemyPokemonName + " Appeared!";
                break;
            case BattleMessageType.PlayerAttack:
                outputMessage = playerPokemonName + " used " + playerMoveUsed + "!";
                break;
            case BattleMessageType.EnemyAttack:
                outputMessage = enemyPokemonName + " used " + enemyMoveUsed + "!";
                break;
            case BattleMessageType.MoveEffectiveness:
                switch(typeMultiplier) {
                    case 0:
                        outputMessage = "No Effect";
                        break;
                    case 0.5:
                        outputMessage = "It's not very Effective!";
                        break;
                    case 1:
                        break;
                    case 2:
                        outputMessage = "It's Super Effective!\n A critical hit!";
                        break;             
                }
                break;                        
        }
    }

    //not being used yet
    public void currentStatusEffect() {

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
        tempDefPoke.transform.localScale += battlePokemon.pokemon.scalePos;

        dPoke.GetComponent<SpriteRenderer>().sprite = battlePokemon.pokemon.image;
        enemyHealth = battlePokemon.pokemon.HP;
        enemyFullHealth = battlePokemon.pokemon.FullHP;
        enemySpeed = battlePokemon.pokemon.pokemonStats.SpeedStat;
        enemyName = battlePokemon.pokemon.PName;
        enemyHPForeground.fillAmount = enemyFullHealth;
        enemyLevel = battlePokemon.pokemon.level;
        enemyType = battlePokemon.pokemon.type;
        attackStatEnemy = battlePokemon.pokemon.pokemonStats.AttackStat;
        specAttackStatEnemy = battlePokemon.pokemon.pokemonStats.SpAttackStat;
        defenseStatEnemy = battlePokemon.pokemon.pokemonStats.DefenceStat;
        specDefenseStatEnemy = battlePokemon.pokemon.pokemonStats.SpDefenceStat;


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
                playerFullHealth = player.ownedPokemon[i].pokemon.FullHP;
                playerSpeed = player.ownedPokemon[i].pokemon.pokemonStats.SpeedStat;
                playerName = player.ownedPokemon[i].pokemon.PName;
                HPForeground.fillAmount = playerFullHealth;
                playerLevel = player.ownedPokemon[i].pokemon.level;
                playerType = player.ownedPokemon[i].pokemon.type;
                attackStat = player.ownedPokemon[i].pokemon.pokemonStats.AttackStat;
                specAttackStat = player.ownedPokemon[i].pokemon.pokemonStats.SpAttackStat;
                defenseStat = player.ownedPokemon[i].pokemon.pokemonStats.DefenceStat;
                specDefenseStat = player.ownedPokemon[i].pokemon.pokemonStats.SpDefenceStat;
                    
                // player.ownedPokemon[i].moves
                // Move1.text = ;

                //Move1
                if(player.ownedPokemon[i].moves[0].Name != null) {
                    Move1.text = player.ownedPokemon[i].moves[0].Name;
                    Move1CurPP = player.ownedPokemon[i].moves[0].currentPP;
                    Move1MaxPP = player.ownedPokemon[i].moves[0].PP.ToString();
                    Move1Type = player.ownedPokemon[i].moves[0].moveType;
                    Move1Category = player.ownedPokemon[i].moves[0].category;
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
                    Move2Type = player.ownedPokemon[i].moves[1].moveType;
                    Move2Category = player.ownedPokemon[i].moves[1].category;
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
                    Move3Type = player.ownedPokemon[i].moves[2].moveType;
                    Move3Category = player.ownedPokemon[i].moves[2].category;
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
                    Move4Type = player.ownedPokemon[i].moves[3].moveType;
                    Move4Category = player.ownedPokemon[i].moves[3].category;
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
        tempAtkPoke.transform.localScale += player.ownedPokemon[i].pokemon.scalePos;
        tempAtkPoke.transform.position += player.ownedPokemon[i].pokemon.pos;
        updateBattleStatus();



    }
    public bool healthRemaining(int i) {
        if(player.ownedPokemon[i].pokemon.HP == 0)
            return false;
        else 
            return true;    
    }

    //needs to be improved upon
    public void battle(float movePow, MoveType type,PokemonType moveType, float pow) {
        // print("battle called");
        // bool playerHasAttacked = false;
        // bool enemyHasAttacked = false;
        float enemyPreviousHealth = enemyHealth;
        float playerPreviousHealth = playerHealth;

        k = Random.Range(0, lg.wildPokemon[j].moves.Count);
        float enemyAttack;
        
        //----------------------------------------------------
            //need to rework this to check it the current PP of a move != 0
                enemyAttack = lg.wildPokemon[j].moves[k].power;
                lg.wildPokemon[j].moves[k].currentPP--;
        //-----------------------------------------------------
        print(lg.wildPokemon[j].moves[k].Name); 

        enemyCurHealth = enemyHealth;
        playerCurHealth = playerHealth;
        

        if(playerSpeed >=enemySpeed) { //player speed > enemy speed

            //player Attack
            if(type == MoveType.Physical) {

                enemyHealth -= calcDamage(playerLevel,type,moveType,playerType,attackStat,pow,defenseStatEnemy,enemyType);
                print("player attacked");
                updateEnemyHealthBar(enemyHealth);
            } else if(type == MoveType.Special) {
                enemyHealth -= calcDamage(playerLevel,type,moveType,playerType,specAttackStat,pow,specDefenseStatEnemy,enemyType);
                print("player attacked");
                updateEnemyHealthBar(enemyHealth);
            }
            
            if(enemyHealth >= 0) {
                if(lg.wildPokemon[j].moves[k].category == MoveType.Physical) {
                    playerHealth -= calcDamage(enemyLevel,lg.wildPokemon[j].moves[k].category,lg.wildPokemon[j].moves[k].moveType,enemyType,attackStatEnemy,lg.wildPokemon[j].moves[k].power,defenseStat,playerType);
                    print("enemy attacked");
                    updatePlayerHealthBar(playerHealth);
                } else if(lg.wildPokemon[j].moves[k].category == MoveType.Special) {
                    playerHealth -= calcDamage(enemyLevel,lg.wildPokemon[j].moves[k].category,lg.wildPokemon[j].moves[k].moveType,enemyType,specAttackStatEnemy,lg.wildPokemon[j].moves[k].power,specDefenseStat,playerType);
                    print("enemy attacked");
                    updatePlayerHealthBar(playerHealth);
                }
            }
            print("EnemyHealth"+enemyHealth);
            updateBattleStatus();
            // playerHasAttacked = true;
            
        } else if(playerSpeed < enemySpeed) { //player speed < enemy speed
            //add enemy  attack code
            if(lg.wildPokemon[j].moves[k].category == MoveType.Physical) {
                playerHealth -= calcDamage(enemyLevel,lg.wildPokemon[j].moves[k].category,lg.wildPokemon[j].moves[k].moveType,enemyType,attackStatEnemy,lg.wildPokemon[j].moves[k].power,defenseStat,playerType);
                print("enemy attacked");
                updatePlayerHealthBar(playerHealth);
            } else if(lg.wildPokemon[j].moves[k].category == MoveType.Special) {
                playerHealth -= calcDamage(enemyLevel,lg.wildPokemon[j].moves[k].category,lg.wildPokemon[j].moves[k].moveType,enemyType,specAttackStatEnemy,lg.wildPokemon[j].moves[k].power,specDefenseStat,playerType);
                print("enemy attacked");
                updatePlayerHealthBar(playerHealth);
            }
            print("PlayerHealth"+playerHealth);
            if(playerHealth > 0) {
                if(type == MoveType.Physical) {
                    enemyHealth -= calcDamage(playerLevel,type,moveType,playerType,attackStat,pow,defenseStatEnemy,enemyType);
                    print("player attacked");
                    updateEnemyHealthBar(enemyHealth);
                } else if(type == MoveType.Special) {
                    enemyHealth -= calcDamage(playerLevel,type,moveType,playerType,specAttackStat,pow,specDefenseStatEnemy,enemyType);
                    print("player attacked");
                    updateEnemyHealthBar(enemyHealth);
                }
            }
            updateBattleStatus();
            // enemyHasAttacked = true;
        }
        // if(playerHasAttacked) {
        //     if(lg.wildPokemon[j].moves[k].category == MoveType.Physical) {
        //         playerHealth -= calcDamage(enemyLevel,lg.wildPokemon[j].moves[k].category,lg.wildPokemon[j].moves[k].moveType,enemyType,attackStatEnemy,pow,defenseStat,playerType);
        //     } else if(lg.wildPokemon[j].moves[k].category == MoveType.Special) {
        //         playerHealth -= calcDamage(enemyLevel,lg.wildPokemon[j].moves[k].category,lg.wildPokemon[j].moves[k].moveType,enemyType,specAttackStatEnemy,pow,specDefenseStat,playerType);
        //     }
        //     print("PlayerHealth"+playerHealth);
        // } else if(enemyHasAttacked) {
        //     if(type == MoveType.Physical) {
        //         enemyHealth -= calcDamage(playerLevel,type,moveType,playerType,attackStat,pow,defenseStatEnemy,enemyType);
        //     } else if(type == MoveType.Special) {
        //         enemyHealth -= calcDamage(playerLevel,type,moveType,playerType,specAttackStat,pow,specDefenseStatEnemy,enemyType);
        //     }
        //     print("EnemyHealth"+enemyHealth);
        // }
    }
    float calcDamage(float level,MoveType type,PokemonType attType,PokemonType attckerType,float atkStat,float pow, float defStat, PokemonType defenderType) {
            float Z = Random.Range(217,255);
            typeMultiplier = typeModifiers(type,attType,defenderType);
            float output;
            if(attType == attckerType) {
                // return Mathf.Floor(((((((((((2*level/5+2)*atkStat*pow)/defStat)/50)+2)*(float)1.5)*typeModifiers(type,attType,defenderType)/10)*Z)/255)));
                output = 2*level/5+2;
                output *= atkStat;
                output *= pow;
                output /= defStat;
                output /=50;
                output +=2;
                output *=(float)1.5;
                output *=(typeModifiers(type,attType,defenderType)*10);
                output /= 10;
                output *= Z;
                output /= 255;
                return Mathf.Floor(output);
            }
                    
            else {
                output = 2*level/5+2;
                output *=atkStat;
                output *= pow;
                output /=defStat;
                output /= 50;
                output +=2;
                output *=1;
                output *=(typeModifiers(type,attType,defenderType)*10);
                output /=10;
                output *= Z;
                output /=255;
                return Mathf.Floor(output);
            }    
    }

    //update enemy healthBar
    public void updateEnemyHealthBar(float enemyHealth) {
        float midLimit = enemyFullHealth * 0.50f;
        float lowLimit = enemyFullHealth * 0.15f;
        float health = enemyHealth;

        // if(enemyHealth < lowLimit) {
        //     enemyHPForeground.color = Color.red;
        // } else if (enemyHealth < midLimit) {
        //     enemyHPForeground.color = Color.yellow;
        // } else {
        //     enemyHPForeground.color = Color.green;
        // }

        if(health < midLimit) {
            enemyHPForeground.color = Color.Lerp(Color.red, Color.yellow, health/midLimit);
            // enemyHPForeground.rectTransform.localScale = new Vector3((enemyHealth)/enemyFullHealth,1,1);
            // enemyHPForeground.fillAmount = Mathf.Lerp(enemyPreviousHealth,health/enemyFullHealth, Time.deltaTime * 10f);
            enemyHPForeground.fillAmount = enemyHealth/enemyFullHealth;
        } else {
            enemyHPForeground.color = Color.Lerp(Color.yellow, Color.green, (health - midLimit)/(enemyFullHealth - midLimit));
            // enemyHPForeground.rectTransform.localScale = new Vector3((enemyHealth)/enemyFullHealth,1,1);
            // enemyHPForeground.fillAmount = Mathf.Lerp(enemyPreviousHealth,health/enemyFullHealth, Time.deltaTime * 10f);
            enemyHPForeground.fillAmount = enemyHealth/enemyFullHealth;
        }
    }
    //upate player healthBar
    public void updatePlayerHealthBar(float playerHealth) {
        float midLimit = playerFullHealth * 0.50f;
        float lowLimit = playerFullHealth * 0.15f;
        float health = playerHealth;

        // if(enemyHealth < lowLimit) {
        //     enemyHPForeground.color = Color.red;
        // } else if (enemyHealth < midLimit) {
        //     enemyHPForeground.color = Color.yellow;
        // } else {
        //     enemyHPForeground.color = Color.green;
        // }

        if(health < midLimit) {
            HPForeground.color = Color.Lerp(Color.red, Color.yellow, health/midLimit);
            // HPForeground.rectTransform.localScale = new Vector3(playerHealth/playerFullHealth,1,1);
            // HPForeground.fillAmount = Mathf.Lerp(playerPreviousHealth,health/playerFullHealth, Time.deltaTime * 10f);
            HPForeground.fillAmount = playerHealth/playerFullHealth;
        } else {
            HPForeground.color = Color.Lerp(Color.yellow, Color.green, (health - midLimit)/(playerFullHealth - midLimit));
            // HPForeground.rectTransform.localScale = new Vector3(playerHealth/playerFullHealth,1,1);
            // HPForeground.fillAmount = Mathf.Lerp(playerPreviousHealth,health/playerFullHealth, Time.deltaTime * 10f);
            HPForeground.fillAmount = playerHealth/playerFullHealth;
        }
    }

    public void updateBattleStatus() {
        
        
        //updating player status
        playerPokemonName.text = playerName;
        playerPokemonLevel.text = playerLevel.ToString();
        if(playerHealth < 0) {
        	playerHealth = 0;	
        }
        if(enemyHealth < 0) {
        	enemyHealth = 0;
        }
        HPInfo.text = playerHealth + "/" + playerFullHealth;

        //--------------------------- comment out later ----------------------------
        // HPForeground.rectTransform.localScale = new Vector3(Mathf.Lerp(playerHealth,playerCurHealth,playerHealth/playerFullHealth),1,1);


        // HPForeground.rectTransform.localScale = new Vector3(playerHealth/playerFullHealth,1,1);
        
        // do {
        //     HPForeground.rectTransform.localScale = new Vector3(playerCurHealth/playerFullHealth,1,1);
        //     playerCurHealth--;
        // } while(playerHealth<=playerCurHealth);
        
        

        //updating enemy status
        enemyPokemonName.text  = enemyName;
        enemyPokemonLevel.text = enemyLevel.ToString();

        // enemyHPForeground.rectTransform.localScale = new Vector3(Mathf.Lerp(enemyCurHealth,enemyHealth,enemyHealth/enemyFullHealth),1,1);
        // do {
        //     enemyHPForeground.rectTransform.localScale = new Vector3(enemyCurHealth/enemyFullHealth,1,1);
        //     enemyCurHealth--;
        // } while(enemyHealth<=enemyCurHealth);


        // enemyHPForeground.rectTransform.localScale = new Vector3((enemyHealth)/enemyFullHealth,1,1);
        // -------------------------------- end of comment out ----------------------------------------
        
        //need to create method when player is faints
        //playerFaint();
        //need to create method when enemy is faints
        //enemyFaint();
        //need to create method when both faint at same time
        if(playerHealth <= 0 && enemyHealth <= 0) {
            Debug.Log("Both Pokemon Fainted");
        } else if (enemyHealth <= 0) {
            
            enemyFainted();
        } else if(playerHealth <= 0) {
            
            playerFainted();
        }
        changeMenu(BattleMenu.Selection);
    }

    
    void updateInfoStatus() {
        //selection info - info panel
        changeMenu(BattleMenu.Selection);
        SelectionInfoText.text = "What will "+ playerPokemonName +" do?";
    }

    //should be called at start and end of battle
    //updates after every attack and defense
    //attack made, crit hit/super effective/normal/not very effective, status effect
    void updateMessageStatus(string messageTxt) {
        changeMenu(BattleMenu.Info);
        // string messageTxt = "";



        InfoText.text = messageTxt;
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

                    //for debugging only
                    // print(Move1.text + player.ownedPokemon[i].moves[0].currentPP);
                }
                //Move2
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[1].Name != null) {
                    player.ownedPokemon[i].moves[1].currentPP = Move2CurPP;

                    //for debugging only
                 	// print(Move2.text + player.ownedPokemon[i].moves[1].currentPP);   
                }
                //Move3
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[2].Name != null) {
                    player.ownedPokemon[i].moves[2].currentPP = Move3CurPP;

                    //for debugging only
                    // print(Move3.text + player.ownedPokemon[i].moves[2].currentPP);
                }
                //Move4
                //Need to add else condition for null
                if(player.ownedPokemon[i].moves[3].Name != null) {
                    player.ownedPokemon[i].moves[3].currentPP = Move4CurPP;

                    //for debugging only
                    // print(Move4.text + player.ownedPokemon[i].moves[3].currentPP);
                }
                changeMenu(BattleMenu.Info);
                //set Info menu to print out that enemy fainted
        gm.ExitBattle();
    }
    void playerFainted() {

        Debug.Log("Player Fainted");
        changeMenu(BattleMenu.Info);
        //set Info menu to print out that enemy fainted


        player.ownedPokemon[i].pokemon.HP = (int)playerFullHealth;
        gm.ExitBattle();
    }

    public float typeModifiers(MoveType type, PokemonType attType, PokemonType defenderType) {
        double[,] typeSpecPokemonType = new double[15,15];
            //Fire Atk
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Fire] = 0.5;
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Water] = 0.5;    
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Grass] = 2;
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Ice] = 2;        
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Flying] = 1;    
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Ground] = 1;                          
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Rock] = 0.5; 
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Bug] = 2;               
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Poison] = 1;        
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Fire, (int)PokemonType.Dragon] = 0.5;  
            //Water Atk
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Fire] = 2;
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Water] = 0.5;    
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Grass] = 0.5;
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Flying] = 1;    
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Ground] = 2;                          
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Rock] = 2; 
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Bug] = 1;               
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Poison] = 1;        
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Water, (int)PokemonType.Dragon] = 0.5;
            //Grass Atk
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Fire] = 0.5;
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Water] = 2;    
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Grass] = 0.5;
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Flying] = 0.5;    
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Ground] = 2;                          
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Rock] = 2; 
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Bug] = 0.5;               
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Poison] = 0.5;        
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Grass, (int)PokemonType.Dragon] = 0.5; 
            //Electric Atk
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Fire] = 1;
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Water] = 2;    
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Grass] = 0.5;
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Electric] = 0.5;
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Flying] = 2;    
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Ground] = 0;                          
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Rock] = 1; 
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Bug] = 1;               
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Poison] = 1;        
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Electric, (int)PokemonType.Dragon] = 0.5;
            //Ice Atk
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Fire] = 1;
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Water] = 0.5;    
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Grass] = 2;
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Ice] = 0.5;        
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Flying] = 2;    
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Ground] = 2;                          
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Rock] = 1; 
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Bug] = 1;               
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Poison] = 1;        
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Ice, (int)PokemonType.Dragon] = 2;
            //Psychic Atk
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Fire] = 1;
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Grass] = 1;
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Psychic] = 0.5;        
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Fighting] = 2;  
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Flying] = 1;    
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Ground] = 1;                          
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Rock] = 1; 
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Bug] = 1;               
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Poison] = 2;        
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Psychic, (int)PokemonType.Dragon] = 1; 

            // double[,] typeSpecPokemonType = new double[10,16];
            //Normal Atk
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Fire] = 1;
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Grass] = 1;
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Flying] = 1;    
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Ground] = 1;                          
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Rock] = 0.5; 
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Bug] = 1;               
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Poison] = 1;        
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Ghost] = 0;        
            typeSpecPokemonType[(int)PokemonType.Normal, (int)PokemonType.Dragon] = 1;
            //Fighting
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Fire] = 1;
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Grass] = 1;
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Ice] = 2;        
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Psychic] = 0.5;        
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Normal] = 2;
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Flying] = 0.5;    
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Ground] = 1;                          
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Rock] = 2; 
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Bug] = 0.5;               
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Poison] = 0.5;        
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Ghost] = 0;        
            typeSpecPokemonType[(int)PokemonType.Fighting, (int)PokemonType.Dragon] = 1; 
            //Flying
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Fire] = 1;
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Grass] = 2;
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Electric] = 0.5;
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Fighting] = 2;  
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Flying] = 1;    
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Ground] = 1;                          
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Rock] = 0.5; 
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Bug] = 2;               
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Poison] = 1;        
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Flying, (int)PokemonType.Dragon] = 1;
            //Ground
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Fire] = 2;
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Grass] = 0.5;
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Electric] = 2;
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Flying] = 0;    
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Ground] = 1;                          
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Rock] = 2; 
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Bug] = 0.5;               
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Poison] = 2;        
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Ground, (int)PokemonType.Dragon] = 1;
            //Rock
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Fire] = 2;
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Grass] = 1;
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Ice] = 2;        
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Fighting] = 0.5;  
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Flying] = 2;    
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Ground] = 0.5;                          
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Rock] = 1; 
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Bug] = 1;               
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Poison] = 1;        
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Rock, (int)PokemonType.Dragon] = 1;
            //Bug
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Fire] = 0.5;
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Grass] = 2;
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Fighting] = 0.5;  
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Flying] = 0.5;    
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Ground] = 1;                          
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Rock] = 1; 
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Bug] = 1;               
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Poison] = 2;        
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Bug, (int)PokemonType.Dragon] = 1;
            //Poison
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Fire] = 1;
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Grass] = 2;
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Flying] = 1;    
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Ground] = 0.5;                          
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Rock] = 0.5; 
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Bug] = 2;               
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Poison] = 0.5;        
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Ghost] = 0.5;        
            typeSpecPokemonType[(int)PokemonType.Poison, (int)PokemonType.Dragon] = 1;
            //Ghost
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Fire] = 1;
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Grass] = 1;
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Psychic] = 0;        
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Normal] = 0;
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Flying] = 1;    
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Ground] = 1;                          
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Rock] = 1; 
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Bug] = 1;               
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Poison] = 1;        
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Ghost] = 2;        
            typeSpecPokemonType[(int)PokemonType.Ghost, (int)PokemonType.Dragon] = 1;
            //Ghost
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Fire] = 1;
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Water] = 1;    
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Grass] = 1;
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Electric] = 1;
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Ice] = 1;        
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Psychic] = 1;        
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Normal] = 1;
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Fighting] = 1;  
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Flying] = 1;    
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Ground] = 1;                          
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Rock] = 1; 
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Bug] = 1;               
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Poison] = 1;        
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Ghost] = 1;        
            typeSpecPokemonType[(int)PokemonType.Dragon, (int)PokemonType.Dragon] = 1;

            return (float)typeSpecPokemonType[(int)attType, (int)defenderType];
        
        

    }
}
// public enum PokemonType {
//     Fire = 0,
//     Water,
//     Grass,
//     Electric,
//     Ice,
//     Psychic,
//     Normal,
//     Fighting,
//     Flying,
//     Ground,
//     Rock,
//     Bug,
//     Poison,
//     Ghost,
//     Dragon
//     }
public enum BattleMenu {
    Selection,
    Pokemon,
    Bag,
    Fight,
    Info
}
public enum BattleMessageType {
    StatusEffect,
    WeatherEffect,
    StartWildBattle,
    StartTrainerBattle,
    PlayerAttack,
    EnemyAttack,
    MoveEffectiveness //crit hit,supereffective, etc.
}