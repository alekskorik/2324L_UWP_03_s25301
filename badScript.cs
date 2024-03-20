using UnityEngine;
using System.Collections;

public class HorribleScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rigidbody;
    private bool isMoving = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer()
    {
        while (true)
        {
            isMoving = true;
            rigidbody.velocity = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        if (isMoving)
        {
            player.transform.Rotate(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Horrible Script");
    }
}
