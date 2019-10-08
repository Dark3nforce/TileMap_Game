using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // public GameObject playerCamera;
    // public GameObject battleCamera;

    // public GameObject player;
    // SceneManager sm;

    public List<BasePokemon> allPokemon = new List<BasePokemon>();
    public List<PokemonMoves> allMoves = new List<PokemonMoves>();

    // private Transform defencePodium;
    // private Transform attackPodium;
    // public GameObject emptyPoke;

    private BattleManager bm;
    private LongGrass lg;
    Player player;
    

    public GameObject menu;
    // private MenuController mc;

	void Start () {
        // playerCamera.SetActive(true);
        // battleCamera.SetActive(false);
        // defencePodium = GameObject.Find("DefensePodium").GetComponent<Transform>();
        // attackPodium = GameObject.Find("AttackPodium").GetComponent<Transform>();
        // bm = GameObject.Find("Battle Camera").GetComponent<BattleManager>();
        bm = GetComponent<BattleManager>();
        // lg = gameObject.find().GetComponent<LongGrass>();
        lg = GameObject.Find("Testing_Battles").GetComponent<LongGrass>();
        player = GameObject.Find("Player").GetComponent<Player>();
        Debug.Log(lg);
        // mc = GetComponent<MenuController>();

    }
	
	void Update () {
    //     if(Input.GetKeyDown(KeyCode.Space)) {
    //         // EnterBattle(Rarity.Common);
    //         EnterBattle();
    //    } 
        if(Input.GetKeyDown(KeyCode.E)) {
            // Debug.Log("E button pressed");
            toggleMenuUI();
        }
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            player.LoadPlayer();
        }
	}

    public void toggleMenuUI() {
        if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
            }
            else {
                menu.SetActive(true);
            }
    }

    // public void EnterBattle(Rarity rarity)
    public void EnterBattle()
    {
        // playerCamera.SetActive(false);
        // battleCamera.SetActive(true);
        // var rarity = this.rarity;
        // BasePokemon battlePokemon = GetRandomPokemonFromList(GetPokemonByRarity(rarity));

        // Debug.Log(rarity);

       // player.GetComponent<PlayerMovement>().isAllowedToMove = false;


        Time.timeScale = 0f;
        // bm.start(rarity);
        SceneManager.LoadScene("Battle_Scene",LoadSceneMode.Additive);
        // SceneManager.LoadScene("Battle_Scene");
        // bm.loadBattle(rarity);
        // bm.loadBattle();

        // GameObject dPoke = Instantiate(emptyPoke, defencePodium.transform.position, Quaternion.identity) as GameObject;

        // dPoke.transform.parent = defencePodium;

        // BasePokemon tempPoke = dPoke.AddComponent<BasePokemon>() as BasePokemon;
        // tempPoke.AddMember(battlePokemon);

        // dPoke.GetComponent<SpriteRenderer>().sprite = battlePokemon.image;

        // bm.changeMenu(BattleMenu.Selection);
        Debug.Log("EnterBattle method finish");
        // SceneManager.LoadScene("Battle_Scene",LoadSceneMode.Additive);
        

    }

    public void ExitBattle() {
        SceneManager.UnloadSceneAsync("Battle_Scene");
        Time.timeScale = 1f;
        lg.triggered = false;
        Debug.Log(lg.triggered);
    }

    public List<BasePokemon> GetPokemonByRarity(Rarity rarity)
    {
        List<BasePokemon> returnPokemon = new List<BasePokemon>();
        foreach (BasePokemon Pokemon in allPokemon)
        {
            if (Pokemon.rarity == rarity)
                returnPokemon.Add(Pokemon);
        }

        return returnPokemon;
    }

    public BasePokemon GetRandomPokemonFromList(List<BasePokemon> pokeList)
    {
        BasePokemon poke = new BasePokemon();
        int pokeIndex = Random.Range(0, pokeList.Count - 1);
        poke = pokeList[pokeIndex];
        return poke;
    }
}

[System.Serializable]
public class PokemonMoves
{
    string Name;
    public MoveType category;
    public Stat moveStat;
    public PokemonType moveType;
    public int PP;
    public float power;
    public float accuracy;
}

[System.Serializable]
public class Stat
{
    public float minimum;
    public float maximum;
}

public enum MoveType
{
    Physical,
    Special,
    Status
}
