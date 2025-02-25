using TMPro;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public TextMeshProUGUI interactionText;
    public string npcName = "Guard";
    private bool isPlayerNearby = false;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        Debug.Log("You interacted with " + npcName);
        // Here you can trigger dialogue, animations, quests, etc.
        interactionText.text = "Talk to john he might know something";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionText.text = "Press 'E' to talk";
            interactionText.gameObject.SetActive(true);
            Debug.Log("Press 'E' to interact with " + npcName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionText.gameObject.SetActive(false);
        }
    }
}
