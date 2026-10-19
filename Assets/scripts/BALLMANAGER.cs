using UnityEngine;

public class BALLMANAGER : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Renderer _renderer;
    private Vector3 _startPosition;

    private DOORMANAGER.Gate _currentcolor;
    private bool _hasColor = false;
    private bool _gameCompleted = false;

    public DOORMANAGER.Gate CurrentColor
    {
        get { return _currentcolor; }
    }

    public bool HasColor
    {
        get { return _hasColor; }
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _startPosition = transform.position;
    }

    void Update()
    {
        if (!_gameCompleted)
        {
            Movement();
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        transform.Translate(direction * (moveSpeed * Time.deltaTime), Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bir Nesneye Çarptı");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            ChangeColor(DOORMANAGER.Gate.red, Color.red);
            Debug.Log("Kırmızı!");

        }
        else if (other.CompareTag("Blue"))
        {
            ChangeColor(DOORMANAGER.Gate.blue, Color.blue);
            Debug.Log("Mavi!");
        }
        else if (other.CompareTag("Green"))
        {
            ChangeColor(DOORMANAGER.Gate.green, Color.green);
            Debug.Log("Yeşil!");
        }
        else if (other.CompareTag("Yellow"))
        {
            ChangeColor(DOORMANAGER.Gate.yellow, Color.yellow);
            Debug.Log("Sarı!");
        }
        else if (other.CompareTag("Finish"))
        {
            CompleteGame();
        }
    }

    private void ChangeColor(DOORMANAGER.Gate newColor, Color color)
    {
        _currentcolor = newColor;
        _hasColor = true;

        _renderer.material.color = color;
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        _renderer.material.color = Color.white;
        _hasColor = false;
        Debug.Log("Yanlış Renk!");
    }
    public void CompleteGame()
    {
        _gameCompleted = true;
        Debug.Log("Kazandın!");
    }
}
