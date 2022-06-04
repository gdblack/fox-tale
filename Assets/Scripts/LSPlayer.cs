using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint;
    public float moveSpeed = 10f;
    private bool _levelLoading;
    public LSManager lsManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f && !_levelLoading)
        {


            if (Input.GetAxisRaw("Horizontal") > 0.5f) // To Right
            {
                if (currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);
                }
            }
            if (Input.GetAxisRaw("Horizontal") < -0.5f) // To Left
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                }
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f) // To Up
            {
                if (currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);
                }
            }
            if (Input.GetAxisRaw("Vertical") < -0.5f) // To Down
            {
                if (currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);
                }
            }
            if (currentPoint.isLevel && !string.IsNullOrEmpty(currentPoint.levelToLoad) && !currentPoint.isLocked)
            {
                LSUIController.instance.ShowInfo(currentPoint);

                if (Input.GetButtonDown("Jump"))
                {
                    // load the level
                    _levelLoading = true;
                    lsManager.LoadLevel();
                }
            }
        }
    }

    public void SetNextPoint(MapPoint nextPoint)
    {
        LSUIController.instance.HideInfo();
        currentPoint = nextPoint;
        AudioManager.instance.PlaySFX(5);
    }
}
