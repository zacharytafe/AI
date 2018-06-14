using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float maxHealth = 100f;
        [Header("UI")]
        public GameObject healthBarUI;
        public Vector2 healthBarOffset = new Vector2(0f, 5f);

        private Slider healthSlider;
        private float health = 100f;

        public void DealDamage(float damage)
        {
            //Deal damage to enemy
            health -= damage;
            // Update the slider
            if (healthSlider)
            {
                // Converts health to a 0-1 value
                healthSlider.value = health / maxHealth;
            }
            //If there is no health
            if(health <= 0)
            {
                //Kill off the gameObject
                Destroy(gameObject);
            }
        }

        // Use this for initialization
        void Start()
        {
            health = maxHealth;
        }

        void OnDestroy()
        {
            // If there is a health slider created
            if (healthSlider)
            {
                // Destroy it
                Destroy(healthSlider.gameObject);
            }
        }

        Vector3 GetHealthBarPos()
        {
            Camera cam = Camera.main;
            Vector2 position = cam.WorldToScreenPoint(transform.position);
            return position + healthBarOffset;
        }

        // Update is called once per frame
        void Update()
        {
            if(healthSlider)
            {
                // Update it's postion in UI
                healthSlider.transform.position = GetHealthBarPos();
            }
        }

        public void SpawnHealthBar(Transform parent)
        {
            // create new health bar at calculated position
            // and attached to the new parent
            GameObject clone = Instantiate(healthBarUI, GetHealthBarPos(), Quaternion.identity, parent);
            // Get the slider component for late use
            healthSlider = clone.GetComponent<Slider>();
        }
    }
}