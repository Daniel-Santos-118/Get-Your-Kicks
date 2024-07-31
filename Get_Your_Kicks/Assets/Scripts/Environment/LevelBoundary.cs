using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -5f;
    public static float rightSide = 5f;
    public float internalLeft;
    public float internalRight;
    // Start is called before the first frame update
    /*void Start(){}*/

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
