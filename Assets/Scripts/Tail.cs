using UnityEngine;

public class Tail : MonoBehaviour
{
    private float _stepsPassed;

    private void Awake()
    {
        SnakeMovement.OnStep += IndexCalculation;
    }
    private void IndexCalculation(int length)
    {
        _stepsPassed++;

        if (_stepsPassed >= length + 1)
        {
            SnakeMovement.OnStep -= IndexCalculation;
            Destroy(gameObject);
        }
    }
}