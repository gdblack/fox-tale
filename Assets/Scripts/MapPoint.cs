using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel, isLocked;
    public string levelToLoad, levelToCheck, levelName;
    public int gemsCollected, totalGems;
    public float bestTime, targetTime;
    public GameObject gemBadge, timeBadge;

    // Start is called before the first frame update
    void Start()
    {
        if (isLevel && !string.IsNullOrEmpty(levelToLoad))
        {
            if (PlayerPrefs.HasKey($"{levelToLoad}_gems"))
            {
                gemsCollected = PlayerPrefs.GetInt($"{levelToLoad}_gems");
            }
            if (PlayerPrefs.HasKey($"{levelToLoad}_time"))
            {
                bestTime = PlayerPrefs.GetFloat($"{levelToLoad}_time");
            }
            if (gemsCollected >= totalGems)
            {
                gemBadge.SetActive(true);
            }
            if (bestTime <= targetTime && bestTime != 0)
            {
                timeBadge.SetActive(true);
            }
            isLocked = true;

            if (!string.IsNullOrEmpty(levelToCheck))
            {
                if (PlayerPrefs.HasKey($"{levelToCheck}_unlocked"))
                {
                    isLocked = PlayerPrefs.GetInt($"{levelToCheck}_unlocked") != 1;
                }
            }
            if (levelToLoad == levelToCheck)
            {
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
