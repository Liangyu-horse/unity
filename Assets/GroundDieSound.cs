using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDieSound : MonoBehaviour
{
    public AudioSource die;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D()
    {
        die.Play();
        anim.gameObject.GetComponent<Animator>().enabled = false;
    }
}
