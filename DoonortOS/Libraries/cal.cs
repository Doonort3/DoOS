using System;

namespace DoonortOS.Libraries
{
    public class CAL
    {
        public class Menu
        {
            public static void Bar(string[] text)
            {
                ConsoleColor old = Console.BackgroundColor;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 80; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < text.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(text[i][0]);
                    Console.ForegroundColor = ConsoleColor.White;
                    text[i] = text[i].Remove(0, 1);
                    Console.Write(text[i]);
                    Console.Write(" | ");
                }
                Console.BackgroundColor = old;
            }

            public static char StripMenu(string[] text, string[] shorts, int x, string Name)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.White;
                int y = 1;
                Console.SetCursorPosition(x, y);
                for (int it = 0; it != 11; it++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x, y);
                Console.Write(Name);
                for (int i = 0; i != text.Length; i++)
                {
                    y++;
                    Console.SetCursorPosition(x, y);
                    for (int it = 0; it != 10; it++)
                    {
                        Console.Write(" ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(x, y);
                    Console.Write(text[i]);
                    Console.SetCursorPosition(x + 10, y);
                    Console.Write(shorts[i]);
                }
                return Console.ReadKey().KeyChar;
            }
        }

        public class Box
        {
            static public char MsgBox(string Title, string Message, string[] buttons, int y = 6, int x = 25, ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black, ConsoleColor Bar = ConsoleColor.Blue, ConsoleColor BarText = ConsoleColor.White)
            {
                Console.BackgroundColor = Bar;
                Console.ForegroundColor = BarText;
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x, y);
                Console.Write(" [" + Title + "]");
                Console.ForegroundColor = text;
                Console.BackgroundColor = back;
                Console.SetCursorPosition(x, y + 1);
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }

                Console.SetCursorPosition(x, y + 2);
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }
                int x3 = Console.CursorLeft;
                Console.SetCursorPosition(x + 1, y + 2);
                Console.Write(Message); 
                Console.SetCursorPosition(x, y + 3);
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x + 1, y + 4);
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x3, y + 2);
                Console.Write(" ");
                Console.SetCursorPosition(x3, y + 3);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x + 1, y + 3);
                for(int i = 0; i<buttons.Length; i++)
                {
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(buttons[i][0]);
                    Console.ForegroundColor = ConsoleColor.Black;
                    buttons[i] = buttons[i].Remove(0, 1);
                    Console.Write(buttons[i] + "]");
                    Console.Write(" ");
                }
                return Console.ReadKey().KeyChar;
            }


            static public string InputBox(string Title, string Print, int y = 6, int x = 25, ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black, ConsoleColor Bar = ConsoleColor.Blue, ConsoleColor BarText = ConsoleColor.White)
            {
                Console.BackgroundColor = Bar;
                Console.ForegroundColor = BarText;
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x, y);
                Console.Write(" [" + Title + "]");
                Console.ForegroundColor = text;
                Console.BackgroundColor = back;
                Console.SetCursorPosition(x, y + 1);
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }

                Console.SetCursorPosition(x, y + 2);
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x + 1, y + 2);
                Console.Write(Print + ": ["); int x2 = Console.CursorLeft; Console.SetCursorPosition(x + 33, y + 2); Console.Write("]"); int x3 = Console.CursorLeft + 1;
                Console.SetCursorPosition(x, y + 3);
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x + 1, y + 4);
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < 35; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x3, y + 2);
                Console.Write(" ");
                Console.SetCursorPosition(x3, y + 3);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x2, y + 2);
                string toret = Read.LootiTerminal(x + 33, ']');
                return toret;
            }

            static public string[] Login (int y = 6, int x = 25, ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black, ConsoleColor Bar = ConsoleColor.Blue, ConsoleColor BarText = ConsoleColor.White)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Clear();
                string log = Box.InputBox("Login", "Login", y, x, back, text, Bar, BarText);
                string pass = Box.InputBox("Login", "Password", y, x, back, text, Bar, BarText);
                string[] toret = new string[2];
                toret[0] = log;
                toret[1] = pass;
                return toret;
            }





        }

        public class Read
        {
            static public string LootiTerminal(int mxcurpos, char bck)
            {
                string toreturn = "";
                for (; ; )
                {
                    string arrow = "";

                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Enter)
                    {
                        return toreturn + arrow;
                    }
                    else if (input.Key == ConsoleKey.Backspace)
                    {
                        int x = Console.CursorLeft;
                        if (toreturn.Length != 0)
                        {

                            Console.CursorLeft--;
                            toreturn = toreturn.Remove(toreturn.Length - 1, 1);
                            Console.Write(" ");
                            Console.CursorLeft--;
                        }
                        else
                        {
                            Console.CursorLeft = x;
                        }
                    }
                    else if (input.Key == ConsoleKey.LeftArrow)
                    {

                        if (toreturn.Length > 0)
                        {
                            arrow = toreturn[toreturn.Length - 1] + arrow;
                            toreturn = toreturn.Remove(toreturn.Length - 1, 1);
                        }
                    }
                    else if (input.Key == ConsoleKey.RightArrow && arrow.Length > 0)
                    {
                        toreturn += arrow[0];
                        arrow = arrow.Remove(0, 1);
                    }
                    else if (input.Key == ConsoleKey.RightArrow && arrow.Length == 0)
                    {
                        Console.CursorLeft--;
                    }
                    else
                    {
                        if (Console.CursorLeft <= mxcurpos)
                        {
                            toreturn += input.KeyChar.ToString();
                        }
                        else
                        {

                            Console.CursorLeft--;
                            Console.Write(bck);
                            Console.CursorLeft--;
                        }
                    }
                }
            }
        }
    }
}
