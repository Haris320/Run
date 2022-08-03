using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    GameObject player;
    public GameObject camera;
    public static bool gravity;
    float speed = 3.5f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        gravity = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -3 || transform.position.y >4)
            SceneManager.LoadScene(sceneName: "SampleScene");


        if(Input.GetKey(KeyCode.Space) && !gravity)
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
            
            camera.transform.Rotate(0,90,180);
        }

        if (Input.GetKey(KeyCode.Space) && gravity)
        {
            Physics.gravity = new Vector3(0, 9.8f, 0);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(gravity)
                transform.Translate(Vector3.forward * Time.deltaTime * 1, Space.World);
            else
                transform.Translate(Vector3.back * Time.deltaTime * 2, Space.World);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(gravity)
                transform.Translate(Vector3.back * Time.deltaTime * 2, Space.World);
            else
                transform.Translate(Vector3.forward * Time.deltaTime * 1, Space.World);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(gravity)
                rb.AddForce(Vector2.up * 0.05f, ForceMode.Impulse);
            else
                rb.AddForce(Vector2.down * 0.1f, ForceMode.Impulse);
        }


        Debug.Log(gravity);

        //Vector3 pos = new Vector3()

        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        //camera.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        //camera.transform.position = Vector3.MoveTowards(transform.position, transform.position, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(GameObject.Find("Player").transform.position.y);
        if (collision.gameObject.name.Contains("Obstacle"))
        {
            SceneManager.LoadScene(sceneName: "SampleScene");
        }

        if (collision.gameObject.transform.parent.gameObject.name.Contains("Ceiling"))
        {
            gravity = false;

        }

        if (collision.gameObject.transform.parent.gameObject.name.Contains("Floor"))
        {
            gravity = true;
        }

        

    }

}
