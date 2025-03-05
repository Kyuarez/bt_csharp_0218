using UnityEngine;


//�Է��̳� �ٸ� �̺�Ʈ�� ó���Ѵ�.
//���� ���� ������Ʈ�� �ٸ� ������Ʈ�� ����� ������.
//����� ������Ʈ�� �Ѱ��� �ϸ� �ؾ� �ȴ�.
public class PlayerController : MonoBehaviour
{
    MeshRenderer meshRenderer;

    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Rotate(new Vector3(v, 0, -h).normalized * rotationSpeed * Time.deltaTime);    
    }   
}
