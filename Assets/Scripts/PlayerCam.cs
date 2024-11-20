using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private Vector3 CameraOffset = new Vector3(0, 6f, -4f);


    private void Awake()
    {
        transform.position = Player.transform.position + CameraOffset;
        transform.LookAt(Player.transform.position);
    }
    private void FixedUpdate()
    {
        Vector3 TargetPosition = Player.transform.position + CameraOffset;

        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.fixedDeltaTime * 16f);
    }
}
