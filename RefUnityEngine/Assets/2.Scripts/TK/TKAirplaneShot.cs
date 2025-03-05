using System.Reflection;
using UnityEngine;

public class TKAirplaneShot : MonoBehaviour
{
    [SerializeField] private Transform bombEntrance;
    [SerializeField] private Transform misslieEntracne;

    private GameObject prefab_misslie;
    private GameObject prefab_bomb;
    private Transform spawnBucket;

    private void Awake()
    {
        spawnBucket = GameObject.FindGameObjectWithTag("ObjectPool").transform;
        prefab_misslie = Resources.Load<GameObject>("Prefabs/Weapon/missile");
        prefab_bomb = Resources.Load<GameObject>("Prefabs/Weapon/Bomb");
    }

    private void Update()
    {
        if (true == Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject missile = Instantiate(prefab_misslie, spawnBucket);
            missile.transform.position = transform.position;
            missile.transform.rotation = transform.rotation;
        }
        if (true == Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.eulerAngles.z > 1.0f || transform.eulerAngles.z < -1.0f)
            {
                return;
            }
                
            GameObject bomb = Instantiate(prefab_bomb, spawnBucket);
            bomb.transform.position = transform.position;
        }
    }
}
