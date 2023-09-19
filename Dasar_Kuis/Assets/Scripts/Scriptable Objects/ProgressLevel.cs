using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "Player Progress", menuName = "Quiz Game/Create New Progress Data")]
public class ProgressLevel : ScriptableObject
{
    [System.Serializable]
    public struct DataProgress
    {
        public int koin;
        public Dictionary<string, int> levelPackProgress;
    }
    public DataProgress dataProgress = new DataProgress();

    public void SimpanProgress()
    {
        string fileName = "contoh.txt";
        string directory = Application.dataPath + "/Temporary/";
        string path = directory + fileName;

        dataProgress.koin = 200;

        if(dataProgress.levelPackProgress == null) dataProgress.levelPackProgress = new Dictionary<string, int>();

        dataProgress.levelPackProgress.Add("A", 3);
        dataProgress.levelPackProgress.Add("B", 1);
        dataProgress.levelPackProgress.Add("C", 5);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory Created : " + directory);
        }

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("file Created at: "+ path);
        }

        var FileStream = File.Open(path, FileMode.Open);
        var formatter = new BinaryFormatter();
        FileStream.Flush();
        formatter.Serialize(FileStream, dataProgress);
        /*
        var writer = new BinaryWriter(FileStream);

        writer.Write(dataProgress.koin);
        foreach(var i in dataProgress.levelPackProgress)
        {
            writer.Write(i.Key);
            writer.Write(i.Value);
        }

        writer.Dispose();
        */
        FileStream.Dispose();

        Debug.Log("Data berhasil dimasukkan ke dalam " + path);
    }
    public void MuatProgress()
    {

    }
}