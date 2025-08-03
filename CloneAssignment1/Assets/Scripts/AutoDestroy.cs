using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 0.3f;

    private void Start()
    {
       Destroy(gameObject, lifetime);
    }
}
