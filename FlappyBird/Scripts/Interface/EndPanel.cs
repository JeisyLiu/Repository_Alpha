using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    // Start is called before the first frame update

    // components on canvas
    Button m_btn_restart;
    Button m_btn_quit;
    Text m_text_bestscore;
    Text m_text_currentscore;

    void Start()
    {
        Debug.Log("End panel started");
        this.m_btn_restart = this.transform.Find("Restart_BTN").gameObject.GetComponent<Button>();
        this.m_btn_quit = this.transform.Find("Quit_BTN").gameObject.GetComponent<Button>();
        this.m_text_bestscore = this.transform.Find("BestScore_TXT").gameObject.GetComponent<Text>();
        this.m_text_currentscore = this.transform.Find("CurrentScore_TXT").gameObject.GetComponent<Text>();

        this.m_btn_restart.onClick.AddListener(RestartGame);
        this.m_btn_quit.onClick.AddListener(QuitGame);
        this.m_text_bestscore.text = "最高得分是 " + GameDataManager.SuperBird.getInstance().m_BestScore;
        this.m_text_currentscore.text = "当前得分是 " + GameDataManager.SuperBird.getInstance().m_CurrentScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RestartGame()
    {
        // TODO: call the event manager
    }

    void QuitGame()
    {
        // TODO: call the evn
    }

    public void ActivateEndPanel()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateEndPanel()
    {

    }
}
