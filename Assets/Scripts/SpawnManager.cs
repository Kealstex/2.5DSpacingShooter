using System;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject tripleShotPowerUp;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private float enemySpawnTime; 
    private bool _stopSpawn = false;
    
    private float tripleShotSpawnTime = 7f;
    
    private float _maxYScreenPosition = 7f;
    private float _minXScreenPosition = -10f;
    private float _maxXScreenPosition = 10f;

    private void Start(){
        StartCoroutine(SpawnObjectRoutine(enemy, enemySpawnTime, enemyContainer));
        StartCoroutine(SpawnObjectRoutine(tripleShotPowerUp, tripleShotSpawnTime));
    }

    public void OnPlayerDeath(){
        _stopSpawn = true;
    }

    private Vector2 RandomTopSpawn(){
        var randomX = Random.Range(_minXScreenPosition, _maxXScreenPosition);
        return new Vector2(randomX, _maxYScreenPosition);
    }

    private IEnumerator SpawnObjectRoutine(GameObject obj, float spawnTime = 0f, GameObject parent = null ){
        while (!_stopSpawn){
            var position = RandomTopSpawn();
            
            var spawnObj = Instantiate(obj, position, Quaternion.identity);
            
            if (parent != null){
                spawnObj.transform.SetParent(parent.transform);
            }

            if (spawnTime == 0f){
                spawnTime = Random.Range(5f, 12f);
            }
            
            yield return new WaitForSeconds(spawnTime);
        }
    }
}