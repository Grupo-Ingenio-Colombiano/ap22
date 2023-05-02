using UnityEngine;

public class CharacterAppearanceManager : MonoBehaviour
{
    [SerializeField] GameObject helmet;

    [SerializeField] GameObject glasses;

    [SerializeField] GameObject boots;

    [SerializeField] GameObject casualShoes;

    [SerializeField] GameObject casualPants;

    [SerializeField] GameObject bootPants;

    [SerializeField] GameObject normalHair;

    [SerializeField] GameObject hatHair;

    [SerializeField] GameObject harness;

    [SerializeField] GameObject gloves;

    [SerializeField] GameObject handsAndBody;

    [SerializeField] GameObject glovesAndBody;

    [SerializeField] GameObject mask;

    [SerializeField] GameObject shirt;

    [SerializeField] GameObject coat;

    [SerializeField] GameObject camiseta;

    [SerializeField] GameObject orejeras;

    [SerializeField] GameObject Overol_Botoom;

    [SerializeField] GameObject Overol_Botoom_bots;

    [SerializeField] GameObject Overol_top;

    [SerializeField] GameObject Cronometer;

    [SerializeField] UserData userData;

   

    //metodos casco____________________________________________
    void SetCharWithHelmet()
    {
        if (hatHair != null)
        {
            normalHair.SetActive(false);
            hatHair.SetActive(true);
        }

        helmet.SetActive(true);
    }

    void SetCharWithoutHelmet()
    {

        helmet.SetActive(false);
        if (hatHair != null)
        {
            normalHair.SetActive(true);
            hatHair.SetActive(false);
        }
    }
    //metodos gafas____________________________________________
    void SetCharWithGlasses()
    {
        glasses.SetActive(true);
    }

    void SetCharWithoutGlasses()
    {
        glasses.SetActive(false);
    }

    //metodos botas____________________________________________
    void SetCharWithBoots()
    {

        /*if (Overol_Botoom.activeInHierarchy)
        {
            Overol_Botoom.SetActive(false);
            Overol_Botoom_bots.SetActive(true);

            boots.SetActive(true);
            casualShoes.SetActive(false);

            bootPants.SetActive(false);
        }

        else
        {
            casualPants.SetActive(false);
            bootPants.SetActive(true);

            boots.SetActive(true);
            casualShoes.SetActive(false);
        }*/

        boots.SetActive(true);
        casualShoes.SetActive(false);
    }

    void SetCharWithoutBoots()
    {
        /* (Overol_Botoom_bots.activeInHierarchy)
        {
            Overol_Botoom.SetActive(true);
            bootPants.SetActive(false);
            boots.SetActive(false);
            Overol_Botoom_bots.SetActive(false);
            casualShoes.SetActive(true);
        }
        else
        {

            casualPants.SetActive(true);
            bootPants.SetActive(false);

            boots.SetActive(false);
            casualShoes.SetActive(true);
        }*/

        boots.SetActive(false);
        casualShoes.SetActive(true);
    }

    //metodos Arnes____________________________________________
    void SetCharWithHarness()
    {
        harness.SetActive(true);
    }

    void SetCharWithoutHarness()
    {
        harness.SetActive(false);
    }

    //metodos bata____________________________________________
    void SetCharWithCoat()
    {
        shirt.SetActive(false);
        Overol_top.SetActive(false);
        coat.SetActive(true);
        camiseta.SetActive(false);
    }

    void SetCharWithOutCoat()
    {
        shirt.SetActive(true);
        coat.SetActive(false);
        camiseta.SetActive(false);
    }

    //metodos guantes____________________________________________

    void SetGloves()
    {
        gloves.SetActive(true);
        handsAndBody.SetActive(false);
        glovesAndBody.SetActive(true);
    }

    void SetWithOutGloves()
    {
        gloves.SetActive(false);
        handsAndBody.SetActive(true);
        glovesAndBody.SetActive(false);
    }

    //metodos mascara____________________________________________
    void SetMask()
    {
        mask.SetActive(true);
    }

    void SetWithOutMask()
    {
        mask.SetActive(false);
    }


    //_______________________________________________________________


    //metodos camiseta____________________________________________
    void SetCamiseta()
    {
        /*if (boots.activeInHierarchy)
        {
            Overol_Botoom_bots.SetActive(false);
            bootPants.SetActive(true);
            camiseta.SetActive(true);
            coat.SetActive(false);
            shirt.SetActive(false);
            Overol_top.SetActive(false);
        }

        else
        {
            camiseta.SetActive(true);
            Overol_top.SetActive(false);
            Overol_Botoom.SetActive(false);            
            coat.SetActive(false);
            shirt.SetActive(false);
            casualPants.SetActive(true);
        }*/
        camiseta.SetActive(true);
        Overol_top.SetActive(false);
        Overol_Botoom.SetActive(false);
        coat.SetActive(false);
        shirt.SetActive(false);
        casualPants.SetActive(true);
        var inventoty = FindObjectOfType(typeof(Inventory)) as Inventory;
        if(inventoty.FindIndexItem("Overol") < inventoty.inventoryList.Count)
        inventoty.inventoryList[inventoty.FindIndexItem("Overol")].isNowEquiped = false;
    }

    void SetWithOutCamiseta()
    {
        if (boots.activeInHierarchy)
        {
            Overol_Botoom_bots.SetActive(false);
            bootPants.SetActive(true);
            shirt.SetActive(true);
        }
        else
        {
            camiseta.SetActive(false);
            shirt.SetActive(true);
            casualPants.SetActive(true);
        }

        

    }


    //_______________________________________________________________

    //metodos Orejeras____________________________________________
    void SetOrejeras()
    {
        orejeras.SetActive(true);
    }

    void SetWithOutOrejeras()
    {
        orejeras.SetActive(false);
    }


    //_______________________________________________________________

    //metodos Overol____________________________________________
    void SetOverol()
    {
        if (camiseta.activeInHierarchy)
        {
            Overol_top.SetActive(true);
            camiseta.SetActive(false);
        }

        if (shirt.activeInHierarchy)
        {            
            Overol_top.SetActive(true);            
            shirt.SetActive(false);
        }

        if (coat.activeInHierarchy)
        {            
            Overol_top.SetActive(true);            
            coat.SetActive(false);
        }

        if (casualPants.activeInHierarchy)
        {
            casualPants.SetActive(false);
            Overol_Botoom.SetActive(true);
        }

        /* (bootPants.activeInHierarchy)
        {
            bootPants.SetActive(false);
            Overol_Botoom_bots.SetActive(true);
        }*/
        var inventoty = FindObjectOfType(typeof(Inventory)) as Inventory;
        if (inventoty.FindIndexItem("Camiseta") < inventoty.inventoryList.Count)
            inventoty.inventoryList[inventoty.FindIndexItem("Camiseta")].isNowEquiped = false;
    }

    void SetWithOutOverol()
    {

        /* (boots.activeInHierarchy)
        {
            Overol_Botoom.SetActive(false);
            Overol_Botoom_bots.SetActive(false);
            Overol_top.SetActive(false);
            bootPants.SetActive(true);
            shirt.SetActive(true);
            camiseta.SetActive(false);
        }

        else
        {
            Overol_Botoom.SetActive(false);
            Overol_Botoom_bots.SetActive(false);
            Overol_top.SetActive(false);
            casualPants.SetActive(true);
            shirt.SetActive(true);
            camiseta.SetActive(false);
        }*/

        Overol_Botoom.SetActive(false);        
        Overol_top.SetActive(false);
        casualPants.SetActive(true);
        shirt.SetActive(true);
        camiseta.SetActive(false);

    }


    //_______________________________________________________________


    //metodos Cronometer____________________________________________
    void SetCrono()
    {
        Cronometer.SetActive(true);
    }

    void SetWithOutCrono()
    {
        Cronometer.SetActive(false);
    }


    //_______________________________________________________________

    public void SetItem(string item)
    {

        var inventoty = FindObjectOfType(typeof(Inventory)) as Inventory;        




        switch (item)
        {
            case "Botas":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetCharWithBoots();

                }
                else
                {
                    SetCharWithoutBoots();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;

            case "Gafas":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetCharWithGlasses();

                }
                else
                {
                    SetCharWithoutGlasses();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Bata":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetCharWithCoat();

                }
                else
                {
                    SetCharWithOutCoat();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Guantes":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetGloves();

                }
                else
                {
                    SetWithOutGloves();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Casco":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetCharWithHelmet();

                }
                else
                {
                    SetCharWithoutHelmet();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Máscara para vapores":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetMask();

                }
                else
                {
                    SetWithOutMask();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Protector de oídos":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetOrejeras();

                }
                else
                {
                    SetWithOutOrejeras();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;

            case "Overol":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetOverol();

                }
                else
                {
                    SetWithOutOverol();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;

            case "Camiseta":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    SetCamiseta();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                }
                else
                {
                    SetWithOutCamiseta();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;

            case "Cronómetro":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    SetCrono();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                }
                else
                {
                    SetWithOutCrono();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;
        }
    }

    public void SetItem(string item, int numero)
    {

        var inventoty = FindObjectOfType(typeof(Inventory)) as Inventory;




        switch (item)
        {
            case "Botas":
                Debug.Log(inventoty.inventoryList[inventoty.indice]);
                if (!inventoty.inventoryList[numero].isNowEquiped)
                {
                    inventoty.inventoryList[numero].isNowEquiped = true;
                    SetCharWithBoots();

                }
                else
                {
                    SetCharWithoutBoots();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;

            case "Gafas":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetCharWithGlasses();

                }
                else
                {
                    SetCharWithoutGlasses();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Bata":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetCharWithCoat();

                }
                else
                {
                    SetCharWithOutCoat();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Guantes":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetGloves();

                }
                else
                {
                    SetWithOutGloves();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Casco":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetCharWithHelmet();

                }
                else
                {
                    SetCharWithoutHelmet();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Máscara para vapores":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetMask();

                }
                else
                {
                    SetWithOutMask();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }

                break;

            case "Protector de oídos":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetOrejeras();

                }
                else
                {
                    SetWithOutOrejeras();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;

            case "Overol":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                    SetOverol();

                }
                else
                {
                    SetWithOutOverol();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;

            case "Camiseta":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    SetCamiseta();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                }
                else
                {
                    SetWithOutCamiseta();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;

            case "Cronómetro":
                if (!inventoty.inventoryList[inventoty.indice].isNowEquiped)
                {
                    SetCrono();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = true;
                }
                else
                {
                    SetWithOutCrono();
                    inventoty.inventoryList[inventoty.indice].isNowEquiped = false;
                }
                break;
        }
    }


}