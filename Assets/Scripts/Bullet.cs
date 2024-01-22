using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Vector3 _direction;

    public void Fire(Vector3 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if (_direction != Vector3.zero)
        {
            transform.position += _speed * Time.deltaTime * _direction;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enenmy = other.gameObject.GetComponent<Enemy>();
        if (enenmy != null)
        {
            enenmy.TakeDamage(5);
            Destroy(gameObject);
        }
    }
}