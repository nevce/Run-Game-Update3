using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool isGamePaused = false; 

    public void TogglePause()
    {
        if (isGamePaused)
        {
            // Oyun devam ediyor, zaman� s�rd�r
            Time.timeScale = 1;
        }
        else
        {
            // Oyun durduruluyor, zaman� s�f�rla
            Time.timeScale = 0;
        }

        // Oyun durumu tersine �evir
        isGamePaused = !isGamePaused;
    }
}
