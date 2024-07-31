using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject[] section;
    public int zPos = 0;
    public bool creatingSection = false;
    public int secNum;
    public GameObject thePlayer;

    void Update()
    {
        if (thePlayer.GetComponent<PlayerMove>().isSpeedPowerUpActive)
        {
            if (creatingSection == false)
            {
                creatingSection = true;
                StartCoroutine(GenerateSection());
            }

            IEnumerator GenerateSection()
            {
                secNum = Random.Range(0, 3);
                Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                zPos += 50;
                yield return new WaitForSeconds(1);
                creatingSection = false;
            }
        }
        else
        {
            if (!thePlayer.GetComponent<PlayerMove>().isSpeedPowerUpActive)
            {
                if (creatingSection == false)
                {
                    creatingSection = true;
                    StartCoroutine(GenerateSection());
                }

                IEnumerator GenerateSection()
                {
                    secNum = Random.Range(0, 3);
                    Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                    zPos += 50;
                    yield return new WaitForSeconds(4);
                    creatingSection = false;
                }
            }
        }
    }
}
