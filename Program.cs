using JogoDaVelha;
namespace src
{
    internal static class Program
    {
        // Iniciado por Jo�o Paulo Costa Pires
        // Data de Cria��o: 20/10/2024
        // Sobre: Este jogo da velha foi desenvolvido como um projeto acad�mico.
        // GitHub: https://github.com/piressjp/

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Application.Run(new StartForm());
        }
    }
}
