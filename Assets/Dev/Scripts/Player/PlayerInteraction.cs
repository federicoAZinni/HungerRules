using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] Inventory playerInventory; // Referencia al inventario del jugador.

    private Craftear npcInteraction; // NPC con el que interactuará.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && npcInteraction != null)
        {
            npcInteraction.TryCraft(playerInventory);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Craftear>(out Craftear npc))
        {
            npcInteraction = npc;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Craftear>() != null)
        {
            npcInteraction = null;
        }
    }
}

