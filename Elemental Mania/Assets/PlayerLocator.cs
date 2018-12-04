using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerLocator : MonoBehaviour {
        
    [System.Serializable]
    struct PlayerInfo
    {
        [SerializeField]
        public GameObject kPlayer;

        [HideInInspector]
        public PlayerController kController;
    }

    [SerializeField]
    private PlayerInfo kPlayerOne;

    [SerializeField]
    private PlayerInfo kPlayerTwo;

    private static PlayerLocator m_Locator;

    public static PlayerLocator instance{
        get
        {
            return m_Locator;
        }
    }

    /// <summary>
    /// Returns the associated playercontroller for the gameobject, 
    /// if the gameobject is a player
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>
    /// The player controller
    /// </returns>
    public PlayerController GetPlayerController(GameObject obj)
    {
        if(obj == kPlayerOne.kPlayer)
        {
            return kPlayerOne.kController;
        }
        else if (obj == kPlayerTwo.kPlayer)
        {
            return kPlayerTwo.kController;
        }
        else
        {
            if (obj.transform.parent == null)
                return null;
            else
                return GetPlayerController(obj.transform.parent.gameObject);
        }
    }

    public GameObject GetPlayer(GameObject obj)
    {
        if(IsPlayerTag(obj))
        {
            return obj;
        }
        else
        {
            if(obj.transform.parent == null)
            {
                return null;
            }
            else
            {
                return GetPlayer(obj.transform.parent.gameObject);
            }
        }
    }

    private bool IsPlayerTag(GameObject obj)
    {
        return obj.CompareTag("PlayerOne") || obj.CompareTag("PlayerTwo");
    }

    public bool IsPlayer(GameObject obj)
    {
      
        if(IsPlayerTag(obj))
        {
            return true;
        }
        else
        {
            if (obj.transform.parent == null)
                return false;
            else
                return IsPlayer(obj.transform.parent.gameObject);
        }       
    }

    public PlayerController GetOpponent(PlayerController obj)
    {
        if (obj == kPlayerOne.kController)
        {
            return kPlayerTwo.kController;
        }
        else if (obj == kPlayerTwo.kController)
        {
            return kPlayerOne.kController;
        }
        else
        {
            return null;
        }
    }

	// Use this for initialization
	void Awake () {
        Assert.IsNotNull(kPlayerOne.kPlayer);
        Assert.IsNotNull(kPlayerTwo.kPlayer);
        Assert.IsNull(m_Locator);
        kPlayerOne.kController = kPlayerOne.kPlayer.GetComponent<PlayerController>();
        kPlayerTwo.kController = kPlayerTwo.kPlayer.GetComponent<PlayerController>();
        m_Locator = this;
	}
}
