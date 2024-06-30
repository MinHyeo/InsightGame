<<<<<<< HEAD
using UnityEngine;
using UnityEngine.Events;

namespace Monster
{
    public class CheckAttackable : MonoBehaviour
    {
        public event UnityAction PlayerAttacked;
        public event UnityAction PlayerUnAttacked;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Monster is attacking the player.");
                PlayerAttacked?.Invoke();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Monster stopped attacking the player.");
                PlayerUnAttacked?.Invoke();
            }
        }
    }
=======
using UnityEngine;
using UnityEngine.Events;

namespace Monster
{
    public class CheckAttackable : MonoBehaviour
    {
        public event UnityAction PlayerAttacked;
        public event UnityAction PlayerUnAttacked;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Monster is attacking the player.");
                PlayerAttacked?.Invoke();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Monster stopped attacking the player.");
                PlayerUnAttacked?.Invoke();
            }
        }
    }
>>>>>>> monster-TWJ
}