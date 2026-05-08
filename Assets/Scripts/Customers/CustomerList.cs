using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Customer_List", menuName = "Customer List")]
public class CustomerList : ScriptableObject
{
    public Customer[] customers;

    public Customer GetByName(string name)
    {
        foreach (Customer customer in customers)
            if (customer.customerName == name) return customer;
        Debug.Log("Effect not found: "+name);
        return null;
    }
}
