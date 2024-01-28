using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjectList;
    private GameObject _currentGameObject;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private GameObject _fella;
    [SerializeField] private GameObject _vent;
    private bool _spawnedFella = false;
    private GameObject _currentItem;
    private int I = 0;


    void SpawnItem()
    {
        if (I < _gameObjectList.Length)
        {
            _currentGameObject = _gameObjectList[I];
            StartCoroutine(timer());
        }
        I++;
    }

    void SpawnManager()
    {
        if (Item.isUsed)
        {
            SpawnItem();
            Item.isUsed = false;
        }
        if (I == _gameObjectList.Length && !_spawnedFella)
        {
            _spawnedFella = true;
            Instantiate(_fella, new Vector3(0, 0.5f, -5), Quaternion.identity);
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(Random.Range(5, 16));
        _vent.GetComponent<Renderer>().material.color = Color.black;
        _audioSource.PlayOneShot(_audioClips[0]);
        yield return new WaitForSeconds(Random.Range(1, 3));
        _vent.GetComponent<Renderer>().material.color = Color.white;
        _audioSource.PlayOneShot(_audioClips[1]);
        Instantiate(_currentGameObject, this.transform.position, Quaternion.identity);
    }
    void Update()
    {
        SpawnManager();
    }

    void Start()
    {
        SpawnItem();
    }
}
