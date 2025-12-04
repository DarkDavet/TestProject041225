using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    private void Start()
    {
       playerMovement.Init();
    }
}
