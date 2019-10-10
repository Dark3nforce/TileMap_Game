using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BagInventoryData
{
    //variables to be saved
    // public float[] position; //player position at time of save
    // public int sceneIndex;
    // public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();

    public BagInventoryData(BagInventory inv) {
        //converts vector3 into a serializable format
        // position = new float[3];
        // position[0] = player.transform.position.x;
        // position[1] = player.transform.position.y;
        // position[2] = player.transform.position.z;

        // //current scene
        // sceneIndex = player.sceneIndex;
    }
}
