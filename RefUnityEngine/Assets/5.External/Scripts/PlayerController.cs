using UnityEngine;


//입력이나 다른 이벤트를 처리한다.
//현재 게임 오브젝트에 다른 컴포넌트에 명령을 내린다.
//사용자 컴포넌트는 한가지 일만 해야 된다.
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
