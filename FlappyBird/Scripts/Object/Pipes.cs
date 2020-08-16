using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Start is called before the first frame update
    public float m_speed = 1.5f;
    Vector3 m_position;

    void Start()
    {
        // 
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerPawn.isGameRunning)
        {
            return;
        }
        // keep moving to left from right
        this.m_position = this.transform.position;
        this.m_position.x -= Time.deltaTime * this.m_speed;
        this.transform.position = this.m_position;
    }
}
