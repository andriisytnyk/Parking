using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Classes
{
    public class Menu
    {
        public delegate void MenuMethod();
        public List<MenuMethod> Methods;
        public Menu(params MenuMethod[] methods)
        {
            Methods = new List<MenuMethod>();
            Methods.AddRange(methods);
            ItemColor = ConsoleColor.Yellow;
            SelectionColor = ConsoleColor.Blue;
        }
        public ConsoleColor ItemColor;
        public ConsoleColor SelectionColor;
        public int SelectedItem { get; private set; }
        private int _top;

        public void Show(bool addEmptyLineBefore = true)
        {
            _top = Console.CursorTop;
            if (addEmptyLineBefore)
            {
                Console.WriteLine();
                _top++;
            }
            Console.ForegroundColor = ItemColor;
            for (var i = 0; i < Methods.Count; i++)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = SelectionColor;
                }
                else
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ItemColor;
                }
                Console.WriteLine(Methods[i].Method.Name);
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.ResetColor();
            WaitForInput();
        }

        private void WaitForInput()
        {
            var cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.Enter:
                    Methods[SelectedItem]();
                    break;
                default:
                    KeyPress();
                    break;
            }
        }

        private void MoveDown()
        {
            SelectedItem = SelectedItem == Methods.Count - 1 ? 0 : SelectedItem + 1;
            Console.SetCursorPosition(0, _top);
            Show(false);
        }

        private void MoveUp()
        {
            SelectedItem = SelectedItem == 0 ? Methods.Count - 1 : SelectedItem - 1;
            Console.SetCursorPosition(0, _top);
            Show(false);
        }

        private void KeyPress()
        {
            Console.Clear();
            Show(false);
        }
    }
}
