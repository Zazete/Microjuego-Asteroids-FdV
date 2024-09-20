using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject miniMeteorPrefab;  // Prefab para el mini-meteorito
    public float miniMeteorSpeed = 300f; // Velocidad a la que se separan los mini-meteoritos
    public float separationAngle = 45f;  // Ángulo entre los mini-meteoritos

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            generateChilds();
            // GenerateMiniMeteors(collision);
        }
    }


    private void generateChilds()
    {
        GameObject miniMeteor1 = Instantiate(miniMeteorPrefab, transform.position, Quaternion.identity);
        miniMeteor1.GetComponent<Rigidbody>().AddForce(Vector3.right * miniMeteorSpeed);
        GameObject miniMeteor2 = Instantiate(miniMeteorPrefab, transform.position, Quaternion.identity);
        miniMeteor2.GetComponent<Rigidbody>().AddForce(Vector3.left * miniMeteorSpeed);
    }
   /* private void GenerateMiniMeteors(Collision collision)
    {
        // Calcula la dirección de impacto normalizada
        Vector3 impactDirection = (transform.position - collision.transform.position).normalized;

        // Instancia dos mini-meteoritos
        GameObject miniMeteor1 = Instantiate(miniMeteorPrefab, transform.position, Quaternion.identity);
        GameObject miniMeteor2 = Instantiate(miniMeteorPrefab, transform.position, Quaternion.identity);

        // Calcula la dirección de separación
        Vector3 direction1 = Quaternion.Euler(0, separationAngle, 0) * impactDirection;
        Vector3 direction2 = Quaternion.Euler(0, -separationAngle, 0) * impactDirection;

        // Asigna la velocidad a los mini-meteoritos
        miniMeteor1.GetComponent<Rigidbody>().AddForce(direction1 * miniMeteorSpeed);
        miniMeteor2.GetComponent<Rigidbody>().AddForce(direction2 * miniMeteorSpeed);

        // Opcional: para depuración visual
        Debug.DrawRay(transform.position, direction1 * 10, Color.red, 2f);
        Debug.DrawRay(transform.position, direction2 * 10, Color.blue, 2f);
    }
*/
}
