using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayMode : MonoBehaviour
{
    [SerializeField] Sprite Press;
    [SerializeField] Sprite UnPress;
    public List<GameObject> GameModes;

    public void ChooseMode(int index)
    {
        for (int i = 0; i < GameModes.Count; i++)
        {   
            if(i != index)
            {
                GameModes[i].transform.Find("Mode").gameObject.GetComponent<Image>().sprite = UnPress;
                GameModes[i].transform.Find("Map").gameObject.SetActive(false);
            }
            else
            {
                GameModes[i].transform.Find("Mode").gameObject.GetComponent<Image>().sprite = Press;
                GameModes[i].transform.Find("Map").gameObject.SetActive(true);
            }
        }
    }
}
