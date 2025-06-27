using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;

    private GameObject projectileInstance;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectileInstance = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
