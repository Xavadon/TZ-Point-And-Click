using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private TransformMovement _transformMovement;
    
    private PlayerControls _playerControls;
    private Vector2 _playerInput => _playerControls.Player.Move.ReadValue<Vector2>();

    private void Awake()
    {
        if (_transformMovement == null) _transformMovement = GetComponent<TransformMovement>();

        _playerControls = new PlayerControls();
        _playerControls.Enable();
    }

    private void Update()
    {
        _transformMovement.Move(_playerInput);
        _transformMovement.Flip(_playerInput);
    }
}