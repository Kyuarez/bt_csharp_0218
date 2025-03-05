using UnityEngine;

public class TKMissile : MonoBehaviour
{
    private float moveSpeed = 50f;
    private float destroyTime = 10f;

    private void OnEnable()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }
}
