using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    [SerializeField] private float _speed = 50f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * _speed, ForceMode.Impulse);
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
