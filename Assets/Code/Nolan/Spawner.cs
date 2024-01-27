using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private GameObject[] _gameObjectList;
    [SerializeField]private GameObject _test;
    private GameObject _currentItem;

    void SpawnItem(){
        Instantiate(_currentItem, this.transform.position, Quaternion.identity);
    }

    void SpawnManager(){
        if(Item.isUsed)
        {
            Item.isUsed = false;
            Instantiate(_test, this.transform.position, Quaternion.identity);
        }
    }

    void Update(){
        SpawnManager();
    }
}
