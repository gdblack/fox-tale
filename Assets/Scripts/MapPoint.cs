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

    // Start is called before the first frame update
    void Start()
    {
        if (isLevel && !string.IsNullOrEmpty(levelToLoad))
        {
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
