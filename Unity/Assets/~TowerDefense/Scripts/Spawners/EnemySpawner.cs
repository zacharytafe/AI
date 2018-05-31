﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class EnemySpawner : Spawner
    {
        public Transform path;
        [Header("UI")]
        public Transform healthBarParent;

        private Transform start;
        private Transform end;

        void GetPath()
        {
            if(path != null)
            {
                start = path.FindChild("Start");
                end = path.FindChild("End");
            }
        }

        // Use this for initialization
        void Start()
        {
            GetPath();
        }

        public override void Spawn()
        {
            // Create a new instance of a prefab
            GameObject clone = Instantiate(prefab, start.position, start.rotation);
            // Set clone under spawner as cild
            clone.transform.SetParent(transform);
            // Set agent's target to end transform
            AIAgents agent = clone.GetComponent<AIAgents>();
            agent.target = end;

            // Spawn a health bar
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.SpawnHealthBar(healthBarParent);
        }
    }
}