using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(Player player) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream,data);
        stream.Close();
        Debug.Log("Saved");
    }

    public static PlayerData LoadPlayer() {
        string path = Application.persistentDataPath + "/Player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("Loaded");
            return data;
        } else {
            Debug.Log("Save file not found in "+ path);
            return null;
        }
    }

    public static void SaveInventory(BagInventory inv) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Inventory.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        BagInventoryData data = new BagInventoryData(inv);

        formatter.Serialize(stream,data);
        stream.Close();
        Debug.Log("Saved");
    }

    public static BagInventoryData LoadInventory() {
        string path = Application.persistentDataPath + "/Inventory.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            BagInventoryData data = formatter.Deserialize(stream) as BagInventoryData;
            stream.Close();
            Debug.Log("Loaded");
            return data;
        } else {
            Debug.Log("Save file not found in "+ path);
            return null;
        }
    }
}
