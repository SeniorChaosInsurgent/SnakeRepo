using UnityEngine;
using System;

public class SnakeMovement : MonoBehaviour
{
    public static event Action OnFoodCollect;
    public static event Action<int> OnStep;
    public static event Action OnPlayerDeath;

    public int Length => _length;

    private Vector2 _movementDirection;

    [SerializeField] private float _stepCooldown;
    [SerializeField] private GameObject _tail;

    private int _length;
    private float _timeSinceLastStep;
    private float _step = 0.5f;

    private PlayerInputs _playerInputs;

    private Vector3 _currentPosition;
        
    private Rigidbody2D _rb2D;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _playerInputs = GetComponent<PlayerInputs>();
    }

    private void Update()
    {
        _timeSinceLastStep += Time.deltaTime;
        _currentPosition = transform.position;
    }

    private void FixedUpdate()
    {
        _movementDirection = _playerInputs.MovementDirection;

        if (_rb2D != null)
        {
            if (_timeSinceLastStep >= _stepCooldown)
            {
                _timeSinceLastStep = 0;
                _rb2D.position += _movementDirection * _step;
                Instantiate(_tail, _currentPosition, Quaternion.Euler(0, 0, 0));
                OnStep?.Invoke(_length);
            }
        }
        else
        {
            _rb2D = GetComponent<Rigidbody2D>();
            Debug.LogWarning("No Rigidbody Present");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            _length++;
            OnFoodCollect?.Invoke();
        }
        if (collision.CompareTag("Player"))
        {
            OnPlayerDeath?.Invoke();
            Time.timeScale = 0;
        }
    }
}