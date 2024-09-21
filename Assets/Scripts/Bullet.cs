using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Bullet : MonoBehaviour
{

    public float speed = 15f;
    public float lifeTime;
    public float maxLifeTime = 2f;
    public Vector3 targetVector;

    // Start is called before the first frame update
    void OnEnable()
    {
        lifeTime = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            gameObject.SetActive(false);
        }
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
        scoreText.GetComponent<TextMeshProUGUI>().text = "Puntos: " + Player.SCORE;
    }

}
