using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public AudioSource fly;
    public AudioSource hit;
    public AudioSource point;
    public float flyForce = 100f;
    private bool isDead = false;
    private Animator anim;

    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Time.timeScale = 0;
        GameControl.instance.highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScoreText").ToString();
    }


    void Update()
    {
        if (!GameControl.instance.gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            GameControl.instance.startGame();

        }
        else if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.velocity = Vector2.zero;
                body.AddForce(new Vector2(0, flyForce));
                anim.SetTrigger("Fly");
                fly.Play();
            }
        }
    }

    void OnCollisionEnter2D()
    {

        hit.Play();
        body.velocity = Vector2.zero;
        body.AddForce(new Vector2(1, 0));
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }

    private void OnTriggerEnter2D()
    {
        point.Play();
    }
}
