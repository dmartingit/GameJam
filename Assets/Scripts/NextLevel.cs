using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
    public class NextLevel : MonoBehaviour
    {

        public void ButtonClicked()
        {
            Debug.Log("Clicked");
            Application.LoadLevel("Levels/Level2");
        }
    }
}
