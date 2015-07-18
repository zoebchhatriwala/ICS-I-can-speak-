using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ICS.Resources;
using Windows.Phone.Speech.Synthesis;
using System.ComponentModel;


namespace ICS
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            BackKeyPress += OnBackKeyPressed;
            

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        SpeechSynthesizer spk= new SpeechSynthesizer();
        private Windows.Foundation.IAsyncAction task;
    

        private  void About_Click(object sender, RoutedEventArgs e)
        {
           
          if (RE.IsChecked == true)
                {
                   MessageBox.Show("This Is Simple Application Which Converts Text To Speech.\nThis App Is Created by Zoeb Jainuddin Chhatriwala.\nHelp Others Allah Will help You.");
                }
                else if (RF.IsChecked == true)
                {

                    MessageBox.Show("This Is application simple qui convertit le texte en parole.\nCette appli est créé par Zoeb Jainuddin Chhatriwala.");
                }
                else if (RS.IsChecked == true)
                {
                    MessageBox.Show("Esta es una aplicación simple que convierte texto a voz.\nEsta aplicación es creado por Zoeb Jainuddin Chhatriwala.");
                }
                else if (RG.IsChecked == true)
                {
                    MessageBox.Show("This Is einfache Anwendung, die Text Konvertiert To Speech.\nDiese App von Zoeb Jainuddin Chhatriwala erstellt.");
                }
            }
        

        private void speak_Click(object sender, RoutedEventArgs e)
        {
            
            string lang="";
            
           
            if (tb.Text == "")
            {
           if (RE.IsChecked == true)
                {
                    tb.Text = "Enter Something Here";
                }
                else if (RF.IsChecked == true)
                {
                    tb.Text = "Entrez quelque chose ici";

                }
                else if (RS.IsChecked == true)
                {
                    tb.Text = "Escriba algo aquí";
                }
                else if (RG.IsChecked == true)
                {
                    tb.Text = "Geben Sie hier etwas";
                }
            }
            else
            {
                if (RE.IsChecked == true)
                {
                    lang = "en";
                }
                else if (RF.IsChecked == true)
                {
                    lang = "fr";
                    
                }
                else if (RS.IsChecked == true)
                {
                    lang = "es";
                }
                else if (RG.IsChecked == true)
                {
                    lang = "de";
                }
            

                if (Male.IsChecked == true)
                {
                    IEnumerable<VoiceInformation>
                      voices = from voice in InstalledVoices.All
                               where
                               voice.Language.Substring(0,2).Equals(lang)
                               &&
                               voice.Gender.Equals(VoiceGender.Male)
                               select voice;
                    
                 try
                 {
                     spk.SetVoice(voices.ElementAt(0));
                      
                     }catch(System.InvalidOperationException){}
                    catch(System.ArgumentOutOfRangeException){};
                   
                }
                else if(Female.IsChecked == true)
                {
                    IEnumerable<VoiceInformation>
                      voices = from voice in InstalledVoices.All
                               where
                               voice.Language.Substring(0,2).Equals(lang)
                               &&
                               voice.Gender.Equals(VoiceGender.Female)
                               select voice;
                    try
                    {
                        spk.SetVoice(voices.ElementAt(0));

                    }
                    catch (System.InvalidOperationException)
                    {}
                    catch (System.ArgumentOutOfRangeException) { };
                }

                
            task=spk.SpeakTextAsync(tb.Text);
            task.AsTask();
           
        
            
            
           
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Can1.Visibility = System.Windows.Visibility.Collapsed;
            if (RE.IsChecked == true)
            {
                Titleblock.Text = "I Can Speak";
            }
            else if (RF.IsChecked == true)
            {
                Titleblock.Text = "Je peux parler";

            }
            else if (RS.IsChecked == true)
            {
                Titleblock.Text = "HABLO";
            }
            else if (RG.IsChecked == true)
            {
                Titleblock.Text = "Ich kann sprechen";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Can1.Visibility = System.Windows.Visibility.Visible;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

            tb.Text = "";
           
        }

       
        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            RE.IsChecked = true;
            Male.IsChecked = true;
            tb.Text = "Welcome To ICS App";
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
            task.Cancel();
            }
            catch (System.NullReferenceException)
            {}
        }



        void OnBackKeyPressed(object sender, CancelEventArgs e)
        {
            

            if (Can1.Visibility==Visibility.Collapsed)
            {
                // Do not cancel navigation
                return;
            }
            else
            {
                Can1.Visibility = Visibility.Collapsed;
                if (RE.IsChecked == true)
                {
                    Titleblock.Text = "I Can Speak";
                }
                else if (RF.IsChecked == true)
                {
                    Titleblock.Text = "Je peux parler";

                }
                else if (RS.IsChecked == true)
                {
                    Titleblock.Text = "HABLO";
                }
                else if (RG.IsChecked == true)
                {
                    Titleblock.Text = "Ich kann sprechen";
                }
            }

            e.Cancel = true;
            
        }
       
       

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}