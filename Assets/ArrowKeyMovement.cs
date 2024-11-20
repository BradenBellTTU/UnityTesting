using UnityEngine;
using TMPro;

public class ArrowKeyMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject circlePrefab; // Reference to the circle prefab
    public Camera mainCamera; // Reference to the main camera

    void Start()
    {
        UpdateScoreText();
        SpawnNewCircle();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.position += movement * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            score++;
            Destroy(other.gameObject);
            UpdateScoreText();
            SpawnNewCircle();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void SpawnNewCircle()
    {
        Vector3 spawnPosition = GetRandomPositionWithinCamera();
        Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomPositionWithinCamera()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float x = Random.Range(mainCamera.transform.position.x - cameraWidth / 2, mainCamera.transform.position.x + cameraWidth / 2);
        float y = Random.Range(mainCamera.transform.position.y - cameraHeight / 2, mainCamera.transform.position.y + cameraHeight / 2);

        return new Vector3(x, y, 0);
    }
}