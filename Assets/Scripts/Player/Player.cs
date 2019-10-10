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
    public BasePokemon pokemon;
    public int level;
    public List<PokemonMoves> moves = new List<PokemonMoves>();
}
