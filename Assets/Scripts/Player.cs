using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private GameController _controller;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var mousePosition = Camera.main.ScreenToWorldPoint(screenPos);
            mousePosition.z = 0;
            var direction = mousePosition.normalized;
            SpawnBullet(direction);
        }
    }

    private void SpawnBullet(Vector3 direction)
    {
        var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bullet.Fire(direction);
    }

    public void Die()
    {
        _controller.EndGame();
        Destroy(gameObject);
    }
}