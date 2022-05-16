
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject tripleLaserPrefab;
    [SerializeField] private Transform bulletsSpawn;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject shieldsVisualizer;
    [SerializeField] private PlayerInput inputSystem;
    private List<GameObjectState> damageFireActivated = new List<GameObjectState>();
    
    private InputAction _restartAction;
    private float _speedMultiplier = 2f;
    private GameObject _bullets;
    private bool _hasShield;

    private float _nextFire;
    private Vector2 _moveInput;


    public void Start(){
        _bullets = laserPrefab;
        
        _restartAction = inputSystem.actions.FindAction("Restart", true);
        _restartAction.Disable();
        
        var hurtFireGameobjects =  GameObject.FindGameObjectsWithTag("HurtFire");
        for (var ind=0; ind < hurtFireGameobjects.Length; ind++){
            var hurtFire = hurtFireGameobjects[ind];
            damageFireActivated.Add(new GameObjectState(hurtFire));
            hurtFire.SetActive(false);
        }
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

    public void OnRestart(InputAction.CallbackContext input){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Death(){
        
        //Disable all actions , except for restart
        inputSystem.actions.Disable();
        _restartAction.Enable();
        
        DisablePlayerVisualization();
    }

    public void ActivateTripleShot(){
        _bullets = tripleLaserPrefab;
        StartCoroutine(DisableTripleShot(5f));
    }

    public void IncreaseSpeed(){
        moveSpeed *= _speedMultiplier;
        StartCoroutine(DecreaseSpeed(5f));
    }

    public void ActivateShields(){
        shieldsVisualizer.SetActive(true);
        _hasShield = true;
    }

    public void DisableShields(){
        shieldsVisualizer.SetActive(false);
        _hasShield = false;
    }

    public bool HasShields(){
        return _hasShield;
    }

    public void VisualizeDamageFire(){
        var activateFireInd = Random.Range(0, 2);
        if (damageFireActivated[activateFireInd].isActivated){
            activateFireInd = activateFireInd == 0 ? 1 : 0;
        }
        damageFireActivated[activateFireInd].SetActive(true);
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
    
    private IEnumerator DisableTripleShot(float lifetimeSeconds){
        yield return new WaitForSeconds(lifetimeSeconds);
        _bullets = laserPrefab;
    }
    private IEnumerator DecreaseSpeed(float lifetimeSeconds){
        yield return new WaitForSeconds(lifetimeSeconds);
        moveSpeed /= _speedMultiplier;
    }

    private void DisablePlayerVisualization(){
        GetComponent<SpriteRenderer>().sprite = null;
        foreach (var hurtFire in damageFireActivated){
            hurtFire.SetActive(false);
        }
        GameObject.Find("Thruster").SetActive(false);
    }
    

}
