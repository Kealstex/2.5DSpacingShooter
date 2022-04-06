using UnityEngine.InputSystem;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Vector2 m_Move;
    
    // Update is called once per frame
    public void Update()
    {
        Move(m_Move);
        PositionClamp();
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        m_Move = input.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        if(direction.sqrMagnitude < 0.1f)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        var move = direction * scaledMoveSpeed;
        transform.position += new Vector3(move.x, move.y, 0);
    }

    private void PositionClamp()
    {
        var position = transform.position;
        var x = Mathf.Clamp(position.x, -9f, 9f);
        var y = Mathf.Clamp(position.y, -3.7f, 0f);
        position = new Vector3(x, y, 0f);
        transform.position = position;
    }
}
