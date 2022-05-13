using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 30f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject explosion;

    void Update(){
        Moving();
        Rotating();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Laser"){
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void Rotating(){
        var perFrameRotate = rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * perFrameRotate);
    }

    private void Moving(){
        var perFrameMove = moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * perFrameMove, Space.World);
    }
}
