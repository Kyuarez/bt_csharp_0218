using UnityEngine;

public class TKAirplane : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject missleEntrance;
    [SerializeField] private GameObject missilePrefab;

    private float moveSpeed = 3.0f;
    private float rotateSpeed = 20.0f;

    void Update()
    {
        Movement();
        ShotMissile();
    }

    public void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //move
        transform.Translate(new Vector3(h, v, h).normalized * moveSpeed * Time.deltaTime);

        //rotate
        model.transform.Rotate(new Vector3(0, 0, -h) * rotateSpeed * Time.deltaTime);
        //transform.eulerAngles += new Vector3(1, 0, 0) * -v * rotateSpeed * Time.deltaTime;
    }

    public void ShotMissile()
    {
        if (true == Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject missile = Instantiate(missilePrefab, missleEntrance.transform);
            missile.transform.rotation = model.transform.rotation;
        }
    }

}
