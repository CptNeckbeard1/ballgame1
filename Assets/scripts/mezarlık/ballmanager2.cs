using UnityEngine;

public class ballmanager2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    private Renderer _renderer;
    private Vector3 _StartPosition;

    private doormanager2.Gate _currentColor;
    private bool _hasColor = false;
    private bool _gameCompleted = false;

    public doormanager2.Gate CurrentColor => _currentColor;
    public bool HasColor => _hasColor;

    private void Awake() 
    {
        _renderer = GetComponent<Renderer>();
        _StartPosition = transform.position;
    }

    private void Update()
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
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(direction * (moveSpeed * Time.deltaTime), Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Nesneye çarptı");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            ChangeColor(doormanager2.Gate.Red, Color.red);
            Debug.Log("Kırmızı!");
        }
        else if (other.CompareTag("Blue"))
        {
            ChangeColor(doormanager2.Gate.Blue, Color.blue);
            Debug.Log("Mavi!");
        }
        else if (other.CompareTag("Yellow"))
        {
            ChangeColor(doormanager2.Gate.Yellow, Color.yellow);
            Debug.Log("Sarı!");
        }
        else if (other.CompareTag("Green"))
        {
            ChangeColor(doormanager2.Gate.Green, Color.green);
            Debug.Log("Yeşil!");
        }
        else if (other.CompareTag("Finish"))
        {
            CompleteGame();
        }
    }

    private void ChangeColor(doormanager2.Gate newColor, Color color)
    {
        _currentColor = newColor;
        _hasColor = true;
        _renderer.material.color = color;
    }

    public void ResetPlayer()
    {
        transform.position = _StartPosition;
        _renderer.material.color = Color.white;
        _hasColor = false;
        Debug.Log("Oyuncu sıfırlandı!");
    }

    public void CompleteGame()
    {
        _gameCompleted = true;
        Debug.Log("Oyun tamamlandı");
    }
}