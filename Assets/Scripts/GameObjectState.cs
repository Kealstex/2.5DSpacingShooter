using UnityEngine;

public class GameObjectState
{
    private GameObject _gameObject;
    public bool isActivated {
        get => _gameObject.activeSelf;
    }

    public GameObjectState(GameObject _gameObject){
        this._gameObject = _gameObject;
    }

    public void SetActive(bool isActive){
        _gameObject.SetActive(isActive);
    }
}