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

    // Start is called before the first frame update
    void Start()
    {
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
            }
        }
        else
        {
            //menu closed
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.position = mainButtonPosition;
            }
        }
    }

    void OnDestroy()
    {
        mainButton.onClick.AddListener(ToggleMenu);
    }
}
