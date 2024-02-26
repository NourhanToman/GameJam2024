using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomRoom : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] GameObject mirror;
    [SerializeField] float PortalwaitTime = 10;
    [SerializeField] GameObject player;
    public static BedroomRoom instance;
    AudioClip clip;
    public bool BookOpen = false;
    public bool PortalOpen = false;

    [SerializeField] GameObject PausePanel;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        PausePanel.SetActive(false);
        player.GetComponent<CustomThirdPersonController>().MoveSpeed = 2.5f;
        if (GameManager.Instance.state == GameStates.Win)
        {
            TextManger.instance.PlayMessage(10);
        }
        else
        {
           
            clip = AudioManager.instance.GetClip(AudioType.SFX, "Paper");
            AudioManager.instance.Play(AudioType.SFX, clip);
            StartCoroutine(DelaySound(clip.length, AudioType.SFX, "Player1"));
        }
        
    }
    private IEnumerator DelaySound(float length, AudioType type, string name)
    {
        yield return new WaitForSeconds(length);
        AudioManager.instance.Play(type, name);

        if (BookOpen)
        {
            Debug.Log("opened");
            SetRequired(roomsRequirments.BedroonPortal);
        }
    }
    public void SetRequired(roomsRequirments room)
    {
        if (!BookOpen || !PortalOpen)
        {
            switch (room)
            {
                case roomsRequirments.book:
                    BookOpen = true;
                    StartCoroutine(DelaySound(clip.length, AudioType.SFX, "Player2"));
                    break;
                case roomsRequirments.BedroonPortal:
                    PortalOpen = true;
                    StartCoroutine(StartPortal());
                    break;
            }
        }
    }
    private IEnumerator StartPortal()
    {
        yield return new WaitForSeconds(PortalwaitTime);
        AudioManager.instance.Play(AudioType.SFX, "Portal");
        mirror.gameObject.SetActive(false);
        portal.gameObject.SetActive(true);
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape)) {

            if (PausePanel.gameObject.activeSelf)
            {
                PausePanel.gameObject.SetActive(false);
            }
            else
            {
                PausePanel.gameObject.SetActive(true);
            }
        }
    }
}
