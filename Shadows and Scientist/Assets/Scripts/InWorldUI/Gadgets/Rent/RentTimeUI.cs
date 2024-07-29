using TMPro;
using UnityEngine;

namespace RentNamespace
{
    public class RentTimeUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _time;

        public void SetTime(int mins, int secs)
        {
            string minsStr = mins>9? "" : "0" + mins.ToString();
            string secsStr = secs>9? "" : "0" + secs.ToString();

            if (secs % 2 == 0)
            {
                if (mins == 0)
                {
                    _time.text = $"!!!!!";
                }
                else
                {
                    _time.text = $"{mins} {secs}";
                }
            }
            else
            {

                _time.text = $"{mins}:{secs}";
            }
        }
    }
}