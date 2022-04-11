using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
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
        if (other.tag == "Player")
        {
            // This is very expensive on performance - it looks in all objects for this type.
            // FindObjectOfType<PlayerHealthController>().DealDamage();

            PlayerHealthController.instance.DealDamage();
        }
    }
}
