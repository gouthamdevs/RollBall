using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed;
    private int count;
    public TextMeshProUGUI PointsText;
    public GameObject WinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject LoseText;

    public GameObject EnemeyObject;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetPoints();
        WinText.SetActive(false);
        LoseText.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        if (transform.position.y < 0)
        {
            LoseText.SetActive(true);
            if (transform.position.y < -20)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUP"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetPoints();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {   
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            LoseText.SetActive(true);
        }
    }


    void SetPoints()
    {
        PointsText.text = "Points:" + count.ToString();
        if (count >= 9)
        {
            Destroy(EnemeyObject);
            WinText.SetActive(true);
        }
    }
    

}
