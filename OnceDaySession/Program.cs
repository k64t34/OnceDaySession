/*
 * Created by SharpDevelop.
 * User: Andrew
 * Date: 21.10.2015
 * Time: 21:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace OnceDaySession
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		/// 
		static int TimerInterval=2; //Timer in minutes 
		static int CountdownTimerInterval=4; //Timer in minutes 
		[STAThread]
		
		
		private static void Main(string[] args)
		{
			Thread.Sleep(TimerInterval*1000);
			Thread tAlarm1 = new Thread(ShowAlarm1);
    		tAlarm1.Start();            
			
			Thread.Sleep(CountdownTimerInterval*1000);
			Thread tAlarm2 = new Thread(ShowAlarm2);
			tAlarm1.Abort();
    		tAlarm2.Start();   
			Thread.Sleep(1000);

			//ExitWindows.LogOff(true);
			
				
			Thread.Sleep(3000);
			
			tAlarm2.Abort();
		}
		
		static  void ShowAlarm1() 
		{
		ShowAlarm("Ваш сеанс работы будет прекращен через "+CountdownTimerInterval+" сек."); 	
		}
		static void ShowAlarm2() 
		{
		ShowAlarm("Завершение сеанса"); 		
		}
		static void ShowAlarm(String msg) 
		{
		Form f = new Form();
		
		f.StartPosition=FormStartPosition.CenterScreen;
		f.Width=200;
		f.Height=100;
			
		//f.SetBounds(10,10,200,200);		
		f.FormBorderStyle = FormBorderStyle.None;
		
		f.MinimizeBox = false;
		f.MaximizeBox = false;
		f.ShowInTaskbar = false;			
		Label l = new Label();
		l.Text=msg;		
		l.TextAlign=ContentAlignment.MiddleCenter;
		float currentSize;
		currentSize = l.Font.Size;
        currentSize += 4.0F;
        l.Font = new Font(l.Font.Name, currentSize,l.Font.Style, l.Font.Unit);
        l.Dock=DockStyle.Fill;
		f.Controls.Add(l);			
		f.ShowDialog();	
		}
	}
}
