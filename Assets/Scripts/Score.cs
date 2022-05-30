using System;
using Managers;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private int _value=0;

    private void Start(){
        
        GlobalEventManager.OnEnemyKilled += Increase;
        
        if (uiManager == null)
            uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void Increase(){
        _value+=10;
        uiManager.UpdateScore(_value);
    }

    private void OnDestroy(){
        GlobalEventManager.OnEnemyKilled -= Increase;
    }
}