using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IDLE = "Idle";
    private const string MOVE = "Move";
    private const string DEAD = "Dead";
    private const string VICTORY = "Victory";

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject dustVfx;

    private string currentState;

    private void Start()
    {
        PlayerMovement.IsMoving += PlayerMovement_IsMoving;
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
    }

    private void PlayerMovement_IsMoving(object sender, PlayerMovement.IsMovingEventArgs e)
    {
        ChangeAnimationsState(e.isMoving);
    }

    private void ChangeAnimationsState(string newState)
    {
        if (currentState == newState) return;
        playerAnimator.Play(newState);
        currentState = newState;
    }

    private void ChangeAnimationsState(bool isMoving)
    {
        if (isMoving)
        {
            playerAnimator.Play(MOVE);
        } 
        else
        {
            playerAnimator.Play(IDLE);
        }
    }
}
