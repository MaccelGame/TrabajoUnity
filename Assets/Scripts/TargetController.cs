using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Configuracion")]
    public int puntos = 100;                      //Puntos a sumar al colisionar
    public float tiempoReaparicion = 3f;         //Tiempo que tarda en reaparecer

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameManager.Instance?.SumarPuntos(puntos);
            gameObject.SetActive(false);
            Invoke(nameof(Reactivar), tiempoReaparicion);
        }
    }

    void Reactivar()
    {
        gameObject.SetActive(true);
    }
}
