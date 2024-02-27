using System;
using System.Linq;
using UnityEngine;

public class SelectBootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    [SerializeField] private DetailSelectController detailSelectController;

    private void Awake()
    {
        InitializeSelect();
    }

    private void InitializeSelect()
    {
        Select select = new Select(gameObjects);
        SelectController selectController = new SelectController(select);
        selectController.OnSelected += detailSelectController.Selected;
    }
}
