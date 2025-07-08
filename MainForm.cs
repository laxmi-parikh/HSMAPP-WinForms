using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSMAPP
{
    public partial class MainForm : Form
    {
        public class CustomToolStripRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.CadetBlue, e.Item.ContentRectangle); // Set the color when the item is selected
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.BurlyWood, e.Item.ContentRectangle); // Set the color for normal state
                }
            }
        }
        private Panel mainContentPanel;
        public MainForm() {  InitializeComponent(); InitializeMenu(); InitializeMainContentPanel(); this.WindowState = FormWindowState.Maximized; }
       
        private void InitializeMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Renderer = new CustomToolStripRenderer();

            // Home menu
            ToolStripMenuItem LoginMenu = new ToolStripMenuItem("Home");
            LoginMenu.Font = new Font(LoginMenu.Font.FontFamily, 12); // Change font size to 16
            LoginMenu.Click += new EventHandler(LoginMenu_Click); // Settings menu

            ToolStripMenuItem EditMenu = new ToolStripMenuItem("Edit Profile");
            EditMenu.Font = new Font(LoginMenu.Font.FontFamily, 12); // Change font size to 16
            EditMenu.Click += new EventHandler(EditMenu_Click); // Settings menu


            ToolStripMenuItem companyMenu = new ToolStripMenuItem("Company");
            companyMenu.Font = new Font(companyMenu.Font.FontFamily, 12);
            companyMenu.Click += new EventHandler(CompanyMenu_Click); 
            // Help menu
            ToolStripMenuItem patientMenu = new ToolStripMenuItem("Patient");
            patientMenu.Font = new Font(patientMenu.Font.FontFamily, 12);
            patientMenu.Click += new EventHandler(PatientMenu_Click);

            ToolStripMenuItem generaldetailMenu = new ToolStripMenuItem("General Details");
            generaldetailMenu.Font = new Font(generaldetailMenu.Font.FontFamily, 12);
            generaldetailMenu.Click += new EventHandler(GeneralDetailMenu_Click);

            ToolStripMenuItem investigationdetailMenu = new ToolStripMenuItem("Investigation Details");
            investigationdetailMenu.Font = new Font(investigationdetailMenu.Font.FontFamily, 12);
            investigationdetailMenu.Click += new EventHandler(InvestigationDetailMenu_Click);

            ToolStripMenuItem patientViewMenu = new ToolStripMenuItem("Patient View");
            patientViewMenu.Font = new Font(patientViewMenu.Font.FontFamily, 12);
            patientViewMenu.Click += new EventHandler(PatientViewMenu_Click);

            ToolStripMenuItem testsMenu = new ToolStripMenuItem("Tests");
            testsMenu.Font = new Font(testsMenu.Font.FontFamily, 12);
            testsMenu.Click += new EventHandler(TestsMenu_Click);

            ToolStripMenuItem billMenu = new ToolStripMenuItem("Tests Bill");
            billMenu.Font = new Font(billMenu.Font.FontFamily, 12);
            billMenu.Click += new EventHandler(BillMenu_Click);
            ToolStripMenuItem treatmentMenu = new ToolStripMenuItem("Treatment");
            treatmentMenu.Font = new Font(treatmentMenu.Font.FontFamily, 12);
            treatmentMenu.Click += new EventHandler(TreatmentMenu_Click);

            ToolStripMenuItem treatmentbillMenu = new ToolStripMenuItem("Treatment Bill");
            treatmentbillMenu.Font = new Font(treatmentbillMenu.Font.FontFamily, 12);
            treatmentbillMenu.Click += new EventHandler(TreatmentBillMenu_Click);

            ToolStripMenuItem VisitMenu = new ToolStripMenuItem("Visiting");
            VisitMenu.Font = new Font(VisitMenu.Font.FontFamily, 12);
            VisitMenu.Click += new EventHandler(VisitMenu_Click);

            ToolStripMenuItem VisitbillMenu = new ToolStripMenuItem("Visited Bill");
            VisitbillMenu.Font = new Font(VisitbillMenu.Font.FontFamily, 12);
            VisitbillMenu.Click += new EventHandler(VisitbillMenu_Click);

            ToolStripMenuItem mailMenu = new ToolStripMenuItem("Mail");
            mailMenu.Font = new Font(mailMenu.Font.FontFamily, 12);
            mailMenu.Click += new EventHandler(MailMenu_Click);

            //ToolStripMenuItem exitMenu = new ToolStripMenuItem("Exit");
            //exitMenu.Click  += new EventHandler(ExitMenu_Click);


            menuStrip.Items.Add(LoginMenu);
            menuStrip.Items.Add(EditMenu);
            menuStrip.Items.Add(companyMenu); 
            menuStrip.Items.Add(patientMenu);
           
            menuStrip.Items.Add(generaldetailMenu);
            menuStrip.Items.Add(investigationdetailMenu);
            menuStrip.Items.Add(patientViewMenu);
            menuStrip.Items.Add(testsMenu);
            menuStrip.Items.Add(billMenu);// Add the menu strip to the form
            menuStrip.Items.Add(treatmentMenu);
            menuStrip.Items.Add(treatmentbillMenu);
            menuStrip.Items.Add(VisitMenu);
            menuStrip.Items.Add(VisitbillMenu);
            menuStrip.Items.Add(mailMenu);
           // menuStrip.Items.Add(exitMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }
        private void InitializeMainContentPanel()
        { // Main content

            
        mainContentPanel = new Panel { Dock = DockStyle.Fill, BackColor = System.Drawing.Color.White }; 
            this.Controls.Add(mainContentPanel); // Initially show the Home form
                                                 ShowForm(new Register()); }
        private void LoginMenu_Click(object sender, EventArgs e) { ShowForm(new Register()); }
        private void EditMenu_Click(object sender, EventArgs e) { ShowForm(new EditProfile()); }
        private void CompanyMenu_Click(object sender, EventArgs e) { ShowForm(new CompanyF()); }
        private void PatientMenu_Click(object sender, EventArgs e) { ShowForm(new Home()); }
        private void GeneralDetailMenu_Click(object sender, EventArgs e) { ShowForm(new AddPatient2()); }

        private void InvestigationDetailMenu_Click(object sender, EventArgs e) { ShowForm(new AddPatient3()); }
        private void PatientViewMenu_Click(object sender, EventArgs e) { ShowForm(new ViewPatient()); }

        private void BillMenu_Click(object sender, EventArgs e) { ShowForm(new InvoiceTestperform()); }
        private void TestsMenu_Click(object sender, EventArgs e) { ShowForm(new PatientTests()); }
        // private void  TreatmentMenu_Click(object sender, EventArgs e) { ShowForm(new TreatmentFormcs()); }
        private void TreatmentMenu_Click(object sender, EventArgs e) { ShowForm(new TreatmentDetail());  }
        private void TreatmentBillMenu_Click(object sender, EventArgs e) { ShowForm(new treamentInvoices()); }
        private void VisitMenu_Click(object sender, EventArgs e) { ShowForm(new VisitingDetail()); }
        private void VisitbillMenu_Click(object sender, EventArgs e) { ShowForm(new VisitingInvoice()); }

        private void MailMenu_Click(object sender, EventArgs e) { ShowForm(new SendMail()); }

      //  private void ExitMenu_Click(object sender, EventArgs e) { Close(); Dispose();  }
        //private void Label(object sender, EventArgs e) { this.Text = "Hello ";  }
        private void ShowForm(Form form) { // Clear the main content panel
                                           mainContentPanel.Controls.Clear();
            // Set the form to have no border and fill the panel
            form.TopLevel = false; form.FormBorderStyle = FormBorderStyle.None; form.Dock = DockStyle.Fill;
            // Add the form to the main content panel and show it
            mainContentPanel.Controls.Add(form); form.Show(); 
        }

      
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Dispose(); 
            Application.Exit(); // Ensure the application exits
        }
    } 
        }
