using System;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
using System.Windows;
using System.Timers;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;

//created and designed by Dakota McCombs https://github.com/d82mc
//program is intended to be free and open source
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
        }
        #endregion

        #region row toggles
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (button.Content.ToString() == "OFF")
            {
                button.Content = "ON";
                button.Background = Brushes.Lime;
                button.Foreground = Brushes.Black;
            }
            else
            {
                button.Content = "OFF";
                button.Background = Brushes.Black;
                button.Foreground = Brushes.Lime;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (button1.Content.ToString() == "OFF")
            {
                button1.Content = "ON";
                button1.Background = Brushes.Lime;
                button1.Foreground = Brushes.Black;
            }
            else
            {
                button1.Content = "OFF";
                button1.Background = Brushes.Black;
                button1.Foreground = Brushes.Lime;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (button2.Content.ToString() == "OFF")
            {
                button2.Content = "ON";
                button2.Background = Brushes.Lime;
                button2.Foreground = Brushes.Black;
            }
            else
            {
                button2.Content = "OFF";
                button2.Background = Brushes.Black;
                button2.Foreground = Brushes.Lime;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (button3.Content.ToString() == "OFF")
            {
                button3.Content = "ON";
                button3.Background = Brushes.Lime;
                button3.Foreground = Brushes.Black;
            }
            else
            {
                button3.Content = "OFF";
                button3.Background = Brushes.Black;
                button3.Foreground = Brushes.Lime;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (button4.Content.ToString() == "OFF")
            {
                button4.Content = "ON";
                button4.Background = Brushes.Lime;
                button4.Foreground = Brushes.Black;
            }
            else
            {
                button4.Content = "OFF";
                button4.Background = Brushes.Black;
                button4.Foreground = Brushes.Lime;
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (button5.Content.ToString() == "OFF")
            {
                button5.Content = "ON";
                button5.Background = Brushes.Lime;
                button5.Foreground = Brushes.Black;
            }
            else
            {
                button5.Content = "OFF";
                button5.Background = Brushes.Black;
                button5.Foreground = Brushes.Lime;
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (button6.Content.ToString() == "OFF")
            {
                button6.Content = "ON";
                button6.Background = Brushes.Lime;
                button6.Foreground = Brushes.Black;
            }
            else
            {
                button6.Content = "OFF";
                button6.Background = Brushes.Black;
                button6.Foreground = Brushes.Lime;
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (button7.Content.ToString() == "OFF")
            {
                button7.Content = "ON";
                button7.Background = Brushes.Lime;
                button7.Foreground = Brushes.Black;
            }
            else
            {
                button7.Content = "OFF";
                button7.Background = Brushes.Black;
                button7.Foreground = Brushes.Lime;
            }
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if (button8.Content.ToString() == "OFF")
            {
                button8.Content = "ON";
                button8.Background = Brushes.Lime;
                button8.Foreground = Brushes.Black;
            }
            else
            {
                button8.Content = "OFF";
                button8.Background = Brushes.Black;
                button8.Foreground = Brushes.Lime;
            }
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            if(button9.Content.ToString() == "OFF")
            {
                button9.Content = "ON";
                button9.Background = Brushes.Lime;
                button9.Foreground = Brushes.Black;
            }
            else
            {
                button9.Content = "OFF";
                button9.Background = Brushes.Black;
                button9.Foreground = Brushes.Lime;
            }
        }
        #endregion

        #region fields
        //Create necessary fields to store info
        private int _row = 0, charmode = 0;
        public static int row1_x, row1_y, row2_x, row2_y, row3_x, row3_y, row4_x, row4_y, row5_x, row5_y, row6_x, row6_y, row7_x, row7_y, row8_x, row8_y, row9_x, row9_y, row0_x, row0_y;
        public static Point pt1, pt2, pt3, pt4, pt5, pt6, pt7, pt8, pt9, pt0;
        public static int x, y, rx, ry;
        public static string _x, _y, _rx, _ry;
        public string[] stringArray1, stringArray2, stringArray3, stringArray4, stringArray5, stringArray6, stringArray7, stringArray8, stringArray9, stringArray0;
        static Point returnpos = new Point();
        static System.Timers.Timer wait = new System.Timers.Timer();
        static System.Timers.Timer stopper = new System.Timers.Timer();
        public static char onekey;
        public static string keystring = "        ";
        public static string singlemodifierstring = "     ";
        public static string twokeystring = "  ";
        public static string doublemodifierstring = "     ";
        public static string threekeystring = "   ";
        public static string triplemodifierstring = "     ";
        #endregion

        #region change keymode
        private void charmodebtn_Click(object sender, RoutedEventArgs e)
        {
            switch (charmode)
            {
                case 0:
                    charmode = 1;
                    label3.Content = "DOUBLE KEY";
                    charmodebtn.Content = "Use 3 Keys";
                    keycap_btn.Content = "Capture Keys";
                    break;
                case 1:
                    charmode = 2;
                    label3.Content = "TRIPLE KEY";
                    charmodebtn.Content = "Use 1 Key";
                    keycap_btn.Content = "Capture Keys";
                    break;
                case 2:
                    charmode = 0;
                    label3.Content = "SINGLE KEY";
                    charmodebtn.Content = "Use 2 Keys";
                    keycap_btn.Content = "Capture Key";
                    break;
            }  
        }
        #endregion

        #region set up mouse
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
            _listener = new Listener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();
        }

        private Listener _listener;
        #endregion

        #region onkeypressed
        //Every time a key is pressed, 
        //check if the last keys match any center column box.
        //if they do, send a click to that row's defined x and y
        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            keystring += e.KeyPressed.ToString();
            _rx = GetMousePosition().X.ToString();
            _ry = GetMousePosition().Y.ToString();
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

            switch (charmode)
            {
                case 0:
                    #region Capture Most Recent Character
                    singlemodifierstring = keystring.Substring(keystring.Length - 5);
                    onekey = keystring[keystring.Length - 1];
                    #region detect ctrl, alt, and shift
                    if (onekey == 't' || onekey == 'l')
                    {
                        if (singlemodifierstring.Substring(2,3) == "Alt")
                        {
                            textBox.Text = "Alt";
                        }
                        if (singlemodifierstring.Substring(1, 4) == "Ctrl")
                        {
                            textBox.Text = "Ctrl";
                        }
                        if (singlemodifierstring == "Shift")
                        {
                            textBox.Text = singlemodifierstring;
                        }
                    }
                    else
                    {
                        textBox.Text = onekey.ToString();
                    }
                    #endregion

                    if ((keystring[keystring.Length - 1].ToString() == textBox2.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox2.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox2.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox2.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox2.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox2.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox2.Text) &&
                        button.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row1_x, row1_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row1_x, row1_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row1_x, row1_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((keystring[keystring.Length - 1].ToString() == textBox5.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox5.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox5.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox5.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox5.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox5.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox5.Text) &&
                        button1.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row2_x, row2_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row2_x, row2_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row2_x, row2_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((keystring[keystring.Length - 1].ToString() == textBox8.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox8.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox8.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox8.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox8.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox8.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox8.Text) &&
                        button2.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row3_x, row3_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row3_x, row3_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row3_x, row3_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((keystring[keystring.Length - 1].ToString() == textBox11.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox11.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox11.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox11.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox11.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox11.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox11.Text) &&
                        button3.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row4_x, row4_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row4_x, row4_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row4_x, row4_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((keystring[keystring.Length - 1].ToString() == textBox14.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox14.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox14.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox14.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox14.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox14.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox14.Text) &&
                        button4.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row5_x, row5_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row5_x, row5_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row5_x, row5_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((keystring[keystring.Length - 1].ToString() == textBox17.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox17.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox17.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox17.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox17.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox17.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox17.Text) &&
                        button5.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row6_x, row6_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row6_x, row6_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row6_x, row6_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((keystring[keystring.Length - 1].ToString() == textBox20.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox20.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox20.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox20.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox20.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox20.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox20.Text) &&
                        button6.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row7_x, row7_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row7_x, row7_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row7_x, row7_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((keystring[keystring.Length - 1].ToString() == textBox23.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox23.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox23.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox23.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox23.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox23.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox23.Text) &&
                        button7.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row8_x, row8_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row8_x, row8_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row8_x, row8_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((keystring[keystring.Length - 1].ToString() == textBox26.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox26.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox26.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox26.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox26.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox26.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox26.Text) &&
                        button8.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row9_x, row9_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row9_x, row9_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row9_x, row9_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((keystring[keystring.Length - 1].ToString() == textBox29.Text ||
                        keystring.Substring(keystring.Length - 2) == textBox29.Text ||
                        keystring.Substring(keystring.Length - 3) == textBox29.Text ||
                        keystring.Substring(keystring.Length - 4) == textBox29.Text ||
                        keystring.Substring(keystring.Length - 5) == textBox29.Text ||
                        keystring.Substring(keystring.Length - 6) == textBox29.Text ||
                        keystring.Substring(keystring.Length - 7) == textBox29.Text) &&
                        button9.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row0_x, row0_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row0_x, row0_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row0_x, row0_y, 0, 0);
                        wait.Enabled = true;
                    }
                    #endregion
                    break;
                case 1:
                    #region Capture Last Two Characters
                    doublemodifierstring = keystring.Substring(keystring.Length - 6);
                    twokeystring = keystring.Substring(keystring.Length - 2);
                    #region detect ctrl, alt, and shift
                    if (doublemodifierstring.Substring(2, 3) == "Alt")
                    {
                        textBox.Text = "Alt" + twokeystring[1];
                    }
                    else
                    {
                        if (doublemodifierstring.Substring(1, 4) == "Ctrl")
                        {
                            textBox.Text = "Ctrl" + twokeystring[1];
                        }
                        else
                        {
                            if (doublemodifierstring.Substring(0, 5) == "Shift")
                            {
                                textBox.Text = "Shift" + twokeystring[1];
                            }
                            else
                            {
                                if (doublemodifierstring.Substring(3, 3) == "Alt")
                                {
                                    textBox.Text = "Alt";
                                }
                                else
                                {
                                    if (doublemodifierstring.Substring(2, 4) == "Ctrl")
                                    {
                                        textBox.Text = "Ctrl";
                                    }
                                    else
                                    {
                                        if (doublemodifierstring.Substring(1, 5) == "Shift")
                                        {
                                            textBox.Text = "Shift";
                                        }
                                        else
                                        {
                                            textBox.Text = twokeystring;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    
                    if ((textBox.Text == textBox2.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox2.Text.ToString()) && button.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row1_x, row1_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row1_x, row1_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row1_x, row1_y, 0, 0);
                        wait.Enabled = true;
                    }
                    if ((textBox.Text == textBox5.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox5.Text.ToString()) && button1.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row2_x, row2_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row2_x, row2_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row2_x, row2_y, 0, 0);
                        wait.Enabled = true;
                    }
                    if ((textBox.Text == textBox8.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox8.Text.ToString()) && button2.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row3_x, row3_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row3_x, row3_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row3_x, row3_y, 0, 0);
                        wait.Enabled = true;
                    }
                    if ((textBox.Text == textBox11.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox11.Text.ToString()) && button3.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row4_x, row4_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row4_x, row4_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row4_x, row4_y, 0, 0);
                        wait.Enabled = true;
                    }
                    if ((textBox.Text == textBox14.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox14.Text.ToString()) && button4.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row5_x, row5_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row5_x, row5_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row5_x, row5_y, 0, 0);
                        wait.Enabled = true;
                    }
                    if ((textBox.Text == textBox17.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox17.Text.ToString()) && button5.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row6_x, row6_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row6_x, row6_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row6_x, row6_y, 0, 0);
                        wait.Enabled = true;
                    }
                    if ((textBox.Text == textBox20.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox20.Text.ToString()) && button6.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row7_x, row7_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row7_x, row7_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row7_x, row7_y, 0, 0);
                        wait.Enabled = true;
                    }
                    if ((textBox.Text == textBox23.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox23.Text.ToString()) && button7.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row8_x, row8_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row8_x, row8_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row8_x, row8_y, 0, 0);
                        wait.Enabled = true;
                    }
                    if ((textBox.Text == textBox26.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox26.Text.ToString()) && button8.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row9_x, row9_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row9_x, row9_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row9_x, row9_y, 0, 0);
                        wait.Enabled = true;
                    }
                    if ((textBox.Text == textBox29.Text || textBox.Text[textBox.Text.Length - 1].ToString() == textBox29.Text.ToString()) && button9.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row0_x, row0_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row0_x, row0_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row0_x, row0_y, 0, 0);
                        wait.Enabled = true;
                    }
                    #endregion
                    break;
                case 2:
                    #region Capture Last Three Characters
                    triplemodifierstring = keystring.Substring(keystring.Length - 7);
                    threekeystring = keystring.Substring(keystring.Length - 3);
                    #region detect ctrl, alt, and shift
                    if (triplemodifierstring.Substring(2, 3) == "Alt")
                    {
                        textBox.Text = "Alt" + threekeystring[1] + threekeystring[2];
                    }
                    else
                    {
                        if (triplemodifierstring.Substring(1, 4) == "Ctrl")
                        {
                            textBox.Text = "Ctrl" + threekeystring[1] + threekeystring[2];
                        }
                        else
                        {
                            if (triplemodifierstring.Substring(0, 5) == "Shift")
                            {
                                textBox.Text = "Shift" + threekeystring[1] + threekeystring[2];
                            }
                            else
                            {
                                if (triplemodifierstring.Substring(3, 3) == "Alt")
                                {
                                    textBox.Text = "Alt" + threekeystring[2];
                                }
                                else
                                {
                                    if (triplemodifierstring.Substring(2, 4) == "Ctrl")
                                    {
                                        textBox.Text = "Ctrl" + threekeystring[2];
                                    }
                                    else
                                    {
                                        if (triplemodifierstring.Substring(1, 5) == "Shift")
                                        {
                                            textBox.Text = "Shift" + threekeystring[2];
                                        }
                                        else
                                        {
                                            if (triplemodifierstring.Substring(4, 3) == "Alt")
                                            {
                                                textBox.Text = "Alt";
                                            }
                                            else
                                            {
                                                if (triplemodifierstring.Substring(3, 4) == "Ctrl")
                                                {
                                                    textBox.Text = "Ctrl";
                                                }
                                                else
                                                {
                                                    if (triplemodifierstring.Substring(2, 5) == "Shift")
                                                    {
                                                        textBox.Text = "Shift";
                                                    }
                                                    else
                                                    {

                                                        textBox.Text = threekeystring;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    if ((textBox.Text == textBox2.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox2.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox2.Text.ToString()) &&
                        button.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row1_x, row1_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row1_x, row1_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row1_x, row1_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((textBox.Text == textBox5.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox5.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox5.Text.ToString()) &&
                        button1.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row2_x, row2_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row2_x, row2_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row2_x, row2_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((textBox.Text == textBox8.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox8.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox8.Text.ToString()) &&
                        button2.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row3_x, row3_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row3_x, row3_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row3_x, row3_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((textBox.Text == textBox11.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox11.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox11.Text.ToString()) &&
                        button3.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row4_x, row4_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row4_x, row4_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row4_x, row4_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((textBox.Text == textBox14.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox14.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox14.Text.ToString()) &&
                        button4.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row5_x, row5_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row5_x, row5_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row5_x, row5_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((textBox.Text == textBox17.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox17.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox17.Text.ToString()) &&
                        button5.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row6_x, row6_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row6_x, row6_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row6_x, row6_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((textBox.Text == textBox20.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox20.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox20.Text.ToString()) &&
                        button6.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row7_x, row7_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row7_x, row7_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row7_x, row7_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((textBox.Text == textBox23.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox23.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox23.Text.ToString()) &&
                        button7.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row8_x, row8_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row8_x, row8_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row8_x, row8_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((textBox.Text == textBox26.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox26.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox26.Text.ToString()) &&
                        button8.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row9_x, row9_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row9_x, row9_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row9_x, row9_y, 0, 0);
                        wait.Enabled = true;
                    }

                    if ((textBox.Text == textBox29.Text ||
                        textBox.Text[textBox.Text.Length - 1].ToString() == textBox29.Text.ToString() ||
                        textBox.Text.Substring(textBox.Text.Length - 2) == textBox29.Text.ToString()) &&
                        button9.Content.ToString() == "ON")
                    {
                        wait.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        wait.Interval = 1;
                        stopper.Elapsed += new ElapsedEventHandler(OnStopperEvent);
                        stopper.Interval = 2;
                        SetCursorPos(row0_x, row0_y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, row0_x, row0_y, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, row0_x, row0_y, 0, 0);
                        wait.Enabled = true;
                    }
                    #endregion
                    break;
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
                    textBox1.Background = Brushes.Black;
                    textBox2.Background = Brushes.Black;
                    textBox1.Foreground = Brushes.Lime;
                    textBox2.Foreground = Brushes.Lime;
                    textBox1.BorderBrush = Brushes.Lime;
                    textBox2.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox1.Background = Brushes.Lime;
                    textBox2.Background = Brushes.Lime;
                    textBox1.Foreground = Brushes.Black;
                    textBox2.Foreground = Brushes.Black;
                    textBox1.BorderBrush = Brushes.Black;
                    textBox2.BorderBrush = Brushes.Black;
                }

                if (_row != 2)
                {
                    textBox4.Background = Brushes.Black;
                    textBox5.Background = Brushes.Black;
                    textBox4.Foreground = Brushes.Lime;
                    textBox5.Foreground = Brushes.Lime;
                    textBox4.BorderBrush = Brushes.Lime;
                    textBox5.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox4.Background = Brushes.Lime;
                    textBox5.Background = Brushes.Lime;
                    textBox4.Foreground = Brushes.Black;
                    textBox5.Foreground = Brushes.Black;
                    textBox4.BorderBrush = Brushes.Black;
                    textBox5.BorderBrush = Brushes.Black;
                }

                if (_row != 3)
                {
                    textBox7.Background = Brushes.Black;
                    textBox8.Background = Brushes.Black;
                    textBox7.Foreground = Brushes.Lime;
                    textBox8.Foreground = Brushes.Lime;
                    textBox7.BorderBrush = Brushes.Lime;
                    textBox8.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox7.Background = Brushes.Lime;
                    textBox8.Background = Brushes.Lime;
                    textBox7.Foreground = Brushes.Black;
                    textBox8.Foreground = Brushes.Black;
                    textBox7.BorderBrush = Brushes.Black;
                    textBox8.BorderBrush = Brushes.Black;
                }

                if (_row != 4)
                {
                    textBox10.Background = Brushes.Black;
                    textBox11.Background = Brushes.Black;
                    textBox10.Foreground = Brushes.Lime;
                    textBox11.Foreground = Brushes.Lime;
                    textBox10.BorderBrush = Brushes.Lime;
                    textBox11.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox10.Background = Brushes.Lime;
                    textBox11.Background = Brushes.Lime;
                    textBox10.Foreground = Brushes.Black;
                    textBox11.Foreground = Brushes.Black;
                    textBox10.BorderBrush = Brushes.Black;
                    textBox11.BorderBrush = Brushes.Black;
                }

                if (_row != 5)
                {
                    textBox13.Background = Brushes.Black;
                    textBox14.Background = Brushes.Black;
                    textBox13.Foreground = Brushes.Lime;
                    textBox14.Foreground = Brushes.Lime;
                    textBox13.BorderBrush = Brushes.Lime;
                    textBox14.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox13.Background = Brushes.Lime;
                    textBox14.Background = Brushes.Lime;
                    textBox13.Foreground = Brushes.Black;
                    textBox14.Foreground = Brushes.Black;
                    textBox13.BorderBrush = Brushes.Black;
                    textBox14.BorderBrush = Brushes.Black;
                }

                if (_row != 6)
                {
                    textBox16.Background = Brushes.Black;
                    textBox17.Background = Brushes.Black;
                    textBox16.Foreground = Brushes.Lime;
                    textBox17.Foreground = Brushes.Lime;
                    textBox16.BorderBrush = Brushes.Lime;
                    textBox17.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox16.Background = Brushes.Lime;
                    textBox17.Background = Brushes.Lime;
                    textBox16.Foreground = Brushes.Black;
                    textBox17.Foreground = Brushes.Black;
                    textBox16.BorderBrush = Brushes.Black;
                    textBox17.BorderBrush = Brushes.Black;
                }

                if (_row != 7)
                {
                    textBox19.Background = Brushes.Black;
                    textBox20.Background = Brushes.Black;
                    textBox19.Foreground = Brushes.Lime;
                    textBox20.Foreground = Brushes.Lime;
                    textBox19.BorderBrush = Brushes.Lime;
                    textBox20.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox19.Background = Brushes.Lime;
                    textBox20.Background = Brushes.Lime;
                    textBox19.Foreground = Brushes.Black;
                    textBox20.Foreground = Brushes.Black;
                    textBox19.BorderBrush = Brushes.Black;
                    textBox20.BorderBrush = Brushes.Black;
                }

                if (_row != 8)
                {
                    textBox22.Background = Brushes.Black;
                    textBox23.Background = Brushes.Black;
                    textBox22.Foreground = Brushes.Lime;
                    textBox23.Foreground = Brushes.Lime;
                    textBox22.BorderBrush = Brushes.Lime;
                    textBox23.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox22.Background = Brushes.Lime;
                    textBox23.Background = Brushes.Lime;
                    textBox22.Foreground = Brushes.Black;
                    textBox23.Foreground = Brushes.Black;
                    textBox22.BorderBrush = Brushes.Black;
                    textBox23.BorderBrush = Brushes.Black;
                }

                if (_row != 9)
                {
                    textBox25.Background = Brushes.Black;
                    textBox26.Background = Brushes.Black;
                    textBox25.Foreground = Brushes.Lime;
                    textBox26.Foreground = Brushes.Lime;
                    textBox25.BorderBrush = Brushes.Lime;
                    textBox26.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox25.Background = Brushes.Lime;
                    textBox26.Background = Brushes.Lime;
                    textBox25.Foreground = Brushes.Black;
                    textBox26.Foreground = Brushes.Black;
                    textBox25.BorderBrush = Brushes.Black;
                    textBox26.BorderBrush = Brushes.Black;
                }

                if (_row != 10)
                {
                    textBox28.Background = Brushes.Black;
                    textBox29.Background = Brushes.Black;
                    textBox28.Foreground = Brushes.Lime;
                    textBox29.Foreground = Brushes.Lime;
                    textBox28.BorderBrush = Brushes.Lime;
                    textBox29.BorderBrush = Brushes.Lime;
                }
                else
                {
                    textBox28.Background = Brushes.Lime;
                    textBox29.Background = Brushes.Lime;
                    textBox28.Foreground = Brushes.Black;
                    textBox29.Foreground = Brushes.Black;
                    textBox28.BorderBrush = Brushes.Black;
                    textBox29.BorderBrush = Brushes.Black;
                }
            }
        }
        #endregion

        private void Serialize(string save)
        {
            XmlSerializer ser = new XmlSerializer(typeof(string));

            
        }
    }
}