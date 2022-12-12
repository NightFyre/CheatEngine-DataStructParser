
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml;

namespace CEDataStructParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            switch (Application.Current.MainWindow.WindowState)
            {
                case WindowState.Maximized: Application.Current.MainWindow.WindowState = WindowState.Normal; return;
                case WindowState.Normal: Application.Current.MainWindow.WindowState = WindowState.Maximized; return;
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //---------------------------------------------------------------------------------------------------
        //  PARSING
        //---------------------------------------------------------------------------------------------------

        public static string ParseElement(XmlNode element)
        {
            // EXAMPLE NODE ATTRIBUTES
            /*
                <Element Offset="48" Vartype="Pointer" Bytesize="8" OffsetHex="00000030" Description="PlayerController" DisplayMethod="unsigned integer">
                - [0] Offset: 48
                - [1] Vartype: Pointer
                - [2] Bytesize: 8
                - [3] OffsetHex: 00000030
                - [4] Description: PlayerController
                - [5] DisplayMethod: unsigned integer
            */
            string Type = "";                                               //  [1]
            string Name = element.Attributes[4].Value.Replace(".", "");     //  [4]
            string Offset = $"0x{element.Attributes[3].Value}";               //  [3]            

            // If name contains "[]" , need to remove this from the string and add it onto offset
            if (Name.Contains("["))
            {
                string buf = Name;                                             //  Clone Name
                Name = Name.Remove(Name.IndexOf("["));                   //  Remove " [ DATA ] "
                Offset += $" : {buf.Substring(buf.IndexOf('['))}";         //  Append offset with data
            }

            // Var Type Redefinitons
            /*
                Pointer             =   "Description"
                Double              =   double
                Float               =   float
                4 Bytes             =   int32_t
                byte                =   unsigned char
            */
            switch (element.Attributes[1].Value)
            {
                case "Pointer":
                    switch (element.HasChildNodes)  // Null Pointer Check
                    {
                        case true: Type = $"{element.ChildNodes[0].Attributes[0].Value.Replace(".", "")}*"; break;       //  Return Class Pointer
                        case false: Type = $"{Name}*"; break;                                                            //  Return VariableName       note: this will still be an error when dealing with structs and enums that have not yet been included . . .
                    }
                    break;

                //  Pretty self explanatory what's going on here, if type is not a pointer, we return a static string defined below
                case "Double": Type = "double"; break;
                case "Float": Type = "float"; break;
                case "4 Bytes": Type = "int32_t"; break;
                case "Byte": Type = "unsigned char"; break;
            }

            //  Return Formatted String
            return $"   {Type} {Name}; //   {Offset}\n";
        }

        private void ParseTable_Click(object sender, RoutedEventArgs e)
        {
            string input = new TextRange(DataTable_RichTextBox.Document.ContentStart, DataTable_RichTextBox.Document.ContentEnd).Text;      //  Obtain input data
            XmlDocument doc = new XmlDocument();                                                                                            //  Create XML Reader Instance
            try { doc.LoadXml(input); }                                                                                                     //  Try Loading the Input Data
            catch (XmlException arg) { DataTable_RichTextBox.Document.Blocks.Clear(); DataTable_RichTextBox.AppendText(arg.Message); }      //  Catch Error
            if (doc.DocumentElement == null) return;
            DataTable_RichTextBox.Document.Blocks.Clear();

            // Let the data parsing begin
            string buf = $"class {ClassNameEntry_TextBox.Text} // : < Inherited Class > \n{{\n    //  OFFSETS\npublic:\n";
            foreach (XmlNode node in doc.DocumentElement)                                                           //  Loop Offsets
                buf += ParseElement(node);                                                                          //  Parse Data 
            DataTable_RichTextBox.AppendText( buf + "};");                                                          //  Print data
        }

        private void ClearTable_Click(object sender, RoutedEventArgs e)
        {
            DataTable_RichTextBox.Document.Blocks.Clear();
            ClassNameEntry_TextBox.Text = "<ClassName>";
        }

    }
}
