using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //variables to be saved
    public float[] position; //player position at time of save
    public int sceneIndex;
    public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();

    public PlayerData(Player player) {
        //converts vector3 into a serializable format
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        //current scene
        sceneIndex = player.sceneIndex;

        foreach(OwnedPokemon op in player.ownedPokemon) {
            ownedPokemon.Add(op);
        }
        
    }

    public override string ToString() {
        string s = "PlayerData ";
        s += "Position: (" + position[0] + ", " + position[1] + ", " + position[2] + ") ";
        s += "Scene Index: " + sceneIndex + "|";
        foreach(OwnedPokemon op in ownedPokemon) {
            s += op + "|";
        }
        return s;
    }

}
