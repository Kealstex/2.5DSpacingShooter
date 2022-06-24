
using System;
using System.Collections;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] [Range(1,3)] private int damage;

    private static readonly int OnDeath = Animator.StringToHash("onDeath");

    // Update is called once per frame
    private void Update(){
        Move();
        if (transform.position.y < -5f)
            TeleportToUp();
    }

    private void OnTriggerEnter2D(Collider2D other){
        switch (other.tag){
            case "Player":
                other.GetComponent<Health>().Damage(damage);
                Death();
                break;
            case "Laser":
                Destroy(other.gameObject);
                Death();
                break;
        }
    }

    private void Death(){
        var animator = GetComponent<Animator>();
        animator.SetTrigger(OnDeath);
        GlobalEventManager.SendEnemyKilled();
        Destroy(gameObject,1.4f );
    }

    private void Move(){
        var move = Vector2.down * Time.deltaTime * speed;
        transform.Translate(move);
    }

    private void TeleportToUp(){
        var randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7f, 0f);
    }
}
