using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGateChange : MonoBehaviour
{
    public Material SkyMaterial;
    public GameObject Town;
    public GameObject Tower;
    // Start is called before the first frame update
    void Start()
    {
        Town.SetActive(false);
        Tower.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            RenderSettings.skybox = SkyMaterial;
            Town.SetActive(true);
            Tower.SetActive(false);
        }
    }
}
