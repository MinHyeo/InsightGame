using UnityEngine;
using UnityEngine.Events;

namespace Monster.Goblin 
{
    public class GoblinSearch : MonoBehaviour, ISearchable
    {
        public event UnityAction PlayerFound;
        public event UnityAction PlayerUnfound;

        public Transform Target { get; private set; }
        private Vector2 boxCastSize = new Vector2(13f, 1.5f);

        public void Search()
        {
            Debug.Log("Monster is searching for the player.");

            RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, boxCastSize, 0f, Vector2.down, 0f, LayerMask.GetMask("Player"));
            if (raycastHit.collider != null)
            {
                Debug.Log("Monster found the player.");
                Target = raycastHit.transform;
                PlayerFound?.Invoke();
            }
            else
            {
                Debug.Log("Monster did not find the player.");
                PlayerUnfound?.Invoke();
            }
        }
    }
}