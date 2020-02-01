using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamComponent : MonoBehaviour
{
    public static List<TeamComponent> RedTeam = new List<TeamComponent>();
    public static List<TeamComponent> BlueTeam = new List<TeamComponent>();
    
    private void OnEnable() {
        if (gameObject.layer == LayerMask.NameToLayer("Blue Team")) {
            BlueTeam.Add(this);
        } else if (gameObject.layer == LayerMask.NameToLayer("Red Team")) {
            RedTeam.Add(this);
        } else {
            throw new System.Exception("Invalid team on object " + name);
        }
    }

    private void OnDisable() {
        if (gameObject.layer == LayerMask.NameToLayer("Blue Team")) {
            BlueTeam.Remove(this);
        } else if (gameObject.layer == LayerMask.NameToLayer("Red Team")) {
            RedTeam.Remove(this);
        } else {
            throw new System.Exception("Invalid team on object " + name);
        }
        
    }

    public List<TeamComponent> GetEnemies()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Blue Team")) {
            return BlueTeam;
        } else if (gameObject.layer == LayerMask.NameToLayer("Red Team")) {
            return RedTeam;
        } else {
            throw new System.Exception("Invalid team on object " + name);
        }
    }
}
