using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectCharacter : MonoBehaviour
{
    public int actualCharacter;

    public Transform sphereTrasnform;

    public int[] character;

    public float speed = 0.5f;

    public bool rotate;
    Quaternion moveTo;

    public Text characterName;
    public string[] characterNames;
    public Image characterImage;
    public Sprite[] characterSprites;

    public GameObject buttonNext;
    public GameObject buttonPrev;

    public bool RecorridoLibre;

     [SerializeField]
     AudioSource audioSource;

    [Header("Fill fields below")]
    [SerializeField]
    UserData userdata;

    public void Start()
    {
        SetCharacters();
    }

    public void Next()
    {
        if (actualCharacter >= character.Length - 1)
        {
            actualCharacter = 0;
        }
        else
        {
            actualCharacter++;
        }

        int to = actualCharacter * 90;

        Debug.Log(to);

        moveTo = Quaternion.Euler(0, to, 0);

        rotate = true;

        SetCharacters();
    }

    public void Prev()
    {
        if (actualCharacter <= 0)
        {
            actualCharacter = character.Length - 1;
        }
        else
        {
            actualCharacter--;
        }
        int to = actualCharacter * 90;

        Debug.Log(to);

        moveTo = Quaternion.Euler(0, to, 0);

        rotate = true;

        SetCharacters();
    }

    public void Update()
    {
        if (rotate)
        {
            sphereTrasnform.rotation = Quaternion.RotateTowards(sphereTrasnform.rotation, moveTo, speed * Time.deltaTime);
        }
    }

    public void SetCharacters()
    {
        foreach (Transform child in sphereTrasnform)
        {
            if (child.gameObject.name == actualCharacter.ToString())
            {
                child.gameObject.transform.localScale = new Vector3(0.28f, 0.005f, 0.28f);
            }
            else
            {
                child.gameObject.transform.localScale = new Vector3(0.1708774f, 0.00309491f, 0.1708774f);
            }
        }

        characterName.text = characterNames[actualCharacter];
        characterImage.sprite = characterSprites[actualCharacter];
        userdata.PlayerSelected = actualCharacter.ToString();
        print(actualCharacter.ToString()+" selected");
    }

    public void CharacterSelect()
    {
        PlayerPrefs.SetInt("Character", actualCharacter);

        audioSource.Play();

        buttonNext.SetActive(false);
        buttonPrev.SetActive(false);

        int activeScene = SceneManager.GetActiveScene().buildIndex;   
        LevelLoader.sceneToload = activeScene + 1;        
        SceneManager.LoadScene("Loading", LoadSceneMode.Additive);

    }

    public void BackScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;   
        LevelLoader.sceneToload = activeScene - 1;        
        SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
    }

    public void Help()
    {
        Application.OpenURL("https://ingeniocolombiano.com/");
    }
}
