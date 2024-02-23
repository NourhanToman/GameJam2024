using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TextManger : MonoBehaviour
{
    public static TextManger instance;

    List<Message> Dialogmessages;

    [SerializeField]GameObject _player;
    [SerializeField]GameObject _textPrefab;
    [SerializeField] float _dialogTxtDistance;
    [SerializeField] float _interactTxtDistnce;
    [SerializeField] Vector3 _dialogScale;
    [SerializeField] Vector3 _interactableTxtScale;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        LoadDialog();
        _dialogScale = _textPrefab.transform.localScale;
    }
    private void LoadDialog()
    {
        string[] script = File.ReadAllLines("Assets/Resources/Reaper_Dialoge.txt");
        int count = 1;
        /*foreach(Message msg in Dialogmessages)
        {
            msg.audioName = $"{count}";
            msg.message = script[count-1];
            Dialogmessages.Add(msg);
            count++;
        } */
    }
    public void PlayMessage(int messageNo)
    {
        ShowDialogText(Dialogmessages[messageNo]?.message);
        AudioManager.instance.Play(AudioType.Dialog, Dialogmessages[messageNo]?.audioName);
    }
    public void ShowDialogText(string message)
    {
        Vector3 playerForward = _player.transform.forward;
        GameObject messageObj = Instantiate(_textPrefab, playerForward + new Vector3(0,0,_dialogTxtDistance) , Quaternion.identity);

        messageObj.transform.localScale = _dialogScale;
        messageObj.GetComponent<TextMeshPro>().text = message;
        messageObj.GetComponent<TextAnimation>().StartAnimation();
    }
    public void ShowInteractableText(Transform interactable , InteractableObjText message)
    {
       
        GameObject messageObj = Instantiate(_textPrefab, interactable.position + new Vector3(0, _interactTxtDistnce, 0), Quaternion.identity);

        messageObj.transform.localScale = _interactableTxtScale;
        messageObj.GetComponent<TextMeshPro>().text = message.messageText;
        messageObj.GetComponent<TextAnimation>().StartAnimation();
    }
}
