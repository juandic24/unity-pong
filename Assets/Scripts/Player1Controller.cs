using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    // Límites verticales
    [SerializeField] private float minY = -3f;
    [SerializeField] private float maxY = 3f;

    void Update()
    {
        MoveVertical();
    }

    void MoveVertical()
    {
        float verticalInput = 0f;

        if (Keyboard.current.wKey.isPressed)
            verticalInput = 1f;
        else if (Keyboard.current.sKey.isPressed)
            verticalInput = -1f;

        Vector3 newPosition = transform.position;
        newPosition.y += verticalInput * moveSpeed * Time.deltaTime;

        // 🔒 Limitar movimiento
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
}
