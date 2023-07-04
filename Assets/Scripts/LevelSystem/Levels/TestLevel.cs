using Assets.Scripts.CharacterSystem.Enemy;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.LevelSystem.Levels
{
    public class TestLevel : BaseLevel
    {
        private void Start()
        {
            ExecutingLevelCoroutine = StartCoroutine(GetEnumerator());
        }

        public override IEnumerator GetEnumerator()
        {
            var ship1 = EnemyDatabase.Instantiate<EnemyCharacter>("test_enemy_1", new Vector3(0f, 7f), Quaternion.Euler(0, 0, 180f), transform.root);
            ship1.CommandsFollower.Move(new Vector2(0f, 0f), 2f);

            yield return new WaitForSeconds(4f);
            ship1.CommandsFollower.Move(new Vector2(15f, 0f), 2f);         
            ship1.CommandsFollower.Weapon.MainFire.Press();


            DialogueRunner.StartDialogue("TestLevel");
            bool flag = false;
            DialogueRunner.onDialogueComplete.AddListener(() => flag = true);
            yield return new WaitUntil(() => flag);

            ship1 = EnemyDatabase.Instantiate<EnemyCharacter>("test_enemy_1", new Vector3(0f, 7f), Quaternion.Euler(0, 0, 180f), transform.root);
            ship1.CommandsFollower.Move(new Vector2(0f, 0f), 2f);
            yield return new WaitForSeconds(4f);
            ship1.CommandsFollower.Move(new Vector2(-15f, 0f), 2f);
            ship1.CommandsFollower.Weapon.MainFire.Press();

            DialogueRunner.StartDialogue("AfterFirstEnemy");
        }
    }
}
