﻿using Khayaal_SAHM.Main_Form_and_Children_Forms.Bills_Form_and_Mdi_Forms;
using Khayaal_SAHM.Main_Form_and_Children_Forms.Raw_Materials_Form_and_Mdi_Forms;
using System;
using System.Windows.Forms;
namespace Khayaal_SAHM
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            //Application.Run(new Main_Form_and_Children_Forms.Main_Form()); ;

            //Application.Run(new Main_Form_and_Children_Forms.Relations_Form_and_Mdi_Forms.Relations_Form());
            //Application.Run(new Loading_Screen_Form());
            Application.Run(new Bills_Form());
        }

    }
}
