using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool state;

    private Button[] buttons;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Encontro apenas os botões que são diferentes do atual
        buttons = FindObjectsOfType<Button>().Where(i => i.GetInstanceID() != GetInstanceID()).ToArray();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Reset();
    }

    private void Reset()
    {
        state = false;
        spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f);
    }

    void OnMouseDown()
    {
        ToggleState();
        foreach (Button otherButton in buttons)
        {
            if (otherButton.state == state) { otherButton.ToggleState(); }
        }
    }

    private void ToggleState()
    {
        state = !state;
        if (state)
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f);
        }
    }
}
