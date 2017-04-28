using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

public class Mouse_Simulation
{
   [DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
   public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

   private const int MOUSEEVENTF_LEFTDOWN = 0x02;
   private const int MOUSEEVENTF_LEFTUP = 0x04;
   private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
   private const int MOUSEEVENTF_RIGHTUP = 0x10;

   //right clicks at cursor position
   public void rightClick()
   {
      //Call the imported function with the cursor's current position
      int X = Cursor.Position.X;
      int Y = Cursor.Position.Y;
      mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
   }

   //left clicks at cursor position
   public void leftClick()
   {
      //Call the imported function with the cursor's current position
      int X = Cursor.Position.X;
      int Y = Cursor.Position.Y;
      mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
   }

   //get position of the cursor (for testing purpose to write code, outputs in cmd)
   public void getPos()
   {
      Console.WriteLine(Cursor.Position.ToString());
   }

   //change position of cursor by entering x and y parameter
   public void changePos(int pos_x,int pos_y)
   {
  	  Cursor.Position = new Point(pos_x,pos_y);
   }	
   
   //input string through keyboard
   public void inputString(string a)
   {
      SendKeys.SendWait(a);
   }
    
   //wait for some time before proceeding to next method call
   public void waitTime(int t)
   {
      System.Threading.Thread.Sleep(t);
   }

   // shortkey alt with combinations
   public void altWith(params string[] keys)
   {
      shortcutWith("%", keys);
   }

   // shortkey shift with combinations
   public void shiftWith(params string[] keys)
   {
      shortcutWith("+", keys);
   }

   // shortkey ctrl with combinations
   public void ctrlWith(params string[] keys)
   {
      shortcutWith("^", keys);
   }   

   // shortkey combination with any keys.
   // check look-up table for shortcut keys at end of file 
   public void shortcutWith(params string shortcuts, params string[] keys)
   {
      string send_keys = "";
      string shortcut_keys = "";
      string a = ""
      for(int i = 0; i < keys.Length; i++)
      {
         send_keys = send_keys + keys[i];
      }

      for(int i = 0; i < shortcuts.Length; i++)
      {
         shortcut_keys = shortcut_keys + "{" + shortcut_keys[i] + "}";
      }
      if (shortcut_keys != "")
      a = a + shortcut_keys;
      if (keys != "")
      a = a + "(" + send_keys + ")";

      SendKeys.SendWait(a);
   }

   //...other code needed for the application

   //example    
   public static void Main()
   {
      Mouse_Simulation a=new Mouse_Simulation();
    
      a.rightClick();
      a.leftClick();
      a.wait(10000);    
      a.inputString("hello WRENCH"); 

      EventArgs e=new EventArgs();
      MouseEventArgs me = (MouseEventArgs) e;   
      if (me.Button == MouseButtons.Right)
         a.getPos();
   }
}

/*
BACKSPACE	{BACKSPACE}, {BS}, or {BKSP}
BREAK	{BREAK}
CAPS LOCK	{CAPSLOCK}
DEL or DELETE	{DELETE} or {DEL}
DOWN ARROW	{DOWN}
END	{END}
ENTER	{ENTER}or ~
ESC	{ESC}
HELP	{HELP}
HOME	{HOME}
INS or INSERT	{INSERT} or {INS}
LEFT ARROW	{LEFT}
NUM LOCK	{NUMLOCK}
PAGE DOWN	{PGDN}
PAGE UP	{PGUP}
PRINT SCREEN	{PRTSC} (reserved for future use)
RIGHT ARROW	{RIGHT}
SCROLL LOCK	{SCROLLLOCK}
TAB	{TAB}
UP ARROW	{UP}
F1	{F1}
F2	{F2}
F3	{F3}
F4	{F4}
F5	{F5}
F6	{F6}
F7	{F7}
F8	{F8}
F9	{F9}
F10	{F10}
F11	{F11}
F12	{F12}
F13	{F13}
F14	{F14}
F15	{F15}
F16	{F16}
Keypad add	{ADD}
Keypad subtract	{SUBTRACT}
Keypad multiply	{MULTIPLY}
Keypad divide	{DIVIDE}
SHIFT	+
CTRL	^
ALT	%
*/
