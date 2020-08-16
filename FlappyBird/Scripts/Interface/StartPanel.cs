using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    // Start is called before the first frame update
    
    Button m_btnStart;
    void Start()
    {
        // init ui controls
        this.m_btnStart = this.transform.Find("Start_BTN").gameObject.GetComponent<Button>();
        this.m_btnStart.onClick.AddListener(ClickStartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClickStartGame()
    {
        Debug.Log("Hey I clicked");
        // disable the view of the UI
        this.gameObject.SetActive(false);
        PlayerPawn.isGameRunning = true;
    }
}
