using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPawn : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isGameRunning = false;
    public int m_score;
    Vector3 m_JumpForce = new Vector3(0, 5f, 0f);
    Vector3 m_HeadRotation = new Vector3(0, 0, 0);
    Vector3 m_PlusedGravity = new Vector3(0, 10f, 0);
    Rigidbody m_RigidBody;

    int blood = 10;

    void Start()
    {
        Debug.Log("The object starts flying");
        this.m_RigidBody = this.GetComponent<Rigidbody>();
        isGameRunning = false;
        this.m_RigidBody.AddForce(this.m_PlusedGravity, ForceMode.Acceleration);
        this.m_RigidBody.Sleep();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameRunning)
        {
            return;
        }
        // jump 
        if (this.m_RigidBody.IsSleeping())
        {
            this.m_RigidBody.WakeUp();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.m_RigidBody.velocity = Vector3.zero;
            // Obtain the acceleration and calculate the force then plus the force
            this.m_RigidBody.AddForce(this.m_JumpForce, ForceMode.Impulse);
            //this.m_RigidBody.AddRelativeForce(this.m_JumpForce, ForceMode.Impulse);
        }

        // head down and up
        this.m_HeadRotation.y = -this.m_RigidBody.velocity.y / 3 ;
        this.transform.Rotate(this.m_HeadRotation);
        
        // Reach the ground 
        if (this.transform.position.y <= -4.75)
        {
            isGameRunning = false;
            // TODO: GAME STOP             
            Debug.Log("Dropped");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Center")
        {
            Debug.Log("Good!");
            // TODO: Add score and recover more blood
            if (GameDataManager.SuperBird.getInstance().m_CurrentScore++ > GameDataManager.SuperBird.getInstance().m_BestScore)
            {
                GameDataManager.SuperBird.getInstance().m_BestScore = GameDataManager.SuperBird.getInstance().m_CurrentScore;
            }
        }
        else
        {
            Debug.Log("bad");
            // TODO: decrease the blood then show some animation

            // TODO: Pop Restart Game menu

            // TODO: GAME STOP
            isGameRunning = false;
            ResourceIO.getInstance().LoadResourceToView("UI/EndPanel", this.transform);
            
            //startmenu.SetActive(true);
        }
    }
}
