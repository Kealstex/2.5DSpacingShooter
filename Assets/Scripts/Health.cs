using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private SpawnManager spawnManager;

    private Player _player;

    private void Start(){
        _player = GetComponent<Player>();
    }

    private bool HasShields(){
        return _player.HasShields();
    }

    public void Damage(int damageValue){
        if (HasShields()){
            _player.DisableShields();
            return;
        }
        value -= damageValue;

        if (IsDeath()){
            spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    private bool IsDeath(){
        return value < 1;
    }
}