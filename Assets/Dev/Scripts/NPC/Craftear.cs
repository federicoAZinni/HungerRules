using UnityEngine;

public class Craftear : MonoBehaviour
{
    private bool playerInRange = false; // Verifica si el jugador está cerca del NPC.
    [SerializeField] Item material1; // Primer material requerido.
    [SerializeField] Item material2; // Segundo material requerido.
    [SerializeField] Item craftedItem; // Objeto que será creado.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tiene el tag "Player".
        {
            playerInRange = true;
            Debug.Log("Jugador cerca del NPC, puedes craftear.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Jugador salió del rango del NPC.");
        }
    }

    public void TryCraft(Inventory playerInventory)
    {
        if (!playerInRange)
        {
            Debug.Log("Debes estar cerca del NPC para craftear.");
            return;
        }

        // Verifica si el jugador tiene ambos materiales.
        if (playerInventory.HasItem(material1, 1) && playerInventory.HasItem(material2, 1))
        {
            // Remueve los materiales.
            playerInventory.RemoveItem(material1, 1);
            playerInventory.RemoveItem(material2, 1);

            // Agrega el objeto crafteado.
            playerInventory.AddItem(craftedItem);

            Debug.Log($"¡Has crafteado un {craftedItem.name}!");
        }
        else
        {
            Debug.Log("No tienes los materiales necesarios para craftear.");
        }
    }
}
