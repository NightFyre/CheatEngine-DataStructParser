using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace CheatEngineDataStructParser
{
    public partial class NightFyreFrameworks : Form
    {
        public NightFyreFrameworks()
        {
            InitializeComponent();
        }

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
            string Type     = "";                                               //  [1]
            string Name     = element.Attributes[4].Value.Replace(".", "");     //  [4]
            string Offset   = $"0x{element.Attributes[3].Value}";               //  [3]            

            // If name contains "[]" , need to remove this from the string and add it onto offset
            if (Name.Contains("["))
            {
                string buf  = Name;                                             //  Clone Name
                Name        = Name.Remove(Name.IndexOf("["));                   //  Remove " [ DATA ] "
                Offset      += $" : {buf.Substring(buf.IndexOf('['))}";         //  Append offset with data
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
                case "Double"   : Type = "double";          break;
                case "Float"    : Type = "float";           break;
                case "4 Bytes"  : Type = "int32_t";         break;
                case "Byte"     : Type = "unsigned char";   break;
            }
            
            //  Return Formatted String
            return $"   {Type} {Name}; //   {Offset}\n";
        }

        private void ParseInput_MenuStripItem_Click(object sender, EventArgs e)
        {
            string input = DataTable_RichTextBox.Text;                                                              //  Obtain input data
            XmlDocument doc = new XmlDocument();                                                                    //  Create XML Reader Instance
            try { doc.LoadXml(input); }                                                                             //  Try Loading the Input Data
            catch (XmlException arg) { DataTable_RichTextBox.Text = arg.Message; }                                  //  Catch Error
            if (doc.DocumentElement == null) return;

            // Let the data parsing begin
            string buf = $"class {ClassNameEntry_MenuStrip.Text} // : < Inherited Class > \n{{\n    //  OFFSETS\npublic:\n";
            foreach (XmlNode node in doc.DocumentElement)                                                           //  Loop Offsets
                buf += ParseElement(node);                                                                          //  Parse Data 
            DataTable_RichTextBox.Text = buf + "};";                                                                //  Print data
        }

        private void ClearDataTable_MEnuStripItem_Click(object sender, EventArgs e)
        {
            DataTable_RichTextBox.Clear();
            ClassNameEntry_MenuStrip.Text = "<ClassName>";
        }


        //-----------------------------------------------------------------------------------
        //									STYLE PROPERTIES
        //-----------------------------------------------------------------------------------
        private void ClassNameEntry_MenuStrip_Enter(object sender, EventArgs e)
        {
            if (ClassNameEntry_MenuStrip.Text == "<ClassName>")
                ClassNameEntry_MenuStrip.Text = "";
            ClassNameEntry_MenuStrip.ForeColor = Color.Black;
        }

        private void ClassNameEntry_MenuStrip_Leave(object sender, EventArgs e)
        {
            if (ClassNameEntry_MenuStrip.Text == "")
                ClassNameEntry_MenuStrip.Text = "<ClassName>";
            ClassNameEntry_MenuStrip.ForeColor = Color.Gray;
        }
    }
}
