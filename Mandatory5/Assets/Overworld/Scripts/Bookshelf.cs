using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bookshelf : MonoBehaviour
{

    public static List<Page> pages = new List<Page>();
    public GameObject buttonPrefab;
    public GameObject container;
    public GameObject canvas;
    private UnityAction<int> openPageAction;
    public Text title;
    public Text body;
    public Image image;
    
    private void Start()
    {
        openPageAction += OpenPage;
    }

    private void Update()
    {
        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
    }

    public static void AddPage(string title, string body, Sprite image, Sprite cover, int identifier)
    {
        Page page = new Page(title, body, image, identifier, cover);
        foreach (Page item in pages)
        {
            if (item.identifier == identifier)
            {
                return;
            }
        }
        pages.Add(page);

    }

    bool isOpen = false;
    List<Page> oldPages = new List<Page>();
    public void OpenCanvas()
    {
        if (isOpen)
        {
            return;
        }
        isOpen = true;
        canvas.SetActive(true);

        foreach (Page item in pages)
        {
            bool alreadyHasBook = false;
            foreach (Page oldPage in oldPages)
            {
                if (oldPage.identifier == item.identifier)
                {
                    alreadyHasBook = true;
                }
            }
            if (alreadyHasBook)
            {
                continue;
            }
            GameObject newButton = Instantiate(buttonPrefab, container.transform);
            newButton.GetComponent<Button>().onClick.AddListener(delegate { openPageAction(item.identifier); });
            newButton.GetComponentInChildren<Text>().text = item.title;
            if (item.cover != null)
            {
                newButton.GetComponent<Image>().sprite = item.cover;
            }
            oldPages.Add(item);
        }
    }

    public void OpenPage(int identifier)
    {
        Page page;
        foreach (Page item in pages)
        {
            if (item.identifier == identifier)
            {
                title.text = item.title;
                body.text = item.body;
                image.sprite = item.image;
                break;
            }
        }
    }

    public void CloseCanvas()
    {
        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        canvas.SetActive(false);
    }
}

public struct Page
{
    public string title;
    public string body;
    public Sprite image;
    public int identifier;
    public Sprite cover;

    public Page(string title, string body, Sprite image, int identifier, Sprite cover)
    {
        this.title = title;
        this.body = body;
        this.image = image;
        this.identifier = identifier;
        this.cover = cover;
    }
}