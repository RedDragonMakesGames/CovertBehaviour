using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicButton : MonoBehaviour
{
    private bool triggered = false;
    public float panicTime = 5.0f;
    private float panicStartTime = 0.0f;

    public Material panicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && Time.time > panicStartTime + panicTime) 
        {
            BasicEnemy[] enemies = GameObject.FindObjectsOfType<BasicEnemy>();
            foreach (BasicEnemy enemy in enemies)
            {
                enemy.SetPanicking(false);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = true;
            panicStartTime = Time.time;
            BasicEnemy[] enemies = GameObject.FindObjectsOfType<BasicEnemy>();
            foreach (BasicEnemy enemy in enemies)
            {
                enemy.SetPanicking(true);
            }
            GetComponent<Renderer>().material = panicked;
        }
    }
}
