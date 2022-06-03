using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
    public int gemsCollected;
    public string levelToLoad;
    public float timeInLevel;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeInLevel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 0.2f);
        UIController.instance.FadeFromBlack();
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
    }
    public void EndLevel()
    {
        StartCoroutine(EndLevelCoroutine());
    }
    public IEnumerator EndLevelCoroutine()
    {
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds(1 / UIController.instance.fadeSpeed + 0.25f);

        // store lock/unlock in player prefs - key/val pair
        PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().name}_unlocked", 1);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        if (PlayerPrefs.HasKey($"{SceneManager.GetActiveScene().name}_gems"))
        {
            if (gemsCollected > PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().name}"))
            {
                PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().name}_gems", gemsCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().name}_gems", gemsCollected);
        }
        if (PlayerPrefs.HasKey($"{SceneManager.GetActiveScene().name}"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat($"{SceneManager.GetActiveScene().name}_time"))
            {
                PlayerPrefs.SetFloat($"{SceneManager.GetActiveScene().name}_time", timeInLevel);
            }
        }
        else
        {
            PlayerPrefs.SetFloat($"{SceneManager.GetActiveScene().name}_time", timeInLevel);
        }

        SceneManager.LoadScene(levelToLoad);
    }
}
