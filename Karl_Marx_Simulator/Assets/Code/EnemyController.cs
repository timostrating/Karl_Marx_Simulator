using UnityEngine;
using System.Collections;

public class EnemyController : LivingObject {

    public float speed = 2.0f;
    private Transform target;
    private Renderer mainRenderer;


    void Start () {
        mainRenderer = gameObject.GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () {
        Move();
    }

    void Move () {
        if (Vector3.Distance(transform.position, target.position) > 1f) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }


    }

    public override void TakeHit (float damage, Vector3 hitPoint, Vector3 hitDirection) {
        StartCoroutine( Flash() );
        base.TakeHit(damage, hitPoint, hitDirection);
    }

    IEnumerator Flash () {
        Color32 c = this.mainRenderer.material.color;

        this.mainRenderer.material.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        this.mainRenderer.material.color = c;
    }
}
