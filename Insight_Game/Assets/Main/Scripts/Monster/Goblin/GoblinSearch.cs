<<<<<<< HEAD
using UnityEditor.Rendering;
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
            RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, boxCastSize, 0f, Vector2.down, 0f, LayerMask.GetMask("Player"));
            if (raycastHit.collider != null)
            {
                Target = raycastHit.transform;
                PlayerFound?.Invoke();
            }
            else
            {
                Target = null;
                PlayerUnfound?.Invoke();
            }
        }
    }
=======
using UnityEditor.Rendering;
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
            RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, boxCastSize, 0f, Vector2.down, 0f, LayerMask.GetMask("Player"));
            if (raycastHit.collider != null)
            {
                Target = raycastHit.transform;
                PlayerFound?.Invoke();
            }
            else
            {
                Target = null;
                PlayerUnfound?.Invoke();
            }
        }
    }
>>>>>>> monster-TWJ
}