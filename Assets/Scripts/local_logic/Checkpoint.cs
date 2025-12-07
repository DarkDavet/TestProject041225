using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public event Action OnCheckpointReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Reached();
        }
    }

    public void Reached()
    {
        OnCheckpointReached?.Invoke();
        gameObject.SetActive(false);
    }
}
