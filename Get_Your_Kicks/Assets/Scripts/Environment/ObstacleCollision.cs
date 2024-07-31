using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public GameObject levelControl;

    void OnTriggerEnter(Collider other)
    {
        if (!thePlayer.GetComponent<PlayerMove>().isSpeedPowerUpActive)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            thePlayer.GetComponent<PlayerMove>().enabled = false;
            charModel.GetComponent<Animator>().Play("Stumble Backwards");
            levelControl.GetComponent<LevelDistance>().enabled = false;
            levelControl.GetComponent<EndRunSequence>().enabled = true;
        }
    }
}