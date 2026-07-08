using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BarraVidaUIEdy : MonoBehaviour
{
    [Header("Referencia")]
    [SerializeField] private Image fillImage;

    [Header("Umbrales (0-1)")]
    [SerializeField] private float umbralCritico = 0.2f;
    [SerializeField] private float umbralMedio = 0.5f;

    [Header("Colores")]
    [SerializeField] private Color colorAlto = new Color32(0x4C, 0xD1, 0x37, 0xFF);
    [SerializeField] private Color colorMedio = new Color32(0xE1, 0xB1, 0x2C, 0xFF);
    [SerializeField] private Color colorCritico = new Color32(0xE8, 0x41, 0x18, 0xFF);

    private float ultimaVida = -1f;

    private void Awake()
    {
        if (fillImage == null)
            fillImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (InfoEdy.instancia == null) return;

        float vidaActual = InfoEdy.instancia.vida;

        if (!Mathf.Approximately(vidaActual, ultimaVida))
        {
            ActualizarBarra(vidaActual, InfoEdy.instancia.vidaMaxima);
            ultimaVida = vidaActual;
        }
    }

    private void ActualizarBarra(float vidaActual, float vidaMaxima)
    {
        float fillAmount = Mathf.Clamp01(vidaActual / vidaMaxima);
        fillImage.fillAmount = fillAmount;
        ActualizarColor(fillAmount);
    }

    private void ActualizarColor(float fillAmount)
    {
        if (fillAmount < umbralCritico)
            fillImage.color = colorCritico;
        else if (fillAmount < umbralMedio)
            fillImage.color = colorMedio;
        else
            fillImage.color = colorAlto;
    }
}