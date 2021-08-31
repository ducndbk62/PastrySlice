using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public Vector3 force;
    public Vector3 dragForce;
    public GameObject gameFinish;
    public GameObject gameOver;
    public GameObject blade;
    public GameObject btnRevive;
    public GameObject txtCheckPoint;
    public GameObject wall;

    AudioSource audioSource;
    public AudioClip soundKnife;
    public AudioClip soundHolder;

    Collider bladeCollider;

    float lastKinematic = -1.0f;
    float kinematicTime = 0.3f;

    float lastDragTime;
    float dragTime = 0.5f;

    bool isSlow = true;
    bool passedCheckPoint;
    public Vector3 revivePosition;

    Scene scene;
    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        bladeCollider = blade.GetComponent<Collider>();
        m_Rigidbody.centerOfMass = new Vector3(-0.5f, 0, 0);
        scene = SceneManager.GetActiveScene();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        passedCheckPoint = false;

        audioSource = gameObject.GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetButtonDown("Fire1"))
                Jump();
            AdjustRotation();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (Time.time - lastKinematic > kinematicTime)
        //    if (collision.GetContact(0).thisCollider.tag == "Blade" &&
        //       (collision.GetContact(0).otherCollider.tag == "Holder" ||
        //        collision.GetContact(0).otherCollider.tag == "CheckPoint" ||
        //        collision.GetContact(0).otherCollider.tag == "Bonus"))
        //    {
        //        audioSource.clip = soundHolder;
        //        audioSource.Play();
        //        m_Rigidbody.isKinematic = true;
        //    }
        if (collision.GetContact(0).thisCollider.tag == "Hilt")
        {
            audioSource.clip = soundHolder;
            audioSource.Play();
            m_Rigidbody.isKinematic = true;
            m_Rigidbody.isKinematic = false;
            if (collision.transform.position.y < gameObject.transform.position.y)
                m_Rigidbody.AddForce(new Vector3(0, 700, 0));
            //else m_Rigidbody.AddForce(new Vector3(, -200, 0));
            m_Rigidbody.angularVelocity = new Vector3(0, 0, -20);
        }
        
        if (collision.gameObject.tag == "Ground")
        {
            Time.timeScale = 0;
            if (!passedCheckPoint)
                btnRevive.SetActive(false);
            gameOver.SetActive(true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        bladeCollider.isTrigger = true;
    }

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Holder":
                //bladeCollider.isTrigger = false;
                if (Time.time - lastKinematic > kinematicTime)
                {
                    m_Rigidbody.isKinematic = true;
                    audioSource.clip = soundHolder;
                    audioSource.Play();
                    
                }                     
                break;
            case "CheckPoint":
                //bladeCollider.isTrigger = false;
                if (Time.time - lastKinematic > kinematicTime)
                {
                    m_Rigidbody.isKinematic = true;
                    audioSource.clip = soundHolder;
                    audioSource.Play();
                    
                }
                passedCheckPoint = true;
                txtCheckPoint.SetActive(true);
                break;
            case "Bonus":
                wall.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //bladeCollider.isTrigger = false;
                if (Time.time - lastKinematic > kinematicTime)
                {
                    m_Rigidbody.isKinematic = true;
                    audioSource.clip = soundHolder;
                    audioSource.Play();
                    
                }
                break;
            case "Ground":
                Time.timeScale = 0;
                if (!passedCheckPoint)
                    btnRevive.SetActive(false);
                gameOver.SetActive(true);
                break;
            case "ObjSliced":
                if (Time.time - lastDragTime > dragTime)
                {
                    m_Rigidbody.AddForce(dragForce);
                    m_Rigidbody.angularVelocity = new Vector3(0, 0, -0.1f);
                    lastDragTime = Time.time;
                }
                break;
            case "Finish":
                Time.timeScale = 0;
                gameFinish.SetActive(true);
                break;
            case "X2":                
                gameController.GetComponent<GameController>().MultipleLevelCoins(2);
                break;
            case "X3":
                gameController.GetComponent<GameController>().MultipleLevelCoins(3);
                break;
            case "X4":
                gameController.GetComponent<GameController>().MultipleLevelCoins(4);
                break;
            case "X5":
                gameController.GetComponent<GameController>().MultipleLevelCoins(5);
                break;
            case "X10":
                gameController.GetComponent<GameController>().MultipleLevelCoins(10);
                break;
        }    
    }

    void Jump()
    {
        bladeCollider.isTrigger = true;
        isSlow = true;
        audioSource.clip = soundKnife;
        audioSource.Play();
        if (m_Rigidbody.isKinematic)
        {
            lastKinematic = Time.time;
            m_Rigidbody.isKinematic = false;
        }
        else
        {
            m_Rigidbody.isKinematic = true;
            m_Rigidbody.isKinematic = false;
        }
        m_Rigidbody.AddForce(new Vector3(0, 100, 0));
        m_Rigidbody.AddForceAtPosition(force, transform.position - new Vector3(90, 0, 0));
    }

    void AdjustRotation()
    {
        if (!isSlow)
        {
            if (gameObject.transform.right.x > 0 && gameObject.transform.right.y < 0)
            {
                m_Rigidbody.angularVelocity = new Vector3(0, 0, -1f);
                isSlow = true;
            }
        }
        else if (gameObject.transform.right.x < 0.9)
        {
            m_Rigidbody.angularVelocity = new Vector3(0, 0, -80);
            isSlow = false;
        }
    }

    public void Revive()
    {
        gameObject.transform.position = revivePosition;
        gameObject.transform.right = new Vector3(-1, -2, 0);
        m_Rigidbody.isKinematic = true;
        //m_Rigidbody.isKinematic = false;
        gameOver.SetActive(false);
        Time.timeScale = 1.1f;
    }
}