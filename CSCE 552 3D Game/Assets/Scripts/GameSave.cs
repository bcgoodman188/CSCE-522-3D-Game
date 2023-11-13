using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class GameSave
{
    public static void SavePlayer(PlayerMove player) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveGun(VacuumGun gun) {
        BinaryFormatter formatter = new BinaryFormatter();
        string gunPath = Application.persistentDataPath + "/vacuumgun.txt";
        FileStream gunStream = new FileStream(gunPath, FileMode.Create);

        VacuumData gunData = new VacuumData(gun);

        formatter.Serialize(gunStream, gunData);
        gunStream.Close();
    }

    public static void SaveGameState(GameManager game) {
        BinaryFormatter formatter = new BinaryFormatter();
        string gamePath = Application.persistentDataPath + "/gamestate.txt";
        FileStream gameStream = new FileStream(gamePath, FileMode.Create);

        GameData gameData = new GameData(game);

        formatter.Serialize(gameStream, gameData);
        gameStream.Close();
    }

    public static PlayerData LoadPlayer() {
        string path = Application.persistentDataPath + "/player.txt";
        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
    public static VacuumData LoadGun() {
        string gunPath = Application.persistentDataPath + "/vacuumgun.txt";
        if(File.Exists(gunPath)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream gunStream = new FileStream(gunPath, FileMode.Open);

            VacuumData gunData = formatter.Deserialize(gunStream) as VacuumData;
            gunStream.Close();

            return gunData;
        }
        else {
            Debug.Log("Save file not found in " + gunPath);
            return null;
        }
    }
    public static GameData LoadGameState() {
        string gamePath = Application.persistentDataPath + "/gamestate.txt";
        if(File.Exists(gamePath)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream gameStream = new FileStream(gamePath, FileMode.Open);

            GameData gameData = formatter.Deserialize(gameStream) as GameData;
            gameStream.Close();

            return gameData;
        }
        else {
            Debug.Log("Save file for game data not found in" + gamePath);
            return null;
        }
    }
}
