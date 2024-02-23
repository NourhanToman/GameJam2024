using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    [Range(0, 0.5f)][SerializeField] float timeStep = 0.5f;
    [Range(0, 0.5f)][SerializeField] float destroyTime = 0.5f;

    private TextMeshPro text;
    int totalVisableCharactersNo;
    int visableCharNo;
    int counter;
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        counter = 0;
    }
    public void StartAnimation()
    {
        StartCoroutine("Animation");
    }
    private IEnumerator Animation()
    {
        while (true)
        {
            totalVisableCharactersNo = text.textInfo.characterCount;
            visableCharNo = counter;
            text.maxVisibleCharacters = visableCharNo;
            if (visableCharNo > totalVisableCharactersNo)
            {
                // counter = 0; for looping the effect
                yield return new WaitForSeconds(destroyTime);
                Destroy(gameObject);
            }
            counter++;
            yield return new WaitForSeconds(timeStep);
        }
    }
}
