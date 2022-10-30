using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Animator animator;
    public Transform rb;
    void LateUpdate(){
        animator.SetFloat("Horizontal", player.position.x - rb.position.x);
        animator.SetFloat("Vertical", player.position.y - rb.position.y);
    }
}
