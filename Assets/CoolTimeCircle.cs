/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeCircle : MonoBehaviour
{
    [SerializeField] private Image coolTimeCircle2;
    float seconds = 0f;

    private void Start()
    {
        coolTimeCircle2 = GetComponent<Image>();
    }

    public void UpdateClock(float second)
    {
        seconds += Time.deltaTime;
        coolTimeCircle2.fillAmount = second;
    }
}*/

using UnityEngine;
using UnityEngine.UI;

public class CoolTimeCircle : MonoBehaviour
{
    public Image coolTimeCircle; // スタミナゲージとして使うImage
    public float maxStamina = 100f; // 最大スタミナ
    public float staminaDecreaseRate = 20f; // スタミナ減少速度（毎秒）

    private float currentStamina;

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && currentStamina == 100)
        {
            currentStamina = 0;
        }
        else
        {
            currentStamina += staminaDecreaseRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            UpdateStaminaUI();
        }
    }

    void UpdateStaminaUI()
    {
        coolTimeCircle.fillAmount = currentStamina / maxStamina;
    }
}
