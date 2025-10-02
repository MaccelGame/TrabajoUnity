using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public Vector3 pointA;   //El punto de inicio
    public Vector3 pointB;   //El punto de destino
    public float speed = 2f; //La velocidad de movimiento

    private float lenght; //Longitud total del viaje
    private float startTime;     //Tiempo de inicio del movimiento

    void Start()
    {
        startTime = Time.time;
        lenght = Vector3.Distance(pointA, pointB);
    }

    void Update()
    {
        float distanceCovered = (Time.time - startTime) * speed;
        float fraction = distanceCovered / lenght;

        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(fraction, 1));
    }
}
