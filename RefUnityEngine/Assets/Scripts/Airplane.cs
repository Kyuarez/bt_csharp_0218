using UnityEngine;

public class Airplane : MonoBehaviour
{
    private float moveSpeed = 3.0f;
    private float rotationSpeed = 60.0f;

    private void Awake()
    {
                
    }

    private void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        //transform.position += transform.up * v * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.Self);
        transform.eulerAngles += transform.forward * -h * rotationSpeed * Time.deltaTime;
    }
}
