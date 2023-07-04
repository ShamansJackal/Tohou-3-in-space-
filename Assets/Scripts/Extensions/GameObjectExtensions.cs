
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class GameObjectExtensions
    {
        public static T Instantien<T>(this T gameObject, Vector2 position, Vector2 direction) where T : MonoBehaviour
        {
            var rotation = direction.LookAt();

            return Object.Instantiate(gameObject, position, rotation);
        }
    }
}
