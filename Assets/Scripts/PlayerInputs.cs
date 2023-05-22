using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private Vector2 _movementDirection;

    public Vector2 MovementDirection => _movementDirection;

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && _movementDirection != Vector2.left)
        {
            _movementDirection = Vector2.right;
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && _movementDirection != Vector2.right)
        {
            _movementDirection = Vector2.left;
        }

        if (Input.GetAxisRaw("Vertical") > 0 && _movementDirection != Vector2.down)
        {
            _movementDirection = Vector2.up;
        }

        if (Input.GetAxisRaw("Vertical") < 0 && _movementDirection != Vector2.up)
        {
            _movementDirection = Vector2.down;
        }
    }
}