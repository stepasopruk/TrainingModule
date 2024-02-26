using System.Linq;
using UnityEngine;

public class SelectBootstrapper : MonoBehaviour
{
    [SerializeField] private Detail[] details;

    private void Awake()
    {
        InitializeSelect();
    }

    private void InitializeSelect()
    {
        Select select = new Select(details.Select(x => x.gameObject).ToArray());
        SelectController selectController = new SelectController(select);
    }
}
