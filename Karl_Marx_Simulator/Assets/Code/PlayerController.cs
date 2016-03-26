using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject projectile;
    public float projectileSpeed = 15.0f;
    public float firingRate = 0.2f;
    public float speed = 2.5f;
    float xmin;
    float xmax;
    float ymin;
    float ymax;
    float padding = 0.3f;



    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        xmin = bottomLeft.x + padding;
        xmax = topRight.x - padding;
        ymin = bottomLeft.y + padding;
        ymax = topRight.y - padding;
    }

    void Update () {
        // Starts shooting when left mouse button is clicked and stops when it is released
        if (Input.GetMouseButtonDown(0)) {
            InvokeRepeating("Shoot", Mathf.Epsilon, firingRate);
        } else if (Input.GetMouseButtonUp(0)) {
            CancelInvoke("Shoot");
        }

        Move();
    }

    void Move () {
        // vertical and horizontal movement are separated into different loops to allow for both simultaneously
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        // clamps player to window
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void Shoot () {
        // Gets player  and cursor position
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        // sets projectile movement direction and rotation toward the cursor 
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + -90);

        // fires the projectile  and set speed
        GameObject newProjectile = Instantiate(projectile, myPos, rotation) as GameObject;
        newProjectile.GetComponent<Projectile>().SetSpeed(projectileSpeed);
    }
}
