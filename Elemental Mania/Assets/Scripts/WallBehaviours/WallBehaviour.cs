using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Any derivatives must be stateless, as they are used by multiples
public abstract class WallBehaviour : ScriptableObject
{
    public const string kWallFolder = "WallTypes/";

    [SerializeField]
    private int m_MaxHealth;
    [SerializeField]
    private int m_StartingHealth;
    [SerializeField]
    private GameObject m_Visualizer;

    [SerializeField]
    private Resistance m_Resistance;

    public abstract void Tick(Wall _this);

    public virtual void Instantiate(Wall _this)
    {
        GameObject newInstance = GameObject.Instantiate(m_Visualizer, _this.transform);
        _this.Health = m_StartingHealth;
    }
        
    public virtual void Destroy(Wall _this)
    {
        for (int i = 0; i < _this.transform.childCount; ++i)
        {
            GameObject.Destroy(_this.transform.GetChild(i));
        }
    }

    public virtual void ParticleCollision(Wall _this, Weapon weapon, List<ParticleCollisionEvent> events)
    {
        _this.Health -= m_Resistance.GetResistance(weapon.type) * weapon.Damage * events.Count;
    }
}
