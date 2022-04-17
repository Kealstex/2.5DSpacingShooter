using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int value;

    public void Damage(int damageValue){
        value -= damageValue;
        
        if(IsDeath())
            Destroy(gameObject);
    }

    private bool IsDeath(){
        return value < 1;
    }
}