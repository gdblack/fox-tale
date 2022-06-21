using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject objectToSwitch;
    private SpriteRenderer spriteRenderer;
    public Sprite downSprite;
    private bool hasSwitched;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasSwitched)
        {
            objectToSwitch.SetActive(false);
            spriteRenderer.sprite = downSprite;
            hasSwitched = true;
        }
    }
}
