using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
    public class NextLevel : MonoBehaviour
    {
        void Start()
        {
            Button b = gameObject.GetComponent<Button>();
            b.onClick.AddListener(delegate () { this.ButtonClicked(); });
        }

        public void ButtonClicked()
        {
            Application.LoadLevel("Levels/Level2");
        }
    }
}
