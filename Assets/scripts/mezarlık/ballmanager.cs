using UnityEngine;

public class ballmanager : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 3.5f;
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        Movement();
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
        Debug.Log("nesneye çarptın");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            _renderer.material.color = Color.red;
        }
        else if (other.CompareTag("Yellow"))
        {
            _renderer.material.color = Color.yellow;
        }
        else if (other.CompareTag("Green"))
        {
            _renderer.material.color = Color.green;
        }
        else if (other.CompareTag("Blue"))
        {
            _renderer.material.color = Color.blue;
        }
    }
}
