using System;
using System.Net.NetworkInformation;
using UnityEngine;

public class ballmanager1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    private Renderer _renderer;
    private Vector3 _StartPosition;

    private doormanager1.Gate _currentColor;
    private bool _hasColor = false;
    private bool _gameCompleted = false;

    public doormanager1.Gate CurrentColor
    {
        get { return _currentColor;}
    }

    public bool HasColor
    {
        get { return _hasColor;}
    }
 
    private void Awake() 
    {
       _renderer = GetComponent<Renderer>();
       _StartPosition = transform.position;
    }

    private void Update()
    {
        if(!_gameCompleted)
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
        Debug.Log("nesneye çarptı");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            _renderer.material.color = Color.red;
            Debug.Log("Kırmızı!");
        }
        else if (other.CompareTag("Blue"))
        {
            _renderer.material.color = Color.blue;
            Debug.Log("Mavi!");
        }
        else if (other.CompareTag("Yellow"))
        {
            _renderer.material.color = Color.yellow;
            Debug.Log("sarı!");
        }
        else if (other.CompareTag("Green"))
        {
            _renderer.material.color = Color.green;
            Debug.Log("Yeşil!");
        }
    }

    private void changeColor(doormanager1.Gate newColor, Color color)
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
        Debug.Log("Yanlış renk!");
    }

    public void CompleteGame()
    {
        _gameCompleted = true;
        Debug.Log("Oyun tamamlandı");
    }
}
