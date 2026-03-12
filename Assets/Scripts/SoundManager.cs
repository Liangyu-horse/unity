using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource die;
    public AudioSource hit;
    public AudioSource point;

    public void PlayJump()
    {
        jump.Play();
    }
    public void PlayDie()
    {
        die.Play();
    }
    public void PlayHit()
    {
        hit.Play();
    }
    public void PlayPoint()
    {
        point.Play();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Column>() != null)
        {
            PlayPoint();
        }
    }
}
