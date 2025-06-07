  using System;
using UnityEngine;
  using TMPro;

public class Orders : MonoBehaviour
{
    [SerializeField] GameObject sticker;
    [SerializeField] private TextMeshProUGUI timerText; // Display for countdown timer.
    [SerializeField] private float orderDuration = 30f; // Duration for how long the order lasts.
    private float remainingTime;
    
    
    private void Start()
    {
        remainingTime = orderDuration;
        UpdateTimerText();
    }
    
    private void Update()
    {
        RunCountdownTimer();
        MoveSticker();
    }
    
    private void RunCountdownTimer()
    {
        if (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();
            if (remainingTime <= 0f)
            {
                // Trigger event on timer complete (e.g., cancel order, notify player)
                
                TimerComplete();
            }
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.Ceil(remainingTime).ToString(); // convert remaining time to whole seconds
        }
    }

    private void TimerComplete()
    {
        Debug.Log("Order time is up!");
        // Implement additional logic like order failure or removal
    }

    private void MoveSticker()
    {
        sticker.transform.position += new Vector3(150f * Time.deltaTime, 0f, 0f);
        if (sticker.transform.position.x > 1200)
        {
            sticker.transform.position = new Vector3(-150f, sticker.transform.position.y, 0f);
        }
    }
}