using System;


namespace GigalothMapEditor
{
#if WINDOWS 
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MapEditor form = new MapEditor();
            form.Show();
            form.game = new Game1(
                form.pictureBox.Handle,
                //form.pictureBoxSprite.Handle,
                form,
                form.pictureBox);

            form.game.Run();
        }
    }
#endif
}

