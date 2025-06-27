using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _direction;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
            transform.Rotate(0, -1, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }
    }
    
    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _direction * Time.fixedDeltaTime);
    }
}
