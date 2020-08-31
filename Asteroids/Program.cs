using System;
using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        #region Main
        /// <summary>
        /// Точка входа приложения.
        /// Инициализируется Form form с указанными размерами Width и Height,
        /// которая передаётся в качестве входного параметра в класс Game для 
        /// последующей обработки.
        /// </summary>
        static void Main()
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
        #endregion
    }
}
