using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PipeCreator : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> m_PipePool = new List<GameObject>();
    Vector3 m_PipeInitPos;
    private float m_time = 0;
    private float m_deltatime = 2.0f;
    void Start()
    {
        this.m_PipeInitPos = new Vector3(8.69f, 0, 20); //
    }

    // Update is called once per frame
    void Update()
    {
        // Generate Pipes by time
        if (!PlayerPawn.isGameRunning)
        {
            return;
        }

        // fetch the pipe if the pipe exists
        this.m_time += Time.deltaTime;
        if(this.m_time > this.m_deltatime)
        {
            this.m_time = 0;
            if (!FetchOldPipe())
            {
                GenerateNewPipe();
            }
        }
    }

    private void GenerateNewPipe()
    {
        // create a new pipe from Resource
        GameObject pipe = GameObject.Instantiate(Resources.Load<GameObject>("Object/PipeGroup"));
        pipe.transform.SetParent(this.transform);
        // init the property of pipe coordinate
        this.m_PipeInitPos.y = MathTools.RandomNumberGenerator(-48, 0) / 10;
        pipe.transform.position = this.m_PipeInitPos;
        this.m_PipePool.Add(pipe);
    }

    private bool FetchOldPipe()
    {
        GameObject requiredPipes = this.m_PipePool.Find(alpha => alpha.transform.position.x < -10);
        if (requiredPipes != null)
        {
            requiredPipes.transform.SetParent(this.transform);
            this.m_PipeInitPos.y = MathTools.RandomNumberGenerator(-48, 0) / 10;
            requiredPipes.transform.position = this.m_PipeInitPos;
            return true;
        }
        return false;
    }
}
