using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPanel : MonoBehaviour
{
    [SerializeField] private ItemData[] _itemData;
    [SerializeField] private ObjectPlacer _objectPlacer;
    [SerializeField] private GameObject _itemTemplate;
    [SerializeField] private Transform _container;

    private void Start()
    {
        for (int i = 0; i < _itemData.Length; i++)
            AddItem(_itemData[i]);
    }

    private void AddItem(ItemData itemData)
    {
        Instantiate(_itemTemplate, _container).TryGetComponent(out ItemView itemView);
        itemView.Initilize(itemData);
        itemView.ItemSelected += OnItemSelected;
        itemView.ItemDisabled += OnItemDisabled;
    }

    private void OnItemSelected(ItemData itemData)
    {
        _objectPlacer.SetInstalledObject(itemData);
    }

    private void OnItemDisabled(ItemView itemView)
    {
        itemView.ItemSelected -= OnItemSelected;
        itemView.ItemDisabled -= OnItemDisabled;
    }
}
