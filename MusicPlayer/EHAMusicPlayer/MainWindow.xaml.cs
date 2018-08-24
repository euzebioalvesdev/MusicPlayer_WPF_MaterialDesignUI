using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace EHAMusicPlayer
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine Reconhecedor = new SpeechRecognitionEngine();
        SpeechSynthesizer IAHorus = new SpeechSynthesizer();
        string speech;

        public MainWindow()
        {
            InitializeComponent();
            IAHorus.Speak("Iniciando..." + ". . . . .");
            IAHorus.Speak("Sistemas carregados e prontos para utilização!" + ". . . . .");
            IAHorus.Speak("Eu sou o Hórus. Como posso te ajudar?" + ". . . . .");
        }

        public void CarregarGramatica()
        {
            Reconhecedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines("Gramatica\\ComandosDefecto.txt")))));
            Reconhecedor.RequestRecognizerUpdate();
            Reconhecedor.SpeechRecognized += Reconhecedor_SpeechRecognized;
            Reconhecedor.SetInputToDefaultAudioDevice();
            Reconhecedor.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Reconhecedor_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                speech = e.Result.Text;

                switch (speech)
                {
                    case "bom dia horus":
                        IAHorus.Speak("Muito bom dia!" + ". . . . .");
                        IAHorus.Speak("Como você está?" + ". . . . .");
                        break;

                    case "navegar na internet":
                        IAHorus.Speak("Abrindo o navegador padrão" + ". . . . .");
                        System.Diagnostics.Process.Start("https://www.google.com.br/");
                        break;

                    case "adeus horus":
                        IAHorus.Speak("Muito bom dia!" + ". . . . .");
                        Close();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IAHorus.Speak("Muito bom dia!");
            IAHorus.Speak("Como você está?");
        }
    }
}
