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

    [SerializeField] GameObject _DialogTextPrefab;
    [SerializeField] GameObject _InteractablePrefab;

    [SerializeField] float _dialogTxtDistance;
    [SerializeField] float _interactTxtDistnce;
    [SerializeField] float _dialogHight;


    [SerializeField] Vector3 _dialogScale;
    [SerializeField] Vector3 _interactableTxtScale;
    public GameObject _player;
    

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log(".");
            Destroy(gameObject);
           
        }
        else
        {
            instance = this;
            Debug.Log("..");
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        
        Dialogmessages = new List<Message>();
        _dialogScale = _DialogTextPrefab.transform.localScale;
        LoadDialog();
       
       
    }

    private void Update()
    {
        _player = Camera.main.gameObject;
    }
    private void LoadDialog()
    {
        string[] script = File.ReadAllLines("Assets/Resources/Reaper_Dialoge.txt");
        int count = 1;
        foreach (string str in script)
        {
            Message msg = new Message();
            msg.audioName = $"{count}";
            msg.message = str;
            msg.messageNo = count;
            Dialogmessages.Add(msg);
            count++;
        }
    }
    public void PlayMessage(int messageNo)
    {
       
        ShowDialogText(Dialogmessages[messageNo]?.message);
        
        AudioManager.instance.Play(AudioType.Dialog, Dialogmessages[messageNo]?.audioName);
    }
    public void ShowDialogText(string message)
    {
        Vector3 playerForward = _player.transform.forward.normalized;
        GameObject messageObj = Instantiate(_DialogTextPrefab, new Vector3(_player.transform.position.x,
            _player.transform.position.y + _dialogHight,
            _player.transform.position.z + _dialogTxtDistance) , _DialogTextPrefab.transform.rotation,_player.transform);

        messageObj.transform.localScale = _dialogScale;
        messageObj.GetComponent<TextMeshPro>().text = message;
        messageObj.GetComponent<TextAnimation>().StartAnimation();
    }
    public void ShowInteractableText(Transform interactable , InteractableObjText message)
    {
       
        GameObject messageObj = Instantiate(_InteractablePrefab, interactable.position + new Vector3(0, _interactTxtDistnce, 0), Quaternion.identity);

        messageObj.transform.localScale = _interactableTxtScale;
        messageObj.GetComponent<TextMeshPro>().text = message.messageText;
        messageObj.GetComponent<TextAnimation>().StartAnimation();
    }
    public void ShowInteractableText(Transform interactable, string message , float offSet)
    {

        GameObject messageObj = Instantiate(_InteractablePrefab, new Vector3(0, offSet, 0), Quaternion.identity , interactable);

        messageObj.transform.localScale = _interactableTxtScale;
        messageObj.GetComponent<TextMeshPro>().text = message;
        TextAnimation txtAnim = messageObj.GetComponent<TextAnimation>();
        txtAnim.keepText = true;
        txtAnim.StartAnimation();

    }
}
