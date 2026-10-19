using UnityEngine;

public class DOORMANAGER : MonoBehaviour
{
    public enum Gate
    {
        red,
        blue,
        green,
        yellow,

    }

    [SerializeField] private Gate gateColor;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    void Start()
    {
        SetGateColor();
    }

    private void SetGateColor()
    {
        switch (gateColor)
        {
            case Gate.red:
                _renderer.material.color = new Color(1f, 0f, 0f, 0.5f);
                break;

            case Gate.blue:
                _renderer.material.color = new Color(0f, 0f, 1f, 0.5f);
                break;

            case Gate.green:
                _renderer.material.color = new Color(0f, 1f, 0f, 0.5f);
                break;

            case Gate.yellow:
                _renderer.material.color = new Color(1f, 1f, 0f, 0.5f);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BALLMANAGER player = other.GetComponent<BALLMANAGER>();

        if (player != null)
        {
            if (player.HasColor && player.CurrentColor == gateColor)
            {
                Debug.Log("Doğru renk!");
            }
            else
            {
                Debug.Log("Yanlış Renk!");
                player.ResetPlayer();
            }
        }
    }
}
