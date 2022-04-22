
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float speed;
    
    //0 - TripleShot
    //1 - Speed
    //2 - Shields
    [SerializeField] private int powerupID;

    private void Start(){
        var randomX = Random.Range(-7f,7f);
        var position = transform.position;
        position.Set(randomX, position.y, position.z);
    }

    void Update()
    {
        Move();
        
        if (transform.position.y < -8f){
            Destroy(gameObject);
        }
    }

    private void Move(){
        var direction = Vector2.down * speed * Time.deltaTime;
        transform.Translate(direction);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            
            switch (powerupID){
                case 0:
                    other.GetComponent<Player>().ActivateTripleShot();
                    break;
                case 1:
                    other.GetComponent<Player>().IncreaseSpeed();
                    break;
                case 2:
                    other.GetComponent<Player>().ActivateShields();
                    break;
            }

            Destroy(gameObject);
        }
    }
}
