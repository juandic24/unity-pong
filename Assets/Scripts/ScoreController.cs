using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private bool isLeftWall; // ¿esta pared pertenece al jugador izquierdo?
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos que sea la pelota
        if (other.CompareTag("Ball"))
        {
            // 1. Destruir la pelota
            Destroy(other.gameObject);

            // 2. Sumar punto al jugador correcto
            if (isLeftWall)
            {
                gameManager.AddPointToRightPlayer();
            }
            else
            {
                gameManager.AddPointToLeftPlayer();
            }

            // 3. Volver a sacar la pelota desde el centro
            gameManager.SpawnBall();
        }
    }
}
