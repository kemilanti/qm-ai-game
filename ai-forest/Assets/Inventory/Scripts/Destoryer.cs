using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ïú»ÙÎïÌå
public class Destoryer : MonoBehaviour
{
    [SerializeField] private float lifeTimer;

    private void Start()
    {
        Destroy(gameObject, lifeTimer);
    }
}
