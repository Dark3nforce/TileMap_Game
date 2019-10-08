using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //variables to be saved
    public float[] position; //player position at time of save

    public PlayerData(Player player) {
        //converts vector3 into a serializable format
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}
