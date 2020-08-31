using System;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    static class Game
    {
        #region FieldsAndProperties
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        public static int Width { get; set; }
        public static int Height { get; set; }
        #endregion
        #region Game
        /// <summary>
        /// Статический конструктор класса Game.
        /// </summary>
        static Game() {}
        #endregion
        #region Init
        /// <summary>
        /// Статический метод Init, который принимает в качестве входного параметра
        /// Form form. Инициализирует экземпляр класса Graphics, который методом 
        /// CreateGraphics() класса Control передаётся в form.
        /// Метод Load() для инициализации всех элементов.
        /// Timer timer предназначен для реализации перемещения объектов BaseObject и производных
        /// с заданным интервалом. Запуск таймера и подписка на событие Tick метода Timer_Tick.
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            Graphics g; // создаётся поверхность для рисования g
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();  // g помещается на form 
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height)); // Переменная Buffer может изменяет содержимое g.
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        #endregion
        #region Timer_Tick
        /// <summary>
        /// Выполнение метода Timer_Tick в программе на каждое событие timer.Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        #endregion

        #region Draw
        /// <summary>
        /// Изменяется переменная Buffer. Каждый вызов метода Draw сначала очищает Buffer,
        /// потом после вызова метода Draw() в коллекции _objs (в котором изменяется Pos.X и Pos.Y)
        /// передаётся на поверхность для рисования g.
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        #endregion
        #region Load
        /// <summary>
        /// Инициализация объектов класса BaseObject и его производных, с последующим помещением 
        /// в коллекцию _objs
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length/3; i++)
                _objs[i] = new BaseObject(new Point(600, i * 20), new Point(- i, i), new Size(10, 10));
            for (int i = _objs.Length / 3; i < 2*_objs.Length / 3; i++)
                _objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(5, 5));
            for (int i = 2*_objs.Length / 3; i < _objs.Length; i++)
                _objs[i] = new Comet(new Point(600, i * 20), new Point(i, 0), new Size(10, 10));
        }
        #endregion
        #region Update
        /// <summary>
        /// Вызов метода Update каждого объекта в коллекции _objs
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        #endregion
    }
}
