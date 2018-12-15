using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject body;
    public GameObject spirit;

    private GameObject currentState;

    private OutOfBodyExperience changeStateScript;


    void Start()
    {
        if (body == null)
        {
            body = GameObject.FindGameObjectWithTag("Player");
        } else if (spirit == null)
        {
            spirit = GameObject.FindGameObjectWithTag("Spirit");
        }

        currentState = body;

        changeStateScript = this.GetComponent<OutOfBodyExperience>();
    }

    void LateUpdate()
    {
        // Movimentação
        var z = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        currentState.transform.Rotate(0, 0, z);
        currentState.transform.Translate(0, -y, 0);

        // Mecânica do espírito
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(currentState == body)
            {
                changeStateScript.ReleaseSpirit(spirit, body);
                currentState = spirit;

            } else if (currentState == spirit)
            {
                changeStateScript.RetrieveSpirit(body, spirit);
                currentState = body;
            }
        }
    }
}
