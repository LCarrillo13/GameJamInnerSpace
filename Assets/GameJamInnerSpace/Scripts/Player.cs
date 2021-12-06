using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    public GameObject player;

    public Rigidbody rb;

    public int playerSpeed, playerMaxSpeed, playerMinSpeed;
    public float rotationalSpeed, maxRotationalSpeed, minRotationalSpeed;

    
    public ParticleSystem particleSystem;

    public Transform startPos;

    public GameObject pausePanel;
    public bool isPaused;
    
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        rb = GetComponent<Rigidbody>();
        player = gameObject;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        
        if(rb.velocity.magnitude > 0)
        {
            particleSystem.Play(); 
        }
        else
        {
            particleSystem.Stop();
        }
       
        //SetActive(rb.velocity.magnitude > 0);
    }
    
    /// <summary>
    /// Gets the players current inputs
    /// </summary>
    void GetInput()
    {
        // movement
        
        //float torque = 1f;
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up,ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.back,ForceMode.Impulse); 
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.right,ForceMode.Impulse); 
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.left,ForceMode.Impulse); 
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.forward,ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.E))
        {
            rb.AddForce(Vector3.down,ForceMode.Impulse);
        }
        
        // other
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        
    }

    /// <summary>
    /// If the game is not already paused, pauses the game. If the game is already pause, unpauses the game.
    /// </summary>
    void Pause()
    {
        if(!isPaused)
        {
            pausePanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    
    /// <summary>
    /// Kills the player, reseting their velocity and transform position to the spawn point
    /// </summary>
    void Die()
    {
        Debug.Log("Player died");
        rb.velocity = Vector3.zero;
        transform.position = startPos.position;
        
    }
    
    /// <summary>
    /// Swaps to the Win Scene
    /// </summary>
    void Win()
    {
        SceneManager.LoadScene("WinScene");
        // Win stuff
    }

    
    /// <summary>
    /// Triggers Methods depending on what the player collides with. If player collides with the lower boundry or an obstacle, triggers Die method, if player collides with target, triggers Win method.
    /// </summary>
    /// <param name="other">object the player collides with</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("BoundsLimit"))
        {
            Die();
        }
        if(other.transform.CompareTag("Obstacle"))
        {
            Die();
        }
        if(other.transform.CompareTag("Target"))
        {
            Win();
        }
    }
}
