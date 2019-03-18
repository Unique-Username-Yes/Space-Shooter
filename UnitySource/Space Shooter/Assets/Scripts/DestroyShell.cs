using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShell : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < 1)
        {
            Destroy(gameObject);
        }
    }
}
