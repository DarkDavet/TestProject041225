using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;         
    public Vector3 offset = new Vector3(0f, 2f, -5f);
    public float followSpeed = 5f;

    public void Init()
    {

    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            transform.LookAt(target.position + Vector3.up * 1.5f);
        }   
    }
}
