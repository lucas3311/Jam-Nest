using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBodyExperience : MonoBehaviour
{ 
    // o corpo vai expulsar o espirito na frente do corpo (idealmente na direção que ele escolher) e terão essas mudanças:
    // - ativa a instancia do espírito na frente (ou direção desejada) do player
    // - o target do controle é assumido para o espírito
    // - uma segunda camera é criada e passa a seguir e olhar para o espírito

    public void ReleaseSpirit(GameObject spirit, GameObject body)
    {
        spirit.transform.position = body.transform.position + Vector3.forward * 1;
        spirit.SetActive(true);

        body.GetComponent<PlayerProperties>().camera.SetActive(false);
        spirit.GetComponent<SpiritProperties>().camera.SetActive(true);

        Debug.Log("Soltei espirito");
    }

    // o corpo vai expulsar o espirito na frente do corpo (idealmente na direção que ele escolher) e terão essas mudanças:
    // - o target do controle é assumido para o corpo
    // - uma segunda camera é destruida inativa e reativa a primeira camera

    public void RetrieveSpirit(GameObject body, GameObject spirit)
    {
        body.GetComponent<PlayerProperties>().camera.SetActive(true);
        spirit.GetComponent<SpiritProperties>().camera.SetActive(false);

        spirit.SetActive(false);

        Debug.Log("voltei para corpo");
    }

}
