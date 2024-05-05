using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private PlayerControls _playerControls;
    private int _currentScale = 1;
    private Vector2 _playerInput => _playerControls.Player.Move.ReadValue<Vector2>();

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
    }

    private void Update()
    {
        Move(_playerInput);
        Flip(_playerInput);
    }

    private void Move(Vector3 input)
    {
        input.y = 0;
        transform.position += input * _moveSpeed * Time.deltaTime;
    }

    private void Flip(Vector3 input)
    {
        if (input.x > 0)
        {
            _currentScale = 1;
        }
        else if(input.x < 0)
        {
            _currentScale = -1;
        }

        transform.localScale = new Vector3(_currentScale, 1, 1);
    }
}
