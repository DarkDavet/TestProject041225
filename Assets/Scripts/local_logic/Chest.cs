using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private bool isPlayerNear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }

    void Update()
    {
        if (isPlayerNear && Input.GetMouseButtonDown(1))
        {
            OnOpen();
        }
    }

    private void OnOpen()
    {
        obj.SetActive(true);
    }
}
