using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    [SerializeField] private Vector3 direction;

    private void Start()
    {
        direction = -transform.position.normalized;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x) < 0.1f && Mathf.Abs(transform.position.y) < 0.1f)
        {
            return;
        }

        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Die();
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    [SerializeField] private float hp = 10;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
}