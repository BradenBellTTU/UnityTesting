using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of movement

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.position += movement * speed * Time.deltaTime;
    }
}