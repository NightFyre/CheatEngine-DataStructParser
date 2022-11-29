using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace CheatEngineDataStructParser
{
    public partial class NightFyreFrameworks : Form
    {
        struct Tools
        {
            public static string Element(string description, string type, string offset)
            {
                /*
                    <Element Offset="48" Vartype="Pointer" Bytesize="8" OffsetHex="00000030" Description="PlayerController" DisplayMethod="unsigned integer">
                    - [0] Offset: 48
                    - [1] Vartype: Pointer
                    - [2] Bytesize: 8
                    - [3] OffsetHex: 00000030
                    - [4] Description: PlayerController
                    - [5] DisplayMethod: unsigned integer
                */
                return $"   {GetType(type, description)};  //  0x{offset}\n";
            }

            public static string GetType(string input, string description)
            {
                //  Some dumped variables contain a '.' 
                description = description.Replace(".", "");

                // Var Type Redefinitons
                //  Pointer             =   "Description"
                //  Double              =   double
                //  Float               =   float
                //  4 Bytes             =   int32_t
                //  byte                =   unsigned char
                switch (input)
                {
                    case "Pointer": return $"{description}* {description}";
                    case "Double": return $"double {description}";
                    case "Float": return $"float {description}";
                    case "4 Bytes": return $"int32_t {description}";
                    case "Byte": return $"unsigned char {description}";
                }
                return $"[ERROR TYPE]{input}";
            }
        }

        public NightFyreFrameworks()
        {
            InitializeComponent();
        }

        private void ParseInput_MenuStripItem_Click(object sender, EventArgs e)
        {
            string input = DataTable_RichTextBox.Text;                                                                  //  Obtain input data
            XmlDocument doc = new XmlDocument();                                                                        //  Create XML Reader Instance
            try { doc.LoadXml(input); }                                                                                 //  Try Loading the Input Data
            catch (XmlException arg) { DataTable_RichTextBox.Text = arg.Message; }                                      //  Catch Error
            if (doc.DocumentElement == null) return;

            // Let the data parsing begin
            try {
                string buf = $"class {ClassNameEntry_MenuStrip.Text} {{\n";
                foreach (XmlNode node in doc.DocumentElement)                                                               //  Loop Offsets
                    buf += Tools.Element(node.Attributes[4].Value, node.Attributes[1].Value, node.Attributes[3].Value);     //  Parse Data 
                DataTable_RichTextBox.Text = buf + "};";                                                                    //  Print data
            }
            catch (NullReferenceException arg) { DataTable_RichTextBox.Text = arg.Message; }
        }

        private void ClearDataTable_MEnuStripItem_Click(object sender, EventArgs e)
        {
            DataTable_RichTextBox.Clear();
            ClassNameEntry_MenuStrip.Text = "<ClassName>";
        }

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
