using UnityEngine;

public class PlayerPortalScript : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _direction;
    [SerializeField] public float _speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.forward * _speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.back * _speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.left * _speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.right * _speed * Time.fixedDeltaTime);
        }
    }
}
