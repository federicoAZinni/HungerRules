using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour,IConsumable,IWeapon,ICraftable
{
    public  ItemData itemData;
    public int amount;
    public void Attack()
    {
        
    }

    public void Consume()
    {
        Debug.Log($"Item: {itemData.name} was used");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Inventory>(out Inventory inv))
        {
            inv.AddItem(this,amount==0?1:amount);
            gameObject.SetActive(false);
        }
    }
}

public interface IConsumable
{
    public void Consume();
}
public interface IWeapon
{
    public void Attack();
}
public interface ICraftable
{

}

