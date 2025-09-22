using UnityEngine;
using TMPro;

public class CooldownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    void Update()
    {
        if (timer <= 0)
        {
            timer = 0;
            Finish();
            return;
        }
        timer -= Time.deltaTime;
        timerText.text = (Mathf.Round(timer * 10f) / 10f).ToString();
    }
    public void StartCountDown(float cooldownTime)
    {
        gameObject.SetActive(true);
        timer = cooldownTime;
    }
    private void Finish()
    {
        gameObject.SetActive(false);
    }
}
