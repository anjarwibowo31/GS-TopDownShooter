using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private List<EnemyAI> enemies = new List<EnemyAI>();

    private void Start()
    {
        Instance = this;
        EnemyAI[] enemyObjects = FindObjectsOfType<EnemyAI>();
        enemies.AddRange(enemyObjects);
    }

    public void EnemyDestroyed(EnemyAI enemy)
    {
        enemies.Remove(enemy);

        if (enemies.Count == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
