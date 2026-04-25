using UnityEngine;
using System.Collections.Generic;   

[CreateAssetMenu()]// this allows us to create an asset of this type in the editor
public class RecipeSO : ScriptableObject
{
    public List<KitchenObjectSO> kitchenObjectSOList;
    public string recipeName;

}
