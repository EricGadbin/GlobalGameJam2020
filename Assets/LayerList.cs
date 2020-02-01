using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LayerList", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Team : ScriptableObject
{
    public List<TeamComponent> members = new List<TeamComponent>();

    public void Join()
    {
        // members
    }
}