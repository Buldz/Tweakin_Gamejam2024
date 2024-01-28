using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjectList;
    private GameObject _currentGameObject;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    private GameObject _currentItem;
    private int I = 0;


    void SpawnItem()
    {
        _currentGameObject = _gameObjectList[I];
        StartCoroutine(timer());
        I++;
    }

    void SpawnManager()
    {
        if (Item.isUsed)
        {
            SpawnItem();
            Item.isUsed = false;
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(Random.Range(3, 10));
        _audioSource.PlayOneShot(_audioClips[0]);
        yield return new WaitForSeconds(Random.Range(1, 3));
        _audioSource.PlayOneShot(_audioClips[1]);
        Instantiate(_currentGameObject, this.transform.position, Quaternion.identity);
    }
    void Update()
    {
        SpawnManager();
    }
}
