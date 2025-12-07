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

    private const int totalKeys = 36;
    private const int requiredLockKeys = 3;


    void Start()
    {
        GenerateKeys();
    }

    private void GenerateKeys()
    {
        if (keyColors == null || keyColors.Length == 0)
        {
            Debug.LogError("KeyColors array is empty!");
            return;
        }

        List<Color> colors = new List<Color>();

        for (int i = 0; i < requiredLockKeys; i++)
            colors.Add(mgManager.LockColor);

        for (int i = requiredLockKeys; i < totalKeys; i++)
        {
            Color randomColor = keyColors[Random.Range(0, keyColors.Length)];
            colors.Add(randomColor);
        }

        for (int i = 0; i < colors.Count; i++)
        {
            int randIndex = Random.Range(i, colors.Count);
            (colors[i], colors[randIndex]) = (colors[randIndex], colors[i]);
        }

        foreach (Color c in colors)
        {
            GameObject key = Instantiate(keyPrefab, gridParent);
            var img = key.GetComponent<Image>();
            if (img != null) img.color = c;

            var dragSystem = key.GetComponent<mg_chest_KeyDragSystem>();
            if (dragSystem != null) dragSystem.Init(mgManager, c);
        }
    }
}
