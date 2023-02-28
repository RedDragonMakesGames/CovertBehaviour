using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            //Unpause and restart logic here
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed;
        }
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<BasicEnemy>().SetPanicking(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            FindObjectOfType<BasicEnemy>().SetPanicking(false);
        }
        */
    }
}
