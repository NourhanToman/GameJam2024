using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
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
        UnityEngine.TextAsset textAsset = Resources.Load<UnityEngine.TextAsset>("Reaper_Dialoge");
        string[] script = textAsset.text.Split('\n');
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
        GameObject messageObj = Instantiate(_DialogTextPrefab);
        messageObj.transform.localScale = _dialogScale;
        messageObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = message;
        messageObj.transform.GetChild(0).GetComponent<TextAnimationGUI>().StartAnimation();
    }
    public void ShowInteractableText(Transform interactable , InteractableObjText message)
    {
       
        GameObject messageObj = Instantiate(_InteractablePrefab, interactable.position + new Vector3(0, _interactTxtDistnce, 0), Quaternion.identity,interactable);

        messageObj.transform.localScale = _interactableTxtScale;
        messageObj.GetComponent<TextMeshPro>().text = message.messageText;
        messageObj.GetComponent<TextAnimation>().StartAnimation();
    }
    public void ShowInteractableText(Transform interactable, string message , float offSet)
    {

        GameObject messageObj = Instantiate(_InteractablePrefab, interactable.transform.position+ new Vector3(0, offSet, 0), Quaternion.identity,interactable);

        messageObj.transform.localScale = _interactableTxtScale;
        messageObj.GetComponent<TextMeshPro>().text = message;
        TextAnimation txtAnim = messageObj.GetComponent<TextAnimation>();
        txtAnim.keepText = true;
        txtAnim.StartAnimation();

    }
}
