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
        int totalKeys = 36;
        List<Color> colors = new List<Color>();

        for (int i = 0; i < 3; i++)
            colors.Add(mgManager.LockColor);

        for (int i = 3; i < totalKeys; i++)
            colors.Add(keyColors[Random.Range(0, keyColors.Length)]);

        for (int i = 0; i < colors.Count; i++)
        {
            Color temp = colors[i];
            int randIndex = Random.Range(i, colors.Count);
            colors[i] = colors[randIndex];
            colors[randIndex] = temp;
        }

        foreach (Color c in colors)
        {
            GameObject key = Instantiate(keyPrefab, gridParent);
            key.GetComponent<Image>().color = c;
            key.GetComponent<mg_chest_KeyDragSystem>().Init(mgManager, c);
        }
    }
}
