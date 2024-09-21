using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] float thrustForce = 100f;
    [SerializeField] float rotationSpeed = 130f;


    public static int SCORE = 0;
    public static float xBorderLimit, yBorderLimit;

    public GameObject gun, bulletPrefab;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        xBorderLimit = (Camera.main.orthographicSize+1f) * Screen.width / Screen.height;
        yBorderLimit = Camera.main.orthographicSize + 1f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newPos = transform.position;
        if(newPos.x > xBorderLimit) 
            newPos.x = -xBorderLimit + 1;
        else if(newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit - 1;
        else if(newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit + 1;
        else if(newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit;
        transform.position = newPos;

        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

        Vector3 thrustdirection = transform.right;

        rigidbody.AddForce(thrustdirection * thrust * thrustForce);


        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
            if (bullet != null) {
                bullet.transform.position = gun.transform.position;
                bullet.transform.rotation = gun.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision colision) 
    {

        if(colision.gameObject.CompareTag("Enemy") || colision.gameObject.CompareTag("MiniMeteor"))
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
