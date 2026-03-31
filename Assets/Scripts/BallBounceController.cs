using UnityEngine;

public class BallBounceController : MonoBehaviour
{
    [Header("Speed Settings")]
    [SerializeField] private float initialSpeed = 6f;
    [SerializeField] private float speedIncreasePerHit = 0.5f;
    [SerializeField] private float maxSpeed = 12f;

    [Header("Bounce Settings")]
    [SerializeField] private float maxBounceAngle = 75f;
    [SerializeField] private float minVerticalInfluence = 0.2f;

    private float currentSpeed;
    private Vector2 direction;

    void Start()
    {
        ResetBall();
    }

    void Update()
    {
        transform.position += (Vector3)(direction * currentSpeed * Time.deltaTime);
    }

    public void ResetBall()
    {
        currentSpeed = initialSpeed;

        float dirX = Random.value < 0.5f ? -1f : 1f;
        float dirY = Random.Range(-0.5f, 0.5f);

        direction = new Vector2(dirX, dirY).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IncreaseSpeed();
            BounceFromPaddle(collision.transform);
        }
        else if (collision.gameObject.CompareTag("TopWall") ||
                 collision.gameObject.CompareTag("BottomWall"))
        {
            direction.y *= -1f;
            direction = EnforceMinimumVertical(direction);
        }
    }

    void IncreaseSpeed()
    {
        currentSpeed += speedIncreasePerHit;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
    }

    void BounceFromPaddle(Transform paddle)
    {
        float hitOffset = transform.position.y - paddle.position.y;
        float paddleHeight = paddle.GetComponent<Collider2D>().bounds.size.y;

        float normalizedOffset = Mathf.Clamp(hitOffset / (paddleHeight / 2f), -1f, 1f);

        float bounceAngle = normalizedOffset * maxBounceAngle * Mathf.Deg2Rad;

        float dirX = transform.position.x < paddle.position.x ? -1f : 1f;

        direction = new Vector2(
            dirX * Mathf.Cos(bounceAngle),
            Mathf.Sin(bounceAngle)
        );

        direction = EnforceMinimumVertical(direction);
        direction.Normalize();
    }

    Vector2 EnforceMinimumVertical(Vector2 dir)
    {
        if (Mathf.Abs(dir.y) < minVerticalInfluence)
        {
            dir.y = minVerticalInfluence * Mathf.Sign(dir.y == 0 ? 1 : dir.y);
        }

        return dir.normalized;
    }
}