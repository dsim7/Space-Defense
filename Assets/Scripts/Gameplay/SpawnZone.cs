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
    public IntVariableSO lives;
    [Space]
    public Transform enemiesTransform;
    public InLevelTextDisplay infoText;
    public BlackMask mask;
    [Space]
    public PlayerManager playerSave;

    void Start()
    {
        StartLevel();
        wavesCompleted = false;
        mask.fadeRate = 0.5f;

        // Listen to lives
        if (currentLevel.Value != null)
        {
            lives.Value = currentLevel.Value.lives;
            lives.RegisterPostchangeEvent(CheckGameOverOrComplete);
        }
    }

    public void StartLevel()
    {
        currentWaveIndex = 0;
        StartWave();
    }

    void StartWave()
    {
        if (currentLevel.Value != null)
        {
            Wave waveToStart = currentLevel.Value.waves[currentWaveIndex];
            StartCoroutine(waveToStart.Spawn(this, enemiesTransform, NextWave));
        }
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
        Time.timeScale = 0.2f;

        StartCoroutine(FailLevelCoroutine());

        mask.fadeRate = 1f;
        mask.FadeOut(ReturnToMenu);
    }

    void Complete()
    {
        Time.timeScale = 0.2f;

        StartCoroutine(CompleteLevelCoroutine());
        
        mask.fadeRate = 1f;
        mask.FadeOut(ReturnToMenu);
    }

    IEnumerator FailLevelCoroutine()
    {
        infoText.ShowFail();
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator CompleteLevelCoroutine()
    {
        infoText.ShowSuccess();
        currentLevel.Value.Award();

        // Save
        playerSave.Save();

        yield return new WaitForSeconds(1);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
