using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool isGamePaused = false; 

    public void TogglePause()
    {
        if (isGamePaused)
        {
            // Oyun devam ediyor, zamaný sürdür
            Time.timeScale = 1;
        }
        else
        {
            // Oyun durduruluyor, zamaný sýfýrla
            Time.timeScale = 0;
        }

        // Oyun durumu tersine çevir
        isGamePaused = !isGamePaused;
    }
}
