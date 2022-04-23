using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private int _value=0;

    private void Start(){
        if (uiManager == null)
            uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void Increase(){
        _value+=10;
        uiManager.UpdateScore(_value);
    }

    public int Get(){
        return _value;
    }
}