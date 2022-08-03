using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wall;
    public GameObject player;
    public GameObject obstacle;
    private float time = 0.0f;
    Vector3 vector;
    GameObject child;
    GameObject holeInTheWall;
    int counter = 0;
    bool floor = true;

    float position;
    bool generate = false;

    // Start is called before the first frame update
    void Start()
    {
        generate = true;
        if (wall.gameObject.name.Contains("Ceiling"))
        {
            floor = false;
        }
        

        position = wall.transform.position.x + 4f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > .55)
        {
            if (generate)
            {

                generate = false;
                vector = new Vector3(position, wall.transform.position.y, wall.transform.position.z);
                 int randomNumber = Random.Range(0, 16);

                 GameObject hole = wall.transform.GetChild(randomNumber).gameObject;

                GameObject.Destroy(hole.gameObject);
          

                //Debug.Log("Name "+hole.name); 

                GameObject newWall = Instantiate(wall, vector, transform.rotation);


                int randomObs = Random.RandomRange(-2, 2);
                vector = new Vector3(position, wall.transform.position.y, randomObs);
                GameObject obs = Instantiate(obstacle, vector, wall.transform.rotation);

               

                time = 0;
                position += 4;
                counter++;
            }

            
        }

    }
}
