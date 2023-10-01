using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelPackManager : MonoBehaviour
{
    [SerializeField] private List<LevelPack> _ListLevelPack;
    [SerializeField] private Transform _LevelPackContainer;
    [SerializeField] private Transform _LevelPackButtonFormat;
    private string _HeadLineText;
    public void Awake()
    {
        _LevelPackButtonFormat.gameObject.SetActive(false);
        foreach(Transform child in _LevelPackContainer)
        {
            if(child != _LevelPackButtonFormat)
            {
                GameObject.Destroy(child);
            }
        }
        foreach(LevelPack levelPack in _ListLevelPack)
        {
            Transform currentLevelpPack = Instantiate(_LevelPackButtonFormat, _LevelPackContainer);
            currentLevelpPack.gameObject.TryGetComponent<Level_Pack_UI>(out Level_Pack_UI _levelPackUI);
            _levelPackUI._SetLevelPack(levelPack);
            currentLevelpPack.gameObject.SetActive(true);
        }
    }
}