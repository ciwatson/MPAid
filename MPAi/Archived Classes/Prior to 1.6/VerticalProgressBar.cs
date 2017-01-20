using System.Windows.Forms;

namespace MPAi
{
    /// <summary>
    /// Parameter overridden extension of the C# progress bar class.
    /// *** Doesn't appear to be used by any other code, marked for deletion ***
    /// </summary>
    public class VerticalProgressBar : ProgressBar
    {
        /// <summary>
        /// Adds a style parameter to the existing CreateParams method.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }
    }
}
