using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace UraitManagementApplication
{
    partial class SearchByDisciplinesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gbWhereIsDisciplines = new DevExpress.XtraEditors.GroupControl();
            this.ceSPO = new DevExpress.XtraEditors.CheckEdit();
            this.ceVO = new DevExpress.XtraEditors.CheckEdit();
            this.rgWhereIsDisciplines = new DevExpress.XtraEditors.RadioGroup();
            this.teFileImport = new DevExpress.XtraEditors.TextEdit();
            this.btnFileOpen = new DevExpress.XtraEditors.SimpleButton();
            this.lblFirmLevel = new DevExpress.XtraEditors.LabelControl();
            this.lbAllDisciplines = new DevExpress.XtraEditors.ListBoxControl();
            this.lbBasketDisciplines = new DevExpress.XtraEditors.ListBoxControl();
            this.lkpClients = new DevExpress.XtraEditors.LookUpEdit();
            this.teSearchInDisciplines = new DevExpress.XtraEditors.TextEdit();
            this.btnMoveAllDisciplinesToBasket = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveAllDisciplinesFromBasket = new DevExpress.XtraEditors.SimpleButton();
            this.sccListBoxes = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblDisciplinesFrom = new DevExpress.XtraEditors.LabelControl();
            this.lblDisciplinesBasket = new DevExpress.XtraEditors.LabelControl();
            this.lblWname = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearchToWord = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbWhereIsDisciplines)).BeginInit();
            this.gbWhereIsDisciplines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceSPO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceVO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgWhereIsDisciplines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFileImport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAllDisciplines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbBasketDisciplines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpClients.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSearchInDisciplines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccListBoxes)).BeginInit();
            this.sccListBoxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gbWhereIsDisciplines);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1191, 608);
            this.panelControl1.TabIndex = 0;
            // 
            // gbWhereIsDisciplines
            // 
            this.gbWhereIsDisciplines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWhereIsDisciplines.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gbWhereIsDisciplines.Appearance.Options.UseBackColor = true;
            this.gbWhereIsDisciplines.Controls.Add(this.ceSPO);
            this.gbWhereIsDisciplines.Controls.Add(this.ceVO);
            this.gbWhereIsDisciplines.Controls.Add(this.rgWhereIsDisciplines);
            this.gbWhereIsDisciplines.Controls.Add(this.teFileImport);
            this.gbWhereIsDisciplines.Controls.Add(this.btnFileOpen);
            this.gbWhereIsDisciplines.Controls.Add(this.lblFirmLevel);
            this.gbWhereIsDisciplines.Location = new System.Drawing.Point(9, 32);
            this.gbWhereIsDisciplines.Name = "gbWhereIsDisciplines";
            this.gbWhereIsDisciplines.Size = new System.Drawing.Size(1174, 103);
            this.gbWhereIsDisciplines.TabIndex = 0;
            this.gbWhereIsDisciplines.Text = "Источник дисциплин:";
            // 
            // ceSPO
            // 
            this.ceSPO.Location = new System.Drawing.Point(300, 77);
            this.ceSPO.Name = "ceSPO";
            this.ceSPO.Properties.Caption = "СПО";
            this.ceSPO.Size = new System.Drawing.Size(160, 19);
            this.ceSPO.TabIndex = 5;
            // 
            // ceVO
            // 
            this.ceVO.Location = new System.Drawing.Point(157, 77);
            this.ceVO.Name = "ceVO";
            this.ceVO.Properties.Caption = "ВО";
            this.ceVO.Size = new System.Drawing.Size(137, 19);
            this.ceVO.TabIndex = 4;
            // 
            // rgWhereIsDisciplines
            // 
            this.rgWhereIsDisciplines.Location = new System.Drawing.Point(5, 24);
            this.rgWhereIsDisciplines.Name = "rgWhereIsDisciplines";
            this.rgWhereIsDisciplines.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgWhereIsDisciplines.Properties.Appearance.Options.UseBackColor = true;
            this.rgWhereIsDisciplines.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgWhereIsDisciplines.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Из файла"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "ВУЗ/ССУЗ дисциплины"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Все дисциплины")});
            this.rgWhereIsDisciplines.Size = new System.Drawing.Size(145, 85);
            this.rgWhereIsDisciplines.TabIndex = 1;
            this.rgWhereIsDisciplines.SelectedIndexChanged += new System.EventHandler(this.rgWhereIsDisciplines_SelectedIndexChanged);
            // 
            // teFileImport
            // 
            this.teFileImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teFileImport.Location = new System.Drawing.Point(156, 31);
            this.teFileImport.Name = "teFileImport";
            this.teFileImport.Size = new System.Drawing.Size(977, 20);
            this.teFileImport.TabIndex = 0;
            this.teFileImport.DoubleClick += new System.EventHandler(this.teFileImport_Click);
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileOpen.Location = new System.Drawing.Point(1139, 31);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(30, 20);
            this.btnFileOpen.TabIndex = 0;
            this.btnFileOpen.Text = "...";
            this.btnFileOpen.Click += new System.EventHandler(this.teFileImport_Click);
            // 
            // lblFirmLevel
            // 
            this.lblFirmLevel.Location = new System.Drawing.Point(156, 57);
            this.lblFirmLevel.Name = "lblFirmLevel";
            this.lblFirmLevel.Size = new System.Drawing.Size(130, 13);
            this.lblFirmLevel.TabIndex = 3;
            this.lblFirmLevel.Text = "Для уровня образования:";
            // 
            // lbAllDisciplines
            // 
            this.lbAllDisciplines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAllDisciplines.HorizontalScrollbar = true;
            this.lbAllDisciplines.Location = new System.Drawing.Point(1, 23);
            this.lbAllDisciplines.Name = "lbAllDisciplines";
            this.lbAllDisciplines.Size = new System.Drawing.Size(580, 430);
            this.lbAllDisciplines.TabIndex = 11;
            this.lbAllDisciplines.DoubleClick += new System.EventHandler(this.lbAllDisciplines_MouseDoubleClick);
            // 
            // lbBasketDisciplines
            // 
            this.lbBasketDisciplines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBasketDisciplines.HorizontalScrollbar = true;
            this.lbBasketDisciplines.Location = new System.Drawing.Point(35, 26);
            this.lbBasketDisciplines.Name = "lbBasketDisciplines";
            this.lbBasketDisciplines.Size = new System.Drawing.Size(547, 430);
            this.lbBasketDisciplines.TabIndex = 2;
            this.lbBasketDisciplines.DoubleClick += new System.EventHandler(this.lbBasketDisciplines_MouseDoubleClick);
            // 
            // lkpClients
            // 
            this.lkpClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpClients.Location = new System.Drawing.Point(60, 9);
            this.lkpClients.Name = "lkpClients";
            this.lkpClients.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpClients.Size = new System.Drawing.Size(1126, 20);
            this.lkpClients.TabIndex = 0;
            this.lkpClients.EditValueChanged += new System.EventHandler(this.lkpClients_EditValueChanged);
            // 
            // teSearchInDisciplines
            // 
            this.teSearchInDisciplines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teSearchInDisciplines.Location = new System.Drawing.Point(94, 1);
            this.teSearchInDisciplines.Name = "teSearchInDisciplines";
            this.teSearchInDisciplines.Size = new System.Drawing.Size(487, 20);
            this.teSearchInDisciplines.TabIndex = 0;
            this.teSearchInDisciplines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teSearchDisciplines_KeyDown);
            // 
            // btnMoveAllDisciplinesToBasket
            // 
            this.btnMoveAllDisciplinesToBasket.Location = new System.Drawing.Point(8, 23);
            this.btnMoveAllDisciplinesToBasket.Name = "btnMoveAllDisciplinesToBasket";
            this.btnMoveAllDisciplinesToBasket.Size = new System.Drawing.Size(24, 187);
            this.btnMoveAllDisciplinesToBasket.TabIndex = 0;
            this.btnMoveAllDisciplinesToBasket.Text = "->";
            this.btnMoveAllDisciplinesToBasket.Click += new System.EventHandler(this.btnMoveAllDisciplinesToBasket_Click);
            // 
            // btnMoveAllDisciplinesFromBasket
            // 
            this.btnMoveAllDisciplinesFromBasket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveAllDisciplinesFromBasket.Location = new System.Drawing.Point(8, 216);
            this.btnMoveAllDisciplinesFromBasket.Name = "btnMoveAllDisciplinesFromBasket";
            this.btnMoveAllDisciplinesFromBasket.Size = new System.Drawing.Size(24, 237);
            this.btnMoveAllDisciplinesFromBasket.TabIndex = 1;
            this.btnMoveAllDisciplinesFromBasket.Text = "<-";
            this.btnMoveAllDisciplinesFromBasket.Click += new System.EventHandler(this.btnMoveAllDisciplinesFromBasket_Click);
            // 
            // sccListBoxes
            // 
            this.sccListBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sccListBoxes.Location = new System.Drawing.Point(12, 150);
            this.sccListBoxes.Name = "sccListBoxes";
            this.sccListBoxes.Panel1.Controls.Add(this.lbAllDisciplines);
            this.sccListBoxes.Panel1.Controls.Add(this.teSearchInDisciplines);
            this.sccListBoxes.Panel1.Controls.Add(this.lblDisciplinesFrom);
            this.sccListBoxes.Panel2.Controls.Add(this.lbBasketDisciplines);
            this.sccListBoxes.Panel2.Controls.Add(this.btnMoveAllDisciplinesToBasket);
            this.sccListBoxes.Panel2.Controls.Add(this.btnMoveAllDisciplinesFromBasket);
            this.sccListBoxes.Panel2.Controls.Add(this.lblDisciplinesBasket);
            this.sccListBoxes.Size = new System.Drawing.Size(1174, 456);
            this.sccListBoxes.SplitterPosition = 584;
            this.sccListBoxes.TabIndex = 0;
            // 
            // lblDisciplinesFrom
            // 
            this.lblDisciplinesFrom.Location = new System.Drawing.Point(5, 4);
            this.lblDisciplinesFrom.Name = "lblDisciplinesFrom";
            this.lblDisciplinesFrom.Size = new System.Drawing.Size(52, 13);
            this.lblDisciplinesFrom.TabIndex = 0;
            this.lblDisciplinesFrom.Text = "Источник:";
            // 
            // lblDisciplinesBasket
            // 
            this.lblDisciplinesBasket.Location = new System.Drawing.Point(35, 4);
            this.lblDisciplinesBasket.Name = "lblDisciplinesBasket";
            this.lblDisciplinesBasket.Size = new System.Drawing.Size(79, 13);
            this.lblDisciplinesBasket.TabIndex = 0;
            this.lblDisciplinesBasket.Text = "Поиск-корзина:";
            // 
            // lblWname
            // 
            this.lblWname.Location = new System.Drawing.Point(12, 12);
            this.lblWname.Name = "lblWname";
            this.lblWname.Size = new System.Drawing.Size(41, 13);
            this.lblWname.TabIndex = 0;
            this.lblWname.Text = "Клиент:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1111, 616);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearchToWord
            // 
            this.btnSearchToWord.Location = new System.Drawing.Point(950, 616);
            this.btnSearchToWord.Name = "btnSearchToWord";
            this.btnSearchToWord.Size = new System.Drawing.Size(75, 23);
            this.btnSearchToWord.TabIndex = 5;
            this.btnSearchToWord.Text = "Поиск Word";
            this.btnSearchToWord.Click += new System.EventHandler(this.btnSearchToWord_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1031, 616);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Поиск Excel";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SearchByDisciplinesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 651);
            this.Controls.Add(this.btnSearchToWord);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lkpClients);
            this.Controls.Add(this.sccListBoxes);
            this.Controls.Add(this.lblWname);
            this.Controls.Add(this.panelControl1);
            this.Name = "SearchByDisciplinesForm";
            this.Text = "Поиск по дисциплинам";
            this.Load += new System.EventHandler(this.SearchByDisciplinesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbWhereIsDisciplines)).EndInit();
            this.gbWhereIsDisciplines.ResumeLayout(false);
            this.gbWhereIsDisciplines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceSPO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceVO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgWhereIsDisciplines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFileImport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAllDisciplines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbBasketDisciplines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpClients.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSearchInDisciplines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccListBoxes)).EndInit();
            this.sccListBoxes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PanelControl panelControl1;
        private ListBoxControl lbAllDisciplines;
        private ListBoxControl lbBasketDisciplines;
        private LookUpEdit lkpClients;
        private GroupControl gbWhereIsDisciplines;
        private RadioGroup rgWhereIsDisciplines;
        private LabelControl lblFirmLevel;
        private SimpleButton btnFileOpen;
        private TextEdit teFileImport;
        private TextEdit teSearchInDisciplines;
        private SimpleButton btnMoveAllDisciplinesToBasket;
        private SimpleButton btnMoveAllDisciplinesFromBasket;
        private SplitContainerControl sccListBoxes;
        private LabelControl lblDisciplinesBasket;
        private LabelControl lblDisciplinesFrom;
        private LabelControl lblWname;
        private SimpleButton btnCancel;
        private CheckEdit ceSPO;
        private CheckEdit ceVO;
        private SimpleButton btnSearchToWord;
        private SimpleButton btnSearch;
    }
}