using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Resources;
using mshtml;

namespace WPFWebbrowser
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            ObjectForScriptingHelper helper = new ObjectForScriptingHelper(this);
            this.wbMain.ObjectForScripting = helper;
            
 


        }
        
        private void ButtonNavigationStream_Click(object sender, RoutedEventArgs e)
        {
            string appDir = Environment.CurrentDirectory;
            StreamResourceInfo info = Application.GetResourceStream(new Uri("StreamPage.html", UriKind.Relative));
            if (info != null)
                wbMain.NavigateToStream(info.Stream);
            //Uri uri = new Uri(@"pack://application:,,,/StreamPage.htm");
            //Stream source = Application.GetContentStream(uri).Stream;
            // wbMain.NavigateToStream(source);

        }


        private void ButtonNavigationString_Click(object sender, RoutedEventArgs e)
        {
            wbMain.NavigateToString("<html><h2><b>This page comes using String</b></p></h2></html>");

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (wbMain.CanGoBack)
            {
                wbMain.GoBack();
            }
        }

        private void FWButton_Click(object sender, RoutedEventArgs e)
        {
            if (wbMain.CanGoForward)
            {
                wbMain.GoForward();
            }
        }


        private void ButtonNavigateToSite(object sender, RoutedEventArgs e)
        {
            wbMain.Navigate(new Uri("http://www.abhisheksur.com", UriKind.RelativeOrAbsolute));
        }

        private void ButtonNavigateToLocal(object sender, RoutedEventArgs e)
        {
            //Uri uri = new Uri("pack://siteoforigin:,,,/test_ENQUETE/index.html");
            //Stream source = Application.GetContentStream(uri).Stream;
            //wbMain.NavigateToStream(source);
            //wbMain.Navigate(new Uri("pack://siteoforigin:,,,/test_ENQUETE/index.html", UriKind.RelativeOrAbsolute));
            wbMain.Source = new Uri("file://127.0.0.1/C$/Users/hoang/Downloads/Abhi2434_Articles_634061241258134766_WPFWebbrowser/WPFWebbrowser/WPFWebbrowser/bin/Debug/test_ENQUETE/index.html");
            //Uri uri = new Uri(@"pack://application:,,,/test_ENQUETE/index.html", UriKind.Absolute);
            //Stream source = Application.GetResourceStream(uri).Stream;
            //wbMain.NavigateToStream(source);
        }

        private void btnCallDocument_Click(object sender, RoutedEventArgs e)
        {
            //this.wbMain.InvokeScript("WriteFromExternal", new object[] { this.txtMessageFromWPF.Text });
            this.wbMain.InvokeScript("showEnd");
        }
        private void InjectDisableErrorScript()
        {
            //var doc = wbMain.Document as HTMLDocument;
            //if (doc != null)
            //{
            //    //Create the sctipt element
            //    var scriptErrorSuppressed = (IHTMLScriptElement)doc.createElement("SCRIPT");
            //    scriptErrorSuppressed.type = "text/javascript";
            //    scriptErrorSuppressed.text = m_disableScriptError;
            //    //Inject it to the head of the page
            //    IHTMLElementCollection nodes = doc.getElementsByTagName("head");
            //    foreach (IHTMLElement elem in nodes)
            //    {
            //        var head = (HTMLHeadElement)elem;
            //        head.appendChild((IHTMLDOMNode)scriptErrorSuppressed);
            //    }
            //}
        }
        private void wbMain_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string url = e.Uri.AbsoluteUri;
            if (url.Contains("abook-api://"))
            {
                this.wbMain.InvokeScript("showEnd");
            }
        }
    }
}
