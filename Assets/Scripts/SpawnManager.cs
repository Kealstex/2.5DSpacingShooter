
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private float enemySpawnTime; 
    [SerializeField] private GameObject[] powerUps;
    
    private bool _stopSpawn = false;
    
    private float _maxYScreenPosition = 7f;
    private float _minXScreenPosition = -10f;
    private float _maxXScreenPosition = 10f;

    private void Start(){
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpsRoutine());
    }

    public void OnPlayerDeath(){
        _stopSpawn = true;
    }

    private Vector2 RandomTopSpawn(){
        var randomX = Random.Range(_minXScreenPosition, _maxXScreenPosition);
        return new Vector2(randomX, _maxYScreenPosition);
    }

    private IEnumerator SpawnEnemyRoutine(){
        while (!_stopSpawn){
            var position = RandomTopSpawn();
            Instantiate(enemy, position, Quaternion.identity, enemyContainer.transform);
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    private IEnumerator SpawnPowerUpsRoutine(){
        while (!_stopSpawn){
            var powerUpId = Random.Range(0, 3);
            var powerUp = powerUps[powerUpId];
            var position = RandomTopSpawn();
            Instantiate(powerUp, position, Quaternion.identity);

            var nextSpawnTime = Random.Range(5f, 12f);
            yield return new WaitForSeconds(nextSpawnTime);
        }
    }
}