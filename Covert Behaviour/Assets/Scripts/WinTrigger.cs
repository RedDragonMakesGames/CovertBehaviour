using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinTrigger : MonoBehaviour
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
            Debug.Log("You win!");
            FindObjectOfType<TextMeshProUGUI>().text = "You won! Hope you enjoyed, press R if you want to play again!";
            Time.timeScale = 0;                 //Pause game
        }
    }
}
