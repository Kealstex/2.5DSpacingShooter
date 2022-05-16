
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] [Range(1,3)] private int damage;

    private Score _score;
    private static readonly int OnDeath = Animator.StringToHash("onDeath");

    private void Start(){
        _score = GameObject.FindWithTag("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update(){
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
        _score.Increase();
        var animator = GetComponent<Animator>();
        animator.SetTrigger(OnDeath);
        StartCoroutine(DestroyAfterAnim(1.4f));
    }

    private IEnumerator DestroyAfterAnim(float animationLifetime){
        yield return new WaitForSeconds(animationLifetime);
        Destroy(gameObject);
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
