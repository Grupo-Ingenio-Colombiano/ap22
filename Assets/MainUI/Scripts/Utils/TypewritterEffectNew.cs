
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewritterEffectNew : MonoBehaviour
{

    [TextArea]
    public string m_text;
    //[Range(0.01f, 0.1f)]
    [Range(0.01f, 1f)]
    public float m_characterInterval; //(in secs)

    private string m_partialText;
    private float m_cumulativeDeltaTime;
    string[] words;

    [SerializeField]
    bool wordMode;

    private Text m_label;
    int count;


    private void OnEnable()
    {
        m_partialText = "";
        m_label.text = "";
        m_cumulativeDeltaTime = 0;
        count = 0;
    }

    void Awake()
    {
        m_label = GetComponent<Text>();
        words = m_text.Split(' ');
    }

    void Start()
    {
        //m_partialText = "";
        //m_cumulativeDeltaTime = 0;
        //count = 0;
    }

    void Update()
    {

        if (wordMode)
        {
            WordWritting();
        }
        else
        {
            LetterWriting();
        }

    }

    private void LetterWriting()
    {
        m_cumulativeDeltaTime += Time.deltaTime;
        while (m_cumulativeDeltaTime >= m_characterInterval && m_partialText.Length < m_text.Length)
        {
            m_partialText += m_text[m_partialText.Length];
            m_cumulativeDeltaTime -= m_characterInterval;
        }
        m_label.text = m_partialText;
    }

    private void WordWritting()
    {
        m_cumulativeDeltaTime += Time.deltaTime;
        while (m_cumulativeDeltaTime >= m_characterInterval && count < words.Length)
        {
            m_partialText += (words[count] + " ");
            m_cumulativeDeltaTime -= m_characterInterval;
            count++;
        }
        m_label.text = m_partialText;
    }
}