using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EntitiesLibrary;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DataProviderLibrary;

namespace UraitManagementApplication
{
    public partial class SearchByDisciplinesForm : DevExpress.XtraEditors.XtraForm
    {

        private Int32 fcode = 0; 
        private DataTable DT = null;
        private DataTable tmpDT = null;

        protected ApplicationController AppController; // контроллер приложения

        public SearchByDisciplinesForm(ApplicationController appController, Action<Dictionary<string, object>> del, int fcode, XtraForm parent = null)
        {
            this.AppController = appController;
            this.fcode = fcode;
            InitializeComponent();
            //rgFirmLevel.SelectedIndex = 0;            
        }

        public void lkpClients_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lkpClients.Invalidate();
                fcode = (int)lkpClients.EditValue;
                rgWhereIsDisciplines_SelectedIndexChanged(sender, e);
                var row = lkpClients.GetSelectedDataRow() as DataRowView;
                if (row == null) return;
                switch (row["cav_name"].ToString())
                {
                    case "ВО":
                        ceSPO.Checked = false;
                        ceVO.Checked = true;
                        break;
                    case "СПО":
                        ceSPO.Checked = true;
                        ceVO.Checked = false;
                        break;
                    case "ВО + СПО":
                        ceSPO.Checked = true;
                        ceVO.Checked = true;
                        break;
                    default:
                        ceSPO.Checked = false;
                        ceVO.Checked = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке обработке клаента.\n" + ex.Message.ToString(),"Ошибка");
                throw;
            }            
        }

        public void rgWhereIsDisciplines_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rgWhereIsDisciplines.SelectedIndex)
            {
                case 0:
                    {
                        if (tmpDT != null)
                        {
                            lbAllDisciplines.Items.Clear();

                            var existingLines = lbBasketDisciplines.Items.OfType<string>().ToArray();
                            var inputLines = tmpDT.AsEnumerable()
                                .Select(r => r.Field<string>(0))
                                .Where(l => !string.IsNullOrWhiteSpace(l))
                                .Where(l => !existingLines.Any(item => item.Equals(l)))
                                .ToArray();

                            lbAllDisciplines.Items.AddRange(inputLines);
                        }
                        break;
                    }
                case 1:
                    {
                        lbAllDisciplines.Items.Clear();
                        DT = ServiceEntitiesMethods.GetSqlDataTable(string.Format("EXEC DBA.HighSchoolsBooksByDisciplineList_param_discipline_name_spForm {0}, {1}, {2}, {3}, {4} ", fcode.ToString(), "2", "null", "null", "null"));
                        if (DT != null)
                        {
                            var existingLines = lbBasketDisciplines.Items.OfType<string>().ToArray();
                            var inputLines = DT.AsEnumerable()
                            .Select(r => r.Field<string>(1))
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .Where(l => !existingLines.Any(item => item.Equals(l)))
                            .ToArray();

                            lbAllDisciplines.Items.AddRange(inputLines);
                        }
                        break;
                    }
                case 2:
                    {
                        lbAllDisciplines.Items.Clear();
                        DT = ServiceEntitiesMethods.GetSqlDataTable(string.Format("EXEC DBA.HighSchoolsBooksByDisciplineList_param_discipline_name_spForm {0}, {1}, {2}, {3}, {4} ", "0", "0", "null", "null", "null"));
                        if (DT != null)
                        {
                            var existingLines = lbBasketDisciplines.Items.OfType<string>().ToArray();
                            var inputLines = DT.AsEnumerable()
                            .Select(r => r.Field<string>(1))
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .Where(l => !existingLines.Any(item => item.Equals(l)))
                            .ToArray();

                            lbAllDisciplines.Items.AddRange(inputLines);
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            lblDisciplinesFrom.Text = (string)("Источник(" + lbAllDisciplines.Items.Count.ToString() + "):");
        }

        private void teFileImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Документ Microsoft Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            dialog.Title = "Выберите файл с дисциплинами";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                try
                {
                    tmpDT = null;
                    tmpDT = ImportExcel.ImportExcelToDataSet(dialog.FileName);
                    string col_name = "Дисциплина";

                    if (tmpDT.Columns[0].ToString().ToLower() != (col_name.ToLower()))
                    {
                        if (col_name != "Дисциплина")
                        {
                            MessageBox.Show("Столбец \"" + col_name + "\" отсутствует в исходной таблице", "Ошибка импорта Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Столбец \"Дисциплина\" отсутствует в исходной таблице", "Ошибка импорта Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    lbAllDisciplines.Items.Clear();

                    var existingLines = lbBasketDisciplines.Items.OfType<string>().ToArray();
                    var inputLines = tmpDT.AsEnumerable()
                        .Select(r => r.Field<string>(0))
                        .Where(l => !string.IsNullOrWhiteSpace(l))
                        .Where(l => !existingLines.Any(item => item.Equals(l)))
                        .ToArray();

                    lbAllDisciplines.Items.AddRange(inputLines);
                    teFileImport.Text = dialog.FileName;
                }
                catch (Exception ex)
                {
                    AppController.errorHandlerController.Handle(ex);
                }
                rgWhereIsDisciplines.SelectedIndex = 0;
            }
        }

        private void btnMoveAllDisciplinesToBasket_Click(object sender, EventArgs e)
        {
            var temp = lbAllDisciplines.Items.OfType<string>().ToArray().Concat(lbBasketDisciplines.Items.OfType<string>().AsEnumerable().OrderBy(l=>l)).Distinct().ToArray();
            lbBasketDisciplines.Items.Clear();
            listAddRange(lbBasketDisciplines, temp);
            //lbBasketDisciplines.Items.AddRange(temp);
            lbAllDisciplines.Items.Clear();
            lblDisciplinesFrom.Text = (string)("Источник(" + lbAllDisciplines.Items.Count.ToString() + "):");
        }
        /// <summary>
        /// Добавление в листбокс строки с сортировкой по алфавиту
        /// </summary>
        /// <param name="lbc">Листбокс, в который добавляем стрингу</param>
        /// <param name="item">Стринга</param>
        private void listAdd(ListBoxControl lbc, string item )
        {
            var existingLines = lbc.Items.OfType<string>().ToList();
            existingLines.Add(item);
            var inputLines = existingLines.AsEnumerable()
                                          .OrderBy(l => l)
                                          .ToArray();
            lbc.Items.Clear();
            lbc.Items.AddRange(inputLines);
        }
        /// <summary>
        /// Добавление в листбокс массива строк с сортировкой по алфавиту
        /// </summary>
        /// <param name="lbc"> Листбокс, в который вносим массив </param>
        /// <param name="itemArray"> Массив вносимых стрингов</param>
        private void listAddRange(ListBoxControl lbc, string[] itemArray)
        {
            var existingLines = lbc.Items.OfType<string>().ToList();
            existingLines.AddRange(itemArray);
            var inputLines = existingLines.AsEnumerable()
                                          .OrderBy(l => l)
                                          .ToArray();

            lbc.Items.Clear();
            lbc.Items.AddRange(inputLines);
        }

        private void btnMoveAllDisciplinesFromBasket_Click(object sender, EventArgs e)
        {
            var temp = lbBasketDisciplines.Items.OfType<string>().ToArray();
            lbBasketDisciplines.Items.Clear();
            listAddRange(lbAllDisciplines, temp);
            lblDisciplinesFrom.Text = (string)("Источник(" + lbAllDisciplines.Items.Count.ToString() + "):");
        }

        public void teSearchDisciplines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(teSearchInDisciplines.Text))
            {
                DT = ServiceEntitiesMethods.GetSqlDataTable(string.Format("Select NULL AS [Подразделение], " +
                    "d.discipline_name AS [Дисциплина], " +
                    "d.discipline_id AS id, " +
                    "0 AS is_basket " +
                    "FROM DBA.project_disciplines d " +
                    " WHERE d.discipline_name LIKE '{0}%'", teSearchInDisciplines.Text.ToString().ToLower().Replace('*', '%').Trim()));
                lbAllDisciplines.Items.Clear();

                var existingLines = lbBasketDisciplines.Items.OfType<string>().ToList();

                var inputLines = DT.AsEnumerable()
                    .Select(r => r.Field<string>(1))
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .Where(l => !existingLines.Any(item => item.Equals(l)))
                    .ToArray();

                lbAllDisciplines.Items.AddRange(inputLines);

                lblDisciplinesFrom.Text = (string)("Источник(" + lbAllDisciplines.Items.Count.ToString() + "):");

            }
        }

        public void lbAllDisciplines_MouseDoubleClick(object sender, EventArgs e)
        {
            if (lbAllDisciplines.SelectedItem != null)
            {
                object tmp;
                tmp = lbAllDisciplines.SelectedItem;
                if (!lbBasketDisciplines.Items.Contains(tmp))
                {
                    lbAllDisciplines.Items.Remove(tmp);
                    listAdd(lbBasketDisciplines, tmp.ToString());
                    //lbBasketDisciplines.Items.Add(tmp.ToString());
                }
                else
                {
                    lbAllDisciplines.Items.Remove(tmp);
                }

            }
            lblDisciplinesFrom.Text = (string)("Источник(" + lbAllDisciplines.Items.Count.ToString() + "):");
        }

        public void lbBasketDisciplines_MouseDoubleClick(object sender, EventArgs e)
        {
            if (lbBasketDisciplines.SelectedItem != null)
            {
                object tmp;
                tmp = lbBasketDisciplines.SelectedItem;
                if (!lbAllDisciplines.Items.Contains(tmp))
                {
                    lbBasketDisciplines.Items.Remove(tmp);
                    listAdd(lbAllDisciplines, tmp.ToString());
                    //lbAllDisciplines.Items.Add(tmp.ToString());
                }
                else
                {
                    lbBasketDisciplines.Items.Remove(tmp);
                }
            }
            lblDisciplinesFrom.Text = (string)("Источник(" + lbAllDisciplines.Items.Count.ToString() + "):");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(true);
        }

        private void Search(bool flag)
        {
            if (fcode == 0)
            {
                MessageBox.Show("Выберите верный ВУЗ/ССУЗ", "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lbBasketDisciplines.Items.Count <= 0)
            {
                MessageBox.Show("Выберите хотя бы одну дисциплину", "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Worm w = new Worm(2, 1, 0);
                w.Text = "Поиск в процессе";
                w.Show();
                w.Activate();
                w.TopLevel = true;
                DataTable dt;
                Dictionary<string, object> pars;
                string discipline_list = null;
                for (int i = 0; i < lbBasketDisciplines.Items.Count; i++)
                {
                    if (lbBasketDisciplines.Items[i] != null)
                        discipline_list += (lbBasketDisciplines.Items[i].ToString() + "|");
                }
                var query = "dba.edu_high_school_books_list_by_disciplines_new";
                pars = AppController.dataViewController.GetParameters(query);
                w.RiseWorm();
                pars["@discipline_list"] = discipline_list;
                pars["@fcode"] = fcode;
                pars["@firm_level"] = ceSPO.Checked && ceVO.Checked ? 0 : ceVO.Checked && !ceSPO.Checked ? 1 : !ceVO.Checked && ceSPO.Checked ? 2 : 3;
                dt = AppController.dataViewController.DoQuery(query, pars, QueryTypes.StoredProcedure);
                w.RiseWorm();

                if (flag)
                {
                    ExportToExcel(dt, lkpClients.Text);
                }
                else
                {
                    ExportToWord(dt, lkpClients.Text);
                }
                w.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Ошибка при отправке запроса на поиск. \n" + ex.Message.ToString(), "Ошибка");
                return;
            }
        }

        private void ExportToWord(DataTable dt, string FirmName = null)
        {
            if (!ServiceMethods.IsInstalledWord())
            {
                MessageBox.Show("Невозможно экспортировать в Word, так как он не установлен");
                return;
            }
            var xmlFilePath = System.IO.Path.GetTempFileName() + ".xml";
            byte[] tempXml2;
            try
            {
                var query = "dba.book_bannerlist_WordML_by_bcodelist";
                var param = AppController.dataViewController.GetParameters(query);
                var temp = string.Join(";", dt.AsEnumerable().Select(dr => dr.Field<int>("Код").ToString()));//.Take(30));
                param["@bcode_list"] = temp;
                param["@firmName"] = FirmName == null ? DBNull.Value : (object)FirmName;
                param["@header"] = DBNull.Value;
                param["@with_count"] = 0;
                var dtTemp = (AppController.dataViewController.DoQuery(query, param, QueryTypes.StoredProcedure));
                var tempXml = dtTemp.Rows[0][0];
                tempXml2 = tempXml as byte[];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выполнить хранимую процедуру");
                return;
            }
            try
            {
                using (FileStream fs = new FileStream(xmlFilePath, FileMode.OpenOrCreate))
                {
                    fs.Write(tempXml2, 0, tempXml2.Length);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Запись в файл не удалась ");
                return;
            }
            var wrdApp = new Microsoft.Office.Interop.Word.Application();
            var wrdDoc = wrdApp.Documents.Open(xmlFilePath);
            wrdApp.Visible = true;
            var oMissing = System.Reflection.Missing.Value;
            try
            {
                var docFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var date = DateTime.Today.Date;
                //docFilePath = docFilePath.Replace("\\","\");
                docFilePath = Path.Combine(docFilePath, string.Format("Подборка книг по дициплинам для вуза {0} от {1} .doc", FirmName, date.ToString("ddMMyyyy hhmmss")));              
                wrdDoc.SaveAs(docFilePath);
                wrdDoc.Saved = false;
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("Value out of range"))
                {
                    throw;
                }
            }                    
        }

        /// <summary>
        /// Наводим красоту в выводимом файле
        /// </summary>
        /// <param name="dataTable">данные по книгам</param>
        /// <param name="FirmName">Название фирмы, которое вставляется в строку, для кого подборка</param>
        private static void ExportToExcel(DataTable dataTable, string FirmName = null)
        {
            try
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Книги по дисциплинам";

                var columns = dataTable.Columns.Count;
                var rows = dataTable.Rows.Count;

                Worm w = new Worm(rows + (rows / 2), 1, rows);
                w.Text = "Экспорт в Excel-файл";
                w.Show();
                w.Activate();
                w.TopLevel = true;
                object[,] data = new object[rows + 6, columns]; //6 строк сверху заполнятся информацией о поиске и названиями колонок
                Excel.Range range = worksheet.Range["A1", String.Format("{0}{1}", GetExcelColumnName(columns), rows + 6)];
                range.Font.Name = "MS Sans Serif";
                range.Font.Size = 10;
                Excel.Range rangeTmp = worksheet.Range["A1", "A1"];
                data[0, 0] = DateTime.Today.Date.ToString("dd/MM/yyyy");//Дата
                range = worksheet.Range["A1", "A1"];
                range.Font.Bold = true;

                range = worksheet.Range["B1", String.Format("N{0}", 1)];//"Издательство Юрайт" справа от даты
                range.Merge();
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.Font.Bold = true;
                data[0, 1] = "Издательство Юрайт";

                range = worksheet.Range["A2", String.Format("N{0}", 2)];//2nd строка... Контакты Юрайт
                range.Merge();
                range.Font.Size = 9;
                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                data[1, 0] = "Адрес: 111123, Москва, ул.Плеханова, 4 А, бизнес-центр Юникон, тел./факс: (495) 744-00-12 (многоканальный), сайт: urait.ru, электронная библиотека: biblio-online.ru, отдел продаж: vuz@urait.ru";

                range = worksheet.Range["A3", string.Format("N{0}", 3)];//3rd строка... для кого подборка
                range.Merge();
                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                data[2, 0] = "Подборка по дисциплинам для \"" + FirmName + "\"";

                range = worksheet.Range["A4", "N4"];// 4-я строка... всего книг
                range.Font.Bold = true;
                range.Font.Size = 8;
                data[3, 0] = "Всего книг:";
                data[3, 1] = dataTable.AsEnumerable().Where(row => row.Field<int?>(1) != null ).Count(); //rows;

                range = worksheet.Range["A5", string.Format("{0}{1}", GetExcelColumnName(columns), 5)]; // 5-я... сумма заказа
                range.Font.Size = 8;
                range.Font.Bold = true;
                data[4, 6] = "Сумма заказа:";

                worksheet.Range[string.Format("{0}{1}", GetExcelColumnName(8), 5), string.Format("{0}{1}", GetExcelColumnName(10), 5)].Merge();//мержим ячейки, где сумму заказа считать будем

                range = worksheet.Range["A6", string.Format("{0}{1}", GetExcelColumnName(columns), 6)];
                range.Interior.Color = Color.FromArgb(200, 200, 200);
                range.Font.Bold = true;
                range.Font.Size = 7;
                range.Borders.Weight = 2;
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                for (int columnNumber = 0; columnNumber < columns; columnNumber++)//названия колонок в 6-ю строку
                {
                    data[5, columnNumber] = dataTable.Columns[columnNumber].Caption;
                }

                for (int rowNumber = 0; rowNumber < rows; rowNumber++)              //таблицу данных в data
                {
                    for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                    {
                        data[rowNumber + 6, columnNumber] = dataTable.Rows[rowNumber][columnNumber].ToString();
                        w.RiseWorm();
                    }
                }

                for (int rowNumber = 0; rowNumber < rows; rowNumber++)              //обработка ссылок
                {
                    worksheet.Hyperlinks.Add(worksheet.Range[string.Format("I{0}", rowNumber + 7)], dataTable.Rows[rowNumber][8].ToString(), Type.Missing, "Ознакомиться с текстом в ЭБС", "Ознакомиться с текстом в ЭБС");
                }

                range = worksheet.Range["A1", string.Format("{0}{1}", GetExcelColumnName(columns), rows + 6)];
                range.Value = data;//вывод всех данных
                for (int rowNumber = 7; rowNumber < rows + 7; rowNumber++)
                {
                    rangeTmp = worksheet.Range[string.Format("A{0}", rowNumber), string.Format("{0}{1}", GetExcelColumnName(columns), rowNumber)];
                    if ( range[rowNumber,2].Value != null && (int)range[rowNumber, 2].Value % 2 == 0 )
                    {
                        rangeTmp.Interior.Color = Color.FromArgb(252, 231, 205);//покарска чётных  комплектов
                    }
                    w.RiseWorm();
                }

                SetColumnsRowsSize(range, worksheet, columns, rows + 6);
                SetCellsFormat(worksheet, columns, rows + 6);

                worksheet.Rows[6].AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);

                worksheet.Application.ActiveWindow.SplitRow = 6;
                worksheet.Range["A7"].Application.ActiveWindow.FreezePanes = true;//фиксируем кверху всё, что выше заголовка

                worksheet.Range["H5"].Formula = string.Format("=SUMPRODUCT(F7:F{0},Q7:Q{0})", rows + 7);
                w.Close();
                application.Visible = true;
                application.CalculateFull();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка");
            }
        }

        /// <summary>
        /// Расставляются размеры колонок и строк
        /// </summary>
        /// <param name="range"></param>
        /// <param name="worksheet"></param>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        private static void SetColumnsRowsSize(Excel.Range range, Excel.Worksheet worksheet, int columns, int rows)
        {
            range = worksheet.Range["A7", String.Format("{0}{1}", GetExcelColumnName(columns), rows)];
            range.RowHeight = 40;
            range.ColumnWidth = 10;
            worksheet.Range["A5"].RowHeight = 15;
            worksheet.Range["A1"].ColumnWidth = 12;
            worksheet.Range["B1"].ColumnWidth = 9;
            worksheet.Range["C1"].ColumnWidth = 20;
            worksheet.Range["D1"].ColumnWidth = 6;
            worksheet.Range["F1"].ColumnWidth = 17;
            worksheet.Range["G1"].ColumnWidth = 50;
            worksheet.Range["K1"].ColumnWidth = 20;
            worksheet.Range["L1"].ColumnWidth = 20;
            worksheet.Range["O1"].ColumnWidth = 6;
            worksheet.Range["Y1"].ColumnWidth = 40;
            range = worksheet.Range["A6", string.Format("{0}6", GetExcelColumnName(columns))];
            range.RowHeight = 78;
            range.WrapText = true;
            range.HorizontalAlignment = HorizontalAlignment.Center;
            worksheet.Range["A6", string.Format("{0}{1}", GetExcelColumnName(columns), rows)].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
        }

        /// <summary>
        /// Форматы ячеек проставляются
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        private static void SetCellsFormat(Excel.Worksheet worksheet, int columns, int rows)
        {
            Excel.Range rng = worksheet.Range["A7", string.Format("{0}{1}", GetExcelColumnName(columns), rows)];
            rng.Borders.Weight = 1;
            rng.Borders.LineStyle = Excel.XlLineStyle.xlDash;
            rng.Font.Size = 8;
            rng.WrapText = true;
            rng = worksheet.Range["A1", string.Format("{0}{1}", GetExcelColumnName(columns), 5)];
            rng.Interior.Color = Color.FromArgb(255, 204, 153); //цвет шапки
            worksheet.Range["Q7", string.Format("U{0}", rows)].NumberFormat = "# ##0.00р.;-# ##0.00р."; //денежный формат
            worksheet.Range["H5"].NumberFormat = "# ##0.00р.;-# ##0.00р.";
            worksheet.Range["G5", "J5"].Borders.Weight = 2;
            worksheet.Range["E7", string.Format("E{0}", rows)].Font.Bold = true;//дата
            worksheet.Range["E7", string.Format("E{0}", rows)].NumberFormat = "dd/MM/yyyy";//дата
            worksheet.Range["E7", string.Format("E{0}", rows)].Parse();//дата
            worksheet.Range["I7", string.Format("I{0}", rows)].ApplyOutlineStyles();
            worksheet.Range["F7", string.Format("F{0}", rows)].Font.Color = Color.DarkRed;//заказ
            worksheet.Range["F7", string.Format("F{0}", rows)].Font.Bold = true;//заказ
            worksheet.Range["A1", string.Format("{0}{1}", GetExcelColumnName(columns), rows)].Font.Name = "MS Sans Serif";
        }

        private static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        private void SearchByDisciplinesForm_Load(object sender, EventArgs e)
        {
            try
            {
                #region Фильтр - Клиент lkpClients

                // Инициализируем Фильтр - Фирмы
                DataTable FirmsTable = null;
                FirmsTable = AppController.dataViewController.DoQuery("DBA.MarketsFace_Markets_list_with_cav_info", null, QueryTypes.StoredProcedure);
                DataRow FirmRow = FirmsTable.NewRow();
                FirmRow[0] = "<Пусто>"; // Название
                FirmRow[1] = 0; // Код
                FirmRow[2] = "<Пусто>"; // Уровень деятельности
                FirmsTable.Rows.InsertAt(FirmRow, 0);
                lkpClients.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
                lkpClients.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                lkpClients.Properties.AutoSearchColumnIndex = 1;
                DevExpress.XtraEditors.Controls.LookUpColumnInfo[] colFirmsList = 
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Fname", "Название", 140, DevExpress.Utils.FormatType.None, "", 
                                                                                            true, DevExpress.Utils.HorzAlignment.Default),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cav_name", "Уровень деятельности", 3000, DevExpress.Utils.FormatType.None, "", 
                                                                                            true, DevExpress.Utils.HorzAlignment.Default),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Fcode", "Код", 0, DevExpress.Utils.FormatType.None, "", 
                                                                                            true, DevExpress.Utils.HorzAlignment.Default)
            };
                AppController.dataViewController.AssignDataToLookUpEdit(lkpClients, FirmsTable, "Fcode", "Fname", colFirmsList);

                lkpClients.Properties.ReadOnly = false;
                lkpClients.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                lkpClients.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                #endregion
                lkpClients.EditValue = fcode;
                rgWhereIsDisciplines.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке формы. \n" + ex.Message, "Ошибка");
                return;
            }
        }

        private void btnSearchToWord_Click(object sender, EventArgs e)
        {
            Search(false);
        }
              
    }
}