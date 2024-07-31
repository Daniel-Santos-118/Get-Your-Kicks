/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.35f;

    // Update is called once per frame
    void Update()
    {
        if (addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.GetComponent<Text>().text = "" + disRun;
        disEndDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(0.35f);
        addingDis = false;
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.35f;
    public bool isSpeedPowerUpActive = false; // Add this line

    // Update is called once per frame
    void Update()
    {
        if (addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        // Increment disRun based on power-up status
        if (isSpeedPowerUpActive)
        {
            disRun += 2; // Increment by 2 if speed power-up is active
        }
        else
        {
            disRun += 1; // Increment by 1 if speed power-up is not active
        }

        disDisplay.GetComponent<Text>().text = "" + disRun;
        disEndDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
}
