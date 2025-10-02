using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI puntajeText;
    private int puntosTotales = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        ActualizarUI();
    }

    public void SumarPuntos(int puntos)
    {
        puntosTotales += puntos;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        puntajeText.text = "Puntos: " + puntosTotales.ToString();
    }
}
