using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform target;
    private float rotateSpeed = 3.0f;

    Vector3 currentVelocity;
    Quaternion currentQ; 
    float smoothTime = 0.3f;
    float angleSmoothTime = 0.3f;
    //float maxSpeed = 3.0f;

    public bool isPositionRag = false;
    public bool isRotationRag = false;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (isPositionRag)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref currentVelocity, smoothTime);
        }
        else
        {
            transform.position = target.position;
        }   

        if (isRotationRag)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotateSpeed * Time.deltaTime);
        }
        //transform.rotation = SmoothDamp(transform.rotation, target.rotation, ref currentQ, angleSmoothTime);

        //Input.mousePositionDelta
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(Input.mousePositionDelta.y * -1, Input.mousePositionDelta.x, 0) * 360.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.C))
        {
            Quaternion resetQ = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, resetQ, 60.0f * Time.deltaTime);
        }

        float wheelDelta = Input.GetAxisRaw("Mouse ScrollWheel");
        Vector3 moveDirection = target.position - Camera.main.transform.position;
        Camera.main.transform.Translate(moveDirection.normalized * Time.deltaTime * wheelDelta * 200.0f);
    }

    public static Quaternion SmoothDamp(Quaternion rot, Quaternion target, ref Quaternion deriv, float time)
    {
        if (Time.deltaTime < Mathf.Epsilon) return rot;
        // account for double-cover
        var Dot = Quaternion.Dot(rot, target);
        var Multi = Dot > 0f ? 1f : -1f;
        target.x = Multi;
        target.y = Multi;
        target.z = Multi;
        target.w = Multi;
        // smooth damp (nlerp approx)
        var Result = new Vector4(
            Mathf.SmoothDamp(rot.x, target.x, ref deriv.x, time),
            Mathf.SmoothDamp(rot.y, target.y, ref deriv.y, time),
            Mathf.SmoothDamp(rot.z, target.z, ref deriv.z, time),
            Mathf.SmoothDamp(rot.w, target.w, ref deriv.w, time)
        ).normalized;

        // ensure deriv is tangent
        var derivError = Vector4.Project(new Vector4(deriv.x, deriv.y, deriv.z, deriv.w), Result);
        deriv.x -= derivError.x;
        deriv.y -= derivError.y;
        deriv.z -= derivError.z;
        deriv.w -= derivError.w;

        return new Quaternion(Result.x, Result.y, Result.z, Result.w);
    }
}
