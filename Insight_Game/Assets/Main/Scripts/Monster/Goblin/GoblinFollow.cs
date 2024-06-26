using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster.Goblin
{
    public class GoblinFollow : MonoBehaviour, IFollowable
    {
        
        SpriteRenderer sprite;

        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        public void Follow()
        {
            Debug.Log("Monster is following the player.");
        }
    }

}
