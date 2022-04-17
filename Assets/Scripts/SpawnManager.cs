using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private void Start(){
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine(){
        for (;;){
            var randomX = Random.Range(-10f, 10f);
            var position = new Vector3(randomX, 7f,0f);
            var newEnemy= Instantiate(enemy, position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}