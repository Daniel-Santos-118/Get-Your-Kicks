using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public AudioSource powerUp;
    public float powerUpDuration = 10f;

    void OnTriggerEnter(Collider other)
    {
        powerUp.Play();

    }


}