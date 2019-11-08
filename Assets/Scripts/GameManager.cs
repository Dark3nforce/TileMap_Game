using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // public GameObject playerCamera;
    // public GameObject battleCamera;

    // public GameObject player;
    // SceneManager sm;

    public List<WildPokemon> allPokemon = new List<WildPokemon>();
    public List<PokemonMoves> allMoves = new List<PokemonMoves>();

    // private Transform defencePodium;
    // private Transform attackPodium;
    // public GameObject emptyPoke;

    private BattleManager bm;
    LongGrass lg;
    // private LongGrass lg;
    Player player;
    int i = 1;
    

    public GameObject menu;
    // private MenuController mc;

	void Start () {
        
        bm = GetComponent<BattleManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        
    }
	
	void Update () {
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

    public void EnterBattle()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Battle_Scene",LoadSceneMode.Additive);
    }

    public void ExitBattle() {
        SceneManager.UnloadSceneAsync("Battle_Scene");
        Time.timeScale = 1f;
    }

    public List<WildPokemon> GetPokemonByRarity(Rarity rarity)
    {
        
        List<WildPokemon> returnPokemon = new List<WildPokemon>();
        if(allPokemon != null) {
            foreach (WildPokemon Pokemon in allPokemon)
            {
                print("current run thru of GetByRarity: " + i);
                print(" : Rarity getPokemonByRarity: " + rarity);

                //------------------------Problem------------------------
                print("Pokemon  rarity:"+ Pokemon.pokemon.rarity);

                if (Pokemon.pokemon.rarity == rarity) {
                    //----------------------------------------------------
                    i = 0;
                    returnPokemon.Add(Pokemon);
                } else if(rarity == Rarity.Common) {
                    i++;
                    GetPokemonByRarity(Rarity.VeryCommon);
                } else if(rarity == Rarity.SemiRare) {
                    i++;
                    GetPokemonByRarity(Rarity.Common);
                } else if(rarity == Rarity.Rare) {
                    i++;
                    GetPokemonByRarity(Rarity.SemiRare);
                } else if(rarity == Rarity.VeryRare) {
                    i++;
                    GetPokemonByRarity(Rarity.SemiRare);
                }
            }
        }
        else {
            print("all pokemon is null");
            ExitBattle();
        }
        

        return returnPokemon;
        // for(int i = 0; i<lg.wildPokemon.count;i++) {

        // }
    }

    public WildPokemon GetRandomPokemonFromList(List<WildPokemon> pokeList)
    {
        WildPokemon poke = new WildPokemon();
        int pokeIndex = Random.Range(0, pokeList.Count - 1);
        poke = pokeList[pokeIndex];
        return poke;
    }
}

// [System.Serializable]
// public class PokemonMoves
// {
//     public string Name;
//     public MoveType category;
//     public Stat moveStat;
//     public PokemonType moveType;
//     public int currentPP;
//     public int PP;
//     public float power;
//     public float accuracy;

//     // public override string ToString()
//     // {
//     //     return Name + category + moveStat.maximum + moveType + PP;
//     // }
// }

// [System.Serializable]
// public class Stat
// {
//     public float minimum;
//     public float maximum;
// }

// public enum MoveType
// {
//     Physical,
//     Special,
//     Status
// }
