using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager instance;

    [SerializeField] private float globalShakeForce = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy the additional instance
        }
    }

    public void CameraShake(CinemachineImpulseSource impulseSource)
    {
        if (impulseSource == null)
        {
            Debug.LogError("impulseSource is null");
            return;
        }

        impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }
}
