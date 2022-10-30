using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fader : MonoBehaviour
{
    private Animator animator;
    public event Action OnFadeInComplete;
    public event Action OnFadeOutComplete;

    private void Awake()
    {
        GlobalReferences.Fader = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        animator.Play("FadeIn");
    }

    public void FadeOut()
    {
        animator.Play("FadeOut");
    }

    public void FadeInCallback()
    {
        OnFadeInComplete?.Invoke();
    }

    public void FadeOutCallback()
    {
        OnFadeOutComplete?.Invoke();
    }
}
