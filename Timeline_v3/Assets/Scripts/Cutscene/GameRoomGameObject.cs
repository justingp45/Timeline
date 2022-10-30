using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomGameObject : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        GlobalReferences.GameRoom = this;

        animator = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        animator.Play("GameRoom_Fade_In");
    }

    public void FadeOut()
    {
        animator.Play("GameRoom_Fade_Out");
    }
}
