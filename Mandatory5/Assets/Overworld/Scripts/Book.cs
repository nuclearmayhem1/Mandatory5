using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public string title;
    [TextArea(5, 10)] public string body;
    public Sprite image, cover;
    public int bookID;

    public void AddBook()
    {
        Bookshelf.AddPage(title, body, image, cover, bookID);
        Destroy(gameObject);
    }

}
