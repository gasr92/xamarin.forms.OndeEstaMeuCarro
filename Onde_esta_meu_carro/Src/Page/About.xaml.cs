using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Reflection;

namespace Onde_esta_meu_carro.Src.Page
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
            SetDescription();
        }

        private void SetDescription()
        {
            String strDsc;
            var assembly = new AssemblyName(Assembly.GetExecutingAssembly().FullName);
            String strVersion = assembly.Version.ToString();

            strDsc = String.Format("Desenvolvido por Gabriel.\n\nVersão: {0}", strVersion);

            txtDescription.Text = strDsc;
        }

    }
}