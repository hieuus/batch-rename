using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Data;
using Path = System.IO.Path;

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataTable DataTable { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        //Button: Select/Unselect
        private void selectButton_Loaded(object sender, RoutedEventArgs e)
        {
            bool isAddCounterChecked = (bool)addCounterCheckbox.IsChecked;
            bool isRemoveSpaceChecked = (bool)removeSpaceBeginEnding.IsChecked;
            bool isReplaceCheck = (bool)replaceCharacter.IsChecked;
            bool isAddPrefixChecked = (bool)addPrefix.IsChecked;
            bool isAddSubfixChecked = (bool)addSubfix.IsChecked;
            bool isConvertLowercaseChecked = (bool)converLowercase.IsChecked;
            bool isConverPascalCaseChecked = (bool)convertPascalCase.IsChecked;

            if (isAddCounterChecked || isRemoveSpaceChecked || isReplaceCheck
                || isAddPrefixChecked || isAddSubfixChecked || isConvertLowercaseChecked
                || isConverPascalCaseChecked)
            {
                selectButton_Text.Text = "Unselect all";
                var bitmap = new BitmapImage(new Uri("../Icons/remove.png", UriKind.Relative));
                selectButton_Img.Source = bitmap;
            }
            else
            {
                selectButton_Text.Text = "Select all";
                var bitmap = new BitmapImage(new Uri("../Icons/check.png", UriKind.Relative));
                selectButton_Img.Source = bitmap;
            }
        }
        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectButton_Text.Text == "Unselect all")
            {
                addCounterCheckbox.IsChecked = false;
                removeSpaceBeginEnding.IsChecked = false;
                replaceCharacter.IsChecked = false;
                addPrefix.IsChecked = false;
                addSubfix.IsChecked = false;
                converLowercase.IsChecked = false;
                convertPascalCase.IsChecked = false;

                selectButton_Text.Text = "Select all";
                var bitmap = new BitmapImage(new Uri("../Icons/check.png", UriKind.Relative));
                selectButton_Img.Source = bitmap;
            }
            else
            {
                addCounterCheckbox.IsChecked = true;
                removeSpaceBeginEnding.IsChecked = true;
                replaceCharacter.IsChecked = true;
                addPrefix.IsChecked = true;
                addSubfix.IsChecked = true;
                converLowercase.IsChecked = true;
                convertPascalCase.IsChecked = true;

                selectButton_Text.Text = "Unselect all";
                var bitmap = new BitmapImage(new Uri("../Icons/remove.png", UriKind.Relative));
                selectButton_Img.Source = bitmap;
            }

        }

        //Rule: Add Counter
        private void addCounter_Checked(object sender, RoutedEventArgs e)
        {
             paraAddCounter.Visibility = Visibility.Visible;
        }

        private void addCounter_UnChecked(object sender, RoutedEventArgs e)
        {
            paraAddCounter.Visibility = Visibility.Collapsed;
        }

        private void addCounter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool isAddCounterCheckboxChecked = (bool)addCounterCheckbox.IsChecked;
            if (isAddCounterCheckboxChecked)
            {
                addCounterCheckbox.IsChecked = false;
                paraAddCounter.Visibility = Visibility.Collapsed;
            }
            else
            {
                addCounterCheckbox.IsChecked = true;
                paraAddCounter.Visibility = Visibility.Visible;
            }
        }

        //Rule: Remove Space Begin Ending
        private void removeSpaceBeginEnding_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool isRemoveSpaceBeginEndingChecked = (bool)removeSpaceBeginEnding.IsChecked;
            if (isRemoveSpaceBeginEndingChecked)
                removeSpaceBeginEnding.IsChecked = false;
            else removeSpaceBeginEnding.IsChecked = true;

        }

        //Rule: Replace Character
        private void replaceCharacter_Checked(object sender, RoutedEventArgs e)
        {
            paraReplaceCharacter.Visibility = Visibility.Visible;
        }

        private void replaceCharacter_UnChecked(object sender, RoutedEventArgs e)
        {
            paraReplaceCharacter.Visibility = Visibility.Collapsed;
        }
        private void replaceCharacter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool isReplaceCharacterChecked = (bool)replaceCharacter.IsChecked;
            if (isReplaceCharacterChecked)
            {
                replaceCharacter.IsChecked = false;
                paraReplaceCharacter.Visibility = Visibility.Collapsed;
            }
            else
            {
                replaceCharacter.IsChecked = true;
                paraReplaceCharacter.Visibility = Visibility.Visible;
            }
        }

        //Rule: Add Prefix
        private void addPrefix_Checked(object sender, RoutedEventArgs e)
        {
            paraAddPrefix.Visibility = Visibility.Visible;
        }
        private void addPrefix_UnChecked(object sender, RoutedEventArgs e)
        {
            paraAddPrefix.Visibility = Visibility.Collapsed;
        }

        private void addPrefix_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool isAddPrefixChecked = (bool)addPrefix.IsChecked;
            if (isAddPrefixChecked)
            {
                addPrefix.IsChecked = false;
                paraAddPrefix.Visibility = Visibility.Collapsed;
            }
            else
            {
                addPrefix.IsChecked = true;
                paraAddPrefix.Visibility = Visibility.Visible;
            }
        }

        //Rule: Add Prefix
        private void addSubfix_Checked(object sender, RoutedEventArgs e)
        {
            paraAddSubfix.Visibility = Visibility.Visible;
        }
        private void addSubfix_UnChecked(object sender, RoutedEventArgs e)
        {
            paraAddSubfix.Visibility = Visibility.Collapsed;
        }

        private void addSubfix_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool isAddSubfixChecked = (bool)addSubfix.IsChecked;
            if (isAddSubfixChecked)
            {
                addSubfix.IsChecked = false;
                paraAddSubfix.Visibility = Visibility.Collapsed;
            }
            else
            {
                addSubfix.IsChecked = true;
                paraAddSubfix.Visibility = Visibility.Visible;
            }
        }

        //Rule: Convert Lowercase
        private void convertLowercase_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool isConverLowercaseChecked = (bool)converLowercase.IsChecked;
            if (isConverLowercaseChecked)
                converLowercase.IsChecked = false;
            else converLowercase.IsChecked = true;
        }
        //Rule: Convert PascalCase
        private void convertPascalCase_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool isConvertPascalCase = (bool)convertPascalCase.IsChecked;
            if (isConvertPascalCase)
                convertPascalCase.IsChecked = false;
            else convertPascalCase.IsChecked = true;
        }

        private void saveToChooseLocation_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            DataTable dataTable = new DataTable(); 
            dataTable.Columns.Add("STT");
            dataTable.Columns.Add("File Name");
            //dataTable.Columns.Add("New Name");

            var num = 0;

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    num++;

                    FileInfo file = new FileInfo(filename);

                    dataTable.Rows.Add(num, file.Name);
                }
            }
            dataGridRename.ItemsSource = dataTable.DefaultView;


        }

       
    }
}
