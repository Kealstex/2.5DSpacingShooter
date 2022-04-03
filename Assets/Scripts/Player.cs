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
    }

    public void OnMove(InputValue input)
    {
        var inputVec = input.Get<Vector2>();
        var xInput = inputVec.x * speed * Time.deltaTime;
        var yInput = inputVec.y * speed * Time.deltaTime;
        _direction = new Vector3(xInput, yInput,0 );
    }
}
