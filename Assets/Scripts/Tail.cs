using UnityEngine;

public class Tail : MonoBehaviour
{
    private float _stepsPassed;

    private void Awake()
    {
        SnakeMovement.OnStep += IndexCalculation;
        SnakeMovement.OnPlayerDeath += Death;
    }

    private void IndexCalculation(int length)
    {
        _stepsPassed++;

        if (_stepsPassed > 0)
        {
            GetComponent<Collider2D>().enabled = true;
        }

        if (_stepsPassed > length)
        {
            Destroy(gameObject);
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        SnakeMovement.OnStep -= IndexCalculation;
        SnakeMovement.OnPlayerDeath -= Death;
    }
}