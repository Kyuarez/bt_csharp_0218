using UnityEngine;

public class TKBomb : MonoBehaviour
{
    private float moveSpeed = 10f;
    private float destroyTime = 10f;

    private void OnEnable()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}
