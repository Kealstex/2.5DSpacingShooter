using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private SpawnManager spawnManager;

    public void Damage(int damageValue){
        
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