using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevels : MonoBehaviour
{
    public string parentName;

    // Update is called once per frame
    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(45);

        if (parentName == "Ground(Clone)")
        {
            Destroy(gameObject);
        }


    }
}
