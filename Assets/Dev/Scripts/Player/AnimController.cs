using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;

    private void LateUpdate()
    {
        animator.SetFloat("Speed", playerMovement.currentSpeed);
    }
}
