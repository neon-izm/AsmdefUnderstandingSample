using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsmdefLearning.Player
{
    /// <summary>
    /// 普通のプレイヤーの動きのやつ
    /// </summary>
    public class PlayerMover : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(Time.deltaTime, 0, 0);
            }
        }
    }
}