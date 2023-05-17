using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 _movementDirection;

    [SerializeField] private float _speed;

    private PlayerInputs _playerInputs;

    private Rigidbody2D _rb2D;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _playerInputs = GetComponent<PlayerInputs>();
    }

    private void FixedUpdate()
    {
        _movementDirection = _playerInputs.MovementDirection;

        if (_rb2D != null)
        {
            _rb2D.position += _movementDirection * _speed;
            Debug.Log(_movementDirection);
        }
        else
        {
            _rb2D = GetComponent<Rigidbody2D>();
            Debug.LogWarning("No Rigidbody Present");
        }
    }
}