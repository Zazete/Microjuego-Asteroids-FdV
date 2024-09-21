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
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            generateChilds();
        }
    }


private void generateChilds()
{
    // Primer mini meteorito con rotación de 45 grados a la derecha
    GameObject miniMeteor1 = Instantiate(miniMeteorPrefab, transform.position, Quaternion.identity);
    Vector3 direction1 = Quaternion.Euler(0, 0, 45) * Vector3.right; // Aplica la rotación al vector
    miniMeteor1.GetComponent<Rigidbody>().AddForce(direction1 * miniMeteorSpeed);

    // Segundo mini meteorito con rotación de -45 grados a la izquierda
    GameObject miniMeteor2 = Instantiate(miniMeteorPrefab, transform.position, Quaternion.identity);
    Vector3 direction2 = Quaternion.Euler(0, 0, -45) * Vector3.left; // Aplica la rotación al vector
    miniMeteor2.GetComponent<Rigidbody>().AddForce(direction2 * miniMeteorSpeed);
}

}
