using UnityEngine;

public class doormanager1 : MonoBehaviour
{
    [SerializeField] private Gate gateColor;
    private Renderer _renderer;

    public enum Gate
    {
        Red,
        Blue,
        Green,
        Yellow,
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        SetGateColor();
    }

    private void SetGateColor()
    {
        switch (gateColor)
        {
            case Gate.Red:
            _renderer.material.color = Color.red;
            break;

            case Gate.Blue:
            _renderer.material.color = Color.blue;
            break;

            case Gate.Green:
            _renderer.material.color = Color.green;
            break;

            case Gate.Yellow:
            _renderer.material.color = Color.yellow;
            break;

            default:
            _renderer.material.color = Color.white;
            break;
        }
    }

    private void OnTiggerEnter(Collider other)
    {
        ballmanager1 player = other.GetComponent<ballmanager1>();
        if (player != null)
        {
            if(player.HasColor && player.CurrentColor == gateColor)
            {
                Debug.Log("Doğru renk!");
            }

            else
            {
                Debug.Log("Yanlış renk!");
                player.ResetPlayer();
            }
        }        
    }

}
