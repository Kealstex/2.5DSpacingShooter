
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] [Range(1,3)] private int damage;

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
                Destroy(gameObject);
                break;
            case "Laser":
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
        }
    }

    private void Move(){
        var move = Vector3.down * Time.deltaTime * speed;
        transform.Translate(move);
    }

    private void TeleportToUp(){
        var randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7f, 0f);
    }
}
