using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private int _currentScale = 1;

    public void Move(Vector3 input)
    {
        input.y = 0;
        transform.position += input * _moveSpeed * Time.deltaTime;
    }

    public void Flip(Vector3 input)
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
