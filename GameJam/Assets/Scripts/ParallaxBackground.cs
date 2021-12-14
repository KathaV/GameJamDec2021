using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallexMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallexMultiplier.x, deltaMovement.y * parallexMultiplier.y, deltaMovement.z);
        lastCameraPosition = cameraTransform.position;
    }
}
