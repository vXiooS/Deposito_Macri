using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _movespeed = 2f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _turnspeed = 300f;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Transform _spawnPoint;

    private bool _isGrounded = false;
    [SerializeField] private bool _canJump = true;
    private float _jumpCooldown = 2f;
    private float _jumpCooldownTime = 2f;

    private float _timer;
    private float _timerLoseText = 2f;
    private bool _endgame = false;

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _loseText;



    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        

        if (_loseText.gameObject.activeSelf)
        {
            _timerLoseText -= Time.deltaTime;
        }
        if (_timerLoseText <= 0)
        {
            _loseText.gameObject.SetActive(false);
            _timerLoseText = 2f; // Reset the timer for the lose text
        }
        UpdateTimer();
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
        {
            Jump();
        }
        CooldownJump();


    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _direction * _movespeed * Time.fixedDeltaTime);
    }




    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        else if (c.gameObject.CompareTag("Obstacle"))
        {
            transform.position = _spawnPoint.position;
            if (_timerLoseText > 0)
            {
                _loseText.gameObject.SetActive(true);
            }
        }
        else if (c.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You win!");
            _endgame = true;
            _winText.gameObject.SetActive(true);
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    void Movement()
    {
        _direction = Vector3.zero;


        if (Input.GetKey(KeyCode.W))
        {
            _direction += transform.forward * 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction += transform.forward * -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -_turnspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, _turnspeed * Time.deltaTime, 0);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _canJump = false; // Disable jumping until cooldown is over
        }
    }

    void CooldownJump()
    {
        if (_canJump == false)
        {
            _jumpCooldown -= Time.deltaTime;
            if (_jumpCooldown <= 0)
            {
                _canJump = true;
                _jumpCooldown = _jumpCooldownTime; // Reset cooldown
            }
        }
    }

    void UpdateTimer()
    {
        if (_endgame == false)
        {
            _timer += Time.deltaTime;
            _timerText.text = _timer.ToString();
        }
    }
}
