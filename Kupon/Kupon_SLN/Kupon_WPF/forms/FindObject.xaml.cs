using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
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


using Microsoft.CSharp.RuntimeBinder;
using Button = System.Windows.Controls.Button;
using CheckBox = System.Windows.Controls.CheckBox;
using ComboBox = System.Windows.Controls.ComboBox;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using KeyEventHandler = System.Windows.Input.KeyEventHandler;
using Orientation = System.Windows.Controls.Orientation;
using TextBox = System.Windows.Controls.TextBox;

namespace Kupon_WPF
{
    public partial class FindObject : Window
    {
        private List<CheckBox> checkBoxs;
        private List<UIElement> allBoxs;
        // private dataList<IBase> currenList;
        public FindObject()
        {
            InitializeComponent();
            checkBoxs = new List<CheckBox>();
            allBoxs = new List<UIElement>();
            if (MainWindow.UserStat == "administrator")
            { }
            else if (MainWindow.UserStat == "doctor")
            {
                IBaseChooser.Items.RemoveAt(2);
            }
            else if (MainWindow.UserStat == "patient")
            {
                IBaseChooser.Items.RemoveAt(1);
                IBaseChooser.Items.RemoveAt(1);

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
    /*
    /// <summary>
    /// Interaction logic for FindObject.xaml
    /// </summary>
    public partial class FindObject : Window
    {
        private List<CheckBox> checkBoxs;
        private List<UIElement> allBoxs;
        private dataList<IBase> currenList;
        public FindObject()
        {
            InitializeComponent();
            checkBoxs = new List<CheckBox>();
            allBoxs = new List<UIElement>();
            if (MainWindow.UserStat=="administrator")
            {}else if (MainWindow.UserStat=="doctor")
            {
                IBaseChooser.Items.RemoveAt(2);
            }
            else if (MainWindow.UserStat == "patient")
            {
                IBaseChooser.Items.RemoveAt(1);
                IBaseChooser.Items.RemoveAt(1);

            }
            
        }

        private void UserBoxesAdd()
        {
            //adds data for both doctor and user
            RoutedEventHandler eve = CheckBox_Checked;
            CheckBox check = checkBoxInit("ID");
            comboPanel.Children.Add(check);
            comboPanel.Children.Add(checkBoxInit("First name"));
            comboPanel.Children.Add(checkBoxInit("Last name"));
            comboPanel.Children.Add(checkBoxInit("Gender"));
            textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
            textPanel.Children.Add(TextBoxInit(TextBox_Name, 30));
            textPanel.Children.Add(TextBoxInit(TextBox_Name, 30));
            ComboBox box = new ComboBox();
            box.Items.Add("male");
            box.Items.Add("female");
            box.SelectedIndex = 0;
            box.Visibility = Visibility.Hidden;
            allBoxs.Add(box);
            textPanel.Children.Add(box);
        }

        private void board_Clean()
        {
            if (allBoxs != null)
            {
                foreach (var t in allBoxs)
                {
                    textPanel.Children.Remove(t);
                }
                allBoxs.Clear();
            }
            if (checkBoxs != null)
            {
                foreach (var box in checkBoxs)
                {
                    comboPanel.Children.Remove(box);
                }
                checkBoxs.Clear();
            }
            SearchPanel.Children.Clear();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox origin = (CheckBox) sender;
            int i = checkBoxs.IndexOf(origin);
            allBoxs[i].Visibility = Visibility.Visible;
        }

        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox origin = (CheckBox) sender;
            int i = checkBoxs.IndexOf(origin);
            allBoxs[i].Visibility = Visibility.Hidden;
        }

        private void TextBox_NumberOnly(object sender, KeyEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox) sender;
            }
            else return;
            int count = 0;
            if (t.Text.Length > 0 && !commonMethods.isNumber(t.Text))
            {
                foreach (char a in t.Text)
                {
                    string aString = a.ToString();
                    if (!commonMethods.isNumber(aString))
                    {
                        string temp = "";
                        if (count < t.Text.Length) temp = t.Text.Substring(count + 1);
                        t.Text = t.Text.Substring(0, count);
                        t.Text = t.Text + temp;
                        TextBox_NumberOnly(t, e);
                        return;
                    }
                    count = count + 1;
                }
            }
            return;
        }

        private void TextBox_Name(object sender, KeyEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox) sender;
            }
            else return;
            int count = 0;
            if (t.Text.Length > 0 && !commonMethods.validNameCheck(t.Text))
            {
                foreach (char a in t.Text)
                {
                    string aString = a.ToString();
                    if (!commonMethods.validNameCheck(aString))
                    {
                        string temp = "";
                        if (count < t.Text.Length) temp = t.Text.Substring(count + 1);
                        t.Text = t.Text.Substring(0, count);
                        t.Text = t.Text + temp;
                        TextBox_Name(t, e);
                        return;
                    }
                    count = count + 1;
                }
            }
            return;
        }

        private void TextBox_Note(object sender, KeyEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox) sender;
            }
            else return;
            int count = 0;
            if (t.Text.Length > 0 && !commonMethods.validNoteCheck(t.Text))
            {
                foreach (char a in t.Text)
                {
                    string aString = a.ToString();
                    if (!commonMethods.validNoteCheck(aString))
                    {
                        string temp = "";
                        if (count < t.Text.Length) temp = t.Text.Substring(count + 1);
                        t.Text = t.Text.Substring(0, count);
                        t.Text = t.Text + temp;
                        TextBox_Note(t, e);
                        return;
                    }
                    count = count + 1;
                }
            }
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            board_Clean();
            IBaseChooser.SelectedIndex = 0;
            choicePanel.Visibility = Visibility.Hidden;
            SearchButton.Visibility = Visibility.Hidden;
            clearButton.Visibility = Visibility.Hidden;
        }

        private TextBox TextBoxInit(KeyEventHandler e, int maxLength)
        {
            TextBox box = new TextBox();
            box.KeyUp += e;
            box.MaxLength = maxLength;
            box.Visibility = System.Windows.Visibility.Hidden;
            allBoxs.Add(box);
            return box;
    
        }

        private CheckBox checkBoxInit(string text)
        {
            CheckBox box = new CheckBox();
            box.Height = 23;
            box.Checked += CheckBox_Checked;
            box.Unchecked += CheckBox_UnChecked;
            box.Content = text;
            checkBoxs.Add(box);

            return box;
        }

        private void ComboBoxItem_SelectedPatient(object sender, RoutedEventArgs e)
        {
            board_Clean();
            choicePanel.Visibility = Visibility.Visible;
            SearchButton.Visibility = Visibility.Visible;
            clearButton.Visibility = Visibility.Visible;
            UserBoxesAdd();
            comboPanel.Children.Add(checkBoxInit("Age"));
            int[] length = {3, 3};
            textPanel.Children.Add(multiple_ButtonInit(2, length));
            if (MainWindow.UserStat == "administrator")
            {
                comboPanel.Children.Add(checkBoxInit("Main doctor"));
                textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
            }
            comboPanel.Children.Add(checkBoxInit("Date of birth occurs"));
            textPanel.Children.Add(datePanelInit());
            comboPanel.Children.Add(checkBoxInit("to"));
            textPanel.Children.Add(datePanelInit());
        }

        private StackPanel datePanelInit()
        {
            int[] a = {2, 2, 4};
            StackPanel panel = multiple_ButtonInit(3, a);
            ((TextBox) panel.Children[0]).Text = "dd";
            ((TextBox) panel.Children[1]).Text = "mm";
            ((TextBox) panel.Children[2]).Text = "yyyy";
            return panel;
        }

        private StackPanel multiple_ButtonInit(int buttonNum, int[] maxLength)
        {
            StackPanel panel = new StackPanel();
            for (int i = 0; i < buttonNum; i++)
            {
                TextBox box = TextBoxInit(TextBox_NumberOnly, maxLength[i]);
                panel.Children.Add(box);
                box.Visibility = Visibility.Visible;
                box.Width = comboPanel.Width/buttonNum - 3;
                box.Margin = new Thickness(0, 0, 3, 0);
                allBoxs.RemoveAt(allBoxs.Count - 1);
            }
            panel.Visibility = Visibility.Hidden;
            ((TextBox) panel.Children[panel.Children.Count - 1]).Margin = new Thickness(0, 0, 0, 0);
            ((TextBox) panel.Children[panel.Children.Count - 1]).Width = comboPanel.Width/buttonNum;
            allBoxs.Add(panel);
            panel.Orientation = Orientation.Horizontal;
            return panel;
        }

        private void ComboBoxItem_SelectedDoctor(object sender, RoutedEventArgs e)
        {
            board_Clean();
            choicePanel.Visibility = Visibility.Visible;
            SearchButton.Visibility = Visibility.Visible;
            clearButton.Visibility = Visibility.Visible;
            UserBoxesAdd();
            comboPanel.Children.Add(checkBoxInit("Salary"));
            textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
        }

        private void ComboBoxItem_SelectedTreatment(object sender, RoutedEventArgs e)
        {
            board_Clean();
            choicePanel.Visibility = Visibility.Visible;
            SearchButton.Visibility = Visibility.Visible;
            clearButton.Visibility = Visibility.Visible;
            comboPanel.Children.Add(checkBoxInit("ID"));
            textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
            if (MainWindow.UserStat != "patient")
            {
                comboPanel.Children.Add(checkBoxInit("Patient's ID"));
                textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
            }
            comboPanel.Children.Add(checkBoxInit("Visit ID"));
            textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
            comboPanel.Children.Add(checkBoxInit("Created by doctor"));
            textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
            comboPanel.Children.Add(checkBoxInit("Prognosis"));
            textPanel.Children.Add(TextBoxInit(TextBox_Note, 9));
            comboPanel.Children.Add(checkBoxInit("Prescriptions"));
            textPanel.Children.Add(TextBoxInit(TextBox_Note, 9));
            comboPanel.Children.Add(checkBoxInit("Treatment start"));
            textPanel.Children.Add(datePanelInit());
            comboPanel.Children.Add(checkBoxInit("to"));
            textPanel.Children.Add(datePanelInit());
            comboPanel.Children.Add(checkBoxInit("Treatment end"));
            textPanel.Children.Add(datePanelInit());
            comboPanel.Children.Add(checkBoxInit("to"));
            textPanel.Children.Add(datePanelInit());
        }

        private void ComboBoxItem_SelectedVisit(object sender, RoutedEventArgs e)
        {
            board_Clean();
            choicePanel.Visibility = Visibility.Visible;
            SearchButton.Visibility = Visibility.Visible;
            clearButton.Visibility = Visibility.Visible;
            comboPanel.Children.Add(checkBoxInit("ID"));
            textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
            if (MainWindow.UserStat != "patient")
            {
                comboPanel.Children.Add(checkBoxInit("Patient's ID"));
                textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
            }
            if (MainWindow.UserStat != "doctor")
            {
                comboPanel.Children.Add(checkBoxInit("Assigned doctor"));
                textPanel.Children.Add(TextBoxInit(TextBox_NumberOnly, 9));
            }
            comboPanel.Children.Add(checkBoxInit("Doctor's notes"));
            textPanel.Children.Add(TextBoxInit(TextBox_Note, 9));
            comboPanel.Children.Add(checkBoxInit("Visit's date"));
            textPanel.Children.Add(datePanelInit());
            comboPanel.Children.Add(checkBoxInit("to"));
            textPanel.Children.Add(datePanelInit());

        }

        private void IBaseChooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {
            //gets a list of the required objects, put them in stack panels and enter them into SearchPanel
            SearchPanel.Children.Clear();
            string type = IBaseChooser.Text;
            if (type == "Patient") type = "patient";
            else if (type == "Doctor") type = "doctor";
            else if (type == "Treatment") type = "treatment";
            else if (type == "Visit") type = "visit";
            var list = Search(type);
            StackPanel[] panels = labelPanel(type, list);
            StackPanel buttonEditPanel=new StackPanel();
            StackPanel buttonDeletePanel=new StackPanel();
            buttonEditPanel.Children.Add(textedBlock("", Brushes.White));
            buttonDeletePanel.Children.Add(textedBlock("", Brushes.White));
            if (MainWindow.UserStat!="patient")for (int i = 0; i < list.capacity(); i++)
            {
                buttonEditPanel.Children.Add(toEditWindowButton(i));
                buttonDeletePanel.Children.Add(deleteButton(i));
            }


            for (int i = 0; i < panels.Length; i++)
            {
                if(panels[i].Children.Count>0) SearchPanel.Children.Add(panels[i]);
            }
            SearchPanel.Children.Add(buttonEditPanel);
            SearchPanel.Children.Add(buttonDeletePanel);
            currenList = list;
        }

        private Button deleteButton(int index)
        {
            Button but = new Button();
            but.Name = "del" + index.ToString();
            but.Content = "Delete";
            but.Click += deleteButtonClick;
            but.Height = 23;
            return but;
        }

        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;
            string s = but.Name;
            s = s.Substring(3);
            Delete del=new Delete();
            IBase obj;
            int sVal = Convert.ToInt32(s);
            obj = currenList.getData(sVal);

            if (del.delete(obj))
            {

                for (int i = 0; i < SearchPanel.Children.Count ; i++) 
                {
                    ((StackPanel)SearchPanel.Children[i]).Children.RemoveAt(sVal+1);
                }
                Button_ClickSearch(this,e);
            }
        }

        private dataList<IBase> Search(string type)
        {
            string[] search = new string[0];
            Find find = new Find();
            //return find.findByParameter("doctor", "gender", "female");
            for (int i = 0; i < checkBoxs.Count; i++)
            {
                var box = checkBoxs[i];
                if (box.IsChecked == true)
                {
                    string content = (String) box.Content;
                    if (content == "ID") content = "ID";
                        //visit
                    else if (content == "Patient's ID") content = "patientID";
                    else if (content == "Assigned doctor") content = "doctorID";
                    else if (content == "Doctor's notes") content = "doctorNotes";
                    else if (content == "Visit's date") content = "visitDate";
                        //treatment
                    else if (content == "Treatment start") content = "dateOfStart";
                    else if (content == "Treatment end") content = "dateOfEnd";
                    else if (content == "Patient's ID") content = "patientID";
                    else if (content == "Created by doctor") content = "doctorID";
                    else if (content == "Visit ID") content = "visitID";
                    else if (content == "Prognosis") content = "prognosis";
                    else if (content == "Prescriptions") content = "prescriptions";
                        //user
                    else if (content == "First name") content = "firstName";
                    else if (content == "Last name") content = "lastName";
                    else if (content == "Gender") content = "gender";
                        //patient
                    else if (content == "Date of birth occurs") content = "birthDate";
                    else if (content == "Main doctor") content = "mainDoctor";
                    else if (content == "Age") content = "age";
                        //doctor
                    else if (content == "Salary") content = "salary";


                    //adds the correct string
                    if (content == "age")
                    {
                        var pan = allBoxs[i];
                        StackPanel pane = (StackPanel)pan;
                        string first = ((TextBox)pane.Children[0]).Text;
                        string second = ((TextBox)pane.Children[1]).Text;
                        if (first != "" & second != "")
                            search=find.addStringAgeRange(search, Convert.ToInt32(first), Convert.ToInt32(second));
                        else if (first != "") search=find.addStringAge(search, Convert.ToInt32(first));
                    }
                    else if (content.Contains("Date"))
                    {

                        var pan = allBoxs[i];
                        StackPanel pane = (StackPanel) pan;
                        
                        //checks if the date has been updated correctly
                        string d = ((TextBox) pane.Children[0]).Text;
                        string m = ((TextBox)pane.Children[1]).Text;
                        string y = ((TextBox)pane.Children[2]).Text;
                        if (d != "" & m != "" & y != "" & d != "dd" & m != "mm" & y != "yyyy")
                        {
                            DateTime dateStart = new DateTime(Convert.ToInt32(pane.Children[0]),
                                Convert.ToInt32(pane.Children[1]),
                                Convert.ToInt32(pane.Children[2]));
                            i = i + 1;
                            pan = allBoxs[i];
                            pane = (StackPanel)pan;
                            DateTime dateEnd;
                            if (checkBoxs[i].IsChecked == true)
                            {
                                dateEnd = new DateTime(Convert.ToInt32(pane.Children[0]),
                                    Convert.ToInt32(pane.Children[1]),
                                    Convert.ToInt32(pane.Children[2]));
                            }
                            else
                            {
                                dateEnd = dateStart;
                            }
                            search=find.addStringDate(search, content, dateStart, dateEnd);
                        }
                        else i = i + 1;
                    }
                    else if (content=="gender")
                    {
                        search=find.addString(search, content, ((ComboBox)allBoxs[i]).Text);
                    }

                    else
                    {
                        search=find.addString(search, content, ((TextBox) allBoxs[i]).Text);
                    }
                }

            }
            //limits the searchs for patients and doctors
            if (MainWindow.UserStat == "doctor" && type == "patient") search=find.addStringNoLike(search, "mainDoctor", MainWindow.UserID.ToString());
            if (MainWindow.UserStat=="patient" && (type=="visit" || type=="treatment")) search=find.addStringNoLike(search, "patientID", MainWindow.UserID.ToString());
            
            dataList<IBase> list = find.multiParameterSearch(type, search); //creates the list from the database
            
            if (MainWindow.UserStat == "doctor" && (type == "visit" || type == "treatment")) //filters the list
                list = doctorListFilter(list, type);

            return list;
        }

        private dataList<IBase> doctorListFilter(dataList<IBase> list, string type)
        {
            Find find=new Find();
            dataList<IBase> newList;
            int i = list.capacity()-1;
            while (i>=0)
            {
                var obj = list.getData(i);
                if (type == "visit") newList = find.findNameOrID("patient", ((visit) obj).PatientID.ToString());
                else newList = find.findNameOrID("patient", ((treatment) obj).PatientID.ToString());
                patient pat = (patient) (newList.getData(newList.capacity() - 1));
                if (pat!=null && pat.MainDoctor != MainWindow.UserID) list.delData(i);
                i = i - 1;
            }
            return list;
        }

        private TextBlock textedBlock(string text, SolidColorBrush color)
        {
            TextBlock box=new TextBlock();
            box.Text = text;
            box.Background = color;
            box.Height = 23;
            return box;
        }

        private StackPanel[] labelPanel(string dataType, dataList<IBase> list)
        {
            SolidColorBrush color = Brushes.Wheat;
            StackPanel[] panels= new StackPanel[0];

                if (dataType == "patient")
                {
                    //initialization of panels, first line

                    panels=new StackPanel[7];
                    for (int i = 0; i < panels.Length; i++)
                    {
                        panels[i]=new StackPanel();
                        panels[i].Margin=new Thickness(5,2,5,2);
                    }
                    panels[0].Children.Add(textedBlock("ID", Brushes.Wheat));
                    panels[1].Children.Add(textedBlock("First Name", Brushes.Wheat));
                    panels[2].Children.Add(textedBlock("Last Name", Brushes.Wheat));
                    panels[3].Children.Add(textedBlock("Gender", Brushes.Wheat));
                    if (MainWindow.UserStat != "doctor")
                    {
                        panels[4].Children.Add(textedBlock("Main doctor", Brushes.Wheat));
                    }
                    panels[5].Children.Add(textedBlock("Age", Brushes.Wheat));
                    panels[6].Children.Add(textedBlock("Date of birth", Brushes.Wheat));
                    //interior
                    for (int i = 0; i < list.capacity(); i++)
                    {
                        if (i%2 == 0) color = Brushes.WhiteSmoke;
                        else color = Brushes.Gainsboro;
                        patient pat = (patient)list.getData(i);
                        panels[0].Children.Add(textedBlock(pat.getIDString(),color));
                        panels[1].Children.Add(textedBlock(pat.FirstName, color));
                        panels[2].Children.Add(textedBlock(pat.LastName, color));
                        panels[3].Children.Add(textedBlock(pat.Gender, color));
                        if (MainWindow.UserStat!="doctor") panels[4].Children.Add(textedBlock(pat.MainDoctor.ToString(), color));
                        panels[5].Children.Add(textedBlock(pat.age().ToString(), color));
                        panels[6].Children.Add(textedBlock(pat.DateBirth.ToShortDateString(), color));
                    }
                }
                else if (dataType == "doctor")
                {
                    panels=new StackPanel[5];
                    if (list != null)  for (int i = 0; i < panels.Length; i++)
                    {
                        panels[i] = new StackPanel();
                        panels[i].Margin = new Thickness(5, 2, 5, 2);

                    }
                    panels[0].Children.Add(textedBlock("ID", color));
                    panels[1].Children.Add(textedBlock("First Name", color));
                    panels[2].Children.Add(textedBlock("Last name", color));
                    panels[3].Children.Add(textedBlock("Gender", color));
                    panels[4].Children.Add(textedBlock("Salary", color));
                    for (int i = 0; i < list.capacity(); i++)
                    {
                        if (i % 2 == 0) color = Brushes.WhiteSmoke;
                        else color = Brushes.Gainsboro;
                        doctor doc = (doctor)list.getData(i);
                        panels[0].Children.Add(textedBlock(doc.getIDString(), color));
                        panels[1].Children.Add(textedBlock(doc.FirstName, color));
                        panels[2].Children.Add(textedBlock(doc.LastName, color));
                        panels[3].Children.Add(textedBlock(doc.Gender, color));
                        panels[4].Children.Add(textedBlock(doc.Salary.ToString(), color));   
                    }
                }
                else if (dataType == "visit")
                {
                    panels = new StackPanel[5];
                    if (list != null) for (int i = 0; i < panels.Length; i++)
                    {
                        panels[i] = new StackPanel();
                        panels[i].Margin = new Thickness(5, 2, 5, 2);

                    }
                    panels[0].Children.Add(textedBlock("ID", color));
                    panels[1].Children.Add(textedBlock("Date of visit", color));
                    panels[2].Children.Add(textedBlock("Assigned doctor", color));
                    if (MainWindow.UserStat!="patient") panels[3].Children.Add(textedBlock("Patient's ID", color));
                    panels[4].Children.Add(textedBlock("Doctor's notes", color));
                    for (int i = 0; i < list.capacity(); i++)
                    {
                        if (i % 2 == 0) color = Brushes.WhiteSmoke;
                        else color = Brushes.Gainsboro;
                        visit vis = (visit)list.getData(i);
                        panels[0].Children.Add(textedBlock(vis.ID.ToString(), color));
                        panels[1].Children.Add(textedBlock(vis.Date.ToString(), color));
                        panels[2].Children.Add(textedBlock(vis.AssignedDoctor.ToString(), color));
                        if (MainWindow.UserStat != "patient") panels[3].Children.Add(textedBlock(vis.PatientID.ToString(), color));
                        panels[4].Children.Add(textedBlock(vis.DoctorNotes, color));
                    }
                }
                else if (dataType == "treatment")
                {
                    panels = new StackPanel[8];
                    if (list != null) for (int i = 0; i < panels.Length; i++)
                    {
                        panels[i] = new StackPanel();
                        panels[i].Margin = new Thickness(5, 2, 5, 2);

                    }
                    panels[0].Children.Add(textedBlock("ID", color));
                    panels[1].Children.Add(textedBlock("Treatment start", color));
                    panels[2].Children.Add(textedBlock("Treatment end", color));
                    panels[3].Children.Add(textedBlock("Created by", color));
                    if (MainWindow.UserStat != "patient") panels[4].Children.Add(textedBlock("Patient's ID", color));
                    panels[5].Children.Add(textedBlock("Visit's ID", color));
                    panels[6].Children.Add(textedBlock("Prognosis", color));
                    panels[7].Children.Add(textedBlock("Prescriptions", color));
                    for (int i = 0; i < list.capacity(); i++)
                    {
                        if (i % 2 == 0) color = Brushes.WhiteSmoke;
                        else color = Brushes.Gainsboro;
                        treatment treat = (treatment)list.getData(i);
                        panels[0].Children.Add(textedBlock(treat.ID.ToString(), color));
                        panels[1].Children.Add(textedBlock(treat.DateOfStart.ToShortDateString(), color));
                        panels[2].Children.Add(textedBlock(treat.DateOfEnd.ToShortDateString(), color));
                        panels[3].Children.Add(textedBlock(treat.CreatedByDoctor.ToString(), color));
                        if (MainWindow.UserStat != "patient") panels[4].Children.Add(textedBlock(treat.PatientID.ToString(), color));
                        panels[5].Children.Add(textedBlock(treat.VisitID.ToString(), color));
                        panels[6].Children.Add(textedBlock(treat.Prognosis, color));
                        panels[7].Children.Add(textedBlock(treat.Prescriptions, color));
                    }
                }
            return panels;
        }

        private Button toEditWindowButton(int index)
        {
            Button but=new Button();
            but.Content = "Edit";
            but.Name = "edit"+index.ToString();
            but.Click += toEditWindowClick;
            but.Height = 23;
            return but;
        }

        private void toEditWindowClick(object sender, RoutedEventArgs e)
        {
            Button but = (Button) sender;
            IBase obj;
            string s = but.Name;
            s = s.Substring(4);
            obj = currenList.getData(Convert.ToInt32(s));
            Window child;
            if(obj.ID==null) throw new RuntimeBinderException("");
            if (obj is doctor) child = new addDoctor(obj);
            else if (obj is patient) child=new addPatient(obj);
            else if (obj is treatment) child=new addTreatment(obj);
            else if (obj is visit) child = new addVisit(obj);
            else return;
            child.Owner = this;
            child.Show();
        }
    }
   */ 
