using UnityEngine;

public class TKCharacterMovement : MonoBehaviour
{
    float moveSpeed = 4.0f;
    float rotationSpeed = 360.0f;


    void Start()
    {
        
    }

    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.forward * v * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * h * rotationSpeed * Time.deltaTime);
    }
}
