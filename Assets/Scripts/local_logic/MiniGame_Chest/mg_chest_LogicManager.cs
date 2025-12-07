using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mg_chest_LogicManager : MonoBehaviour
{
    [SerializeField] private Image lockImage;
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private Color[] lockColors;

    private Color currentLockColor;
    private RectTransform lockRect;
    public Color LockColor { get => currentLockColor; private set => currentLockColor = value; }
    public RectTransform LockRect { get => lockRect; private set => lockRect = value; }

    
    private int correctKeysPlaced = 0;

    public event Action OnMGWon;

    void Start()
    {
        lockRect = GetComponent<RectTransform>();
        currentLockColor = lockColors[UnityEngine.Random.Range(0, lockColors.Length)];
        lockImage.color = currentLockColor;
        UpdateCounter();
    }

    public bool AddKey(Color keyColor)
    {
        if (ColorUtility.ToHtmlStringRGB(keyColor) == ColorUtility.ToHtmlStringRGB(currentLockColor))
        {
            correctKeysPlaced++;
            UpdateCounter();

            if (correctKeysPlaced >= 3)
            {
                Win();
            }
            return true;
        }
        return false;
    }

    private void UpdateCounter()
    {
        counterText.text = $"{correctKeysPlaced} / 3";
    }

    public void Win()
    {
        OnMGWon?.Invoke();
    }
}
