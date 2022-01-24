using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get; private set; }

    public Color32[] colors = new Color32[4];

    private void Awake()
    {
        Instance = this;

        colors[0] = new Color32(54, 255, 170, 255);
        colors[1] = new Color32(255, 83, 83, 255);
        colors[2] = new Color32(255, 230, 83, 255);
        colors[3] = new Color32(229, 148, 255, 255);
    }

    public Color32 GetRandomColor()
    {
        int randomIndex = Random.Range(0, 4);
        return colors[randomIndex];
    }
}
