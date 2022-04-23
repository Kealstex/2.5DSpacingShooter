using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    private int _value=0;

    public void Increase(){
        _value+=10;
        _uiManager.UpdateScore(_value);
    }

    public int Get(){
        return _value;
    }
}