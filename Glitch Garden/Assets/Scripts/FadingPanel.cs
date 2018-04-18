using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingPanel : MonoBehaviour
{
    public float fadeTime = 2;

    private enum FadeType { FadeIn, FadeOut };
    private Image panel;
    private Color currentColor;
    private float deltaAlpha;

    // Use this for initialization
    void Start()
    {
        panel = GetComponent<Image>();
        currentColor = panel.color;
        currentColor.a = 1;
        StartFade(FadeType.FadeIn);
    }

    void OnDisable()
    {
        StartFade(FadeType.FadeOut);
    }

    void Update()
    {
        if (deltaAlpha != 0)
        {
            UpdateAlpha();
        }
    }

    private void StartFade(FadeType type)
    {
        deltaAlpha = Time.deltaTime / fadeTime;
        deltaAlpha *= (type == FadeType.FadeIn) ? -1 : 1;
        Debug.Log("Fading " + ((type == FadeType.FadeIn) ? "in" : "out") + " with delta alpha of " + deltaAlpha);
    }

    private void UpdateAlpha()
    {
        currentColor.a += deltaAlpha;
        panel.color = currentColor;
        if ((deltaAlpha < 0 && panel.color.a <= 0) || 
            (deltaAlpha >= 0 && panel.color.a >= 1))
        {
            deltaAlpha = 0;
            gameObject.SetActive(false);
        }
    }
}
