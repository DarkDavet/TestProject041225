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
    private int correctKeysPlaced = 0;

    void Start()
    {
        currentLockColor = lockColors[Random.Range(0, lockColors.Length)];
        lockImage.color = currentLockColor;
        UpdateCounter();
    }

    public void AddKey(Color keyColor)
    {
        if (keyColor == currentLockColor)
        {
            correctKeysPlaced++;
            UpdateCounter();

            if (correctKeysPlaced >= 3)
            {
                Win();
            }
        }
    }

    private void UpdateCounter()
    {
        counterText.text = $"{correctKeysPlaced} / 3";
    }

    private void Win()
    {
        
    }
}
