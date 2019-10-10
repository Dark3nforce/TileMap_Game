using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();
    public int sceneIndex;
    

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
        SceneManager.LoadScene(data.sceneIndex);
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
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
