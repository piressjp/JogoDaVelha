using JogoDaVelha;
namespace src
{
    internal static class Program
    {
        // Iniciado por João Paulo Costa Pires
        // Data de Criação: 20/10/2024
        // Sobre: Este jogo da velha foi desenvolvido como um projeto acadêmico.
        // GitHub: https://github.com/piressjp/

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new StartForm());
        }
    }
}
