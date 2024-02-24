using UnityEngine;
public class PasscodePuzzle : InteractableBase
{
    [SerializeField] private string passcodeAnswer;
    [SerializeField] private string playerInput;
    [SerializeField] private Transform puzzleSpawner;
    [SerializeField] private GameObject portal;
    [SerializeField] private CamShake camshake;
    public bool isSolved;
    private bool isActive = false;

    bool isY;
    bool isT;
    bool isV;

    public override void OnInteract()
    {
        base.OnInteract();
        isActive = true;
        if (!isSolved)
        {
            DisplayPuzzleText();
        }
        else
        {
            TextManger.instance.ShowInteractableText(transform, "Unlocked", 0.1f);
        }
    }
    private void DisplayPuzzleText()
    {
        TextManger.instance.ShowInteractableText(transform, $"Enter The Password: {new string('*', playerInput.Length)} ", 0.2f);
    }
    public void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                isT = true;
            }
            if (isT)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    isY = true;
                }
                if (isT)
                {
                    if (Input.GetKeyDown(KeyCode.V))
                    {
                        isSolved = true;
                    }
                }
            }
            if(isSolved) 
            { 
                portal.SetActive(true);
                camshake.enabled = false;
                StopPuzzle();
            }
        }
    }
    private void StopPuzzle()
    {
        isActive = false;
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Text"))
            {
                Destroy(child.gameObject);
            }
        }
        if (isSolved)
        {
            TextManger.instance.ShowInteractableText(transform, "Unlocked", 0.1f);
        }
    }
}