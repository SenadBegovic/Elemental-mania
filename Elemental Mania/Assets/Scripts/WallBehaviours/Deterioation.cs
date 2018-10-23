<<<<<<< HEAD:Elemental Mania/Assets/Scripts/WallBehaviours/Deterioation.cs
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Deterioation : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Damage pr second that this wall deals to itself")]
    private int kDeterioationRate = 2;
    private float m_TimeSinceLastDeterioation = 0;
    private Health m_Health;  


    public void Update()
<<<<<<< HEAD:Elemental Mania/Assets/Scripts/WallBehaviours/FireWallBehaviour.cs
    {
        m_TimeSinceLastDeterioation += Time.deltaTime;
        if (m_TimeSinceLastDeterioation <= 0.5)
        {
            //m_Health -= kDeterioationRate;
        }
    }
}
=======
    {
        m_TimeSinceLastDeterioation += Time.deltaTime;
        if (m_TimeSinceLastDeterioation <= 0.5)
        {
            m_Health.TakeDamage(kDeterioationRate);
        }
    }
}
>>>>>>> e9d944075c29df9c4297f0932a506fae0110b32e:Elemental Mania/Assets/Scripts/WallBehaviours/Deterioation.cs
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EffectiveHealth))]
public class Deterioation : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Damage pr second that this wall deals to itself")]
    private int kDeterioationRate = 2;
    private float m_TimeSinceLastDeterioation = 0;
    private EffectiveHealth m_Health;  


    public void Update()
    {
        m_TimeSinceLastDeterioation += Time.deltaTime;
        if (m_TimeSinceLastDeterioation <= 0.5)
        {
        }
    }
}
>>>>>>> 9101c199ed30a040cd416abe2a71e99627d47146:Elemental Mania/Assets/Scripts/WallBehaviours/Deterioation.cs
