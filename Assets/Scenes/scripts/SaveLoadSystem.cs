using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadSystem
{
    public static GameState gameState = null;
    private static BinaryFormatter formatter = new BinaryFormatter();
    private static string path = Application.persistentDataPath + "/save.dg";
    public static void Save(GameState state) {
        gameState = state;
        
        FileStream fs = new FileStream(path, FileMode.Create);
        formatter.Serialize(fs, state);
        fs.Close();
    }

    public static GameState load() {
        if (File.Exists(path)) {
            FileStream fs = new FileStream(path, FileMode.Open);
            gameState = formatter.Deserialize(fs) as GameState;
            fs.Close();
        }

        return gameState;
    }
}
