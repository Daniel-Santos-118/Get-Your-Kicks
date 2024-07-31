using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 9f;
    public float leftRightSpeed = 9f;
    public float normalJumpHeight = 8f; // Original jump height
    public float powerUpJumpHeightMultiplier = 1.5f; // Multiplier for power-up jump height
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    public bool isSpeedPowerUpActive = false;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (isJumping == false)
            {
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence());
            }
        }
        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 8, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -8, Space.World);
            }
        }
        IEnumerator JumpSequence()
        {
            yield return new WaitForSeconds(0.45f);
            comingDown = true;
            yield return new WaitForSeconds(0.45f);
            isJumping = false;
            comingDown = false;
            playerObject.GetComponent<Animator>().Play("Standard Run");
        }

    }
    public void ActivateJumpPowerUp(float duration)
    {
        StartCoroutine(JumpPowerUpRoutine(duration));
    }

    private IEnumerator JumpPowerUpRoutine(float duration)
    {
        // Apply power-up effect
        float originalJumpHeight = normalJumpHeight;
        normalJumpHeight *= powerUpJumpHeightMultiplier;

        yield return new WaitForSeconds(duration);

        // Revert to normal after duration
        normalJumpHeight = originalJumpHeight;
    }

}
