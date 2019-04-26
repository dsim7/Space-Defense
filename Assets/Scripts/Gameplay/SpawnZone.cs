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
    public IntVariableSO lives;
    [Space]
    public Text infoText, subInfoText;
    [Space]
    public BlackMask mask;

    void Start()
    {
        StartLevel();
        wavesCompleted = false;
        mask.fadeRate = 0.5f;

        // Listen to lives
        if (currentLevel.Value != null)
        {
            lives.Value = currentLevel.Value.lives;
        }
        lives.RegisterPostchangeEvent(CheckGameOverOrComplete);
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
        infoText.text = "FAILED";
        infoText.color = Color.red;
        infoText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator CompleteLevelCoroutine()
    {
        infoText.text = "COMPLETE";
        infoText.color = Color.white;
        infoText.gameObject.SetActive(true);
        subInfoText.text = currentLevel.Value.rewardsDescription;
        currentLevel.Value.Award();
        yield return new WaitForSeconds(1);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
