using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //to let the player get an item, make this bool true, so that the code in the update function can be run.
    public bool pgItemsGet = false;
    [SerializeField] private bool hasPressed = false;

    public ItemPg[] ItemPgs;

    public static GameManager Instance { get { return instance; } }
    private static GameManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }


        /*for (int i = 0; i < ItemPgs.Length; i++)
        {
            ItemPgs[i].value = PlayerPrefs.GetInt(ItemPgs[i].key);
        }*/

    }

    public void SetItem(string key)
    {
        for (int i = 0; i < ItemPgs.Length; i++)
        {
            if (ItemPgs[i].key == key)
            {
                ItemPgs[i].value = 1;
            }
        }
        PlayerPrefs.SetInt(key, 1);
    }

    public int GetItemValue(string key)
    {
        for (int i = 0; i < ItemPgs.Length; i++)
        {
            if (ItemPgs[i].key == key)
            {
                return ItemPgs[i].value;
            }
        }
        return -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        hasPressed = false;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            pgItemsGet = true;
            
            Debug.Log("E-Key is pressed");
        }*/
        /*This is Code will let the player get upgrades, if the player is getting the upgrade at the end of a level then this needs to be called.*/
        //int pgItems = PlayerPrefs.GetInt("pgItem");
        /*if (pgItemsGet == true && !hasPressed && pgItems == 0)
        {
            PlayerPrefs.SetInt("pgItem", 1);
            PlayerPrefs.Save();
            Debug.Log("+1");
            Debug.Log(PlayerPrefs.GetInt("pgItem", 0));
            pgItemsGet = false;
            hasPressed = true;
            
            
            
        }else if (pgItemsGet = true && !hasPressed && pgItems == 1)
        {
            PlayerPrefs.SetInt("pgItem", 2);
            PlayerPrefs.Save();
            Debug.Log("+1");
            Debug.Log(PlayerPrefs.GetInt("pgItem", 0));
            pgItemsGet = false;
            hasPressed = true;
            
        }
        else if (pgItemsGet = true && !hasPressed && pgItems == 2)
        {
            PlayerPrefs.SetInt("pgItem", 3);
            PlayerPrefs.Save();
            Debug.Log("+1");
            Debug.Log(PlayerPrefs.GetInt("pgItem", 0));
            pgItemsGet = false;
            hasPressed = true;
            
        }*/

    }



    
}

[System.Serializable] public struct ItemPg
{
    [Range(0, 1)] public int value;
    public string key;
}