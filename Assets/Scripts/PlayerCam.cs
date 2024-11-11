using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    Player Player;


    private void Awake()
    {
        transform.position = Player.transform.position + new Vector3(0, 8f, -6f);
        transform.LookAt(Player.transform.position);
    }
    private void FixedUpdate()
    {
        Vector3 TargetPosition = Player.transform.position + new Vector3(0, 10f, -4f);
        
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.fixedDeltaTime * 16f);
    }
}
