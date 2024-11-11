using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
    : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private float Facing;

    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private GameObject PlayerModel;
    [SerializeField] private ParticleSystem PlayerSmokeParticles;
    [SerializeField] private float Speed;

    private void FixedUpdate()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
        RotateModel();
    }

    private void MovePlayer()
    {
        var em = PlayerSmokeParticles.emission;
        em.enabled = (PlayerBody.velocity.magnitude > .05f);

        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);
    }

    private void RotateModel()
    {
        if (PlayerBody.velocity.magnitude > .05f)
        {
            float TargetFacing = Mathf.Rad2Deg * Mathf.Atan2(PlayerBody.velocity.x, PlayerBody.velocity.z);
            Facing = Mathf.LerpAngle(Facing, TargetFacing, Time.fixedDeltaTime * 8f);
            Vector3 TargetRotation = new Vector3(-90f, Facing + 180f, 0f);
            PlayerModel.transform.eulerAngles = TargetRotation;
        }
    }

}
