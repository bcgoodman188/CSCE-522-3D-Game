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
}
