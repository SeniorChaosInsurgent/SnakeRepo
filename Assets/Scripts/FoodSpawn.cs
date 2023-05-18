using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    private readonly float[] _possibleXPositions =
        {
            -4.75f,-4.25f,-3.75f,-3.25f,-2.75f,-2.25f,-1.75f,-1.25f,-0.75f,-0.25f,0.25f,0,75f,1.25f,1.75f,2.25f,2.75f,3.25f,3.75f,4.25f,4.75f
        };
    private readonly float[] _possibleYPositions =
        {
            -4.75f,-4.25f,-3.75f,-3.25f,-2.75f,-2.25f,-1.75f,-1.25f,-0.75f,-0.25f,0.25f,0,75f,1.25f,1.75f,2.25f,2.75f,3.25f,3.75f,4.25f,4.75f
        };

    private void Awake()
    {    
        SnakeMovement.OnFoodCollect += FoodPositionUpdater;
        FoodPositionUpdater();
    }

    private void FoodPositionUpdater()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.position = new Vector2
        (
            _possibleXPositions[Random.Range(0, _possibleXPositions.Length)],
            _possibleYPositions[Random.Range(0, _possibleYPositions.Length)]
        );
    }
}