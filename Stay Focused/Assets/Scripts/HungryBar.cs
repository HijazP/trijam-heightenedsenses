using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryBar : MonoBehaviour
{
    public Slider slider;
    private float maxStamina = 10;
    private float currentStamina;
    public GameObject redFill;
    public GameObject hungerText;

    public static HungryBar instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentStamina = 0;
        slider.maxValue = maxStamina;
        slider.value = currentStamina;
    }

    public void AddStamina(float current)
    {
        redFill.SetActive(false);
        slider.value += current;
        if (slider.value == maxStamina)
        {
            currentStamina = maxStamina;
            StatusCharacter.instance.hungry = false;
        }
    }

    public void UseStamina()
    {
        if (StatusCharacter.instance.hungry == false && currentStamina > 0)
        {
            hungerText.SetActive(false);
            currentStamina -= Time.deltaTime;
            slider.value = currentStamina;
        }
        else if (currentStamina <= 0)
        {
            redFill.SetActive(true);
            hungerText.SetActive(true);
            StatusCharacter.instance.hungry = true;
        }
    }
}
