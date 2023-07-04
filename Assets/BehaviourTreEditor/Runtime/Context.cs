using Assets.Scripts.CharacterSystem.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TheKiwiCoder
{

    // The context is a shared object every node has access to.
    // Commonly used components and subsytems should be stored here
    // It will be somewhat specfic to your game exactly what to add here.
    // Feel free to extend this class 
    public class Context {
        public GameObject gameObject;
        public Transform transform;
        public Animator animator;
        public CommandsFollower commandsFollower;
        // Add other game specific systems here

        public static Context CreateFromGameObject(GameObject gameObject) {
            // Fetch all commonly used components
            Context context = new Context
            {
                gameObject = gameObject,
                transform = gameObject.transform,
                animator = gameObject.GetComponent<Animator>(),
                commandsFollower = gameObject.GetComponent<CommandsFollower>()
            };

            // Add whatever else you need here...

            return context;
        }
    }
}