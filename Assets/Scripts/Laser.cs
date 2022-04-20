using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed;

    public void Update(){
        UpMoving();
        DestroyInvisibleLaser();
    }

    private void UpMoving(){
        var direction = Vector3.up * speed * Time.deltaTime;
        transform.Translate(direction);
    }

    private void DestroyInvisibleLaser(){
        if (transform.position.y > 7.75f){
            if (transform.parent != null){
               Destroy(transform.parent.gameObject); 
            }
            Destroy(gameObject);
        }
    }
}