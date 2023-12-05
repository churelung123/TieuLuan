using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class StartCutscene2 : MonoBehaviour
{
    [SerializeField] GameObject PlayerParrentObject;
    [SerializeField] GameObject PlayerAmature;
    [SerializeField] GameObject Player;
    GameObject Clone;
    Transform CloneChild;
    private ThirdPersonController _thirdPersonController;
    // Start is called before the first frame update
    private void Start()
    {
        _thirdPersonController = PlayerAmature.GetComponent<ThirdPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Clone = Instantiate(PlayerParrentObject);
            CloneChild = Clone.transform.Find("CloneChild");
            PlayerAmature.transform.SetParent(CloneChild);
            _thirdPersonController.isFly = true;
            PlayerAmature.transform.rotation = Quaternion.Euler(80, -90, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerAmature.transform.rotation = Quaternion.Euler(0, -90, 0);
            PlayerAmature.transform.SetParent(Player.transform);
            _thirdPersonController.isFly = false;
            Destroy(Clone);
            Destroy(gameObject);
        }
    }
}
