using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySlider : MonoBehaviour
{
    public Image counter;
    public Sprite[] sprites;
    private float value;
    public static Slider slider;

    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.value = ((Maze.size.x -20)/10);
        counter.sprite = sprites[(int)slider.value];
    }
    
    public void OnValueChanged()
    {
        value = slider.value;
        counter.sprite = sprites[(int)slider.value];
        Maze.size = new IntVector2(10 * (int)slider.value + 20, 10 * (int)slider.value + 20);
    }
}
