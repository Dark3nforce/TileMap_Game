using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();
    public int sceneIndex;
    public Time timeplayed;
    public string player_Name;
    public int numBadges;
    public int numPokemonOwned;
    

	void Start () {
        // sceneIndex = Scene.buildIndex();
        // OwnedPokemon p1 = new OwnedPokemon();
        // p1.level = 3;
        // p1.NickName = "Bob";
        // p1.basePokemonID = 17;

        // PokemonMoves pMove = new PokemonMoves();

        // pMove.accuracy = 1;
        // pMove.category = MoveType.Physical;
        // pMove.moveStat = new Stat();
        // pMove.moveStat.minimum = 2;
        // pMove.moveStat.maximum = 5;
        // pMove.moveType = PokemonType.Dark;
        // pMove.power = 2;
        // pMove.PP = 3;
        // p1.moves.Add(pMove);

        // pMove = new PokemonMoves();
        // pMove.accuracy = 2;
        // pMove.category = MoveType.Status;
        // pMove.moveStat = new Stat();
        // pMove.moveStat.minimum = 12;
        // pMove.moveStat.maximum = 15;
        // pMove.moveType = PokemonType.Dragon;
        // pMove.power = 12;
        // pMove.PP = 13;
        // p1.moves.Add(pMove);

        // ownedPokemon.Add(p1);

        // OwnedPokemon p2 = new OwnedPokemon();
        // p2.level = 7;
        // p2.NickName = "Lisa";
        // p2.basePokemonID = 27;
        // ownedPokemon.Add(p2);
	}
	
	void Update () {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        if(SceneManager.GetActiveScene().buildIndex == data.sceneIndex) {
            transform.position = position;
        } else {
            SceneManager.LoadScene(data.sceneIndex);    
            transform.position = position;
        }
    }
    
}

[System.Serializable]
public class OwnedPokemon
{
    public string NickName;

    //do not serailize this field, instead load it with ID
    // [System.NonSerialized] public BasePokemon pokemon; 
    [System.NonSerialized]
    public BasePokemon pokemon; 
    // pokemon = 
    // public int health = pokemon.HP;
    public int basePokemonID;

    public int level;
    public List<PokemonMoves> moves = new List<PokemonMoves>();

    public override string ToString()
    {
        string s = NickName + " PokID: " + basePokemonID + " Level: " + level;

        foreach (PokemonMoves pm in moves)
        {
            s += ", " + pm;
        }
        return s;
    }
}
