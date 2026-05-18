using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;      // ton prefab ennemi
    public Transform player;            // référence au joueur
    public float spawnOffsetX = 15f;    // distance à droite du joueur où les ennemis spawn
    public int enemiesPerWave = 15;     // nombre d'ennemis par vague
    public float timeBetweenWaves = 25f;
    public float timeBetweenSpawns = 0.2f; // petit délai entre chaque spawn dans la vague

    void Start()
    {
        StartCoroutine(WaveLoop());
    }

    private IEnumerator WaveLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            yield return StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            // Spawn à droite du joueur, à la même hauteur (Y) que lui
            Vector3 spawnPos = new Vector3(
                player.position.x + spawnOffsetX,
                player.position.y,
                0f
            );

            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            // On passe la référence au joueur à l'ennemi
            enemy.GetComponent<Enemy>().player = player;

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
