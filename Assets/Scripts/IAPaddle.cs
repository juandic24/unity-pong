using UnityEngine;

public class IAPaddle : MonoBehaviour
{
    [Header("References")]
    private Transform ballTransform;
    private Rigidbody2D ballRb;

    [Header("Difficulty")]
    public float speed = 5f;
    public float maxError = 0.5f;
    public float deadZone = 0.3f;

    [Header("Bounds")]
    [SerializeField] private float topLimit = 4f;
    [SerializeField] private float bottomLimit = -4f;

    [Header("Error Timing")]
    [SerializeField] private float errorUpdateTime = 0.5f;

    private float currentError;
    private float errorTimer;

    void OnEnable()
    {
        BallGeneration.OnBallSpawned += SetBall;
    }

    void OnDisable()
    {
        BallGeneration.OnBallSpawned -= SetBall;
    }

    public void SetBall(GameObject ballInstance)
    {
        ballTransform = ballInstance.transform;
        ballRb = ballInstance.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ballTransform == null || ballRb == null) return;

        // Ignore ball if it's moving away
        if (ballRb.linearVelocity.x < 0) return;

        // Update AI error periodically
        errorTimer -= Time.deltaTime;

        if (errorTimer <= 0f)
        {
            currentError = Random.Range(-maxError, maxError);
            errorTimer = errorUpdateTime;
        }

        float perceivedBallY = ballTransform.position.y + currentError;

        float diff = perceivedBallY - transform.position.y;

        if (Mathf.Abs(diff) < deadZone) return;

        float direction = Mathf.Sign(diff);

        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);

        // Clamp position to stay in bounds
        float clampedY = Mathf.Clamp(transform.position.y, bottomLimit, topLimit);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}