using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 15f;
    public float lifeTime = 2f;
    public Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(speed * targetVector * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("MiniMeteor"))
        {
            IncreaseScore();
        }
    }

    private void IncreaseScore() {
        Player.SCORE++;
        GameObject scoreText = GameObject.FindGameObjectWithTag("UI");
        scoreText.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
    }
}
