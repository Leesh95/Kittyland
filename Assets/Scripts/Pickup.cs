using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem,
        isHeal;
    private bool isCollected;

    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;

                isCollected = true;
                Destroy(gameObject);

                UIController.instance.UpdateGemCount();
            }
            if (isHeal)
            {
                if (
                    PlayerHealthController.instance.currentHealth
                    != PlayerHealthController.instance.maxHealth
                )
                {
                    PlayerHealthController.instance.HealPlayer();

                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
