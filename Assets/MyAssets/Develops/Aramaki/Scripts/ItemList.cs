using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct _itemList
    {
        public string _name;
        public string _description;
        public Image _image;
        public int _amount;
    }
public class ItemList : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public _itemList[] itemList;
    void Start()
    {
        foreach(var item in itemList) {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
