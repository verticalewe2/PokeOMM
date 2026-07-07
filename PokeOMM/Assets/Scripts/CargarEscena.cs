using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
    public void CargarNuevaEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}