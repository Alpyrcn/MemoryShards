using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    int score = 0;
    public Text scoreText;
    public AudioSource Coin;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 vector = new Vector2(vertical, 0);

        rb.AddForce(vector*speed);

        
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        score++;
        Coin.enabled = true;
        scoreText.text = "" + score;
        
   

        
    }


}
