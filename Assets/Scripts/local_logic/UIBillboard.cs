using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour
{
    [SerializeField] private Transform camera;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }
}
