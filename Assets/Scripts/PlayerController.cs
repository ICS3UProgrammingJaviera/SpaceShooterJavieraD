using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    //declare local and global variables
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rb;
    //Get the rigidbody component and assign it to the "rb" variable
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //declare variables and game object components
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private AudioSource audioSource;

    private float nextFire;

    //Make procedure and if statement for if the player shoots using mouse button. Get audiosource component and assign it, then make it play.
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            //Game Object clone
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }
    //make function using physics to make the player move
    void FixedUpdate()
    {
        //Get X and Y axis using "Vertical" and "Horizontal"
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Use verctor movement to make the player as a game object move, calculate player's velocity
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        //make sure the player can't leave the game frame by creating a boundary
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(rb.velocity.z * 0.5f * tilt, 0.0f, rb.velocity.x * -tilt);
    }
}