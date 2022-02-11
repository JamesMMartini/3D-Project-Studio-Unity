using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : MonoBehaviour
{
    [SerializeField] GameObject requiredObject;
    [SerializeField] string message;

    bool activated;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated)
        {
            requiredObject.SetActive(true);
            StartCoroutine(GameManager.Instance.ShowMessage(message));
            activated = true;
        }
    }
}
