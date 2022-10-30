using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmyGameObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        GlobalReferences.Amy = this;

        spriteRenderer = GetComponent<SpriteRenderer>();

        SetSpriteActive(false);
    }

    public void SetSpriteActive(bool active)
    {
        spriteRenderer.enabled = active;
    }
}
