using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Windows;
using System.Timers;
using System.Windows.Input;
using System.Windows.Media;

namespace HotMouse
{
    public partial class HotMouse1 : Window
    {
        public HotMouse1()
        {
            InitializeComponent();
            row = 1;
        }

        #region struct
        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        #endregion

        #region fields
        //Create necessary fields to store info
        private int _row = 0;
        public static int row1_x, row1_y, row2_x, row2_y, row3_x, row3_y, row4_x, row4_y, row5_x, row5_y, row6_x, row6_y, row7_x, row7_y, row8_x, row8_y, row9_x, row9_y, row0_x, row0_y;
        public static Point pt1, pt2, pt3, pt4, pt5, pt6, pt7, pt8, pt9, pt0; 
        public static char[] key, char1, char2, char3, char4, char5, char6, char7, char8, char9, char0;
        public static int x, y, rx, ry;
        public static string _x, _y, _rx, _ry;
        public string[] stringArray1, stringArray2, stringArray3, stringArray4, stringArray5, stringArray6, stringArray7, stringArray8, stringArray9, stringArray0;
        static Point returnpos = new Point();
        static System.Timers.Timer wait = new System.Timers.Timer();
        static System.Timers.Timer stopper = new System.Timers.Timer();
        public static char current;
        public static string keystring;
        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }

        //Instantiate mouse codes
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        #endregion
        
        #region dlls
        //Import dll files to allow for global keyboard and mouse emulation
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);
        #endregion

        #region capture Key
        //send current key to center column
        private void keycap_btn_Click(object sender, RoutedEventArgs e)
        {
            switch (_row)
            {
                case 1:
                    textBox2.Text = textBox.Text;
                    break;
                case 2:
                    textBox5.Text = textBox.Text;
                    break;
                case 3:
                    textBox8.Text = textBox.Text;
                    break;
                case 4:
                    textBox11.Text = textBox.Text;
                    break;
                case 5:
                    textBox14.Text = textBox.Text;
                    break;
                case 6:
                    textBox17.Text = textBox.Text;
                    break;
                case 7:
                    textBox20.Text = textBox.Text;
                    break;
                case 8:
                    textBox23.Text = textBox.Text;
                    break;
                case 9:
                    textBox26.Text = textBox.Text;
                    break;
                case 10:
                    textBox29.Text = textBox.Text;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region return cursor
        //If the cursor position is close to where we sent it to, send it home
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            GetMousePosition();
            if (returnpos.X >= x - 15 && returnpos.X <= x + 15 && returnpos.Y >= y - 15 && returnpos.Y <= y + 15)
            {
                rx = int.Parse(_rx);
                ry = int.Parse(_ry);
                SetCursorPos(rx, ry);
                wait.Stop();
                wait.Enabled = false;
            }
            else
            {
                wait.Stop();
                wait.Enabled = false;
            }
        }

        //Prevent cursor send from reoccuring
        private static void OnStopperEvent(object source, ElapsedEventArgs e)
        {
            wait.Stop();
        }
        #endregion

        #region row movement
        //highlight next row down, jump to top row if you're at the bottom
        private void rowdown_btn_Click(object sender, RoutedEventArgs e)
        {
            if (row != 10)
            {
                row += 1;
                Console.WriteLine("Selected row " + row);
            }
            else
            {
                row -= 9;
                Console.WriteLine("Selected row " + row);
            }
        }
        
        //highlight next row up, jump to bottom row if you're at the top
        private void rowup_btn_Click(object sender, RoutedEventArgs e)
        {
            if (row != 1)
            {
                row -= 1;
                Console.WriteLine("Selected row " + row);
            }
            else
            {
                row += 9;
                Console.WriteLine("Selected row " + row);
            }
        }
        #endregion

        #region clear row
        //clear selected row
        private void clearrow_btn_Click(object sender, RoutedEventArgs e)
        {
            switch (_row)
            {
                case 1:
                    textBox1.Text = "0,0";
                    textBox2.Text = " ";
                    textBox3.Text = null;
                    break;
                case 2:
                    textBox4.Text = "0,0";
                    textBox5.Text = " ";
                    textBox6.Text = null;
                    break;
                case 3:
                    textBox7.Text = "0,0";
                    textBox8.Text = " ";
                    textBox9.Text = null;
                    break;
                case 4:
                    textBox10.Text = "0,0";
                    textBox11.Text = null;
                    textBox12.Text = null;
                    break;
                case 5:
                    textBox13.Text = "0,0";
                    textBox14.Text = " ";
                    textBox15.Text = null;
                    break;
                case 6:
                    textBox16.Text = "0,0";
                    textBox17.Text = " ";
                    textBox18.Text = null;
                    break;
                case 7:
                    textBox19.Text = "0,0";
                    textBox20.Text = null;
                    textBox21.Text = null;
                    break;
                case 8:
                    textBox22.Text = "0,0";
                    textBox23.Text = " ";
                    textBox24.Text = null;
                    break;
                case 9:
                    textBox25.Text = "0,0";
                    textBox26.Text = " ";
                    textBox27.Text = null;
                    break;
                case 10:
                    textBox28.Text = "0,0";
                    textBox29.Text = " ";
                    textBox30.Text = null;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region capture mouse
        //Record mouse x/y to highlighted row, separated by a comma
        private void mousecap_btn_LostMouseCapture(object sender, MouseEventArgs e)
        {
            _x = GetMousePosition().X.ToString();
            _y = GetMousePosition().Y.ToString();

            string[] num = { _x, _y };
            string separator = ", ";


            switch (_row)
            {
                case 1:
                    textBox1.Text = string.Join(separator, num);
                    break;
                case 2:
                    textBox4.Text = string.Join(separator, num);
                    break;
                case 3:
                    textBox7.Text = string.Join(separator, num);
                    break;
                case 4:
                    textBox10.Text = string.Join(separator, num);
                    break;
                case 5:
                    textBox13.Text = string.Join(separator, num);
                    break;
                case 6:
                    textBox16.Text = string.Join(separator, num);
                    break;
                case 7:
                    textBox19.Text = string.Join(separator, num);
                    break;
                case 8:
                    textBox22.Text = string.Join(separator, num);
                    break;
                case 9:
                    textBox25.Text = string.Join(separator, num);
                    break;
                case 10:
                    textBox28.Text = string.Join(separator, num);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region listener
        //Start listeners
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();
        }

        private LowLevelKeyboardListener _listener;
        #endregion

        #region onkeypressed
        //Every time a key is pressed, 
        //check if it is the key in each center column box.
        //if it is, send a click to that row's defined x and y
        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            keystring += e.KeyPressed.ToString();
            current = keystring[keystring.Length - 1];
            textBox.Text = current.ToString();
            
            key = textBox.Text.ToCharArray();

            stringArray1 = textBox1.Text.Split(',');
            stringArray2 = textBox4.Text.Split(',');
            stringArray3 = textBox7.Text.Split(',');
            stringArray4 = textBox10.Text.Split(',');
            stringArray5 = textBox13.Text.Split(',');
            stringArray6 = textBox16.Text.Split(',');
            stringArray7 = textBox19.Text.Split(',');
            stringArray8 = textBox22.Text.Split(',');
            stringArray9 = textBox25.Text.Split(',');
            stringArray0 = textBox28.Text.Split(',');

            char1 = textBox2.Text.ToArray();
            char2 = textBox5.Text.ToArray();
            char3 = textBox8.Text.ToArray();
            char4 = textBox11.Text.ToArray();
            char5 = textBox14.Text.ToArray();
            char6 = textBox17.Text.ToArray();
            char7 = textBox20.Text.ToArray();
            char8 = textBox23.Text.ToArray();
            char9 = textBox26.Text.ToArray();
            char0 = textBox29.Text.ToArray();

            if (stringArray1 != null)
            {
                row1_x = int.Parse(stringArray1.First()); row1_y = int.Parse(stringArray1.Last());
            }
            if (stringArray2 != null)
            {
                row2_x = int.Parse(stringArray2.First()); row2_y = int.Parse(stringArray2.Last());
            }
            if (stringArray3 != null)
            {
                row3_x = int.Parse(stringArray3.First()); row3_y = int.Parse(stringArray3.Last());
            }
            if (stringArray4 != null)
            {
                row4_x = int.Parse(stringArray4.First()); row4_y = int.Parse(stringArray4.Last());
            }
            if (stringArray5 != null)
            {
                row5_x = int.Parse(stringArray5.First()); row5_y = int.Parse(stringArray5.Last());
            }
            if (stringArray6 != null)
            {
                row6_x = int.Parse(stringArray6.First()); row6_y = int.Parse(stringArray6.Last());
            }
            if (stringArray7 != null)
            {
                row7_x = int.Parse(stringArray7.First()); row7_y = int.Parse(stringArray7.Last());
            }
            if (stringArray8 != null)
            {
                row8_x = int.Parse(stringArray8.First()); row8_y = int.Parse(stringArray8.Last());
            }
            if (stringArray9 != null)
            {
                row9_x = int.Parse(stringArray9.First()); row9_y = int.Parse(stringArray9.Last());
            }
            if (stringArray9 != null)
            {
                row0_x = int.Parse(stringArray0.First()); row0_y = int.Parse(stringArray0.Last());
            }

            if (char1 != null && key != null && char1.First() == key.First() && checkBox.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row1_x, row1_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row1_x, row1_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row1_x, row1_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char1 = null;
            }

            if (char2 != null && key != null && char2.First() == key.First() && checkBox1.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row2_x, row2_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row2_x, row2_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row2_x, row2_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char2 = null;
            }

            if (char3 != null && key != null && char3.First() == key.First() && checkBox2.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row3_x, row3_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row3_x, row3_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row3_x, row3_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char3 = null;
            }

            if (char4 != null && key != null && char4.First() == key.First() && checkBox3.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row4_x, row4_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row4_x, row4_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row4_x, row4_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char4 = null;
            }

            if (char5 != null && key != null && char5.First() == key.First() && checkBox4.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row5_x, row5_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row5_x, row5_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row5_x, row5_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char5 = null;
            }

            if (char6 != null && key != null && char6.First() == key.First() && checkBox5.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row6_x, row6_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row6_x, row6_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row6_x, row6_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char6 = null;
            }

            if (char7 != null && key != null && char7.First() == key.First() && checkBox6.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row7_x, row7_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row7_x, row7_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row7_x, row7_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char7 = null;
            }

            if (char8 != null && key != null && char8.First() == key.First() && checkBox7.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row8_x, row8_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row8_x, row8_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row8_x, row8_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char8 = null;
            }

            if (char9 != null && key != null && char9.First() == key.First() && checkBox8.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row9_x, row9_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row9_x, row9_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row9_x, row9_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char9 = null;
            }

            if (char0 != null && key != null && char0.First() == key.First() && checkBox9.IsChecked == true)
            {
                _rx = GetMousePosition().X.ToString();
                _ry = GetMousePosition().Y.ToString();
                wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                wait.Interval = 1;
                stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                stopper.Interval = 2;
                SetCursorPos(row0_x, row0_y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, row0_x, row0_y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, row0_x, row0_y, 0, 0);
                wait.Enabled = true;
                key = null;
                char0 = null;
            }
        }
        #endregion

        #region unhook
        //Unhook keyboard upon close
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }
        #endregion

        #region rowcolors
        //if row is selected, turn it yellow
        public int row
        {
            get { return _row; }
            set
            {
                _row = value;

                if (_row != 1)
                {
                    textBox1.Background = Brushes.Gray;
                    textBox2.Background = Brushes.Gray;
                }
                else
                {
                    textBox1.Background = Brushes.DarkGoldenrod;
                    textBox2.Background = Brushes.DarkGoldenrod;
                }

                if (_row != 2)
                {
                    textBox4.Background = Brushes.Gray;
                    textBox5.Background = Brushes.Gray;
                }
                else
                {
                    textBox4.Background = Brushes.DarkGoldenrod;
                    textBox5.Background = Brushes.DarkGoldenrod;
                }

                if (_row != 3)
                {
                    textBox7.Background = Brushes.Gray;
                    textBox8.Background = Brushes.Gray;
                }
                else
                {
                    textBox7.Background = Brushes.DarkGoldenrod;
                    textBox8.Background = Brushes.DarkGoldenrod;
                }

                if (_row != 4)
                {
                    textBox10.Background = Brushes.Gray;
                    textBox11.Background = Brushes.Gray;
                }
                else
                {
                    textBox10.Background = Brushes.DarkGoldenrod;
                    textBox11.Background = Brushes.DarkGoldenrod;
                }

                if (_row != 5)
                {
                    textBox13.Background = Brushes.Gray;
                    textBox14.Background = Brushes.Gray;
                }
                else
                {
                    textBox13.Background = Brushes.DarkGoldenrod;
                    textBox14.Background = Brushes.DarkGoldenrod;
                }

                if (_row != 6)
                {
                    textBox16.Background = Brushes.Gray;
                    textBox17.Background = Brushes.Gray;
                }
                else
                {
                    textBox16.Background = Brushes.DarkGoldenrod;
                    textBox17.Background = Brushes.DarkGoldenrod;
                }

                if (_row != 7)
                {
                    textBox19.Background = Brushes.Gray;
                    textBox20.Background = Brushes.Gray;
                }
                else
                {
                    textBox19.Background = Brushes.DarkGoldenrod;
                    textBox20.Background = Brushes.DarkGoldenrod;
                }

                if (_row != 8)
                {
                    textBox22.Background = Brushes.Gray;
                    textBox23.Background = Brushes.Gray;
                }
                else
                {
                    textBox22.Background = Brushes.DarkGoldenrod;
                    textBox23.Background = Brushes.DarkGoldenrod;
                }

                if (_row != 9)
                {
                    textBox25.Background = Brushes.Gray;
                    textBox26.Background = Brushes.Gray;
                }
                else
                {
                    textBox25.Background = Brushes.DarkGoldenrod;
                    textBox26.Background = Brushes.DarkGoldenrod;
                }

                if (_row != 10)
                {
                    textBox28.Background = Brushes.Gray;
                    textBox29.Background = Brushes.Gray;
                }
                else
                {
                    textBox28.Background = Brushes.DarkGoldenrod;
                    textBox29.Background = Brushes.DarkGoldenrod;
                }
            }
        }
        #endregion
    }
}