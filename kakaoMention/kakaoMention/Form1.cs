using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;

namespace kakaoMention
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isRunning = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(Keyboardd);
            th.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            th.Start();
            
        }
        
        void Keyboardd()
        {
            int a = 1;
            int c = 0;
            while (isRunning)
            {
                Thread.Sleep(40);
                if((Keyboard.GetKeyStates(Key.OemTilde) & KeyStates.Down) > 0)
                {
                    SendKeys.SendWait("{BACKSPACE}");
                    for(int i=0; i<(int.Parse(human_count.Text)-1); i++)
                    {
                        SendKeys.SendWait("@");
                        Thread.Sleep(300);
                        for(int j=0; j<a; j++)
                        {
                            SendKeys.SendWait("{DOWN}");
                        }
                        SendKeys.SendWait("{ENTER}");
                        Thread.Sleep(100);
                        a++;
                        c++;
                        if (c == 15)
                        { 
                            SendKeys.SendWait("{ENTER}");
                            c = 0;
                        }
                    }
                    SendKeys.SendWait("{ENTER}");
                    Environment.Exit(0);
                }
            }
        }
    }
}
