using UnityEngine;  
using UnityEngine.UI;

namespace Platformer.UI.InGame
{
    public class ScoreController : MonoBehaviour
    {
        private Text textLabel;

        private void Start()
        {
            textLabel = GetComponent<Text>();
        }
        
        private void Update()
        {
                        
        }
    }
}