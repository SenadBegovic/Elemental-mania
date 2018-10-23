using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WeaponController : MonoBehaviour {
    [SerializeField]
    Weapon[] kWeapons;

    private int m_CurrentWeaponIndex;

    [SerializeField]
    InputMapping kInputMapping;
	// Use this for initialization
	void Start () {
        m_CurrentWeaponIndex = 0;

        for (int i = 0; i < kWeapons.Length; i++)
        {
            Assert.IsFalse(kWeapons[i].gameObject.activeInHierarchy, kWeapons[i].name + " was enabled");
        }
        SwitchTo(0);
	}
	
    void SwitchTo(int nextIndex)
    {
        kWeapons[m_CurrentWeaponIndex].gameObject.SetActive(false);

        kWeapons[nextIndex].gameObject.SetActive(true);
        m_CurrentWeaponIndex = nextIndex;
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown(kInputMapping.kNextWeapon))
        {
            int nextIndex = (m_CurrentWeaponIndex + 1) % kWeapons.Length;
            SwitchTo(nextIndex);
        }
        
	}
}
