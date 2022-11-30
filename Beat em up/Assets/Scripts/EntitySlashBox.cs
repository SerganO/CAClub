using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySlashBox : MonoBehaviour
{
    public BoxCollider2D Area;
    public float Damage;

    public void SetAreaActive(bool value)
    {
        Area.gameObject.SetActive(value);
    }
}
