using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnTime = 3f;

    private float coolDown = 0;
    private bool isEndGame = false;

    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        if (isEndGame) return;

        if (coolDown <= 0)
        {
            coolDown = _spawnTime;
            SpawnEnemy();
            return;
        }

        coolDown -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(_enemyPrefab);

        var posX = Random.Range(-20, 20);
        var posY = Random.Range(-20, 20);

        enemy.transform.position = new Vector3(posX, posY);
    }

    public void EndGame()
    {
        isEndGame = true;
    }
}