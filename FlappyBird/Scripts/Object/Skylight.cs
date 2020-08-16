using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skylight : MonoBehaviour
{
    // Start is called before the first frame update
    float m_totaltime;
    Light m_skylight;
    void Start()
    {
        this.m_skylight = this.GetComponent<Light>();
        this.m_totaltime = 0;
        Debug.Log("Start daylight");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPawn.isGameRunning)
        {
            this.m_skylight.intensity = Mathf.Abs(Mathf.Sin(this.m_totaltime += Time.deltaTime / 5) * 2);
        }
    }
}
