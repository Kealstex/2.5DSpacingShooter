using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private UIManager uiManager;

    private Player _player;

    private void Start(){
        _player = GetComponent<Player>();
        if (spawnManager == null)
            spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (uiManager == null)
            uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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
        uiManager.UpdateLives(value);

        if (IsDeath()){
            spawnManager.OnPlayerDeath();
            uiManager.ShowGameOver();
            _player.Death();
        }
    }

    private bool IsDeath(){
        return value < 1;
    }
}