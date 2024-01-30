using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    private GameObject player;
    private Transform playerCamera;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerCamera = player.transform.Find("PlayerCamera");
        }
    }

    private void LateUpdate()
    {
        if (playerCamera != null)
        {
            transform.LookAt(transform.position + playerCamera.forward);
        }
    }
}