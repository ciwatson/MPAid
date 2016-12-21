using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPAid.Cores;
namespace MPAid.NewForms
{
    public partial class AnalysisScreen : Form
    {
        public AnalysisScreen(string recordingFileName, string targetWord, string recognisedWord)
        {
            InitializeComponent();

            PronuciationAdvisor.Advise(recordingFileName, targetWord, recognisedWord);
        }
    }
}