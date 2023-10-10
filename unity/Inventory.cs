using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class Inventory : MonoBehaviour
    {
        public UnityEvent OnInventoryAddItem;
        public UnityEvent OnInventoryEquipItem;
        public UnityEvent OnInventorySellItem;
    }
}