using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using MSWord = Microsoft.Office.Interop.Word;
using System.Reflection;
using Regex = System.Text.RegularExpressions.Regex;

namespace Web_Service_Tut
{
    public partial class Form1 : Form
    {
        Dict.DictServiceSoapClient DictClient;
        Dict.WordDefinition DictServiceDef;

        public Form1() {
            InitializeComponent();
            DictClient = new Dict.DictServiceSoapClient();
            DictServiceDef = new Dict.WordDefinition();
        }

        private void DefineButton_Click(object sender, EventArgs e) { 
            if (WordBox.Text.Length <= 2) return; //TODO: thow and handle exception
            
            // retrieve content from web service
            DictServiceDef = DictClient.DefineInDict("gcide", WordBox.Text.Trim());
            string Def = DictServiceDef.Definitions[0].WordDefinition,
                   Word = DictServiceDef.Word,
                   Type = ParseType(Def),
                   Example = ParseExample(Def);

            // add new definition to list
            DefinitionBox.Text += String.Format( "{0} {1}: {2} \n\t- {3}\n\n", Word, FormatType(Type), FormatDef(Def), FormatExample(Example) );
        }

        private string ParseExample(string Example) {
            do { //traverses & trims the definition until an example pops up
                int start = Example.IndexOf("\n\n"); 
                if (start >0) Example = Example.Remove(0, start +2).TrimStart();
            } while ("0123456789".Contains(Example[0]));

            int end = Example.IndexOfAny(".!?".ToCharArray()); 
            if (end >0) Example = Example.Remove(end +1);

            //TODO: Find a way to generate an example if none given by the web service
            if (Example.IndexOf('{') >= 0) {return "No Example Could Be Generated";}
            else return Example;
        }

        private string ParseType(string Def) {
            // The word type is always before the first period
            Def = Def.Remove(Def.IndexOf('.'));

            string[,] Types = new string[,] { 
                {"interj.","Interjection"}, {"conj.","Conjunction"}, {"prep.","Preposition"}, 
                {"pron.","Pronoun"}, {"adv.","Adverb"}, {"v.","Verb"}, {"n.","Noun"}, {"a.","Adjective"}
            };

            for (int i= 0; i< Types.GetLength(0); i++) {
                if (Def.IndexOf(Types[i,0]) >= 0) return Types[i,1];
            } return "Unknown";
        }

        private string FormatType(string Type) {
            return '(' + Type + ')';
        }
        private string FormatExample(string Example) {
            return '"' + DelWhitespace(Example.Trim()) + '"';
        }
        private string FormatDef(string Def) {
            return DelWhitespace(Trim(Def));
        }

        private string DelWhitespace(string String) {
            return new Regex(@"\W+").Replace(String," ").Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
        }
        private string Trim(string Def) {
            do { //trims front 
                int start = Def.IndexOf("1."); if (start < 0)
                    start = Def.IndexOf('\n'); if (start >= 0)
                    Def = Def.Remove(0, start + 2);
            } while (IsInBracket(Def, 0));

            //trims end
            char[] ends = {'.', '-'};
            int end = Def.IndexOfAny(ends); if (end > 0)
            Def = Def.Remove(end + 1);

            return Def;
        }

        private bool IsInBracket(string String, int index) {
            for (int i= index; i< String.Length; i++) {
                if (String[i] == '[') return false;
                if (String[i] == ']') return true;
            } 
            return false;
        }

        ///////////////////////////////////////////////////////////////////////

        private MSWord.Application WordApp;
        private MSWord.Document WordDoc;

        private void button1_Click(object sender, EventArgs e) {InitializeDoc();}

        private void InitializeDoc() {
            object missing = System.Reflection.Missing.Value;

            WordApp = new MSWord.Application();
            WordDoc = WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            WordApp.Visible = true;
        }

        private void AddDef(string Word, string Type, string Def, string Example)
        {
            Range DocRange = WordDoc.Range(WordDoc.Content.End - 1, WordDoc.Content.End);
            DocRange.set_Style("No Spacing");
            DocRange.Font.Size = 13.5f;
            DocRange.Bold = 0;
            DocRange.Font.Italic = 0;

            //definition spacing
            DocRange.Text = System.Environment.NewLine + System.Environment.NewLine;

            //Word
            DocRange.SetRange(WordDoc.Content.End - 1, WordDoc.Content.End);
            {
                DocRange.Text = Word + ' ';
                DocRange.Font.Bold = -1;
                DocRange.Font.Italic = 0;
            }

            //Type
            DocRange.SetRange(WordDoc.Content.End - 1, WordDoc.Content.End);
            {
                DocRange.Text = Type + ':';
                DocRange.Bold = 0;
                DocRange.Italic = 0;
            }

            //Definition
            DocRange.SetRange(WordDoc.Content.End - 1, WordDoc.Content.End);
            {
                DocRange.Text = Def;
                DocRange.Bold = 0;
                DocRange.Italic = 0;
            }

            //Example
            DocRange.SetRange(WordDoc.Content.End - 1, WordDoc.Content.End);
            {
                DocRange.Text = "\n\t- " + Example;
                DocRange.Bold = 0;
                DocRange.Italic = 0;
                DocRange.Font.Size = 11.0f;
            }
        } // AddDefinition()
    } // Form1
} // Namespace
