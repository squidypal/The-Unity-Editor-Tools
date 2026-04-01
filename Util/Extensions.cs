using UnityEngine;

namespace Util
{
    public enum ConstraintValue2D
    {
        x,
        y
    }
    public static class Extensions
    {
        /// <summary>
        /// Attempts to find a component of type T by searching the root object, its hierarchy, 
        /// and finally the caller's specific GameObject.
        /// </summary>
        /// <param name="objT">The transform to start the search from.</param>
        /// <typeparam name="T">The type of Component to find.</typeparam>
        /// <returns>The component if found; otherwise, null.</returns>
        public static T TryGetComponentFromAll<T>(this Transform objT) where T : Component
        {
            T result = objT.root.GetComponentInChildren<T>();
            if (result != null) return result;

            return objT.GetComponent<T>();
        }
        
        /// <summary>
        /// Calculates the constant force required to move a Rigidbody2D to a target position over a specific duration.
        /// </summary>
        /// <param name="rb">The Rigidbody2D to move.</param>
        /// <param name="target">The world-space target position.</param>
        /// <param name="overTime">The duration in seconds to reach the target.</param>
        /// <returns>The force vector to be applied continuously for the duration of <paramref name="overTime"/>.</returns>
        public static Vector2 GetConstantMoveToForce2D(this Rigidbody2D rb, Vector2 target, float overTime)
        {
            if (overTime <= 0) return Vector2.zero;

            Vector2 currentPos = rb.position;
            Vector2 displacement = target - currentPos;
            Vector2 currentVelocity = rb.linearVelocity;

            // a = 2 * (d - v0 * t) / t^2
            Vector2 acceleration = 2 * (displacement - currentVelocity * overTime) / (overTime * overTime);

            return acceleration * rb.mass;
        }
        
        public static Vector2 GetBrakingForce(this Rigidbody2D rb, float overTime)
        {
            if (overTime <= 0 || rb.linearVelocity.sqrMagnitude < 0.001f) 
                return Vector2.zero;

            // F = m * a -> F = m * (deltaV / deltaT)
            // acceleration = (0 - currentVelocity) / overTime
            Vector2 acceleration = -rb.linearVelocity / overTime;

            return acceleration * rb.mass;
        }
        
        public static Vector2 GetForceToReachTarget(this Rigidbody2D rb, Vector2 targetPos, float timeRemaining)
        {
            if (timeRemaining <= 0) return Vector2.zero;

            Vector2 currentPos = rb.position;
            Vector2 currentVel = rb.linearVelocity;

            // Derived from s = ut + 0.5at^2 -> a = 2(s - ut) / t^2
            Vector2 displacement = targetPos - currentPos;
            Vector2 acceleration = (2 * (displacement - currentVel * timeRemaining)) / (timeRemaining * timeRemaining);

            return acceleration * rb.mass;
        }

    }
}
