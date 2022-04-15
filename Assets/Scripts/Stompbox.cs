using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectible;
    [Range(0, 100)]
    public float chanceToDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            PlayerController.instance.Bounce();

            // pick a random number between 0 - 100
            float dropSelect = Random.Range(0, 100);
            if (dropSelect <= chanceToDrop)
            {
                // drop an item
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
            AudioManager.instance.PlaySFX(3);
        }
    }
}
