using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;  //Prefab del proyectil
    public Transform shootPoint;        //Punto desde donde se dispara
    public float shootForce = 1000f;     //Fuerza del disparo

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || shootPoint == null)
        {
            Debug.LogWarning("Falta asignar el prefab o el punto de disparo.");
            return;
        }

        //Calcula la rotaci�n: rotaci�n del shootPoint + 90 grados en el eje X
        Quaternion rotation = shootPoint.rotation * Quaternion.Euler(90f, 0f, 0f);

        //Instancia el proyectil con la rotaci�n modificada
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, rotation);

        //Aseg�rate de que tenga un Rigidbody
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce);
        }
        else
        {
            Debug.LogWarning("El proyectil necesita un Rigidbody.");
        }
    }
}
