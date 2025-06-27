using TreeEditor;
using UnityEngine;

public class ObstaclePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private Transform _spawnPoint;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _direction += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector3.back;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector3.right;
        }
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Obstacle"))
        {
            transform.position = _spawnPoint.position;
        }
        else if (c.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You win!");
            
        }
    }
}
