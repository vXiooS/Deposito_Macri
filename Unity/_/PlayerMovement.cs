using Unity.Multiplayer.Center.Common;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.forward * _speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.back * _speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.left * _speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.right * _speed);
        }
    }

}
