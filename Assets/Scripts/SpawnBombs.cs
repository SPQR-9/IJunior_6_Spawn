using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpawnBombs : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private GameObject _bombPrafab;
    private Transform[] _points;

    private void Awake()
    {
        _points = new Transform[_spawnPoints.childCount];
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnBombsEveryTime());
    }

    private IEnumerator SpawnBombsEveryTime()
    {
        int randIndex;
        while (true)
        {
            yield return new WaitForSeconds(_timeSpawn);
            randIndex = Random.Range(0, _spawnPoints.childCount);
            Instantiate(_bombPrafab, _points[randIndex]);
        }
    }
}
