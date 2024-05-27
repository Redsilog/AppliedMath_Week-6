using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    IRaycastProvider irayProvider;
    ISelectionMode iSelectionMode;
    ISelector iSelector;

    private Transform currentSelection;

    private void Awake()
    {
        irayProvider = GetComponent<IRaycastProvider>();
        iSelectionMode = GetComponent<ISelectionMode>();
        iSelector = GetComponent<ISelector>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (currentSelection != null){
            iSelectionMode.OnDeselect(currentSelection);
        }
        iSelector.Check(irayProvider.CreateRay());
        currentSelection = iSelector.GetSelection();
        
        if (currentSelection != null){
            iSelectionMode.OnSelect(currentSelection);
        }

    }
}
