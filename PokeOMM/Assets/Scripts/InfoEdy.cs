using UnityEngine;

public class InfoEdy : MonoBehaviour
{
    public static InfoEdy instancia;

    public float vidaMaxima = 100f;
    public float vida = 100f;
    public float ataque = 30f;
    public float defensa = 50f;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}