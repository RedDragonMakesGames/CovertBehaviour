using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has died!");
            FindObjectOfType<TextMeshProUGUI>().text = "You died! Press R to restart";
            Time.timeScale = 0;                 //Pause game
        }
    }
}
