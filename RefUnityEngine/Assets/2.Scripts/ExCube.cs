using UnityEngine;

public class ExCube : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private Material mat;

    private float elapsedTime = 0;
    private float sign = 1;

    public AnimationCurve moveCurve;
    public AnimationCurve rotateCurve;
    public AnimationCurve colorCurve;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        elapsedTime += sign * Time.deltaTime;

        if(elapsedTime > 1 || elapsedTime < 0)
        {
            sign = sign * -1;
        }

        transform.position = Vector3.Lerp(pointA.position, pointB.position, moveCurve.Evaluate(elapsedTime));
        transform.rotation = Quaternion.Slerp(pointA.rotation, pointB.rotation, rotateCurve.Evaluate(elapsedTime));

        //mat.color = Color.Lerp(Color.black, Color.white, colorCurve.Evaluate(elapsedTime));
        mat.SetColor("_BaseColor", Color.Lerp(Color.black, Color.white, colorCurve.Evaluate(elapsedTime)));
    }
}
