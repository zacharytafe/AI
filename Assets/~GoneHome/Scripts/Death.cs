using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

namespace GoneHome
{

    public class Death : MonoBehaviour
    {
        public UnityEvent onDeath;

        // Gets called when Triggered by other object
        void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("DeathZone") ||
                other.name.Contains("Enemy"))
            {
                // We can kill it!
                onDeath.Invoke();
            }
        }

        // Restarts elements in the level (without destroying)
        public void RestartLevel()
        {
            // Grab all FollowEnemy game objects from scene
            FollowEnemy[] followEnemies = FindObjectsOfType<FollowEnemy>();
            // Loop through each one
            foreach (var enemy in followEnemies)
            {
                // Reset enemy
                enemy.Reset();
            }

            // TASK: Reset all PatrolEnemies
            // >>>INSERT CODE HERE<<<

            // Get the player from the scene
            Player player = FindObjectOfType<Player>();
            // Reset the player
            player.Reset();
        }

    }
}