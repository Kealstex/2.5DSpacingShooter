using UnityEngine.InputSystem;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 _direction;
    
    // Update is called once per frame
    public void Update()
    {
        transform.Translate(_direction);
        var x = Mathf.Clamp(transform.position.x, -9f, 9f);
        var y = Mathf.Clamp(transform.position.y, -3.7f, 0f);
        transform.position = new Vector3(x, y, 0f);
    }

    public void OnMove(InputValue input)
    {
        var inputVec = input.Get<Vector2>() * speed * Time.deltaTime;
        _direction = new Vector3(inputVec.x, inputVec.y,0 );
    }
}
