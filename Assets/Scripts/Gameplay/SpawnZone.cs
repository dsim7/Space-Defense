using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnZone : MonoBehaviour
{
    int currentWaveIndex;
    bool wavesCompleted;

    public LevelVariable currentLevel;
    public Transform enemiesTransform;
    public IntVariable lives;
    [Space]
    public Text infoText;
    [Space]
    public BlackMask mask;

    void Start()
    {
        StartLevel();
        wavesCompleted = false;
        mask.fadeRate = 0.5f;

        // Listen to lives
        lives.Value = currentLevel.Value.lives;
        lives.RegisterPostchangeEvent(CheckGameOverOrComplete);
    }

    public void StartLevel()
    {
        currentWaveIndex = 0;
        StartWave();
    }

    void StartWave()
    {
        Wave waveToStart = currentLevel.Value.waves[currentWaveIndex];
        StartCoroutine(waveToStart.Spawn(this, enemiesTransform, NextWave));
    }

    void NextWave()
    {
        currentWaveIndex++;
        if (currentWaveIndex < currentLevel.Value.waves.Count)
        {
            StartWave();
        }
        else
        {
            wavesCompleted = true;
        }
    }

    public void CheckGameOverOrComplete()
    {
        StartCoroutine(CheckGameOverOrCompleteCoroutine());
    }

    IEnumerator CheckGameOverOrCompleteCoroutine()
    {
        yield return null; // Wait a frame, to make sure all enemies that were destroyed are actually gone
        if (!HaveLives())
        {
            GameOver();
        }
        else if (AllEnemiesDead())
        {
            Complete();
        }
    }

    bool HaveLives()
    {
        return lives.Value > 0;
    }

    bool AllEnemiesDead()
    {
        return wavesCompleted && enemiesTransform.childCount == 0;
    }

    void GameOver()
    {
        infoText.text = "GAME OVER";
        infoText.color = Color.red;
        infoText.gameObject.SetActive(true);
        Time.timeScale = 0.2f;
        mask.fadeRate = 1f;
        mask.FadeOut(ReturnToMenu);
    }

    void Complete()
    {
        infoText.text = "COMPLETE";
        infoText.color = Color.white;
        infoText.gameObject.SetActive(true);
        Time.timeScale = 0.2f;
        mask.fadeRate = 1f;
        mask.FadeOut(ReturnToMenu);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
