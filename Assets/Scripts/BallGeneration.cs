using UnityEngine;
using System;

public class BallGeneration : MonoBehaviour
{
    // Prefab que se va a generar
    [SerializeField] private GameObject ballPrefab;

    // Velocidad horizontal de la bola
    [SerializeField] private float ballSpeed = 5f;

    // Punto desde donde se genera la bola (sprite origen)
    [SerializeField] private Transform spawnPoint;

    //Evento que anuncia que la bola apareció
    public static Action<GameObject> OnBallSpawned;

    void Start()
    {
        GenerateBall();
    }
    public void GenerateBall()
    {
        // Elegir dirección aleatoria: -1 (izquierda) o 1 (derecha)
        int randomDirection = UnityEngine.Random.value < 0.5f ? -1 : 1;

        // Crear la bola en la posición del spawnPoint
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

        //Invocar evento de que la bola apareció
        OnBallSpawned?.Invoke(ball);

        // Obtener Rigidbody2D
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Asignar velocidad en X
            rb.linearVelocity = new Vector2(randomDirection * ballSpeed, 0f);
        }
        else
        {
            Debug.LogWarning("La bola no tiene Rigidbody2D");
        }
    }
}
