using UnityEngine;

public class LivingObject : MonoBehaviour, IDamageable{

    public float health = 1f;
    protected bool dead;

    public virtual void TakeHit (float damage, Vector3 hitPoint, Vector3 hitDirection) {
        TakeDamage(damage);
    }

    public virtual void TakeDamage (float damage) {
        health -= damage;

        if (health <= 0 && !dead) {
            Die();
        }
    }

    public virtual void Die () {
        dead = true;
        GameObject.Destroy(gameObject);
    }
}
