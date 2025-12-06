using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mg_chest_KeysGenerator : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private Transform gridParent;
    [SerializeField] private Color[] keyColors;
    [SerializeField] private mg_chest_LogicManager mgManager;

    void Start()
    {
        GenerateKeys();
    }

    private void GenerateKeys()
    {
        Color lockColor = mgManager.LockColor;
        int totalKeys = 36;
        int placedCorrect = 0;

        for (int i = 0; i < totalKeys; i++)
        {
            GameObject key = Instantiate(keyPrefab, gridParent);
            Color chosenColor;

            if (placedCorrect < 3 && Random.Range(0, totalKeys - i) < (3 - placedCorrect))
            {
                chosenColor = lockColor;
                placedCorrect++;
            }
            else
            {
                chosenColor = keyColors[Random.Range(0, keyColors.Length)];
            }

            key.GetComponent<Image>().color = chosenColor;
            key.GetComponent<mg_chest_KeyDragSystem>().Init(mgManager, chosenColor);
        }
    }
}
