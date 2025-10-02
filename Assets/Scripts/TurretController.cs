using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Partes de la torreta (asignar manualmente)")]
    [SerializeField] private Transform baseTorreta;   //Eje Y
    [SerializeField] private Transform torsoTorreta;  //Eje X
    [SerializeField] private Transform boquilla;      //Punto de disparo

    [Header("Configuracion de sensibilidad")]
    [SerializeField] private float sensibilidadX = 5f;
    [SerializeField] private float sensibilidadY = 5f;

    [Header("Limites de rotacion vertical")]
    [SerializeField] private float anguloMinY = -45f;
    [SerializeField] private float anguloMaxY = 45f;

    private float rotacionY = 0f; //Horizontal
    private float rotacionX = 0f; //Vertical

    private void Start()
    {
        //Oculta y bloquea el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Obtener input del mouse
        float inputX = Input.GetAxis("Mouse X");
        float inputY = Input.GetAxis("Mouse Y");

        //Acumular rotacion horizontal (Base)
        rotacionY += inputX * sensibilidadX;

        //Acumular rotacion vertical (Torso) y clamping
        rotacionX -= inputY * sensibilidadY;
        rotacionX = Mathf.Clamp(rotacionX, anguloMinY, anguloMaxY);

        //Aplicar rotacion a la base (solo Y)
        if (baseTorreta != null)
        {
            baseTorreta.localRotation = Quaternion.Euler(0f, rotacionY, 0f);
        }

        //Aplicar rotacion al torso (solo X)
        if (torsoTorreta != null)
        {
            torsoTorreta.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        }
    }

    //Devuelve la posicion de la boquilla
    public Vector3 ObtenerPosicionBoquilla()
    {
        return boquilla != null ? boquilla.position : Vector3.zero;
    }

    //Devuelve la direccion hacia adelante de la boquilla
    public Vector3 ObtenerDireccionDisparo()
    {
        return boquilla != null ? boquilla.forward : Vector3.forward;
    }
}
