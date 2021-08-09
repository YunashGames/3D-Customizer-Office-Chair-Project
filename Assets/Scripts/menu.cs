using UnityEngine;
using UnityEngine.UI;


public class menu : MonoBehaviour
{
    [Header("space between menu items")]
    [SerializeField] Vector2 spacing;

    Button mainButton;
    menuItem[] menuItems;
    bool isExpanded = false;

    Vector2 mainButtonPosition;
    int itemsCount;

    public GameObject chair;
    [SerializeField]
    private Material[] materials;

    Renderer render;


    // Start is called before the first frame update
    void Start()
    {
        //     Renderer   materials

        render = chair.GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = materials[0];



        itemsCount = transform.childCount - 1;
        menuItems = new menuItem[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<menuItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();

        mainButtonPosition = mainButton.transform.position;

        //Reset all menu items position to mainButtonPosition

        ResetPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetPositions ()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i].trans.position = mainButtonPosition;
            menuItems[i].trans.localScale = new Vector3(0, 0, 0);
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if (isExpanded)
        {
            //menu opend
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.position = mainButtonPosition + spacing * (i + 1);
                menuItems[i].trans.localScale = new Vector3(1,1,1);
            }
        }
        else
        {
            //menu closed
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.position = mainButtonPosition;
                menuItems[i].trans.localScale = new Vector3(0, 0, 0);
            }
        }
    }

     public void OnItemClick (int index)
    {
       switch (index)
        {
            case 0: // 1st button
                Debug.Log("0");
                render.sharedMaterial = materials[0];
                ToggleMenu();
                break;
            case 1: // 2nd button
                Debug.Log("1");
                render.sharedMaterial = materials[1];
                ToggleMenu();
                break;
            case 2: // 3rd button
                Debug.Log("2");
                ToggleMenu();
                render.sharedMaterial = materials[2];
                break;
            case 3: // 4th button
                Debug.Log("3");
                ToggleMenu();
                render.sharedMaterial = materials[3];
                break;
            case 4: // 5th button
                Debug.Log("4");
                ToggleMenu();
                render.sharedMaterial = materials[4];
                break;
        }
    }

    void OnDestroy()
    {
        mainButton.onClick.AddListener(ToggleMenu);
    }
}
