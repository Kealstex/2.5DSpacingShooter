using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private float spawnTime;
    private bool _stopSpawn = false;

    private void Start(){
        StartCoroutine(SpawnRoutine());
    }

    public void OnPlayerDeath(){
        _stopSpawn = true;
    }

    private IEnumerator SpawnRoutine(){
        while (!_stopSpawn){
            var randomX = Random.Range(-10f, 10f);
            var position = new Vector3(randomX, 7f, 0f);
            Instantiate(enemy, position, Quaternion.identity, enemyContainer.transform);
            
            yield return new WaitForSeconds(spawnTime);
        }
    }
}