using UnityEngine;
using UnityEngine.UI;

namespace UI.Controls
{
    /// <summary>
    /// Controls scrolling functionality for a ScrollRect.
    /// </summary>
    public class ScrollViewControl : MonoBehaviour // TODO: add better comments
    {
        public ScrollRect scrollRect;

        private const float ScrollStep = 0.1f;

        public void ScrollUp()
        {
            scrollRect.normalizedPosition += new Vector2(0, ScrollStep);
        }

        public void ScrollDown()
        {
            scrollRect.normalizedPosition -= new Vector2(0, ScrollStep);
        }
    }
}