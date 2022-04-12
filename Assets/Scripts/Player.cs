
using UnityEngine.InputSystem;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform laserTransform;
    [SerializeField] private float fireRate;
    private float _nextFire;
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

    public void OnFire(InputAction.CallbackContext input)
    {
        if (!(Time.time > _nextFire)) return;
        
        _nextFire = Time.time + fireRate;
        Instantiate(laserPrefab, laserTransform.position, Quaternion.identity);
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
        VerticalClamp();
        HorizontalTeleport();
    }

    private void VerticalClamp()
    {
        var position = transform.position;
        var y = Mathf.Clamp(position.y, -3.7f, 0f);
        position = new Vector3(position.x, y, 0f);
        transform.position = position;
    }

    private void HorizontalTeleport()
    {
        const float horizontalLimit = 11.27f;
        var position = transform.position;
        if (Mathf.Abs(position.x) > horizontalLimit)
            position.Set(-Mathf.Sign(position.x) * horizontalLimit, position.y, position.z);
        transform.position = position;
    } 

}
