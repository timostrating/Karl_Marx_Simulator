using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 2.0f;
    Transform target;

	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move ()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        
    }
}
