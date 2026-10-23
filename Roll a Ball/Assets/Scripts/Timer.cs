using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject loseTextObject;
    [SerializeField] PlayerController player;
    [SerializeField] float timeLimit = 30f;   // seconds, change it in the Inspector

    float timeLeft;
    bool running = true;

    void Start()
    {
        timeLeft = timeLimit;
        loseTextObject.SetActive(false);
    }

    void Update()
    {
        if (!running) return;

        timeLeft -= Time.deltaTime;   // count down instead of up

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            Lose();
        }

        timerText.text = "Time: " + timeLeft.ToString("F1") + "s";
    }

    void Lose()
    {
        running = false;
        loseTextObject.SetActive(true);
        player.enabled = false;   // switches off the movement script
    }

    public void Stop()
    {
        running = false;          // called by the player when they win
    }
}
