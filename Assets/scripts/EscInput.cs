using UnityEngine;

public class EscInput : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject bgLayer;
    public bool paused = false;

    private void Start()
    {
        UnPause();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) UnPause();
            else Pause();
        }
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        bgLayer.SetActive(true);
    }
    public void UnPause()
    {
        paused = false;
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
        bgLayer.SetActive(false);
    }
}
