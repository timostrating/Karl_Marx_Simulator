using UnityEngine;

public class Projectile : MonoBehaviour {

    public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;

    float lifetime = 3;
    float skinWidth = .1f;

    void Start () {
        Destroy(gameObject, lifetime);

        Collider2D[] initialCollisions = Physics2D.OverlapCircleAll (transform.position, .1f, collisionMask);
        if (initialCollisions.Length > 0) {
            OnHitObject(initialCollisions[0], transform.position);
        }
    }

    public void SetSpeed (float newSpeed) {
        speed = newSpeed;
    }

    void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.up * moveDistance);
    }


    void CheckCollisions (float moveDistance) {
        Ray2D ray = new Ray2D (transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, skinWidth, collisionMask);
        if (hit.collider != null) {
            OnHitObject(hit.collider, hit.point);
        }
    }

    void OnHitObject (Collider2D col, Vector3 hitPoint) {
        IDamageable damageableObject = col.GetComponent<IDamageable> ();
        if (damageableObject != null) {
            damageableObject.TakeHit(damage, hitPoint, transform.forward);
        }
        GameObject.Destroy(gameObject);
    }
}
