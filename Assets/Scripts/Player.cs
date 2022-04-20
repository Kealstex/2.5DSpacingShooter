
using UnityEngine.InputSystem;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject tripleLaserPrefab;
    [SerializeField] private Transform bulletsSpawn;
    [SerializeField] private float fireRate;

    private bool isTrippleShotActive = false;

    private GameObject _bullets;
    private float _nextFire;
    private Vector2 _moveInput;

    public void Start(){
        _bullets = laserPrefab;
    }

    // Update is called once per frame
    public void Update(){
        Move(_moveInput);
        PositionClamp();
    }

    public void OnMove(InputAction.CallbackContext input){
        _moveInput = input.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext input){
        if (!(Time.time > _nextFire)) return;

        _nextFire = Time.time + fireRate;
        Instantiate(_bullets, bulletsSpawn.position, Quaternion.identity);
    }

    public void OnChangeMode(InputAction.CallbackContext input){
        if (isTrippleShotActive){
            DisableTripleShot();
            isTrippleShotActive = false;
        }
        else{
            ActivateTripleShot();
            isTrippleShotActive = true;
        }
            
    }

    private void Move(Vector2 direction){
        if (direction.sqrMagnitude < 0.1f)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        var move = direction * scaledMoveSpeed;
        transform.position += new Vector3(move.x, move.y, 0);
    }

    private void PositionClamp(){
        VerticalClamp();
        HorizontalTeleport();
    }

    private void VerticalClamp(){
        var position = transform.position;
        var y = Mathf.Clamp(position.y, -3.7f, 0f);
        position = new Vector3(position.x, y, 0f);
        transform.position = position;
    }

    private void HorizontalTeleport(){
        const float horizontalLimit = 11.27f;
        var position = transform.position;
        if (Mathf.Abs(position.x) > horizontalLimit)
            position.Set(-Mathf.Sign(position.x) * horizontalLimit, position.y, position.z);
        transform.position = position;
    }


    public void ActivateTripleShot(){
        _bullets = tripleLaserPrefab;
    }

    private void DisableTripleShot(){
        _bullets = laserPrefab;
    }

}
