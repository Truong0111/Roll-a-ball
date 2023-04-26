using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SaveScore(GameController gc)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(gc);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveScore(MenuController mc)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(mc);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ScoreData LoadScore()
    {
        string path = Application.persistentDataPath + "/score.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not find" + path);
            return null;
        }
    }
}
