using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Monster.Goblin 
{
    public class GoblinSearch : MonoBehaviour, ISearchable
    {
        public Transform PlayerTransform;
        public event UnityAction PlayerFound;

        private Vector2 boxCastSize = new Vector2(13f, 1.5f);
        private float boxCastMaxDistance = 10.0f;

        public void Search()
        {
            Debug.Log("Monster is searching for the player.");

            RaycastHit2D raycastHit = Physics2D.BoxCast(GetComponent<Collider>().bounds.center, boxCastSize, 0f, Vector2.down, 0f, LayerMask.GetMask("Player"));
            if (raycastHit.collider != null)
            {
                Debug.Log("Monster found the player.");
                playerTransform = raycastHit.transform;
                PlayerFound?.Invoke();
            }
            else
            {
                Debug.Log("Monster did not find the player.");
                //PlayerFound?.Invoke();
            }
        }
    }
}