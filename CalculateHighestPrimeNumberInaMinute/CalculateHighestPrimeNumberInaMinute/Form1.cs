using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using CalculateIsPrimeLib;

namespace CalculateHighestPrimeNumberInaMinute
{

    public partial class HighestPrimeNumber : Form
    {

       //The program is intended to run for 60 seconds or 1 minute
        static int timer = 60;
       
        //setting the initial highest prime number to 2
       // static int highest_prime_number = 2;

        //static int counter = 3;
        //List containing the Prime Numbers.
        static List<int> primeArray = new List<int>();
        public HighestPrimeNumber()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region UI events
        private void btnStart_Click(object sender, EventArgs e)
        {

            //Prime number 2 is added to the list.
           primeArray.Add(2);

           //Check to see if the worker is busy, if not start the worker and disbale the start button.
           if(!backgroundWorker1.IsBusy)
           {
               btnStart.Enabled = false;
               backgroundWorker1.RunWorkerAsync();
           }
           
         

        }
        #endregion

        #region background workerevents and helpers
       
        /// <summary>
        /// Handles the DoWork event of the backgroundWorker control
        /// This method loops through calculating a Prime Number until StopWatch elapsed time is 60 seconds or 1 minute.
        /// The counter is Initialized to 3 and incremented by 2.
        /// 2 is the only even prime number, so to avoid even number I have considered to increment by 2.
        /// Status updates will be sent every time a number is checked and timer gets updated on every tick (0-60). 
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e"><System.ComponentModel.DoWorkEventArgs> instance containing the event data</param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
               
            Stopwatch sw = new Stopwatch();
            sw.Start();
            CalculateIsPrime cs = new CalculateIsPrime();
            

            for (int counter=3;sw.Elapsed.TotalSeconds < timer; counter+=2)
            {
               int retVal =   cs.calculatePrime(counter);
                if(retVal!=0)
                {
                    if (!primeArray.Contains(retVal))
                        primeArray.Add(retVal);
                }
                backgroundWorker1.ReportProgress((int)sw.Elapsed.Seconds, primeArray[primeArray.Count - 1]);

            }
            
            e.Result = primeArray[primeArray.Count -1];
            
            sw.Stop();
        }

        /// <summary>
        /// Handles ProgressChanged event of the backgroundWorker control
        /// This method will be called using the UI thread that created the component
        /// This method updates the two labels: timer and current highest prime number
        /// </summary>
        /// <param name="sender">The source to the event</param>
        /// <param name="e"><System.ComponentModel.ProgressChangedEventArgs> instance containing the event data</param>

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
            if(e.UserState!=null)
            {
                lblCalculatedNumber.Text = "Highest Prime Number: "+ e.UserState.ToString();
            }
            lblTimeInSec.Text = "Time in Seconds: " + e.ProgressPercentage.ToString();
        }

        /// <summary>
        /// Handles RunWorkerCompleted event of the backgroundWorker control.
        /// This method will be called using the UI thread that created the component.
        /// Enables start button on completion
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e"><System.ComponentModel.RunWorkerCompletedEventArgs> instance containing the event data</param>

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error!=null)
            {
                lblCalculatedNumber.Text = e.Error.Message;
            }
            else{
                lblCalculatedNumber.Text = "Highest Prime Number: " + e.Result.ToString();
            }
            
            //Enable the Start Button
            this.btnStart.Enabled = true;
            //reset the array
            primeArray.Clear();
        }
        #endregion


    }
}
