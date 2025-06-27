using UnityEngine;

public class CylinderScript : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _cylinderPrefab;
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _direzione;
    [SerializeField] private float _speedfb = 0.5f;
    [SerializeField] private float _speedlr = 2f;

    void Awake()
    {
        Debug.Log("CylinderScript Awake called");

        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        Debug.Log("CylinderScript OnEnable called");
    }

    void Start()
    {
        Debug.Log("CylinderScript Start called");
    }

    void Update()
    {
        Debug.Log("CylinderScript Update called");
        Debug.Log("WorldPosition: " + transform.position);
        Debug.Log("Current Position: " + transform.localPosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cylinder = Instantiate(_cylinderPrefab, _spawnPoint.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        Debug.Log("CylinderScript FixedUpdate called");

        if (Input.GetKey(KeyCode.W))
        {
            _direzione = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _direzione = Vector3.back;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _direzione = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _direzione = Vector3.right;
        }
        else
        {
            _direzione = Vector3.zero;
        }

        Move();
    }    

    void LateUpdate()
    {
        Debug.Log("CylinderScript LateUpdate called");
    }

    void OnDisable()
    {
        Debug.Log("CylinderScript OnDisable called");
    }

    void OnDestroy()
    {
        Debug.Log("CylinderScript OnDestroy called");
    }

    void Move()
    {
        if (_direzione == Vector3.forward)
        {
            transform.Translate(Vector3.forward * _speedfb * Time.deltaTime);
        }
        else if (_direzione == Vector3.back)
        {
            transform.Translate(Vector3.back * _speedfb * Time.deltaTime);
        }
        else if (_direzione == Vector3.left)
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.left * _speedlr * Time.deltaTime);
        }
        else if (_direzione == Vector3.right)
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector3.right * _speedlr * Time.deltaTime);
        }
    }
}
