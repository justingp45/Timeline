using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespairGameObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        GlobalReferences.Despair = this;

        spriteRenderer = GetComponent<SpriteRenderer>();

        SetSpriteActive(false);
    }

    public void SetSpriteActive(bool active)
    {
        spriteRenderer.enabled = active;
    }
}
