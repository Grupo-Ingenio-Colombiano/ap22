using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using UnityEditor.VersionControl;

namespace Vp_Packages
{
    public class Instructions : MonoBehaviour
    {
        public int numberOfInstructions;

        public TextMeshProUGUI defaultInstructionsText;

        public TextMeshProUGUI instruction;
        public TextMeshProUGUI instructionCounter;
        public RawImage imageInstructions;

        [Header("Instructions Containers")]
        public GameObject[] instructionsContainer;
        [SerializeField] private GameObject container;

        [TextArea]
        public string defaultMessage;
        [Header("Insert Instructions")]

        [TextArea] public string[] instructions;
        // public Texture[] instructionImages = new Texture[5];

        private int currentItem;
        int counter = 1;

        [Header("Insert Instructions Titles")]

        public string[] instructionsTitles;
        public TextMeshProUGUI title;


        [Header("Indicator Positions")]

        public GameObject[] indicatorPositions;
        public GameObject indicatorOut;
        //public GameObject objectPos;
        public Vector2 objectsPos;

        [Header("Buttons Management")]
        public GameObject nextBtn;
        public GameObject backBtn;
        public GameObject continueBtn;
        public GameObject skipBtn;
        public GameObject indicator;

        [Header("Callback when completing or skipping the instructions")]
        public UnityEvent OnCompletedOrSkippedInstructions;

        [Header("The instructions are shoed by default?")]
        public bool showOnStart = true;

        private bool hasTriggered = false;
        [SerializeField] UserData userData;
        [SerializeField] GameObject instructionPanel;

        // Start is called before the first frame update
        void Start()
        {
            if (userData.isSave == true)
            {
                instructionPanel.SetActive(false);
            }

            if (showOnStart)
            {
                defaultInstructionsText.text = defaultMessage;
                ShowInstruction();
            }
            else
            {
                foreach(var container in instructionsContainer)
                {
                    container.SetActive(false);
                    container.SetActive(false);
                    
                }
            }
    #if UNITY_ANDROID
            instructions[0] = "Utilice el Joystick para moverse por la planta.";
            instructions[1] = "Para correr, deslice el Joystick arriba hasta el punto maximo";
            instructions[2] = "Utilice el bot�n vista de c�mara para cambiar la c�mara a primera o tercera persona";
            instructions[9] = "Con el bot�n 'Soltar' dentro del inventario puede regresar los �tems seleccionados a su lugar.";
    #endif
            for(int i = 0; i< indicatorPositions.Length;i++)
            {
                if(indicatorPositions[i] == null)
                {
                    indicatorPositions[i] = indicatorOut;
                }
            }

        }
        private void Update()
        {
            if (currentItem == 0)
            {
                skipBtn.SetActive(true);
            }
            else
            {
                if (currentItem >= 1)
                {
                    skipBtn.SetActive(false);

                }
            }
        }

        //Si las instrucciones no se muestran por defecto, se debe llamar este metodo
        public void ShowInstructionsFirstTime()
        {
            container.SetActive(true);
            instructionsContainer[0].SetActive(true);
            instructionsContainer[1].SetActive(false);
            instructionsContainer[2].SetActive(false);
            currentItem = 0;
            counter = 1;
            ShowInstruction();
        }

        public void NextButton()
        {
            currentItem++;
            counter++;
            if (currentItem > instructions.Length - 1)
            {
                currentItem = 0;

            }
            ShowInstruction();
        }
        public void BackButton()
        {
            currentItem--;
            counter--;

            if (currentItem < 0)
            {
                currentItem = instructions.Length - 1;
            }
            ShowInstruction();

        }

        public void ShowInstruction()
        {
            instruction.text = instructions[currentItem];
            title.text = instructionsTitles[currentItem];

            objectsPos = indicatorPositions[currentItem].transform.position;
            indicator.transform.position = objectsPos;

            // imageInstructions.texture = instructionImages[currentItem];
            instructionCounter.text = counter.ToString() + " / " + numberOfInstructions.ToString();

            if (counter == 1)
            {
                backBtn.SetActive(false);

            }
            else
            {
                backBtn.SetActive(true);
                continueBtn.SetActive(false);

            }
            if (counter == numberOfInstructions)
            {
                nextBtn.SetActive(false);
                continueBtn.SetActive(true);
            }
            else
            {
                nextBtn.SetActive(true);
                continueBtn.SetActive(false);

            }


            if(counter == 15)
            {
                VpNewNotice.StartSavingAnimation();
                VpNewNotice.StopSavingAnimation();
            }
        }

        public void ResetInstructions()
        {
            currentItem = 0;
            counter = 1;
            ShowInstruction();

        }

        //Se activa cuando las instrucciones se acaban o cuando el usuario las salta
        public void TriggerEndInstructions()
        {
            container.SetActive(false);
            if(!hasTriggered)
            {
                hasTriggered = true;
                OnCompletedOrSkippedInstructions?.Invoke();
            }
        }
    }

}
