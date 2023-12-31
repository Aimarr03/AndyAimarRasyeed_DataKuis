using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Pack 0", menuName ="Quiz Game/New Level Pack")]
public class LevelPack : ScriptableObject
{
    public string _LevelPackName;
    public int indexLevelPack;
    public QuestionData[] levelPack = new QuestionData[0];
    public bool terkunci;
    public int harga;

    public QuestionData GetQuestion(int index)
    {
        return levelPack[index];
    }
    public override string ToString()
    {
        return _LevelPackName;
    }
}
