using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float health = 100f;

        public void DealDamage(float damage)
        {
            //Deal damage to enemy
            health -= damage;
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

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}