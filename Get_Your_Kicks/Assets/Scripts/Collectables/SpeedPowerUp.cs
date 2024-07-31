/*using System.Collections;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public AudioSource powerUp;
    public float powerUpDuration = 10f;
    public float speedMultiplier = 2f;
    public float coolDownTime = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            powerUp.Play();
            StartCoroutine(TriggerPowerUp(other.GetComponent<PlayerMove>()));
            GetComponent<CapsuleCollider>().enabled = false; // Disable collider temporarily
        }
    }

    IEnumerator TriggerPowerUp(PlayerMove playerMovement)
    {
        playerMovement.isSpeedPowerUpActive = true; // Set flag to indicate power-up is active
        playerMovement.moveSpeed *= speedMultiplier;

        Debug.Log("Player Invulnerable");

        yield return new WaitForSeconds(powerUpDuration);

        playerMovement.moveSpeed /= speedMultiplier;

        yield return new WaitForSeconds(coolDownTime);

        playerMovement.isSpeedPowerUpActive = false; // Reset flag when power-up ends
        
    }
}*/

using System.Collections;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public AudioSource powerUp;
    public float powerUpDuration = 10f;
    public float speedMultiplier = 2f;
    public float coolDownTime = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            powerUp.Play();
            StartCoroutine(TriggerPowerUp(other.GetComponent<PlayerMove>()));
            GetComponent<CapsuleCollider>().enabled = false; // Disable collider temporarily
        }
    }

    IEnumerator TriggerPowerUp(PlayerMove playerMovement)
    {
        // Find LevelDistance component and activate power-up
        LevelDistance levelDistance = FindObjectOfType<LevelDistance>();
        if (levelDistance != null)
        {
            levelDistance.isSpeedPowerUpActive = true;
        }

        playerMovement.isSpeedPowerUpActive = true; // Set flag to indicate power-up is active
        playerMovement.moveSpeed *= speedMultiplier;

        Debug.Log("Player Invulnerable");

        yield return new WaitForSeconds(powerUpDuration);

        playerMovement.moveSpeed /= speedMultiplier;

        // Deactivate power-up
        if (levelDistance != null)
        {
            levelDistance.isSpeedPowerUpActive = false;
        }

        yield return new WaitForSeconds(coolDownTime);

        playerMovement.isSpeedPowerUpActive = false; // Reset flag when power-up ends
    }
}
