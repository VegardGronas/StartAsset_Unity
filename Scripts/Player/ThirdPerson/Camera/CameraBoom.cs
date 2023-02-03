using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float targetArmLength = -5f;

    [SerializeField] private List<Collider> ignoreColliders;

    private void Start()
    {
        playerCamera.LookAt(transform.position);    
    }

    private void FixedUpdate()
    {
        Vector3 forward = playerCamera.forward;
        RaycastHit hit;


        if (Physics.Raycast(transform.position, -forward, out hit, -targetArmLength))
        {
            foreach(Collider col in ignoreColliders)
            {
                if (hit.collider != col)
                {
                    playerCamera.position = hit.point;
                }
            }
        }
        else
        {
            Vector3 newPos = playerCamera.localPosition;
            newPos.z = targetArmLength;
            playerCamera.localPosition = newPos;
        }
    }
}
